using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Config_Frozen : Item_Config
{



    public override void Config_Init()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag(CONSTANTS.Active_Tag);
        active_ = gameObject.GetComponent<ACTIVE>();
        currItemConfig_ = CONSTANTS.ITEM_TYPE.FROZEN;
        methodStart_ = UI_Main.instance_.UI_Item_.Update_UI;
        methodStart_ += () => ACTIVE.TriggerEvent_FrozenEnemy(true);

        methodBlinking_ = UI_Main.instance_.UI_Item_.BlinkTextIndefinitely;

        methodEnd_ = UI_Main.instance_.UI_Item_.StopBlinking;
        methodEnd_ += UI_Main.instance_.UI_Item_.Update_UI;
        methodEnd_ += () => item_Main_.item_Health_.Damage();
        methodEnd_ += () => ACTIVE.TriggerEvent_FrozenEnemy(false);

    }

    public override void Collision_With_Player()
    {
        StartCoroutine(active_.SelectConfig(CONSTANTS.ACTIVE_CONFIG.FROZEN, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));
    }




}
