using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Bullet_Mod : UI
{
    private string bullet_stats_UI_;
    private string bullet_type_UI_;

    public void UpdateBullet_Type_UI()
    {
        bullet_type_UI_ = string.Empty;
        if (ActiveItems.GetIsTypeCharged())
            bullet_type_UI_ += CONSTANTS_STRING.UI_BULLET_TYPE_CHARGED;
        if (ActiveItems.GetIsTypeLazer())
            bullet_type_UI_ += CONSTANTS_STRING.UI_BULLET_TYPE_LAZER;
        if (ActiveItems.GetIsTypeMissle())
            bullet_type_UI_ += CONSTANTS_STRING.UI_BULLET_TYPE_MISSILE;
    }

    public void UpdateBullet_Stats_UI()
    {
        bullet_stats_UI_ = string.Empty;
        if (ActiveItems.GetIsStatAccelerate())
            bullet_stats_UI_ += CONSTANTS_STRING.UI_Bullet_Mod_ACC;
        if (ActiveItems.GetIsStatUniformSpeed())
            bullet_stats_UI_ += CONSTANTS_STRING.UI_Bullet_Mod_UNI;
        if (ActiveItems.GetIsStatIncreaseHealth())
            bullet_stats_UI_ += CONSTANTS_STRING.UI_Bullet_Mod_HP;
        if (ActiveItems.GetIsStatIncreasedDamage())
            bullet_stats_UI_ += CONSTANTS_STRING.UI_Bullet_Mod_DAM;
    }

    public string StringFormatter()
    {
        return $"[ {bullet_stats_UI_}{bullet_type_UI_} ]";
    }

    public override void Update_UI()
    {
        UpdateBullet_Type_UI();
        UpdateBullet_Stats_UI();
        string bullet_UI_ = StringFormatter();
        Update_UI_Text(bullet_UI_);
    }
}
