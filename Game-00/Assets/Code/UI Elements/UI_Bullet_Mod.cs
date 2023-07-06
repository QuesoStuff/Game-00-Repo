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
        if (ACTIVE.GetIsTypeCharged())
            bullet_type_UI_ += CONSTANTS_UI.UI_BULLET_TYPE_CHARGED;
        if (ACTIVE.GetIsTypeLazer())
            bullet_type_UI_ += CONSTANTS_UI.UI_BULLET_TYPE_LAZER;
        if (ACTIVE.GetIsTypeMissle())
            bullet_type_UI_ += CONSTANTS_UI.UI_BULLET_TYPE_MISSILE;
    }

    public void UpdateBullet_Stats_UI()
    {
        bullet_stats_UI_ = string.Empty;
        if (ACTIVE.GetIsStatAccelerate())
            bullet_stats_UI_ += CONSTANTS_UI.UI_BULLET_STAT_ACC;
        if (ACTIVE.GetIsStatUniformSpeed())
            bullet_stats_UI_ += CONSTANTS_UI.UI_BULLET_STAT_UNI;
        if (ACTIVE.GetIsStatIncreaseHealth())
            bullet_stats_UI_ += CONSTANTS_UI.UI_BULLET_STAT_HP;
        if (ACTIVE.GetIsStatIncreasedDamage())
            bullet_stats_UI_ += CONSTANTS_UI.UI_BULLET_STAT_DAM;
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
