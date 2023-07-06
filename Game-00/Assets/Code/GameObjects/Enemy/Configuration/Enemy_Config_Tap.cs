using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Config_Tap : Enemy_Config
{


    public override void ConfigureMethods()
    {
        methods_ = new List<Func<bool>>()
        {
            INPUT.instance_.Input_Tap_Up,
            INPUT.instance_.Input_Tap_Down,
            INPUT.instance_.Input_Tap_Left,
            INPUT.instance_.Input_Tap_Right
        };
    }


}
