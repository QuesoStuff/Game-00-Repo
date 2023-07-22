using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Config_Dash : Item_Config
{

    public override void Init_Values()
    {
        Config_Init_Dash();
    }



    public override void Collision_With_Player()
    {
        Collision_Item_Config_Dash();
    }



}
