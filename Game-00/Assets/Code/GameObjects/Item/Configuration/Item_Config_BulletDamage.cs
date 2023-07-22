using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Config_BulletDamage : Item_Config
{

    public override void Init_Values()
    {
        Config_Init_BulletDamage();
    }



    public override void Collision_With_Player()
    {
        Collision_Item_Config_BulletDamage();
    }


}
