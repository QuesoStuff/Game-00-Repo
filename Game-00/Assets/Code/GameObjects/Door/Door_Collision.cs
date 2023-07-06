using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Collision : Collision
{
    [SerializeField] public Door_Main door_Main_;

    /*
        public override void Congfigure_table_OnTriggerEnter2D()
        {
            Add(table_OnTriggerEnter2D_, CONSTANTS.Player_Tag, door_Main_.door_Controller_.Collision_With_Player);
        }
    */
    public override void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.transform.position = door_Main_.teleport_.position;
        base.Congfigure_table_OnTriggerExit2D();
    }
}
