using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item_Config_Lazer : Item_Config
{

    public override void Init_Values()
    {
        Config_Init_Lazer();
    }



    public override void Collision_With_Player()
    {
        Collision_Item_Config_Lazer();
    }



}
