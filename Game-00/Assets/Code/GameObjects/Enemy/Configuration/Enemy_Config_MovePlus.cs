using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Config_MovePlus : Enemy_Config
{


    public override void ConfigureMethods()
    {
        methods_ = new List<Func<bool>>()
        {
            INPUT.instance_.Input_Move_Up,
            INPUT.instance_.Input_Move_Down,
            INPUT.instance_.Input_Move_Left,
            INPUT.instance_.Input_Move_Right,
            INPUT.instance_.Input_Idle
        };
    }

}
