using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Config_Random : Item_Config
{


    public override void Init_Values()
    {
        Init_Values_Random();
    }




    public override void Collision_With_Player()
    {
        Collision_Item_Config_Random();
    }




}
