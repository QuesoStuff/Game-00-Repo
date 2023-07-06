using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Config_Idle : Enemy_Config
{


    public override void ConfigureMethods()
    {
        methods_ = new List<Func<bool>>()
        {
            INPUT.instance_.Input_Idle
        };
    }

}
