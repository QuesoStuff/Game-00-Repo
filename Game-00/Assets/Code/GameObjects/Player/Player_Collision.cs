using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : Collision
{
    [SerializeField] public Player_Main player_Main_;

    public override void Congfigure_table_OnCollisionEnter2D()
    {
        Add(table_OnCollisionEnter2D_, CONSTANTS.Wall_Tag, player_Main_.player_Sound_.BumpIntoWall);
        Add(table_OnCollisionEnter2D_, CONSTANTS.Enemy_Tag, player_Main_.player_Move_.KnockBack);
        Add(table_OnCollisionEnter2D_, CONSTANTS.Enemy_Tag, player_Main_.player_Color_.HoldColor);
        Add(table_OnCollisionEnter2D_, CONSTANTS.Enemy_Tag, player_Main_.player_Health_.Damage);
        Add(table_OnCollisionEnter2D_, CONSTANTS.Enemy_Tag, UI_Main.instance_.UI_Health_.Update_UI);
    }
    public override void Congfigure_table_OnTriggerEnter2D()
    {
        Add(table_OnTriggerEnter2D_, CONSTANTS.Item_Score_Tag, player_Main_.player_Sound_.BumpIntoWall);
        Add(table_OnTriggerEnter2D_, CONSTANTS.Item_Score_Tag, ScoreManager.instance_.ScoreIncrease);
        Add(table_OnTriggerEnter2D_, CONSTANTS.Item_Score_Tag, UI_Main.instance_.UI_Score_.Update_UI);

        Add(table_OnTriggerEnter2D_, CONSTANTS.Item_Health_Tag, player_Main_.player_Sound_.BumpIntoWall);
        Add(table_OnTriggerEnter2D_, CONSTANTS.Item_Health_Tag, player_Main_.player_Health_.Heal);
        Add(table_OnTriggerEnter2D_, CONSTANTS.Item_Health_Tag, UI_Main.instance_.UI_Health_.Update_UI);

        Add(table_OnTriggerEnter2D_, CONSTANTS.Item_Special_Tag, player_Main_.player_Sound_.BumpIntoWall);
        Add(table_OnTriggerEnter2D_, CONSTANTS.Item_Special_Tag, () => Bullet_Config.StartRandomlySetBoolCoroutine(this, 15, 3));
        Add(table_OnTriggerEnter2D_, CONSTANTS.Item_Special_Tag, UI_Main.instance_.UI_Bullet_Stat_.Update_UI);
    }

}
