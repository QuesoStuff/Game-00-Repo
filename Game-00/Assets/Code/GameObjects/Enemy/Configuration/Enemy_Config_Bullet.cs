using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Config_Bullet : Enemy_Config
{


    public override void ConfigureMethods()
    {
        methods_ = new List<Func<bool>>()
        {
            INPUT.instance_.Input_Trigger_Pulled,
            INPUT.instance_.Input_Trigger_Release,
            INPUT.instance_.Input_Trigger_Rapid,
                        INPUT.instance_.Input_Shot_Charged,
            INPUT.instance_.Input_Charged_Valid,
                        INPUT.instance_.Input_Shot_Rapid
        };
    }

}
