using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Collisiom : Collision
{
    [SerializeField] public Item_Main item_Main_;

    public override void Congfigure_table_OnTriggerEnter2D()
    {
        Add(table_OnTriggerEnter2D_, CONSTANTS.Player_Tag, item_Main_.item_Health_.Damage);
    }
    /*
    public override void Congfigure_table_OnCollisionEnter2D()
    {
        base.Congfigure_table_OnCollisionEnter2D();
        Add(table_OnCollisionEnter2D_, CONSTANTS.Player_Tag, item_Main_.item_Health_.Damage);
    }
    */
}
