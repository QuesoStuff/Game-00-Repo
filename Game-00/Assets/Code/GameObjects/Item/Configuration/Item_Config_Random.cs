using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Config_Random : Item_Config
{



    public override void Config_Init()
    {
        ActiveItems_ = gameObject.GetComponent<ActiveItems>();
        methodStart_ = UI_Main.instance_.UI_Item_.Update_UI;
        methodStart_ += () => TriggerEvents.TriggerEvent_FrozenEnemy(true);
        methodBlinking_ = UI_Main.instance_.UI_Item_.BlinkTextIndefinitely;
        methodEnd_ = UI_Main.instance_.UI_Item_.StopBlinking;
        methodEnd_ += UI_Main.instance_.UI_Item_.Update_UI;
        methodEnd_ += () => item_Main_.item_Health_.Damage();
        methodEnd_ += () => TriggerEvents.TriggerEvent_FrozenEnemy(false);

    }



    public override void Collision_With_Player()
    {
        Configure_Item_Config_Random();
    }




}
