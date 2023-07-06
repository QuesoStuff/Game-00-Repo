using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Config_StopPlus : Enemy_Config
{


    public override void ConfigureMethods()
    {
        methods_ = new List<Func<bool>>()
        {
            INPUT.instance_.Input_Move_Up_Stop,
            INPUT.instance_.Input_Move_Down_Stop,
            INPUT.instance_.Input_Move_Left_Stop,
            INPUT.instance_.Input_Move_Right_Stop,
            INPUT.instance_.Input_Idle
        };
    }

}
