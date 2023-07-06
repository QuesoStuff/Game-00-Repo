using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Config_HP : Item_Config
{



    public override void Config_Init()
    {
        currItemConfig_ = CONSTANTS.ITEM_TYPE.HP;
        itemHP_ = item_Main_.item_Health_.Get_Heal();

    }

    public override void Collision_With_Player()
    {
        Player_Main.instance_.player_Health_.Heal(itemHP_);
        UI_Main.instance_.UI_Health_.Update_UI();
        item_Main_.item_Health_.Damage();
    }



}
