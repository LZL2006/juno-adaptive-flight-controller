using System;
using System.Linq;
using System.Collections.Generic;
using REWJUNO;
using REWVIZZY;

// ── Program: Industrial Layered Flight V4 - Modes + Auto + Safety + Vector ──────────────────────────────────
Vz.Init("Industrial Layered Flight V4 - Modes + Auto + Safety + Vector");

// ── Variables ────────────────────────────────────────
// var G = 0;
// var tickSpeed = 0;
// var Slow_Div = 0;
// var Max_Tilt = 0;
// var Max_Tilt_Fail = 0;
// var Max_Yaw_Rate = 0;
// var Max_Rate = 0;
// var Spd_Max = 0;
// var Fail_Spd_Max = 0;
// var Climb_Max = 0;
// var Fail_Descend = 0;
// var Stick_Pitch = 0;
// var Stick_Roll = 0;
// var Stick_Yaw = 0;
// var Vel_Mode = 0;
// var Head_Offset = 0;
// var Tau_Cmd = 0;
// var AccRef_Max = 0;
// var Tau_Climb = 0;
// var AccRefU_Max = 0;
// var Kff_Acc = 0;
// var Kff_Rate = 0;
// var FF_Fade = 0;
// var Aux_Div = 0;
// var auxCnt = 0;
// var auxRun = 0;
// var vRefF = 0;
// var vRefR = 0;
// var vRefU = 0;
// var aRefF = 0;
// var aRefR = 0;
// var aRefU = 0;
// var ffRateP = 0;
// var ffRateR = 0;
// var tgtPitchPrev = 0;
// var tgtRollPrev = 0;
// var yawRoom = 0;
// var angK = 0;
// var Ang_Mode = 0;
// var Bal_Mode = 0;
// var Kp_Bal = 0;
// var Cmd_Max = 0;
// var Outer_On = 0;
// var pitchOld = 0;
// var rollOld = 0;
// var dAngPF = 0;
// var dAngRF = 0;
// var corrP = 0;
// var corrR = 0;
// var corrAcc = 0;
// var crossAcc = 0;
// var Kp_Pos = 0;
// var Kp_Speed = 0;
// var Ki_Speed = 0;
// var Kd_Speed = 0;
// var Int_Window = 0;
// var Int_Bleed = 0;
// var Kp_Angle = 0;
// var Kp_Rate = 0;
// var Ki_Rate = 0;
// var Kd_Rate = 0;
// var Rate_Int_Window = 0;
// var Kp_YawAng = 0;
// var Kp_YawRate = 0;
// var Ki_YawRate = 0;
// var Kp_Climb = 0;
// var Ki_Climb = 0;
// var Climb_Window = 0;
// var hoverBase = 0;
// var Mass_Ref = 0;
// var Thr_Sqrt = 0;
// var Aero_FF_Gain = 0;
// var Use_VzAoA = 0;
// var Drag_Quad_Edge = 0;
// var Drag_Quad_Axial = 0;
// var Drag_Lin_Edge = 0;
// var Drag_Lin_Axial = 0;
// var PartID_FL = 0;
// var PartID_FR = 0;
// var PartID_BL = 0;
// var PartID_BR = 0;
// var Temp_Warn = 0;
// var Temp_Crit = 0;
// var Derate_Min = 0;
// var Shock_Acc = 0;
// var Shock_Hold = 0;
// var Ax_FL = 0;
// var Ay_FL = 0;
// var Ax_FR = 0;
// var Ay_FR = 0;
// var Ax_BL = 0;
// var Ay_BL = 0;
// var Ax_BR = 0;
// var Ay_BR = 0;
// var Yc_FL = 0;
// var Yc_FR = 0;
// var Yc_BL = 0;
// var Yc_BR = 0;
// var Throttle_Manual = 0;
// var Use_IntHeading = 0;
// var climbAuto = 0;
// var integralVF = 0;
// var integralVR = 0;
// var integralPitchRate = 0;
// var integralRollRate = 0;
// var integralYawRate = 0;
// var climbIntegral = 0;
// var accFFilt = 0;
// var accRFilt = 0;
// var ratePitchOld = 0;
// var rateRollOld = 0;
// var ratePitchDFilt = 0;
// var rateRollDFilt = 0;
// var vFOld = 0;
// var vROld = 0;
// var velOldU = 0;
// var posN = 0;
// var posE = 0;
// var targetPosN = 0;
// var targetPosE = 0;
// var shockTimer = 0;
// var gateShock = 0;
// var manualThr = 0;
// var dispCnt = 0;
// var targetPitch = 0;
// var targetRoll = 0;
// var baseThr = 0;
// var baseThrottle = 0;
// var cmdPitch = 0;
// var cmdRoll = 0;
// var cmdYaw = 0;
// var gEff = 0;
// var hFL = 0;
// var hFR = 0;
// var hBL = 0;
// var hBR = 0;
// var capFL = 0;
// var capFR = 0;
// var capBL = 0;
// var capBR = 0;
// var maskOld = 0;
// var maskNow = 0;
// var failAny = 0;
// var yawLost = 0;
// var recalcAlloc = 0;
// var slowCnt = 0;
// var runSlow = 0;
// var dtS = 0;
// var outFL = 0;
// var outFR = 0;
// var outBL = 0;
// var outBR = 0;
// var heading = 0;
// var targetYaw = 0;
// var lastTime = 0;
// var nowT = 0;
// var dt = 0;
// var inputPitch = 0;
// var inputRoll = 0;
// var inputYaw = 0;
// var inputThrottle = 0;
// var currentPitch = 0;
// var currentRoll = 0;
// var headRad = 0;
// var sinH = 0;
// var cosH = 0;
// var tiltCos = 0;
// var tiltCosC = 0;
// var angularVel = 0;
// var ratePitch = 0;
// var rateYaw = 0;
// var rateRoll = 0;
// var ratePitchD = 0;
// var rateRollD = 0;
// var rateAlpha = 0;
// var stickActive = 0;
// var takeoffUnlock = 0;
// var groundFlag = 0;
// var gGate = 0;
// var velSurface = 0;
// var vecN = 0;
// var vecE = 0;
// var vNr = 0;
// var vEr = 0;
// var climbRate = 0;
// var vF = 0;
// var vR = 0;
// var vN = 0;
// var vE = 0;
// var accF = 0;
// var accR = 0;
// var accU = 0;
// var accAlpha = 0;
// var accMag = 0;
// var tFL = 0;
// var tFR = 0;
// var tBL = 0;
// var tBR = 0;
// var massNow = 0;
// var massUse = 0;
// var airSpd = 0;
// var aoaDeg = 0;
// var slipDeg = 0;
// var faxA = 0;
// var faxB = 0;
// var faxX = 0;
// var fax2 = 0;
// var kQuad = 0;
// var kLin = 0;
// var kDrag = 0;
// var aeroF = 0;
// var aeroR = 0;
// var aeroU = 0;
// var stickClimb = 0;
// var targetClimb = 0;
// var errClimb = 0;
// var gateClimbWin = 0;
// var gateClimbCtr = 0;
// var accZcmd = 0;
// var thrustRatio = 0;
// var spdLim = 0;
// var targetVF = 0;
// var targetVR = 0;
// var errVF = 0;
// var errVR = 0;
// var gateWinF = 0;
// var gateWinR = 0;
// var gateSpeed = 0;
// var bleedF = 0;
// var bleedR = 0;
// var accCmdF = 0;
// var accCmdR = 0;
// var tiltLim = 0;
// var tiltMag = 0;
// var tiltScale = 0;
// var errN = 0;
// var errE = 0;
// var errPosF = 0;
// var errPosR = 0;
// var speedFast = 0;
// var lockPos = 0;
// var errPitchAng = 0;
// var errRollAng = 0;
// var targetPitchRate = 0;
// var targetRollRate = 0;
// var errPitchRate = 0;
// var errRollRate = 0;
// var gateRateP = 0;
// var gateRateR = 0;
// var yawStickOn = 0;
// var yawFollow = 0;
// var errYawAng = 0;
// var errYawRate = 0;
// var gateYaw = 0;
// var qT_FL = 0;
// var qT_FR = 0;
// var qT_BL = 0;
// var qT_BR = 0;
// var iT = 0;
// var muPT = 0;
// var qP_FL = 0;
// var qP_FR = 0;
// var qP_BL = 0;
// var qP_BR = 0;
// var iP = 0;
// var muRT = 0;
// var muRP = 0;
// var qR_FL = 0;
// var qR_FR = 0;
// var qR_BL = 0;
// var qR_BR = 0;
// var iR = 0;
// var muYT = 0;
// var muYP = 0;
// var muYR = 0;
// var qY_FL = 0;
// var qY_FR = 0;
// var qY_BL = 0;
// var qY_BR = 0;
// var iY = 0;
// var sT = 0;
// var sP = 0;
// var sR = 0;
// var sY = 0;
// var uFL = 0;
// var uFR = 0;
// var uBL = 0;
// var uBR = 0;
// var mxU = 0;
// var mnU = 0;
// var scaleM = 0;
// var centerM = 0;
// var mx1 = 0;
// var mn1 = 0;
// var shiftM = 0;
// var mFL = 0;
// var mFR = 0;
// var mBL = 0;
// var mBR = 0;
// var capOver = 0;
// var capShift = 0;
// var nearVertical = 0;
// var attProtect = 0;
// var lpAlpha = 0;
// var rawFL = 0;
// var rawFR = 0;
// var rawBL = 0;
// var rawBR = 0;
// var pRadNV = 0;
// var dotNV = 0;
// var recoveryScale = 0;
// var recoveryLim = 0;
// var dtRaw = 0;
// var FlightMode = 0;
// var FlightModeOld = -1;
// var homePosN = 0;
// var homePosE = 0;
// var homeValid = 0;
// var rthAlt = 20;
// var rthAltErr = 0;
// var rthDistance = 0;
// var rthArriveDist = 1.5;
// var autoTakeoffPhase = 0;
// var autoTakeoffTargetAlt = 10;
// var autoTakeoffStartPosN = 0;
// var autoTakeoffStartPosE = 0;
// var takeoffErr = 0;
// var autoLandPhase = 0;
// var disarmFlag = 0;
// var altAGL = 0;
// var lastInputTimeAI = 0;
// var rcLossThreshold = 3;
// var rcLost = 0;
// var fallTimer = 0;
// var fallDetected = 0;
// var safetyOverride = 0;
// var batteryLevel = 1;
// var batteryWarn = 0.2;
// var batteryCrit = 0.1;
// var batteryAlarm = 0;
// var batteryCritical = 0;
// var yawLockOn = 0;
// var yawLockTarget = 0;
// var yawAdaptAngle = 0;
// var yawAdaptGain = 0.3;
// var poiActive = 0;
// var poiTargetN = 0;
// var poiTargetE = 0;
// var poiRelN = 0;
// var poiRelE = 0;
// var poiBearing = 0;
// var dirVec = 0;
// var northVec2 = 0;
// var rightVec2 = 0;
// var upAxis = 0;
// var vertDot = 0;
// var displayFlash = 0;
// var modeSwitchTime = 0;
// var vecAttOn = 0;
// var flightModeLatch = 0;
// var guidanceMode = 0;
// var waypointN = 0;
// var waypointE = 0;
// var waypointAlt = 10;
// var waypointRadius = 3;
// var chaseTargetID = -1;
// var chaseTargetPos = 0;
// var chaseTargetVel = 0;
// var interceptN = 0;
// var interceptE = 0;
// var interceptAlt = 0;
// var interceptTime = 0;
// var interceptIters = 0;
// var chaseIterDist = 0;
// var predFallTime = 0;
// var predFallN = 0;
// var predFallE = 0;
// var predFallAlt = 0;
// var predTerrainH = 0;
// var predValid = 0;
// var predDisplay = 0;
// var swarmMode = 0;
// var leaderID = -1;
// var leaderPos = 0;
// var leaderVel = 0;
// var swarmCrafts = [];
// var swarmNeighborPos = 0;
// var swarmRelVec = 0;
// var swarmN = 0;
// var swarmE = 0;
// var swarmNorthUnit = 0;
// var swarmRightUnit = 0;
// var swarmOffsetFwd = -10;
// var swarmOffsetRight = -10;
// var swarmOffsetUp = 0;
// var swarmNeighborCount = 0;
// var swarmIdx = 0;
// var swarmCid = -1;
// var swarmDist = 0;
// var swarmMinDist = 999999;
// var swarmFoundLeader = 0;
// var swarmOffsetLocal = 0;
// var swarmOffsetPci = 0;
// var swarmDesiredPos = 0;
// var swarmDesiredRel = 0;
// var camActive = 0;
// var camPos = 0;
// var camDir = 0;
// var camUp = 0;
// var camTargetPos = 0;
// var camHorizDist = 50;
// var camProbePos = 0;
// var camHeadingRad = 0;
// var camNorthUnit = 0;
// var camRightUnit = 0;
// var camDeltaN = 0;
// var camDeltaE = 0;
// var xfWorldVec = 0;
// var xfLocalVec = 0;
// var xfHeadingRad = 0;
// var terrainAtTarget = 0;
// var terrainProbePos = 0;
// var swarmLeaderVelN = 0;
// var swarmLeaderVelE = 0;
// var leaderMass = 0;
// var rhoApi = 0;
// var rhoX = 0;
// var rhoMdl = 0;
// var rhoRaw = 0;
// var rhoOk = 0;
// var gNow = 0;
// var tEstPrev = 0;
// var vFEst = 0;
// var vREst = 0;
// var vUEst = 0;
// var tEst = 0;
// var dtE = 0;
// var aEstF = 0;
// var aEstR = 0;
// var aEstU = 0;
// var thrMean = 0;
// var tModel = 0;
// var spdE = 0;
// var okE = 0;
// var hovE = 0;
// var aThr = 0;
// var dEstF = 0;
// var dEstR = 0;
// var dEstU = 0;
// var decelE = 0;
// var qE = 0;
// var validE = 0;
// VZPOS x=290 y=-20
using (new OnReceiveMessage("SetWaypoint"))
{
    waypointN = Vz.ListGet(data, 1);
    waypointE = Vz.ListGet(data, 2);
    waypointAlt = Vz.ListGet(data, 3);
}
// VZPOS x=590 y=-20
using (new OnReceiveMessage("SetChaseTarget"))
{
    chaseTargetID = data;
}
// VZPOS x=890 y=-20
using (new OnReceiveMessage("ClearChase"))
{
    chaseTargetID = -1;
}
// VZPOS x=1190 y=-20
using (new OnReceiveMessage("ClearWaypoint"))
{
    waypointAlt = 0;
}
// VZPOS x=1490 y=-20
using (new OnStart())
{
    using (new While(true))
    {
        using (new If((chaseTargetID >= 0)))
        {
            chaseTargetPos = Vz.RawXmlCraftProperty(@"<CraftProperty property=""Craft.Position"" style=""craft""><Variable list=""false"" local=""false"" variableName=""chaseTargetID"" /></CraftProperty>");
            chaseTargetVel = Vz.RawXmlCraftProperty(@"<CraftProperty property=""Craft.Velocity"" style=""craft""><Variable list=""false"" local=""false"" variableName=""chaseTargetID"" /></CraftProperty>");
            interceptN = chaseTargetPos.y;
            interceptE = chaseTargetPos.z;
            interceptAlt = chaseTargetPos.x;
            interceptTime = (Vz.Length((chaseTargetPos - Vz.Craft.Nav.Position())) / Vz.Max(5, Vz.Length(Vz.Craft.Velocity.Surface())));
            interceptIters = 0;
            using (new While((interceptIters < 3)))
            {
                interceptN = (chaseTargetPos.y + (chaseTargetVel.y * interceptTime));
                interceptE = (chaseTargetPos.z + (chaseTargetVel.z * interceptTime));
                interceptAlt = (chaseTargetPos.x + (chaseTargetVel.x * interceptTime));
                chaseIterDist = Vz.Length((Vz.Vec(interceptN, interceptE, interceptAlt) - Vz.Craft.Nav.Position()));
                interceptTime = (chaseIterDist / Vz.Max(5, Vz.Length(Vz.Craft.Velocity.Surface())));
                interceptIters = (interceptIters + 1);
            }
        }
        Vz.WaitSeconds(0.1);
    }
}
// VZPOS x=1790 y=-20
using (new OnStart())
{
    using (new While(true))
    {
        terrainProbePos = Vz.Craft.Nav.Position();
        predTerrainH = (Vz.Craft.AltitudeASL() - Vz.PosToLatLongAgl(terrainProbePos).z);
        using (new If(((Vz.Craft.AltitudeASL() - predTerrainH) > 0.5)))
        {
            predFallTime = ((climbRate + Vz.Sqrt(((climbRate * climbRate) + ((2 * G) * (Vz.Craft.AltitudeASL() - predTerrainH))))) / G);
            predValid = 1;
        }
        using (new Else())
        {
            predFallTime = 0;
            predValid = 0;
        }
        using (new If((predValid == 1)))
        {
            predFallN = (posN + (vN * predFallTime));
            predFallE = (posE + (vE * predFallTime));
            predFallAlt = predTerrainH;
            predDisplay = Vz.Join("Fall@(", Vz.Round(predFallN), ",", Vz.Round(predFallE), ") t=", Vz.Round(predFallTime), "s", "");
        }
        Vz.WaitSeconds(0.1);
    }
}
// VZPOS x=2090 y=-20
using (new OnStart())
{
    using (new While(true))
    {
        using (new If((camActive == 1)))
        {
            camPos = Vz.Craft.Camera.Position();
            camDir = Vz.Craft.Camera.Pointing();
            camTargetPos = (camPos + (camDir * camHorizDist));
            camProbePos = camTargetPos;
            swarmDesiredRel = (camTargetPos - Vz.Craft.Nav.Position());
            camNorthUnit = Vz.Craft.Nav.North();
            camRightUnit = Vz.Craft.Nav.Right();
            camDeltaN = Vz.Dot(swarmDesiredRel, camNorthUnit);
            camDeltaE = Vz.Dot(swarmDesiredRel, camRightUnit);
        }
        Vz.WaitSeconds(0.05);
    }
}
// VZPOS x=2390 y=-20
using (new OnStart())
{
    using (new While(true))
    {
        using (new If((Vz.ActivationGroup(10) == true)))
        {
            Vz.SetActivationGroup(10, false);
            swarmMode = (swarmMode + 1);
            using (new If((swarmMode > 2)))
            {
                swarmMode = 0;
            }
        }
        using (new If((swarmMode == 1)))
        {
            Vz.Broadcast(BroadCastType.AllCraft, "SwarmLeaderPos", Vz.Craft.Nav.Position());
        }
        using (new If((swarmMode == 2)))
        {
            using (new If((leaderID < 0)))
            {
                swarmMinDist = 999999;
                swarmCrafts = Vz.Planet(Vz.Craft.Orbit.Planet()).CraftIDs();
                swarmIdx = 1;
                using (new While((swarmIdx <= Vz.ListLength(swarmCrafts))))
                {
                    swarmCid = Vz.ListGet(swarmCrafts, swarmIdx);
                    using (new If((!(swarmCid == Vz.RawXmlCraftProperty(@"<CraftProperty property=""Part.ThisID"" style=""part""><Constant number=""0"" /></CraftProperty>")))))
                    {
                        swarmNeighborPos = Vz.RawXmlCraftProperty(@"<CraftProperty property=""Craft.Position"" style=""craft""><Variable list=""false"" local=""false"" variableName=""swarmCid"" /></CraftProperty>");
                        swarmDist = Vz.Length((swarmNeighborPos - Vz.Craft.Nav.Position()));
                        using (new If(((swarmDist < swarmMinDist) && (swarmDist > 2))))
                        {
                            swarmMinDist = swarmDist;
                            leaderID = swarmCid;
                            swarmFoundLeader = 1;
                        }
                    }
                    swarmIdx = (swarmIdx + 1);
                }
            }
            using (new If((leaderID >= 0)))
            {
                swarmDist = Vz.Join(Vz.StringOp("friendly", leaderID, "distance"), "");
                leaderMass = Vz.Join(Vz.StringOp("friendly", leaderID, "mass"), "");
                using (new If(((leaderMass < 1) || (swarmDist > 2000))))
                {
                    leaderID = -1;
                    swarmMode = 0;
                }
                using (new Else())
                {
                    leaderPos = Vz.Join(Vz.StringOp("friendly", leaderID, "coordinate"), "");
                    leaderVel = Vz.Join(Vz.StringOp("friendly", leaderID, "velocity"), "");
                    swarmOffsetLocal = Vz.Vec(swarmOffsetRight, swarmOffsetFwd, swarmOffsetUp);
                    swarmOffsetPci = Vz.RawXmlCraftProperty(@"<CraftProperty property=""Part.LocalToPci"" style=""part-transform""><Variable list=""false"" local=""false"" variableName=""leaderID"" /><Variable list=""false"" local=""false"" variableName=""swarmOffsetLocal"" /></CraftProperty>");
                    swarmDesiredPos = (leaderPos + swarmOffsetPci);
                    swarmDesiredRel = (swarmDesiredPos - Vz.Craft.Nav.Position());
                    swarmNorthUnit = Vz.Craft.Nav.North();
                    swarmRightUnit = Vz.Craft.Nav.Right();
                    swarmN = Vz.Dot(swarmDesiredRel, swarmNorthUnit);
                    swarmE = Vz.Dot(swarmDesiredRel, swarmRightUnit);
                    swarmLeaderVelN = Vz.Dot(leaderVel, swarmNorthUnit);
                    swarmLeaderVelE = Vz.Dot(leaderVel, swarmRightUnit);
                }
            }
        }
        Vz.WaitSeconds(0.1);
    }
}
using (new OnStart())
{
    G = Vz.Length(Vz.Craft.Velocity.Gravity());
    G = ((G > 1) ? G : 9.81);
    tickSpeed = 0;
    Slow_Div = 1;
    Max_Tilt = 30;
    Max_Tilt_Fail = 40;
    Max_Yaw_Rate = 30;
    Max_Rate = 45;
    Spd_Max = 20;
    Fail_Spd_Max = 10;
    Climb_Max = 3;
    Fail_Descend = 5;
    Stick_Pitch = 1;
    Stick_Roll = 1;
    Stick_Yaw = 1;
    Vel_Mode = 1;
    Head_Offset = 0;
    Kp_Pos = 0;
    Kp_Speed = 0;
    Ki_Speed = 0;
    Kd_Speed = 0;
    Int_Window = 2;
    Int_Bleed = 1;
    Kp_Angle = 1.5;
    Kp_Rate = 0.007;
    Ki_Rate = 0.001;
    Kd_Rate = 0.002;
    Rate_Int_Window = 10;
    Kp_YawAng = 2;
    Kp_YawRate = 0.03;
    Ki_YawRate = 0;
    Kp_Climb = 1.5;
    Ki_Climb = 0.4;
    Climb_Window = 4;
    hoverBase = 0.62;
    Mass_Ref = 57.7;
    Thr_Sqrt = 1;
    Aero_FF_Gain = 0;
    Rho_Mode = 0;
    Rho0 = 1.225;
    Rho_H = 8000;
    Rho_Ref = 0;
    Rho_Min = 0.15;
    Rho_Max = 2;
    Rho_Manual = 1;
    Sch_Min = 0.6;
    Sch_Max = 1.8;
    Rpm_Max = 7000;
    Cd_Ref = 1;
    Est_Vmin = 6;
    Use_CdA = 0;
    rhoF = 1;
    rhoRatio = 1;
    rhoInit = 0;
    gSch = 1;
    thrComp = 1;
    kThrust = 1;
    estNum = 0;
    estDen = 0;
    cdaEst = 0;
    areaEst = 0;
    cdaValid = 0;
    Use_VzAoA = 1;
    Drag_Quad_Edge = 0.6;
    Drag_Quad_Axial = 1.5;
    Drag_Lin_Edge = 3;
    Drag_Lin_Axial = 0;
    Temp_Warn = 450;
    Temp_Crit = 560;
    Derate_Min = 0.6;
    Shock_Acc = 25;
    Shock_Hold = 0.4;
    Ax_FL = 1;
    Ay_FL = 1;
    Ax_FR = 1;
    Ay_FR = -1;
    Ax_BL = -1;
    Ay_BL = 1;
    Ax_BR = -1;
    Ay_BR = -1;
    Yc_FL = -1;
    Yc_FR = 1;
    Yc_BL = 1;
    Yc_BR = -1;
    Throttle_Manual = 0.3;
    Use_IntHeading = 0;
    climbAuto = (((Kp_Climb + Ki_Climb) > 0) ? 1 : 0);
    Ang_Mode = 0;
    angK = 1;
    heading = Vz.Craft.Nav.Heading();
    angK = ((Ang_Mode == 2) ? 0.0174533 : ((Ang_Mode == 0) ? ((Vz.Abs(heading) > 360) ? 0.0174533 : 1) : 1));
    Bal_Mode = 0;
    Kp_Bal = 0.1;
    Cmd_Max = 0.3;
    Outer_On = 1;
    corrP = 0;
    corrR = 0;
    corrAcc = 0;
    crossAcc = 0;
    dAngPF = 0;
    dAngRF = 0;
    pitchOld = ((Vz.Craft.Nav.Pitch() * angK) * (-1));
    pitchOld = (pitchOld - (360 * Vz.Round((pitchOld / 360))));
    rollOld = (Vz.Craft.Nav.BankAngle() * angK);
    rollOld = (rollOld - (360 * Vz.Round((rollOld / 360))));
    Tau_Cmd = 0.5;
    Tau_Climb = 0.4;
    AccRef_Max = 5;
    AccRefU_Max = 4;
    Kff_Acc = 1;
    Kff_Rate = 0.6;
    FF_Fade = 10;
    Aux_Div = 5;
    auxCnt = 0;
    auxRun = 0;
    vRefF = 0;
    vRefR = 0;
    vRefU = 0;
    aRefF = 0;
    aRefR = 0;
    aRefU = 0;
    ffRateP = 0;
    ffRateR = 0;
    tgtPitchPrev = 0;
    tgtRollPrev = 0;
    yawRoom = 0.3;
    kDrag = 0;
    massUse = Mass_Ref;
    integralVF = 0;
    integralVR = 0;
    integralPitchRate = 0;
    integralRollRate = 0;
    integralYawRate = 0;
    climbIntegral = 0;
    accFFilt = 0;
    accRFilt = 0;
    ratePitchOld = 0;
    rateRollOld = 0;
    ratePitchDFilt = 0;
    rateRollDFilt = 0;
    vFOld = 0;
    vROld = 0;
    velOldU = 0;
    posN = 0;
    posE = 0;
    targetPosN = 0;
    targetPosE = 0;
    shockTimer = 0;
    gateShock = 1;
    manualThr = hoverBase;
    dispCnt = 0;
    targetPitch = 0;
    targetRoll = 0;
    baseThr = hoverBase;
    baseThrottle = 0;
    cmdPitch = 0;
    cmdRoll = 0;
    cmdYaw = 0;
    gEff = G;
    hFL = 1;
    hFR = 1;
    hBL = 1;
    hBR = 1;
    capFL = 1;
    capFR = 1;
    capBL = 1;
    capBR = 1;
    maskOld = -1;
    maskNow = 15;
    failAny = 0;
    yawLost = 0;
    recalcAlloc = 1;
    slowCnt = 0;
    runSlow = 0;
    dtS = 0;
    PartID_FL = Vz.PartNameToID("FL");
    PartID_FR = Vz.PartNameToID("FR");
    PartID_BL = Vz.PartNameToID("BL");
    PartID_BR = Vz.PartNameToID("BR");
    outFL = 0;
    outFR = 0;
    outBL = 0;
    outBR = 0;
    heading = ((Use_IntHeading == 1) ? 0 : (Vz.Craft.Nav.Heading() * angK));
    heading = (heading - (360 * Vz.Round((heading / 360))));
    targetYaw = heading;
    lastTime = Vz.Time.TotalTime();
    nearVertical = 0;
    attProtect = 0;
    lpAlpha = 0;
    rawFL = 0;
    rawFR = 0;
    rawBL = 0;
    rawBR = 0;
    pRadNV = 0;
    dotNV = 0;
    recoveryScale = 0;
    recoveryLim = 0;
    dtRaw = 0;
    FlightMode = 0;
    FlightModeOld = -1;
    homePosN = 0;
    homePosE = 0;
    homeValid = 0;
    rthAlt = 20;
    rthAltErr = 0;
    rthDistance = 0;
    rthArriveDist = 1.5;
    autoTakeoffPhase = 0;
    autoTakeoffTargetAlt = 10;
    autoTakeoffStartPosN = 0;
    autoTakeoffStartPosE = 0;
    takeoffErr = 0;
    autoLandPhase = 0;
    disarmFlag = 0;
    altAGL = 0;
    lastInputTimeAI = Vz.Time.TotalTime();
    rcLossThreshold = 10;
    rcLost = 0;
    fallTimer = 0;
    fallDetected = 0;
    safetyOverride = 0;
    batteryLevel = 1;
    batteryWarn = 0.2;
    batteryCrit = 0.1;
    batteryAlarm = 0;
    batteryCritical = 0;
    yawLockOn = 0;
    yawLockTarget = 0;
    yawAdaptAngle = 0;
    yawAdaptGain = 0.3;
    poiActive = 0;
    poiTargetN = 0;
    poiTargetE = 0;
    poiRelN = 0;
    poiRelE = 0;
    poiBearing = 0;
    dirVec = 0;
    northVec2 = 0;
    rightVec2 = 0;
    upAxis = 0;
    vertDot = 0;
    displayFlash = 0;
    modeSwitchTime = 0;
    vecAttOn = 1;
    flightModeLatch = 0;
    guidanceMode = 0;
    waypointN = 0;
    waypointE = 0;
    waypointAlt = 10;
    waypointRadius = 3;
    chaseTargetID = -1;
    interceptN = 0;
    interceptE = 0;
    interceptAlt = 0;
    interceptTime = 0;
    predFallTime = 0;
    predValid = 0;
    swarmMode = 0;
    leaderID = -1;
    swarmOffsetFwd = -10;
    swarmOffsetRight = -10;
    swarmOffsetUp = 0;
    camActive = 0;
    camHorizDist = 50;
    using (new While(true))
    {
        nowT = Vz.Time.TotalTime();
        dtRaw = (nowT - lastTime);
        using (new If(((dtRaw > 0.5) || (dtRaw < 0))))
        {
            dt = 0.01;
        }
        using (new Else())
        {
            dt = Vz.Min(0.1, Vz.Max(0.005, dtRaw));
        }
        lastTime = nowT;
        dtS = (dtS + dt);
        inputPitch = (Vz.Craft.Property("Input.Pitch") * Stick_Pitch);
        inputRoll = (Vz.Craft.Property("Input.Roll") * Stick_Roll);
        inputYaw = (Vz.Craft.Property("Input.Yaw") * Stick_Yaw);
        using (new If((Vz.Abs(inputPitch) < 0.05)))
        {
            inputPitch = 0;
        }
        using (new Else())
        {
            inputPitch = ((inputPitch - (0.05 * ((inputPitch > 0) ? 1 : -1))) / 0.95);
        }
        using (new If((Vz.Abs(inputRoll) < 0.05)))
        {
            inputRoll = 0;
        }
        using (new Else())
        {
            inputRoll = ((inputRoll - (0.05 * ((inputRoll > 0) ? 1 : -1))) / 0.95);
        }
        using (new If((Vz.Abs(inputYaw) < 0.05)))
        {
            inputYaw = 0;
        }
        using (new Else())
        {
            inputYaw = ((inputYaw - (0.05 * ((inputYaw > 0) ? 1 : -1))) / 0.95);
        }
        inputThrottle = Vz.CraftInput(CraftInput.Throttle);
        currentPitch = ((Vz.Craft.Nav.Pitch() * angK) * (-1));
        currentPitch = (currentPitch - (360 * Vz.Round((currentPitch / 360))));
        currentRoll = (Vz.Craft.Nav.BankAngle() * angK);
        currentRoll = (currentRoll - (360 * Vz.Round((currentRoll / 360))));
        nearVertical = Vz.Max(((Vz.Abs(currentPitch) > 70) ? 1 : 0), ((Vz.Abs(currentRoll) > 70) ? 1 : 0));
        attProtect = Vz.Max(((Vz.Abs(currentPitch) > (Max_Tilt * 1.5)) ? 1 : 0), ((Vz.Abs(currentRoll) > (Max_Tilt * 1.5)) ? 1 : 0));
        batteryLevel = Vz.Craft.Fuel.Battery();
        using (new If((batteryLevel > 0.001)))
        {
            using (new If((batteryLevel < batteryCrit)))
            {
                batteryCritical = 1;
                batteryAlarm = 1;
            }
            using (new ElseIf((batteryLevel < batteryWarn)))
            {
                batteryAlarm = 1;
                batteryCritical = 0;
            }
            using (new Else())
            {
                batteryAlarm = 0;
                batteryCritical = 0;
            }
        }
        groundFlag = (Vz.Craft.Grounded() ? 1 : 0);
        takeoffUnlock = ((inputThrottle > 0.55) ? 1 : 0);
        using (new If((flightModeLatch == 4)))
        {
            takeoffUnlock = 1;
        }
        gGate = ((1 - (groundFlag * (1 - takeoffUnlock))) * (1 - (groundFlag * failAny)));
        using (new If((((Vz.Abs(inputPitch) > 0.05) || (Vz.Abs(inputRoll) > 0.05)) || ((Vz.Abs((inputThrottle - 0.5)) > 0.05) || (Vz.Abs(inputYaw) > 0.1)))))
        {
            lastInputTimeAI = Vz.Time.TotalTime();
        }
        using (new If((((Vz.Time.TotalTime() - lastInputTimeAI) > rcLossThreshold) && (groundFlag == 0))))
        {
            rcLost = 1;
        }
        using (new Else())
        {
            rcLost = 0;
        }
        using (new If((Vz.ActivationGroup(2) == true)))
        {
            Vz.SetActivationGroup(2, false);
            flightModeLatch = 1;
        }
        using (new If((Vz.ActivationGroup(3) == true)))
        {
            Vz.SetActivationGroup(3, false);
            flightModeLatch = 2;
        }
        using (new If((Vz.ActivationGroup(5) == true)))
        {
            Vz.SetActivationGroup(5, false);
            flightModeLatch = 4;
        }
        using (new If((Vz.ActivationGroup(6) == true)))
        {
            Vz.SetActivationGroup(6, false);
            flightModeLatch = 5;
        }
        using (new If((Vz.ActivationGroup(4) == true)))
        {
            Vz.SetActivationGroup(4, false);
            flightModeLatch = 3;
        }
        using (new If(((safetyOverride == 1) && (!(flightModeLatch == 5)))))
        {
            flightModeLatch = 0;
        }
        using (new If((batteryCritical == 1)))
        {
            flightModeLatch = 5;
        }
        using (new If((((rcLost == 1) && (flightModeLatch < 3)) && (safetyOverride == 0))))
        {
            flightModeLatch = 3;
        }
        FlightModeOld = FlightMode;
        FlightMode = flightModeLatch;
        using (new If((Vz.ActivationGroup(1) == true)))
        {
            camActive = 1;
        }
        using (new Else())
        {
            camActive = 0;
        }
        using (new If((camActive == 1)))
        {
            guidanceMode = 3;
        }
        using (new ElseIf((chaseTargetID >= 0)))
        {
            guidanceMode = 2;
        }
        using (new ElseIf((waypointAlt > 0)))
        {
            guidanceMode = 1;
        }
        using (new ElseIf((swarmMode == 2)))
        {
            guidanceMode = 0;
        }
        using (new Else())
        {
            guidanceMode = 0;
        }
        using (new If((guidanceMode > 0)))
        {
            FlightMode = 2;
        }
        using (new If((!(FlightMode == FlightModeOld))))
        {
            modeSwitchTime = Vz.Time.TotalTime();
            using (new If((FlightMode == 2)))
            {
                targetPosN = posN;
                targetPosE = posE;
                targetYaw = heading;
            }
            using (new If((FlightMode == 3)))
            {
                using (new If((homeValid == 0)))
                {
                    homePosN = posN;
                    homePosE = posE;
                    homeValid = 1;
                }
                targetPosN = homePosN;
                targetPosE = homePosE;
            }
            using (new If((FlightMode == 4)))
            {
                autoTakeoffPhase = 1;
                autoTakeoffStartPosN = posN;
                autoTakeoffStartPosE = posE;
                targetPosN = autoTakeoffStartPosN;
                targetPosE = autoTakeoffStartPosE;
            }
            using (new If((FlightMode == 5)))
            {
                autoLandPhase = 0;
            }
        }
        angularVel = Vz.Craft.Velocity.Angular();
        dAngPF = (dAngPF + ((((currentPitch - pitchOld) / dt) - dAngPF) * (dt / (dt + 0.02))));
        dAngRF = (dAngRF + ((((currentRoll - rollOld) / dt) - dAngRF) * (dt / (dt + 0.02))));
        pitchOld = currentPitch;
        rollOld = currentRoll;
        ratePitch = ((Bal_Mode == 0) ? (Vz.Rad2Deg(angularVel.x) * (-1)) : dAngPF);
        rateYaw = Vz.Rad2Deg(angularVel.y);
        rateRoll = ((Bal_Mode == 0) ? Vz.Rad2Deg(angularVel.z) : dAngRF);
        ratePitchD = Vz.Min(1000, Vz.Max(-1000, ((ratePitch - ratePitchOld) / dt)));
        rateRollD = Vz.Min(1000, Vz.Max(-1000, ((rateRoll - rateRollOld) / dt)));
        rateAlpha = (dt / (dt + 0.03));
        ratePitchDFilt = (ratePitchDFilt + ((ratePitchD - ratePitchDFilt) * rateAlpha));
        rateRollDFilt = (rateRollDFilt + ((rateRollD - rateRollDFilt) * rateAlpha));
        ratePitchOld = ratePitch;
        rateRollOld = rateRoll;
        heading = ((Use_IntHeading == 1) ? (heading + (rateYaw * dt)) : (Vz.Craft.Nav.Heading() * angK));
        heading = (heading - (360 * Vz.Round((heading / 360))));
        headRad = Vz.Deg2Rad((heading + Head_Offset));
        sinH = Vz.Sin(headRad);
        cosH = Vz.Cos(headRad);
        tiltCos = (Vz.Cos(Vz.Deg2Rad(currentPitch)) * Vz.Cos(Vz.Deg2Rad(currentRoll)));
        tiltCosC = Vz.Max(0.5, tiltCos);
        stickActive = (((Vz.Abs(inputPitch) + Vz.Abs(inputRoll)) > 0.1) ? 1 : 0);
        altAGL = Vz.Craft.AltitudeAGL();
        using (new If((((homeValid == 0) && (groundFlag == 0)) && (altAGL > 1))))
        {
            homePosN = posN;
            homePosE = posE;
            homeValid = 1;
        }
        slowCnt = (slowCnt + 1);
        runSlow = ((slowCnt >= Slow_Div) ? 1 : 0);
        using (new While((runSlow == 1)))
        {
            velSurface = Vz.Craft.Velocity.Surface();
            vF = velSurface.y;
            vR = (velSurface.z * (-1));
            climbRate = (velSurface.x * (-1));
            vN = ((vF * cosH) - (vR * sinH));
            vE = ((vF * sinH) + (vR * cosH));
            accF = (((vF - vFOld) / dtS) - (Vz.Deg2Rad(rateYaw) * vR));
            accR = (((vR - vROld) / dtS) + (Vz.Deg2Rad(rateYaw) * vF));
            accU = ((climbRate - velOldU) / dtS);
            vFOld = vF;
            vROld = vR;
            velOldU = climbRate;
            accAlpha = (dtS / (dtS + 0.05));
            accFFilt = (accFFilt + ((Vz.Min(30, Vz.Max(-30, accF)) - accFFilt) * accAlpha));
            accRFilt = (accRFilt + ((Vz.Min(30, Vz.Max(-30, accR)) - accRFilt) * accAlpha));
            accMag = Vz.Sqrt((((accF * accF) + (accR * accR)) + (accU * accU)));
            shockTimer = ((accMag > Shock_Acc) ? Shock_Hold : Vz.Max(0, (shockTimer - dtS)));
            gateShock = ((shockTimer > 0) ? 0 : 1);
            using (new If(((((Vz.Craft.AltitudeAGL() > 10) && (climbRate < -10)) && (Vz.Abs((inputThrottle - 0.5)) < 0.1)) && (groundFlag == 0))))
            {
                fallTimer = (fallTimer + dtS);
            }
            using (new Else())
            {
                fallTimer = 0;
            }
            using (new If((fallTimer > 1)))
            {
                fallDetected = 1;
                safetyOverride = 1;
            }
            using (new Else())
            {
                fallDetected = 0;
            }
            auxCnt = (auxCnt + 1);
            auxRun = ((auxCnt >= Aux_Div) ? 1 : 0);
            using (new While((auxCnt == 2)))
            {
                massNow = Vz.Craft.Performance.Mass();
                massUse = ((massNow > 1) ? massNow : Mass_Ref);
                airSpd = Vz.Sqrt((((vF * vF) + (vR * vR)) + (climbRate * climbRate)));
                aoaDeg = Vz.Craft.Nav.AngleOfAttack();
                slipDeg = Vz.Craft.Nav.SideSlip();
                faxA = (Vz.Sin(Vz.Deg2Rad(aoaDeg)) * Vz.Cos(Vz.Deg2Rad(slipDeg)));
                faxB = ((((vF * Vz.Sin(Vz.Deg2Rad(currentPitch))) + (vR * Vz.Sin(Vz.Deg2Rad(currentRoll)))) + (climbRate * tiltCos)) / Vz.Max(0.5, airSpd));
                faxX = ((Use_VzAoA == 1) ? faxA : faxB);
                fax2 = ((airSpd > 0.5) ? (faxX * faxX) : 0);
                rhoApi = Vz.Craft.Atmosphere.AirDensity();
                rhoX = Vz.Min(4, Vz.Max(0, (Vz.Craft.AltitudeASL() / Rho_H)));
                rhoMdl = (Rho0 / ((((1 + rhoX) + ((rhoX * rhoX) * 0.5)) + (((rhoX * rhoX) * rhoX) / 6)) + ((((rhoX * rhoX) * rhoX) * rhoX) / 24)));
                rhoRaw = ((Rho_Mode == 0) ? rhoApi : ((Rho_Mode == 1) ? rhoMdl : 1));
                rhoOk = ((rhoRaw > 0.001) ? 1 : 0);
                using (new If(((rhoInit == 0) && (rhoOk == 1))))
                {
                    rhoF = rhoRaw;
                    rhoInit = 1;
                    Rho_Ref = ((Rho_Ref > 0) ? Rho_Ref : rhoRaw);
                }
                rhoF = ((rhoOk == 1) ? (rhoF + ((rhoRaw - rhoF) * 0.4)) : rhoF);
                rhoRatio = Vz.Min(Rho_Max, Vz.Max(Rho_Min, (rhoF / Vz.Max(0.001, Rho_Ref))));
                gNow = Vz.Length(Vz.Craft.Velocity.Gravity());
                G = ((gNow > 1) ? gNow : G);
                kQuad = ((((Use_CdA == 1) && (cdaValid == 1)) ? ((0.5 * rhoF) * cdaEst) : ((Drag_Quad_Edge + ((Drag_Quad_Axial - Drag_Quad_Edge) * fax2)) * rhoRatio)));
                kLin = (Drag_Lin_Edge + ((Drag_Lin_Axial - Drag_Lin_Edge) * fax2));
                kDrag = (Aero_FF_Gain * (((kQuad * airSpd) + kLin) / massUse));
                corrP = ((corrP * 0.95) + (dAngPF * (Vz.Rad2Deg(angularVel.x) * (-1))));
                corrR = ((corrR * 0.95) + (dAngRF * Vz.Rad2Deg(angularVel.z)));
                corrAcc = ((corrAcc * 0.95) + ((currentPitch * accF) + (currentRoll * accR)));
                crossAcc = ((crossAcc * 0.95) + ((currentPitch * accR) - (currentRoll * accF)));
                auxCnt = 3;
            }
            using (new While((auxRun == 1)))
            {
                hFL = ((PartID_FL > 0) ? (Vz.RawXmlCraftProperty(@"<CraftProperty property=""Part.Activated"" style=""part""><Variable list=""false"" local=""false"" variableName=""PartID_FL"" /></CraftProperty>") ? 1 : 0) : 0);
                hFR = ((PartID_FR > 0) ? (Vz.RawXmlCraftProperty(@"<CraftProperty property=""Part.Activated"" style=""part""><Variable list=""false"" local=""false"" variableName=""PartID_FR"" /></CraftProperty>") ? 1 : 0) : 0);
                hBL = ((PartID_BL > 0) ? (Vz.RawXmlCraftProperty(@"<CraftProperty property=""Part.Activated"" style=""part""><Variable list=""false"" local=""false"" variableName=""PartID_BL"" /></CraftProperty>") ? 1 : 0) : 0);
                hBR = ((PartID_BR > 0) ? (Vz.RawXmlCraftProperty(@"<CraftProperty property=""Part.Activated"" style=""part""><Variable list=""false"" local=""false"" variableName=""PartID_BR"" /></CraftProperty>") ? 1 : 0) : 0);
                tFL = ((PartID_FL > 0) ? Vz.RawXmlCraftProperty(@"<CraftProperty property=""Part.Temperature"" style=""part""><Variable list=""false"" local=""false"" variableName=""PartID_FL"" /></CraftProperty>") : 0);
                tFR = ((PartID_FR > 0) ? Vz.RawXmlCraftProperty(@"<CraftProperty property=""Part.Temperature"" style=""part""><Variable list=""false"" local=""false"" variableName=""PartID_FR"" /></CraftProperty>") : 0);
                tBL = ((PartID_BL > 0) ? Vz.RawXmlCraftProperty(@"<CraftProperty property=""Part.Temperature"" style=""part""><Variable list=""false"" local=""false"" variableName=""PartID_BL"" /></CraftProperty>") : 0);
                tBR = ((PartID_BR > 0) ? Vz.RawXmlCraftProperty(@"<CraftProperty property=""Part.Temperature"" style=""part""><Variable list=""false"" local=""false"" variableName=""PartID_BR"" /></CraftProperty>") : 0);
                capFL = (1 - ((1 - Derate_Min) * Vz.Min(1, Vz.Max(0, ((tFL - Temp_Warn) / (Temp_Crit - Temp_Warn))))));
                capFR = (1 - ((1 - Derate_Min) * Vz.Min(1, Vz.Max(0, ((tFR - Temp_Warn) / (Temp_Crit - Temp_Warn))))));
                capBL = (1 - ((1 - Derate_Min) * Vz.Min(1, Vz.Max(0, ((tBL - Temp_Warn) / (Temp_Crit - Temp_Warn))))));
                capBR = (1 - ((1 - Derate_Min) * Vz.Min(1, Vz.Max(0, ((tBR - Temp_Warn) / (Temp_Crit - Temp_Warn))))));
                maskNow = (((hFL + (hFR * 2)) + (hBL * 4)) + (hBR * 8));
                failAny = ((maskNow == 15) ? 0 : 1);
                yawLost = failAny;
                recalcAlloc = ((maskNow == maskOld) ? 0 : 1);
                maskOld = maskNow;
                auxCnt = 0;
                auxRun = 0;
            }
            posN = (posN + (vN * dtS));
            posE = (posE + (vE * dtS));
            speedFast = ((Vz.Sqrt(((vF * vF) + (vR * vR))) > 1) ? 1 : 0);
            lockPos = Vz.Max(Vz.Max(stickActive, speedFast), Vz.Max((1 - gGate), failAny));
            targetPosN = ((lockPos == 1) ? posN : targetPosN);
            targetPosE = ((lockPos == 1) ? posE : targetPosE);
            using (new If(((FlightMode == 3) && (stickActive == 0))))
            {
                targetPosN = homePosN;
                targetPosE = homePosE;
            }
            using (new If((FlightMode == 4)))
            {
                targetPosN = autoTakeoffStartPosN;
                targetPosE = autoTakeoffStartPosE;
            }
            using (new If((FlightMode == 2)))
            {
                using (new If((stickActive == 1)))
                {
                    targetPosN = posN;
                    targetPosE = posE;
                }
            }
            using (new If((guidanceMode == 1)))
            {
                targetPosN = waypointN;
                targetPosE = waypointE;
                using (new If((Vz.Sqrt((((waypointN - posN) * (waypointN - posN)) + ((waypointE - posE) * (waypointE - posE)))) < waypointRadius)))
                {
                    waypointAlt = 0;
                    guidanceMode = 0;
                }
            }
            using (new ElseIf((guidanceMode == 2)))
            {
                targetPosN = interceptN;
                targetPosE = interceptE;
            }
            using (new ElseIf((guidanceMode == 3)))
            {
                targetPosN = (posN + camDeltaN);
                targetPosE = (posE + camDeltaE);
            }
            using (new If((guidanceMode == 0)))
            {
                using (new If((swarmMode == 2)))
                {
                    targetPosN = (posN + swarmN);
                    targetPosE = (posE + swarmE);
                }
            }
            errN = (targetPosN - posN);
            errE = (targetPosE - posE);
            errPosF = Vz.Min(5, Vz.Max(-5, (((errN * cosH) + (errE * sinH)) * Kp_Pos)));
            errPosR = Vz.Min(5, Vz.Max(-5, (((errE * cosH) - (errN * sinH)) * Kp_Pos)));
            using (new If((((guidanceMode == 0) && (swarmMode == 2)) && (leaderID >= 0))))
            {
                errPosF = (errPosF + ((swarmLeaderVelN * cosH) + (swarmLeaderVelE * sinH)));
                errPosR = (errPosR + ((swarmLeaderVelE * cosH) - (swarmLeaderVelN * sinH)));
            }
            aeroF = (kDrag * vF);
            aeroR = (kDrag * vR);
            aeroU = (kDrag * climbRate);
            using (new If((inputThrottle < 0.5)))
            {
                manualThr = ((inputThrottle * 2) * hoverBase);
            }
            using (new Else())
            {
                manualThr = (hoverBase + (((inputThrottle - 0.5) * 2) * (1 - hoverBase)));
            }
            stickClimb = (((inputThrottle - 0.5) * 2) * Climb_Max);
            targetClimb = ((failAny == 1) ? Vz.Min(stickClimb, (-1 * Fail_Descend)) : stickClimb);
            altAGL = Vz.Craft.AltitudeAGL();
            using (new If((FlightMode == 1)))
            {
                targetClimb = 0;
            }
            using (new If((FlightMode == 2)))
            {
                targetClimb = 0;
            }
            using (new If((FlightMode == 3)))
            {
                rthAltErr = (20 - altAGL);
                using (new If((rthAltErr > 0.5)))
                {
                    targetClimb = Vz.Min(Climb_Max, (rthAltErr * 0.4));
                }
                using (new ElseIf((rthAltErr < -0.5)))
                {
                    targetClimb = Vz.Max((-1 * Fail_Descend), (rthAltErr * 0.4));
                }
                using (new Else())
                {
                    targetClimb = 0;
                }
            }
            using (new If((FlightMode == 4)))
            {
                using (new If((autoTakeoffPhase == 1)))
                {
                    takeoffErr = (autoTakeoffTargetAlt - altAGL);
                    using (new If((takeoffErr > 0.5)))
                    {
                        targetClimb = Vz.Min(Climb_Max, Vz.Max(0.2, (takeoffErr * 0.4)));
                    }
                    using (new Else())
                    {
                        autoTakeoffPhase = 2;
                        targetClimb = 0;
                    }
                }
                using (new ElseIf((autoTakeoffPhase == 2)))
                {
                    targetClimb = 0;
                }
            }
            using (new If(((FlightMode == 4) && (autoTakeoffPhase == 2))))
            {
                flightModeLatch = 2;
            }
            using (new If((FlightMode == 5)))
            {
                using (new If((autoLandPhase == 0)))
                {
                    targetClimb = 0;
                    autoLandPhase = 1;
                }
                using (new ElseIf((autoLandPhase == 1)))
                {
                    targetClimb = (-1 * Vz.Min(1, Vz.Max(0.1, (altAGL * 0.2))));
                    using (new If((altAGL < 1.5)))
                    {
                        autoLandPhase = 2;
                    }
                }
                using (new ElseIf((autoLandPhase == 2)))
                {
                    targetClimb = -0.3;
                    using (new If((Vz.Craft.Grounded() == true)))
                    {
                        autoLandPhase = 3;
                        disarmFlag = 1;
                    }
                }
                using (new ElseIf((autoLandPhase == 3)))
                {
                    targetClimb = -0.5;
                }
            }
            rthDistance = Vz.Distance(Vz.Vec(homePosN, homePosE, 0), Vz.Vec(posN, posE, 0));
            using (new If((((FlightMode == 3) && (rthDistance < rthArriveDist)) && (stickActive == 0))))
            {
                flightModeLatch = 5;
            }
            using (new If((safetyOverride == 1)))
            {
                targetClimb = Vz.Max(-1, Vz.Min(1, (climbRate * (-0.3))));
            }
            using (new If((guidanceMode == 1)))
            {
                using (new If((Vz.Abs((waypointAlt - altAGL)) > 0.5)))
                {
                    targetClimb = Vz.Min(Climb_Max, Vz.Max((-1 * Fail_Descend), ((waypointAlt - altAGL) * 0.4)));
                }
                using (new Else())
                {
                    targetClimb = 0;
                }
            }
            using (new If((guidanceMode == 2)))
            {
                using (new If((Vz.Abs((interceptAlt - altAGL)) > 0.5)))
                {
                    targetClimb = Vz.Min(Climb_Max, Vz.Max((-1 * Climb_Max), ((interceptAlt - altAGL) * 0.4)));
                }
                using (new Else())
                {
                    targetClimb = 0;
                }
            }
            using (new If((swarmMode == 2)))
            {
                using (new If((Vz.Abs(((leaderPos.z + swarmOffsetUp) - Vz.Craft.AltitudeASL())) > 0.5)))
                {
                    targetClimb = Vz.Min(Climb_Max, Vz.Max((-1 * Climb_Max), (((leaderPos.z + swarmOffsetUp) - Vz.Craft.AltitudeASL()) * 0.4)));
                }
                using (new Else())
                {
                    targetClimb = 0;
                }
            }
            aRefU = Vz.Min(AccRefU_Max, Vz.Max((-1 * AccRefU_Max), ((targetClimb - vRefU) / (Tau_Climb + dtS))));
            vRefU = ((vRefU + (aRefU * dtS)) * gGate);
            errClimb = (vRefU - climbRate);
            gateClimbWin = ((Vz.Abs(errClimb) < Climb_Window) ? 1 : 0);
            gateClimbCtr = Vz.Max(((Vz.Abs((inputThrottle - 0.5)) < 0.05) ? 1 : 0), failAny);
            climbIntegral = Vz.Min(5, Vz.Max(-5, (climbIntegral + (((((errClimb * dtS) * gateClimbWin) * gateClimbCtr) * gGate) * gateShock))));
            accZcmd = ((climbAuto == 1) ? Vz.Min(6, Vz.Max(-6, ((((errClimb * Kp_Climb) + (climbIntegral * Ki_Climb)) + aeroU) + (Kff_Acc * aRefU)))) : 0);
            gEff = Vz.Max(3, (G + accZcmd));
            using (new If(((FlightMode == 0) && (guidanceMode == 0))))
            {
                gEff = G;
                climbIntegral = 0;
            }
            thrustRatio = ((massUse * gEff) / ((Mass_Ref * G) * rhoRatio));
            baseThr = ((Thr_Sqrt == 1) ? (hoverBase * Vz.Sqrt(thrustRatio)) : (hoverBase * thrustRatio));
            using (new If(((FlightMode == 0) && (guidanceMode == 0))))
            {
                thrComp = ((Rho_Manual == 1) ? Vz.Min(1.8, Vz.Max(0.7, (1 / Vz.Sqrt(rhoRatio)))) : 1);
                baseThr = (manualThr * thrComp);
                climbIntegral = 0;
            }
            gSch = Vz.Min(Sch_Max, Vz.Max(Sch_Min, ((hoverBase / Vz.Max(0.35, baseThr)) / rhoRatio)));
            spdLim = ((failAny == 1) ? Fail_Spd_Max : Spd_Max);
            targetVF = ((inputPitch * spdLim) + (errPosF * (1 - stickActive)));
            targetVR = ((inputRoll * spdLim) + (errPosR * (1 - stickActive)));
            using (new If((FlightMode >= 2)))
            {
                using (new If((stickActive == 1)))
                {
                    targetVF = (inputPitch * spdLim);
                    targetVR = (inputRoll * spdLim);
                }
                using (new Else())
                {
                    targetVF = (errPosF * 2);
                    targetVR = (errPosR * 2);
                }
            }
            using (new If((FlightMode == 5)))
            {
                targetVF = 0;
                targetVR = 0;
            }
            aRefF = Vz.Min(AccRef_Max, Vz.Max((-1 * AccRef_Max), ((targetVF - vRefF) / (Tau_Cmd + dtS))));
            aRefR = Vz.Min(AccRef_Max, Vz.Max((-1 * AccRef_Max), ((targetVR - vRefR) / (Tau_Cmd + dtS))));
            vRefF = ((vRefF + (aRefF * dtS)) * gGate);
            vRefR = ((vRefR + (aRefR * dtS)) * gGate);
            errVF = (vRefF - vF);
            errVR = (vRefR - vR);
            gateWinF = ((Vz.Abs(errVF) < Int_Window) ? 1 : 0);
            gateWinR = ((Vz.Abs(errVR) < Int_Window) ? 1 : 0);
            gateSpeed = (((((stickActive == 0) ? 1 : 0) * gGate) * gateShock) * (1 - attProtect));
            bleedF = Vz.Max(0, (1 - (((1 - gateWinF) * Int_Bleed) * dtS)));
            bleedR = Vz.Max(0, (1 - (((1 - gateWinR) * Int_Bleed) * dtS)));
            integralVF = (Vz.Min(20, Vz.Max(-20, ((integralVF * bleedF) + (((errVF * dtS) * gateSpeed) * gateWinF)))) * gGate);
            integralVR = (Vz.Min(20, Vz.Max(-20, ((integralVR * bleedR) + (((errVR * dtS) * gateSpeed) * gateWinR)))) * gGate);
            accCmdF = ((((errVF * Kp_Speed) + ((integralVF * Ki_Speed) - (accFFilt * Kd_Speed))) + aeroF) + (Kff_Acc * aRefF));
            accCmdR = ((((errVR * Kp_Speed) + ((integralVR * Ki_Speed) - (accRFilt * Kd_Speed))) + aeroR) + (Kff_Acc * aRefR));
            targetPitch = Vz.Rad2Deg(Vz.Atan((accCmdF / gEff)));
            targetRoll = Vz.Rad2Deg(Vz.Atan((accCmdR / gEff)));
            tiltLim = ((failAny == 1) ? Max_Tilt_Fail : Max_Tilt);
            tiltMag = Vz.Sqrt(((targetPitch * targetPitch) + (targetRoll * targetRoll)));
            tiltScale = ((tiltMag > tiltLim) ? (tiltLim / tiltMag) : 1);
            targetPitch = ((targetPitch * tiltScale) * Outer_On);
            targetRoll = ((targetRoll * tiltScale) * Outer_On);
            targetPitch = (targetPitch * (1 - attProtect));
            targetRoll = (targetRoll * (1 - attProtect));
            using (new If((nearVertical == 1)))
            {
                dirVec = Vz.Craft.Nav.Direction();
                northVec2 = Vz.Craft.Nav.North();
                rightVec2 = Vz.Craft.Nav.Right();
                upAxis = Vz.Cross(northVec2, rightVec2);
                vertDot = Vz.Abs(Vz.Dot(dirVec, upAxis));
                dotNV = Vz.Sqrt(Vz.Max(0, (1 - (vertDot * vertDot))));
                dotNV = Vz.Min(1, Vz.Max(0, dotNV));
                recoveryScale = Vz.Max(0.2, dotNV);
                recoveryLim = ((failAny == 1) ? Max_Tilt_Fail : Max_Tilt);
                targetPitch = Vz.Min(recoveryLim, Vz.Max((-1 * recoveryLim), (currentPitch * recoveryScale)));
                targetRoll = Vz.Min(recoveryLim, Vz.Max((-1 * recoveryLim), (currentRoll * recoveryScale)));
                using (new If((dotNV < 0.15)))
                {
                    yawLost = 1;
                    targetYaw = heading;
                }
            }
            ffRateP = (ffRateP + ((Vz.Min(Max_Rate, Vz.Max((-1 * Max_Rate), ((targetPitch - tgtPitchPrev) / dtS))) - ffRateP) * accAlpha));
            ffRateR = (ffRateR + ((Vz.Min(Max_Rate, Vz.Max((-1 * Max_Rate), ((targetRoll - tgtRollPrev) / dtS))) - ffRateR) * accAlpha));
            ffRateP = (ffRateP * (1 - attProtect));
            ffRateR = (ffRateR * (1 - attProtect));
            tgtPitchPrev = targetPitch;
            tgtRollPrev = targetRoll;
            dtS = 0;
            slowCnt = 0;
            runSlow = 0;
        }
        using (new While((recalcAlloc == 1)))
        {
            qT_FL = hFL;
            qT_FR = hFR;
            qT_BL = hBL;
            qT_BR = hBR;
            iT = (((((hFL + hFR) + hBL) + hBR) > 0.5) ? (1 / (((hFL + hFR) + hBL) + hBR)) : 0);
            muPT = ((((((-1 * Ax_FL) * hFL) + ((-1 * Ax_FR) * hFR)) + ((-1 * Ax_BL) * hBL)) + ((-1 * Ax_BR) * hBR)) * iT);
            qP_FL = (((-1 * Ax_FL) * hFL) - (muPT * hFL));
            qP_FR = (((-1 * Ax_FR) * hFR) - (muPT * hFR));
            qP_BL = (((-1 * Ax_BL) * hBL) - (muPT * hBL));
            qP_BR = (((-1 * Ax_BR) * hBR) - (muPT * hBR));
            iP = ((((qP_FL * qP_FL) + (qP_FR * qP_FR)) + (qP_BL * qP_BL)) + (qP_BR * qP_BR));
            iP = ((iP > 0.05) ? (1 / iP) : 0);
            muRT = (((((Ay_FL * hFL) + (Ay_FR * hFR)) + (Ay_BL * hBL)) + (Ay_BR * hBR)) * iT);
            muRP = ((((((Ay_FL * hFL) * qP_FL) + ((Ay_FR * hFR) * qP_FR)) + ((Ay_BL * hBL) * qP_BL)) + ((Ay_BR * hBR) * qP_BR)) * iP);
            qR_FL = (((Ay_FL * hFL) - (muRT * hFL)) - (muRP * qP_FL));
            qR_FR = (((Ay_FR * hFR) - (muRT * hFR)) - (muRP * qP_FR));
            qR_BL = (((Ay_BL * hBL) - (muRT * hBL)) - (muRP * qP_BL));
            qR_BR = (((Ay_BR * hBR) - (muRT * hBR)) - (muRP * qP_BR));
            iR = ((((qR_FL * qR_FL) + (qR_FR * qR_FR)) + (qR_BL * qR_BL)) + (qR_BR * qR_BR));
            iR = ((iR > 0.05) ? (1 / iR) : 0);
            muYT = (((((Yc_FL * hFL) + (Yc_FR * hFR)) + (Yc_BL * hBL)) + (Yc_BR * hBR)) * iT);
            muYP = ((((((Yc_FL * hFL) * qP_FL) + ((Yc_FR * hFR) * qP_FR)) + ((Yc_BL * hBL) * qP_BL)) + ((Yc_BR * hBR) * qP_BR)) * iP);
            muYR = ((((((Yc_FL * hFL) * qR_FL) + ((Yc_FR * hFR) * qR_FR)) + ((Yc_BL * hBL) * qR_BL)) + ((Yc_BR * hBR) * qR_BR)) * iR);
            qY_FL = ((((Yc_FL * hFL) - (muYT * hFL)) - (muYP * qP_FL)) - (muYR * qR_FL));
            qY_FR = ((((Yc_FR * hFR) - (muYT * hFR)) - (muYP * qP_FR)) - (muYR * qR_FR));
            qY_BL = ((((Yc_BL * hBL) - (muYT * hBL)) - (muYP * qP_BL)) - (muYR * qR_BL));
            qY_BR = ((((Yc_BR * hBR) - (muYT * hBR)) - (muYP * qP_BR)) - (muYR * qR_BR));
            iY = ((((qY_FL * qY_FL) + (qY_FR * qY_FR)) + (qY_BL * qY_BL)) + (qY_BR * qY_BR));
            iY = ((iY > 0.05) ? (1 / iY) : 0);
            recalcAlloc = 0;
        }
        errPitchAng = (targetPitch - currentPitch);
        errPitchAng = (errPitchAng - (360 * Vz.Round((errPitchAng / 360))));
        errRollAng = (targetRoll - currentRoll);
        errRollAng = (errRollAng - (360 * Vz.Round((errRollAng / 360))));
        targetPitchRate = Vz.Min(Max_Rate, Vz.Max((-1 * Max_Rate), ((errPitchAng * Kp_Angle) + ((Kff_Rate * ffRateP) * Vz.Max(0, (1 - (Vz.Abs(errPitchAng) / FF_Fade)))))));
        targetRollRate = Vz.Min(Max_Rate, Vz.Max((-1 * Max_Rate), ((errRollAng * Kp_Angle) + ((Kff_Rate * ffRateR) * Vz.Max(0, (1 - (Vz.Abs(errRollAng) / FF_Fade)))))));
        errPitchRate = (targetPitchRate - ratePitch);
        errRollRate = (targetRollRate - rateRoll);
        gateRateP = (((Vz.Abs(errPitchRate) < Rate_Int_Window) ? 1 : 0) * (1 - attProtect));
        gateRateR = (((Vz.Abs(errRollRate) < Rate_Int_Window) ? 1 : 0) * (1 - attProtect));
        integralPitchRate = (Vz.Min(100, Vz.Max(-100, (integralPitchRate + ((((errPitchRate * dt) * gateRateP) * gGate) * gateShock)))) * gGate);
        integralRollRate = (Vz.Min(100, Vz.Max(-100, (integralRollRate + ((((errRollRate * dt) * gateRateR) * gGate) * gateShock)))) * gGate);
        cmdPitch = (Vz.Min(Cmd_Max, Vz.Max((-1 * Cmd_Max), (((Bal_Mode == 2) ? (errPitchAng * Kp_Bal) : ((errPitchRate * Kp_Rate) + ((integralPitchRate * Ki_Rate) - (ratePitchDFilt * Kd_Rate)))) * gSch))) * gGate);
        cmdRoll = (Vz.Min(Cmd_Max, Vz.Max((-1 * Cmd_Max), (((Bal_Mode == 2) ? (errRollAng * Kp_Bal) : ((errRollRate * Kp_Rate) + ((integralRollRate * Ki_Rate) - (rateRollDFilt * Kd_Rate)))) * gSch))) * gGate);
        baseThrottle = ((Thr_Sqrt == 1) ? (baseThr / Vz.Sqrt(tiltCosC)) : (baseThr / tiltCosC));
        baseThrottle = ((gGate == 0) ? 0 : Vz.Min(0.95, Vz.Max(0.05, baseThrottle)));
        yawStickOn = ((Vz.Abs(inputYaw) > 0.1) ? 1 : 0);
        yawFollow = Vz.Max(Vz.Max(yawStickOn, (1 - gGate)), Vz.Max(yawLost, Vz.Max(nearVertical, attProtect)));
        targetYaw = ((yawFollow == 1) ? heading : targetYaw);
        using (new If((Vz.ActivationGroup(8) == true)))
        {
            using (new If((yawLockOn == 0)))
            {
                yawLockTarget = heading;
                yawLockOn = 1;
            }
            yawFollow = 0;
            targetYaw = yawLockTarget;
        }
        using (new Else())
        {
            yawLockOn = 0;
        }
        using (new If((Vz.ActivationGroup(9) == true)))
        {
            using (new If((yawStickOn == 0)))
            {
                yawAdaptAngle = Vz.Rad2Deg(Vz.Atan((vR / Vz.Max(2, Vz.Abs(vF)))));
                using (new If((vF < 0)))
                {
                    yawAdaptAngle = (yawAdaptAngle + 180);
                }
                targetYaw = (heading + (yawAdaptAngle * yawAdaptGain));
                yawFollow = 0;
            }
        }
        using (new If((Vz.ActivationGroup(7) == true)))
        {
            using (new If((poiActive == 0)))
            {
                poiTargetN = (posN + (Vz.Cos(Vz.Deg2Rad(heading)) * 50));
                poiTargetE = (posE + (Vz.Sin(Vz.Deg2Rad(heading)) * 50));
                poiActive = 1;
            }
            poiRelN = (poiTargetN - posN);
            poiRelE = (poiTargetE - posE);
            poiBearing = Vz.Rad2Deg(Vz.Atan2(poiRelE, poiRelN));
            using (new If((yawStickOn == 0)))
            {
                targetYaw = poiBearing;
                yawFollow = 0;
            }
        }
        using (new Else())
        {
            poiActive = 0;
        }
        errYawAng = Vz.Rad2Deg(Vz.Atan2(Vz.Sin(Vz.Deg2Rad((targetYaw - heading))), Vz.Cos(Vz.Deg2Rad((targetYaw - heading)))));
        errYawRate = ((yawStickOn == 1) ? ((inputYaw * Max_Yaw_Rate) - rateYaw) : (Vz.Min(Max_Rate, Vz.Max((-1 * Max_Rate), (errYawAng * Kp_YawAng))) - rateYaw));
        gateYaw = (((1 - yawStickOn) * gGate) * (1 - yawLost));
        integralYawRate = (Vz.Min(20, Vz.Max(-20, (integralYawRate + ((errYawRate * dt) * gateYaw)))) * gGate);
        cmdYaw = ((Vz.Min(0.2, Vz.Max(-0.2, (((errYawRate * Kp_YawRate) + (integralYawRate * Ki_YawRate)) * gSch))) * gGate) * (1 - yawLost));
        yawRoom = Vz.Max(0, ((Vz.Min(baseThrottle, (1 - baseThrottle)) - Vz.Abs(cmdPitch)) - Vz.Abs(cmdRoll)));
        cmdYaw = Vz.Min(yawRoom, Vz.Max((-1 * yawRoom), cmdYaw));
        sT = (4 * baseThrottle);
        sP = ((4 * cmdPitch) - (muPT * sT));
        sR = (((4 * cmdRoll) - (muRT * sT)) - (muRP * sP));
        sY = ((((4 * cmdYaw) - (muYT * sT)) - (muYP * sP)) - (muYR * sR));
        uFL = (((((qT_FL * sT) * iT) + ((qP_FL * sP) * iP)) + ((qR_FL * sR) * iR)) + ((qY_FL * sY) * iY));
        uFR = (((((qT_FR * sT) * iT) + ((qP_FR * sP) * iP)) + ((qR_FR * sR) * iR)) + ((qY_FR * sY) * iY));
        uBL = (((((qT_BL * sT) * iT) + ((qP_BL * sP) * iP)) + ((qR_BL * sR) * iR)) + ((qY_BL * sY) * iY));
        uBR = (((((qT_BR * sT) * iT) + ((qP_BR * sP) * iP)) + ((qR_BR * sR) * iR)) + ((qY_BR * sY) * iY));
        mxU = Vz.Max(Vz.Max(((hFL * uFL) - (9 * (1 - hFL))), ((hFR * uFR) - (9 * (1 - hFR)))), Vz.Max(((hBL * uBL) - (9 * (1 - hBL))), ((hBR * uBR) - (9 * (1 - hBR)))));
        mnU = Vz.Min(Vz.Min(((hFL * uFL) + (9 * (1 - hFL))), ((hFR * uFR) + (9 * (1 - hFR)))), Vz.Min(((hBL * uBL) + (9 * (1 - hBL))), ((hBR * uBR) + (9 * (1 - hBR)))));
        scaleM = (((mxU - mnU) > 1) ? (1 / (mxU - mnU)) : 1);
        centerM = ((mxU + mnU) * 0.5);
        mx1 = (centerM + ((mxU - centerM) * scaleM));
        mn1 = (centerM + ((mnU - centerM) * scaleM));
        shiftM = ((mx1 > 1) ? (mx1 - 1) : ((mn1 < 0) ? mn1 : 0));
        mFL = (centerM + (((uFL - centerM) * scaleM) - shiftM));
        mFR = (centerM + (((uFR - centerM) * scaleM) - shiftM));
        mBL = (centerM + (((uBL - centerM) * scaleM) - shiftM));
        mBR = (centerM + (((uBR - centerM) * scaleM) - shiftM));
        capOver = Vz.Max(0, Vz.Max(Vz.Max((hFL * (mFL - capFL)), (hFR * (mFR - capFR))), Vz.Max((hBL * (mBL - capBL)), (hBR * (mBR - capBR)))));
        capShift = Vz.Max(0, Vz.Min(capOver, (mn1 - shiftM)));
        using (new If((capOver > 0.01)))
        {
            integralVF = (integralVF * 0.95);
            integralVR = (integralVR * 0.95);
            climbIntegral = (climbIntegral * 0.95);
        }
        lpAlpha = (dt / (dt + 0.05));
        rawFL = (Vz.Min(capFL, Vz.Max(0, (mFL - capShift))) * hFL);
        rawFR = (Vz.Min(capFR, Vz.Max(0, (mFR - capShift))) * hFR);
        rawBL = (Vz.Min(capBL, Vz.Max(0, (mBL - capShift))) * hBL);
        rawBR = (Vz.Min(capBR, Vz.Max(0, (mBR - capShift))) * hBR);
        outFL = (outFL + ((rawFL - outFL) * lpAlpha));
        outFR = (outFR + ((rawFR - outFR) * lpAlpha));
        outBL = (outBL + ((rawBL - outBL) * lpAlpha));
        outBR = (outBR + ((rawBR - outBR) * lpAlpha));
        using (new If((disarmFlag == 1)))
        {
            outFL = 0;
            outFR = 0;
            outBL = 0;
            outBR = 0;
        }
        using (new If((((disarmFlag == 1) && (inputThrottle > 0.8)) && (groundFlag == 1))))
        {
            disarmFlag = 0;
            autoLandPhase = 0;
            flightModeLatch = 0;
        }
        using (new If((((safetyOverride == 1) && (inputThrottle > 0.8)) && ((Vz.Abs(inputPitch) > 0.5) || (Vz.Abs(inputRoll) > 0.5)))))
        {
            safetyOverride = 0;
            fallTimer = 0;
            fallDetected = 0;
        }
        dispCnt = (dispCnt + 1);
        using (new While((dispCnt >= 20)))
        {
            displayFlash = (((Vz.Time.TotalTime() % 1) > 0.5) ? 1 : 0);
            Vz.Display(Vz.Join("V4 mode", FlightMode, " h", Vz.Round(heading), " alt", Vz.Round(Vz.Craft.AltitudeAGL()), " up", Vz.Round(climbRate), " mask", maskNow, " tMax", Vz.Round(Vz.Max(Vz.Max(tFL, tFR), Vz.Max(tBL, tBR))), ""), 7);
            Vz.Display(Vz.Join("rcLost", rcLost, " fall", fallDetected, " bat", Vz.Round((batteryLevel * 100)), " NV", nearVertical, " dot", Vz.Round((dotNV * 100)), ""), 7);
            Vz.Display(Vz.Join("LeaderDist: ", Vz.StringOp("friendly", leaderID, "distance"), ""), 7);
            Vz.Display(Vz.Join("THr:", Vz.Round((Vz.CraftInput(CraftInput.Throttle) * 100)), "baseThr:", Vz.Round((baseThr * 100)), "gGate:", gGate, "hFL:", hFL, "G:", G, ""), 7);
            Vz.Display(Vz.Join("rho", Vz.Round((rhoF * 1000)), " r%", Vz.Round((rhoRatio * 100)), " sch", Vz.Round((gSch * 100)), " rpm", Vz.Round((((outFL + outFR) + (outBL + outBR)) * (Rpm_Max * 0.25))), " CdA", Vz.Round((cdaEst * 100)), " A", Vz.Round((areaEst * 100)), " kT", Vz.Round((kThrust * 100)), ""), 7);
            using (new If((((batteryAlarm == 1) || (rcLost == 1)) || (fallDetected == 1))))
            {
                using (new If((displayFlash == 1)))
                {
                    Vz.Display("!! WARNING !!", 7);
                }
            }
            dispCnt = 0;
        }
        Vz.WaitSeconds(tickSpeed);
    }
}
// VZPOS x=2690 y=-20
// VZPOS x=2990 y=-20
using (new OnStart())
{
    Vz.WaitSeconds(1);
    tEstPrev = Vz.Time.TotalTime();
    vFEst = vF;
    vREst = vR;
    vUEst = climbRate;
    using (new While(true))
    {
        Vz.WaitSeconds(0.1);
        tEst = Vz.Time.TotalTime();
        dtE = Vz.Min(0.5, Vz.Max(0.02, (tEst - tEstPrev)));
        tEstPrev = tEst;
        aEstF = (((vF - vFEst) / dtE) - (Vz.Deg2Rad(rateYaw) * vR));
        aEstR = (((vR - vREst) / dtE) + (Vz.Deg2Rad(rateYaw) * vF));
        aEstU = ((climbRate - vUEst) / dtE);
        vFEst = vF;
        vREst = vR;
        vUEst = climbRate;
        thrMean = (((outFL + outFR) + (outBL + outBR)) * 0.25);
        tModel = (((Mass_Ref * G) * rhoRatio) * ((thrMean / hoverBase) * (thrMean / hoverBase)));
        spdE = Vz.Sqrt((((vF * vF) + (vR * vR)) + (climbRate * climbRate)));
        okE = ((((((gGate > 0.5) ? 1 : 0) * gateShock) * (1 - attProtect)) * ((Vz.Abs(ratePitch) < 20) ? 1 : 0)) * ((Vz.Abs(rateRoll) < 20) ? 1 : 0));
        hovE = (((((okE * ((spdE < 1) ? 1 : 0)) * ((Vz.Abs(climbRate) < 0.3) ? 1 : 0)) * ((Vz.Abs(aEstU) < 0.4) ? 1 : 0)) * ((thrMean > 0.2) ? 1 : 0)) * ((tiltCos > 0.97) ? 1 : 0));
        kThrust = Vz.Min(1.4, Vz.Max(0.7, (kThrust + (((((massUse * G) / tiltCos) / Vz.Max(1, tModel)) - kThrust) * (0.02 * hovE)))));
        aThr = ((tModel * kThrust) / massUse);
        dEstF = (aEstF - (aThr * Vz.Sin(Vz.Deg2Rad(currentPitch))));
        dEstR = (aEstR - (aThr * Vz.Sin(Vz.Deg2Rad(currentRoll))));
        dEstU = (aEstU - ((aThr * tiltCos) - G));
        decelE = ((-1 * (((dEstF * vF) + (dEstR * vR)) + (dEstU * climbRate))) / Vz.Max(0.5, spdE));
        qE = ((0.5 * rhoF) * (spdE * spdE));
        validE = (okE * ((spdE > Est_Vmin) ? 1 : 0));
        estNum = ((estNum * 0.97) + (validE * ((decelE * massUse) * qE)));
        estDen = ((estDen * 0.97) + (validE * (qE * qE)));
        cdaValid = ((estDen > 100) ? 1 : 0);
        cdaEst = Vz.Min(20, Vz.Max(0, (estNum / Vz.Max(0.000001, estDen))));
        areaEst = (cdaEst / Vz.Max(0.1, Cd_Ref));
    }
}
var LocalToWorld = Vz.DeclareCustomExpression("LocalToWorld", "PartID", "LocalVec").SetReturn((PartID, LocalVec) =>
{
    return Vz.RawXmlCraftProperty(@"<CraftProperty property=""Part.LocalToPci"" style=""part-transform""><Variable list=""false"" local=""true"" variableName=""PartID"" /><Variable list=""false"" local=""true"" variableName=""LocalVec"" /></CraftProperty>");
});
// VZPOS x=2690 y=40
var WorldToLocal = Vz.DeclareCustomExpression("WorldToLocal", "PartID", "PciVec").SetReturn((PartID, PciVec) =>
{
    return Vz.PartPciToLocal(PartID, PciVec);
});
// VZPOS x=2690 y=100
var LocalHeadingOf = Vz.DeclareCustomExpression("LocalHeadingOf", "WorldVec").SetReturn((WorldVec) =>
{
    return Vz.Rad2Deg(Vz.Atan2(Vz.PartPciToLocal(0, WorldVec).z, Vz.PartPciToLocal(0, WorldVec).y));
});
// VZPOS x=2690 y=160
var GroundDelta = Vz.DeclareCustomExpression("GroundDelta", "FromPos", "ToPos").SetReturn((FromPos, ToPos) =>
{
    return Vz.Vec(Vz.Dot((ToPos - FromPos), Vz.Craft.Nav.North()), Vz.Dot((ToPos - FromPos), Vz.Craft.Nav.Right()), 0);
});
// VZPOS x=2690 y=220
var ClampSymmetric = Vz.DeclareCustomExpression("ClampSymmetric", "V", "MaxV").SetReturn((V, MaxV) =>
{
    return Vz.Max(Vz.Min(V, MaxV), (0 - MaxV));
});
// VZPOS x=2690 y=280
var ClampToBox = Vz.DeclareCustomExpression("ClampToBox", "V", "MinV", "MaxV").SetReturn((V, MinV, MaxV) =>
{
    return Vz.Max(Vz.Min(V, MaxV), MinV);
});
// VZPOS x=2690 y=340
var Clamp_Vector_Magnitude = Vz.DeclareCustomExpression("Clamp Vector Magnitude", "Vector", "Magnitude").SetReturn((Vector, Magnitude) =>
{
    return (Vz.Norm(Vector) * Vz.Min(Magnitude, Vz.Max(Vz.Length(Vector), 0)));
});
// VZPOS x=2690 y=400
var PredictFallPoint = Vz.DeclareCustomExpression("PredictFallPoint", "Pos", "Vel", "TerrainH").SetReturn((Pos, Vel, TerrainH) =>
{
    return (Pos + (Vel * ((Vel.x + Vz.Sqrt(((Vel.x * Vel.x) + ((2 * 9.81) * Vz.Max(0.1, (Pos.x - TerrainH)))))) / 9.81)));
});
// VZPOS x=2690 y=460
var GetDistance = Vz.DeclareCustomExpression("GetDistance", "A", "B").SetReturn((A, B) =>
{
    return Vz.Distance(A, B);
});
// VZORPHANEXPR PFZhcmlhYmxlIGxpc3Q9ImZhbHNlIiBsb2NhbD0iZmFsc2UiIHZhcmlhYmxlTmFtZT0iZGF0YSIgcG9zPSIzOTQuMDMwNywtNzYuMDM0MDUiIC8+
Console.WriteLine(Vz.context.currentProgram.Serialize().ToString());