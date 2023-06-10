using System; // needed for Unity Action Events (Type of Delegate)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Collision : Collision
{
    [SerializeField] public Enemy_Main enemy_Main_;


    // Start is called before the first frame update
    public override void Congfigure_table_OnCollisionEnter2D()
    {

        table_OnCollisionEnter2D_ = new Dictionary<string, List<Action>>();
        Add(table_OnCollisionEnter2D_, CONSTANTS.Wall_Tag, enemy_Main_.enemy_Sound_.BumpIntoWall);
        Add(table_OnCollisionEnter2D_, CONSTANTS.Player_Tag, enemy_Main_.enemy_Move_.KnockBack);
        Add(table_OnCollisionEnter2D_, CONSTANTS.Player_Tag, enemy_Main_.enemy_Sound_.Clash);

    }
    public override void Congfigure_table_OnCollisionExit2D()
    {
    }
    public override void Congfigure_table_OnTriggerEnter2D()
    {
        table_OnTriggerEnter2D_ = new Dictionary<string, List<Action>>();
        Add(table_OnTriggerEnter2D_, CONSTANTS.Bullet_Tag, enemy_Main_.enemy_Color_.HoldColor);

    }
    public override void Congfigure_table_OnTriggerExit2D()
    {

        table_OnTriggerExit2D_ = new Dictionary<string, List<Action>>();
        Add(table_OnTriggerExit2D_, CONSTANTS.Bullet_Tag, enemy_Main_.enemy_Sound_.Clash);
        Add(table_OnTriggerExit2D_, CONSTANTS.Bullet_Tag, enemy_Main_.enemy_Health_.Damage);
    }




}
