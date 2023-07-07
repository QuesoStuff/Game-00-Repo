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
        Configure_Item_Config_Score();
    }



}
