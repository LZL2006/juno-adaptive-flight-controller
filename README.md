# V8 Adaptive Aero Flight Controller for Juno: New Origins

A layered, fault-tolerant quadcopter flight program for *Juno: New Origins* (Vizzy visual scripting, authored through the REWJUNO / REWVIZZY C# generator). Version 8 adds three adaptive techniques that make a heavy electric quadcopter fly consistently across a planet whose air density changes strongly with altitude:

1. Real-time air density compensation of hover and manual throttle
2. Dynamic thrust ratio correction (throttle-squared thrust model, tilt compensation and control-gain scheduling)
3. Online aerodynamic CdA (drag area) estimation, with self-calibration of the thrust model at hover

Source file: `CommandChipMain_v8_density.cs`

---

## Defensive Publication Notice

This repository constitutes a **public defensive disclosure** of the algorithms described herein, including but not limited to: Real-time Air Density Compensation, Dynamic Thrust Ratio Correction, and Online Aerodynamic CdA Estimation.

The first commit to this public repository establishes the prior disclosure date. These algorithms are disclosed as **prior art** and are **not patentable by anyone**. Any attempt to claim patent rights over these techniques after the disclosure date will be challenged using this repository's commit history as evidence.

---

## 1. Target vehicle and assumptions

| Item                                                   | Value                                                                  |
| ------------------------------------------------------ | ---------------------------------------------------------------------- |
| Airframe                                               | X-configuration quadcopter, motors FL, FR, BL, BR                      |
| Reference mass                                         | 57.7 kg (`Mass_Ref`)                                                   |
| Hover throttle at reference mass and reference density | 0.62 (`hoverBase`)                                                     |
| Motor speed                                            | proportional to throttle, maximum 7000 rpm (hover is about 4340 rpm)   |
| Propeller thrust                                       | proportional to air density times rotor speed squared                  |
| Rotation sense                                         | FL clockwise, FR counter-clockwise, BL counter-clockwise, BR clockwise |

The program is a Vizzy program: no strings or branches inside expressions, about one instruction per assignment, and a per-frame instruction budget. All formulas below are therefore written as scalar assignments.

## 2. Algorithm 1: Real-time air density compensation

### 2.1 Physical basis

Rotor speed `n` is proportional to throttle `u`. Propeller thrust is

```
T = k * rho * n^2  =  k' * rho * u^2
```

where `rho` is the local air density. Thrust therefore depends on the **square of throttle** and **linearly on density**. A controller that treats thrust as linear in throttle, or that ignores density, hovers correctly only at one altitude.

### 2.2 Density sensing

Density is read about every fifth control cycle:

```
rhoRaw = AirDensity API            (Rho_Mode = 0)
       = Rho0 / exp(h / Rho_H)     (Rho_Mode = 1, barometric fallback)
       = 1                         (Rho_Mode = 2, compensation off)
```

The exponential in the fallback model is evaluated with a fourth-order series, `1 + x + x^2/2 + x^3/6 + x^4/24`, with `x = clamp(h / Rho_H, 0, 4)`, because the visual scripting language provides no exponential block.

The raw value is accepted only if it is greater than 0.001, then low-pass filtered:

```
rhoF = rhoF + (rhoRaw - rhoF) * 0.4
```

### 2.3 Reference density and ratio

The reference density `Rho_Ref` is captured automatically from the first valid reading at start-up, or it may be set manually. The control law uses the clamped ratio

```
rhoRatio = clamp(rhoF / Rho_Ref, Rho_Min, Rho_Max)      (0.15 .. 2.0)
```

### 2.4 Hover throttle formula

From `T = k' * rho * u^2` and the hover calibration `T = m * g` at `u = hoverBase`, `rho = Rho_Ref`, `m = Mass_Ref`:

```
Thr_hover = hoverBase * sqrt( (m / Mass_Ref) * (g_eff / g) / rhoRatio )
          = 0.62 * sqrt( rho_ref / rho_now )     (at reference mass and 1 g)
```

For example, at half the reference density the hover throttle rises by a factor of 1.414 (0.62 to 0.877). Hover is no longer possible below `rhoRatio = (hoverBase / 0.95)^2`, about 0.43, because collective throttle is limited to 0.95. This value is useful as an altitude ceiling warning.

### 2.5 Tilt compensation consistent with the quadratic thrust law

Vertical thrust is `T * cos(tilt)`. To keep vertical thrust constant, `T` must grow by `1 / cos(tilt)`, which with `T proportional to u^2` means throttle grows by `1 / sqrt(cos(tilt))`:

```
baseThrottle = baseThr / sqrt(tiltCosC)        (Thr_Sqrt = 1)
baseThrottle = baseThr / tiltCosC              (Thr_Sqrt = 0, linear model)
tiltCosC     = max(0.5, cos(pitch) * cos(roll))
```

### 2.6 Manual throttle compensation

In pure manual throttle mode the stick centre corresponds to hover at the reference density. The stick-to-throttle map is piecewise linear (0 maps to 0, 0.5 maps to `hoverBase`, 1 maps to 1) and is multiplied by

```
thrComp = clamp(1 / sqrt(rhoRatio), 0.7, 1.8)
```

so that the stick centre still holds altitude at any density. A stick at zero still commands zero throttle.

## 3. Algorithm 2: Dynamic thrust ratio correction and gain scheduling

### 3.1 Thrust ratio for automatic altitude control

The climb loop produces a commanded vertical acceleration `accZcmd` from climb-rate error, an integral term, an aerodynamic feed-forward and a reference-model feed-forward. The throttle needed to deliver it is

```
gEff        = max(3, g + accZcmd)
thrustRatio = (massNow * gEff) / (Mass_Ref * g * rhoRatio)
baseThr     = hoverBase * sqrt(thrustRatio)            (Thr_Sqrt = 1)
            = hoverBase * thrustRatio                  (Thr_Sqrt = 0)
```

Mass is read live (`massNow`), so payload changes are handled. Local gravity `g` is the magnitude of the gravity vector, refreshed together with density, so it does not depend on the coordinate frame in which the vector is reported.

### 3.2 Control-gain scheduling

Differential thrust between motors is the control actuator. Its slope with respect to throttle is `dT/du = 2 k' rho u`. The same differential throttle therefore produces less torque at low density or low throttle. The rate-loop outputs (pitch, roll and yaw commands) are scaled by

```
gSch = clamp( (hoverBase / max(0.35, baseThr)) / rhoRatio, Sch_Min, Sch_Max )   (0.6 .. 1.8)
```

At the reference condition `gSch = 1`, so the controller behaves exactly as before the adaptation. The limits prevent excessive gain at idle throttle.

## 4. Algorithm 3: Online CdA (drag area) estimation

The estimator runs in its own 10 Hz script thread so it does not consume the flight loop's instruction budget. It compares the acceleration the rotors should produce with the acceleration actually measured. The difference is attributed to aerodynamic drag.

### 4.1 Expected thrust acceleration

```
thrMean = mean of the four filtered motor outputs
T_model = Mass_Ref * g * rhoRatio * (thrMean / hoverBase)^2
aThr    = T_model * kThrust / massNow
```

`kThrust` is the adaptive thrust coefficient correction (section 5).

### 4.2 Measured acceleration

Velocity (forward `vF`, right `vR`, up `vU`) is differentiated at 10 Hz, with yaw-rate coupling removed:

```
aF = dvF/dt - yawRate * vR
aR = dvR/dt + yawRate * vF
aU = dvU/dt
```

### 4.3 Drag deceleration along the velocity

The thrust acceleration is projected onto the body-tilt axes, then subtracted:

```
dF = aF - aThr * sin(pitch)
dR = aR - aThr * sin(roll)
dU = aU - (aThr * cos(pitch) * cos(roll) - g)

decel = -(dF*vF + dR*vR + dU*vU) / max(0.5, |v|)           (deceleration magnitude along the velocity)
```

### 4.4 Weighted least-squares identification

Dynamic pressure is `q = 0.5 * rho * |v|^2` and drag force is `Fd = decel * massNow`. With `Fd = CdA * q`, a recursive weighted least-squares estimate with forgetting factor 0.97 per sample is

```
num = 0.97 * num + valid * (Fd * q)
den = 0.97 * den + valid * (q * q)
CdA = clamp(num / den, 0, 20)          (m^2)
area = CdA / Cd_Ref                     (reference drag coefficient, default 1.0)
```

Weighting by `q` makes low-speed samples contribute little. A sample is `valid` only when all of the following hold: speed above `Est_Vmin` (6 m/s), flight gate open, no shock event, no attitude protection, and pitch and roll rates below 20 deg/s. The estimate is reported as valid when `den` exceeds 100.

### 4.5 Using the estimate

The identified drag area replaces the static quadratic drag coefficient in the aerodynamic acceleration feed-forward (`Use_CdA = 1`):

```
kQuad = 0.5 * rhoF * CdA                           (identified)
kQuad = (Edge + (Axial - Edge) * fax2) * rhoRatio  (static model scaled by density)
kDrag = Aero_FF_Gain * (kQuad * |v| + kLin) / massNow
```

`fax2` is the squared axial flow fraction derived from angle of attack and sideslip.

## 5. Algorithm 4: Hover-based thrust coefficient self-calibration

The thrust model has an unknown scale error. At steady hover the weight must equal vertical thrust, which allows the error to be removed online. The calibration updates only when the aircraft is almost stationary:

```
hover = flight gate open and speed < 1 m/s and |climb rate| < 0.3 m/s and |aU| < 0.4 m/s^2
        and thrMean > 0.2 and cos(tilt) > 0.97

kThrust = clamp( kThrust + ( (massNow * g / cos(tilt)) / max(1, T_model) - kThrust ) * 0.02 * hover,
                 0.7, 1.4 )
```

A value of `kThrust` close to 1 confirms that the reference hover throttle and mass are correct. A persistent offset indicates a wrong `hoverBase` or `Mass_Ref`.

## 6. Underlying flight control architecture (unchanged by V8)

- Cascaded loops: stick or position input, velocity reference model with feed-forward, tilt target, angle loop, rate loop with integral and filtered derivative, then control allocation.
- Control allocation by sequential orthogonalisation (Gram-Schmidt) in the priority order collective, pitch, roll, yaw, recomputed whenever the motor health mask changes. This keeps the controller working with one or more failed motors.
- Saturation handling by scaling and shifting the motor command set so that collective thrust is preserved.
- Thermal derating from motor temperature, a shock-detection freeze, a yaw-headroom limiter, and attitude protection with a near-vertical recovery mode.
- Wrapped angle errors to avoid 360 degree discontinuities, and automatic detection of angle units.
- Flight modes: manual, altitude hold, position hold, return to launch, auto take-off, auto landing, plus safety logic for battery, loss of input and free fall.

## 7. Parameters introduced in V8

| Parameter            | Default     | Meaning                                             |
| -------------------- | ----------- | --------------------------------------------------- |
| `Mass_Ref`           | 57.7        | Reference total mass in kg                          |
| `hoverBase`          | 0.62        | Hover throttle at reference mass and density        |
| `Thr_Sqrt`           | 1           | 1 = thrust proportional to throttle squared         |
| `Rho_Mode`           | 0           | 0 = density API, 1 = barometric model, 2 = off      |
| `Rho0`, `Rho_H`      | 1.225, 8000 | Barometric model sea-level density and scale height |
| `Rho_Ref`            | 0           | Reference density, 0 = capture at start             |
| `Rho_Min`, `Rho_Max` | 0.15, 2     | Density ratio limits                                |
| `Rho_Manual`         | 1           | Density compensation of manual throttle             |
| `Sch_Min`, `Sch_Max` | 0.6, 1.8    | Control-gain scheduling limits                      |
| `Rpm_Max`            | 7000        | Maximum motor speed (display only)                  |
| `Cd_Ref`             | 1           | Reference drag coefficient for area conversion      |
| `Est_Vmin`           | 6           | Minimum speed in m/s for CdA estimation             |
| `Use_CdA`            | 0           | 1 = use the identified CdA in the drag feed-forward |

## 8. Display

The program prints one status line containing density, density ratio, gain schedule (percent), mean rotor rpm, CdA, area and the thrust calibration factor, so the adaptive behaviour can be observed in flight.

## 9. Usage

1. Place the generator source `CommandChipMain_v8_density.cs` in the REWJUNO project and run it. The program is printed as Vizzy XML.
2. Import the XML into the command chip's flight program.
3. Set `Mass_Ref` and `hoverBase` to the values that give a stable hover on your craft at the take-off altitude.
4. Confirm the air density block name in the game. If the generator reports an unknown member, replace the single line `rhoApi = Vz.Craft.Atmosphere.AirDensity();` with the block that returns local air density.

## 10. Limitations and status

- The names of some game API members (air density, battery, part health and temperature) are taken from the game's block set and may differ between game versions.
- The density-compensation and CdA-estimation algorithms were checked against a simplified point-mass simulation and by static review. Tuning on a specific airframe is required.
- The static drag feed-forward is disabled by default (`Aero_FF_Gain = 0`) because the velocity feedback gains are zero in the default configuration.

## 11. License

Licensed under the Apache License, Version 2.0. See `LICENSE`. The license includes an express patent grant and a patent-retaliation clause.

Author: LZL2006
First public disclosure date: 2026-10-30

---

## 中文摘要

本项目为《Juno: New Origins》的四旋翼分层飞控程序（Vizzy 脚本）。V8 版公开三项自适应技术：

1. **实时空气密度补偿**：推力与油门平方、空气密度成正比，悬停油门为 `Thr_hover = 0.62 × √(ρ_ref / ρ_now)`（参考质量、标准重力下），并随质量和重力加速度变化；倾斜补偿按 `1/√cos(倾角)` 计算；手动油门同样按密度补偿。
2. **动态推力比修正与增益调度**：`thrustRatio = m·g_eff / (m_ref·g·ρ比)`，油门取其平方根；俯仰、横滚、偏航指令按 `gSch = (hoverBase / 当前油门) / ρ比` 调度，参考条件下等于 1，不改变原有操控。
3. **在线 CdA（阻力面积）辨识**：用推力模型得到的理论加速度减去实测加速度，得到沿速度方向的阻力减速度，再用带遗忘因子（0.97）的加权最小二乘估算 `CdA = Σ(Fd·q) / Σ(q²)`，迎风面积为 `CdA / Cd_Ref`；并在悬停稳态下用重力平衡自适应校正推力系数 `kThrust`。

使用 Apache 2.0 许可证；首次提交的时间戳即为公开日期。

> 本文件仅为技术说明，不构成法律意见。
