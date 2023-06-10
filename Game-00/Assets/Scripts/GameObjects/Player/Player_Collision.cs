using System; // needed for Unity Action Events (Type of Delegate)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : Collision
{
    [SerializeField] public Player_Main player_Main_;

    public override void Congfigure_table_OnCollisionEnter2D()
    {
        table_OnCollisionEnter2D_ = new Dictionary<string, List<Action>>();
        Add(table_OnCollisionEnter2D_, CONSTANTS.Wall_Tag, player_Main_.player_Sound_.BumpIntoWall);
        Add(table_OnCollisionEnter2D_, CONSTANTS.Enemy_Tag, player_Main_.player_Move_.KnockBack);

    }
    public override void Congfigure_table_OnCollisionExit2D()
    {
        table_OnCollisionExit2D_ = new Dictionary<string, List<Action>>();
        Add(table_OnCollisionExit2D_, CONSTANTS.Enemy_Tag, player_Main_.player_Health_.Damage);
        Add(table_OnCollisionExit2D_, CONSTANTS.Enemy_Tag, UI_Main.instance_.UI_Health_.Update_UI);

        Add(table_OnCollisionExit2D_, CONSTANTS.Enemy_Tag, player_Main_.player_Color_.HoldColor);

    }


    public override void Congfigure_table_OnTriggerEnter2D()
    {

    }
    public override void Congfigure_table_OnTriggerExit2D()
    {

    }
}
