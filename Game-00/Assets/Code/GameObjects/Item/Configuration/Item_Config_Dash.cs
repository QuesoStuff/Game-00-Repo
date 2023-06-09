using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Config_Dash : Item_Config
{



    public override void Config_Init()
    {
        ActiveItems_ = gameObject.GetComponent<ActiveItems>();
        currItemConfig_ = CONSTANTS.ITEM_TYPE.DASH;
        methodStart_ = UI_Main.instance_.UI_Item_.Update_UI;
        methodStart_ += () => Player_Main.instance_.player_Controller_.Item_Dash(15 - 3);


        methodBlinking_ = UI_Main.instance_.UI_Item_.BlinkTextIndefinitely;

        methodEnd_ = UI_Main.instance_.UI_Item_.StopBlinking;
        methodEnd_ += UI_Main.instance_.UI_Item_.Update_UI;
        methodEnd_ += () => item_Main_.item_Health_.Damage();

    }

    public override void Collision_With_Player()
    {
        Configure_Item_Config_Dash();
    }



}
