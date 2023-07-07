using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Config_Missile : Item_Config
{



    public override void Config_Init()
    {
        ActiveItems_ = gameObject.GetComponent<ActiveItems>();
        currItemConfig_ = CONSTANTS.ITEM_TYPE.MISSLE;
        methodStart_ = UI_Main.instance_.UI_Bullet_Stat_.Update_UI;

        methodBlinking_ = UI_Main.instance_.UI_Bullet_Stat_.BlinkTextIndefinitely;

        methodEnd_ = UI_Main.instance_.UI_Bullet_Stat_.StopBlinking;
        methodEnd_ += UI_Main.instance_.UI_Bullet_Stat_.Update_UI;
        methodEnd_ += () => item_Main_.item_Health_.Damage();

    }

    public override void Collision_With_Player()
    {
        Configure_Item_Config_Missile();
    }



}
