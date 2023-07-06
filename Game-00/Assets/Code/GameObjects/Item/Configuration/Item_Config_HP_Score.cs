using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Config_HP_Score : Item_Config
{



    public override void Config_Init()
    {
        currItemConfig_ = CONSTANTS.ITEM_TYPE.HP_AND_SCORE;
        itemScore_ = ScoreManager.instance_.AssignScore();
        itemHP_ = item_Main_.item_Health_.Get_Heal();

    }

    public override void Collision_With_Player()
    {
        ScoreManager.instance_.ScoreIncrease(itemScore_);
        Player_Main.instance_.player_Health_.Heal(itemHP_);
        Record_Main.instance_.records_Controller_.HighScore();
        UI_Main.instance_.UI_Health_.Update_UI();
        UI_Main.instance_.UI_Score_.Update_UI();
        item_Main_.item_Health_.Damage();

    }



}
