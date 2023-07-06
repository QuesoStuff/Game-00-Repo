using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Config_Accelarate : Item_Config
{



    public override void Config_Init()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag(CONSTANTS.Active_Tag);
        active_ = gameObject.GetComponent<ACTIVE>();
        currItemConfig_ = CONSTANTS.ITEM_TYPE.ACCELARATE;
        methodStart_ = UI_Main.instance_.UI_Bullet_Stat_.Update_UI;

        methodBlinking_ = UI_Main.instance_.UI_Bullet_Stat_.BlinkTextIndefinitely;

        methodEnd_ = UI_Main.instance_.UI_Bullet_Stat_.StopBlinking;
        methodEnd_ += UI_Main.instance_.UI_Bullet_Stat_.Update_UI;

        methodEnd_ += () => item_Main_.item_Health_.Damage();

    }

    public override void Collision_With_Player()
    {
        StartCoroutine(active_.SelectConfig(CONSTANTS.ACTIVE_CONFIG.ACCELARATE, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));
    }



}
