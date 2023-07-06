using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Config_Score : Item_Config
{



    public override void Config_Init()
    {
        currItemConfig_ = CONSTANTS.ITEM_TYPE.SCORE;
        itemScore_ = ScoreManager.instance_.AssignScore(CONSTANTS.DEFAULT_SCORE_EXTRA);
    }

    public override void Collision_With_Player()
    {
        ScoreManager.instance_.ScoreIncrease(itemScore_);
        Record_Main.instance_.records_Controller_.HighScore();
        UI_Main.instance_.UI_Score_.Update_UI();
        item_Main_.item_Health_.Damage();
    }



}
