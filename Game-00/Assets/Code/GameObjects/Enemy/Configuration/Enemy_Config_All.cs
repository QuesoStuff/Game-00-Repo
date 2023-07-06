using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Config_All : Enemy_Config
{


    public override void ConfigureMethods()
    {
        methods_ = new List<Func<bool>>()
        {
            INPUT.instance_.Input_Move_Up,
            INPUT.instance_.Input_Move_Down,
            INPUT.instance_.Input_Move_Left,
            INPUT.instance_.Input_Move_Right,
            INPUT.instance_.Input_Tap_Up,
            INPUT.instance_.Input_Tap_Down,
            INPUT.instance_.Input_Tap_Left,
            INPUT.instance_.Input_Tap_Right,
            INPUT.instance_.Input_Move_Up_Stop,
            INPUT.instance_.Input_Move_Down_Stop,
            INPUT.instance_.Input_Move_Left_Stop,
            INPUT.instance_.Input_Move_Right_Stop,
            INPUT.instance_.Input_Trigger_Pulled,
            INPUT.instance_.Input_Trigger_Release,
            INPUT.instance_.Input_Trigger_Rapid,
            INPUT.instance_.Input_Idle,
            INPUT.instance_.Input_Dash_Move,
            INPUT.instance_.Input_Shot_Rapid,
            INPUT.instance_.Input_Shot_Charged,
            INPUT.instance_.Input_Charged_Valid,
            INPUT.instance_.Input_Pause_Resume
        };
    }

}
