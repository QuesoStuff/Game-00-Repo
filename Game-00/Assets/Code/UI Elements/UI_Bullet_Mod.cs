using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Bullet_Mod : UI
{

    private string bullet_stats_UI_;
    private string bullet_type_UI_;
    private string bullet_UI_;

    public void UpdateBullet_Type_UI()
    {
        bullet_type_UI_ = null;
        if (Bullet_Config.GetIsTypeCharged())
            bullet_type_UI_ += CONSTANTS_UI.UI_BULLET_TYPE_CHARGED;
        if (Bullet_Config.GetIsTypeLazer())
            bullet_type_UI_ += CONSTANTS_UI.UI_BULLET_TYPE_LAZER;
        if (Bullet_Config.GetIsTypeMissle())
            bullet_type_UI_ += CONSTANTS_UI.UI_BULLET_TYPE_MISSILE;
    }

    public void UpdateBullet_Stats_UI()
    {
        bullet_stats_UI_ = null;
        if (Bullet_Config.GetIsStatAccelerate())
            bullet_stats_UI_ += CONSTANTS_UI.UI_BULLET_STAT_ACC;
        if (Bullet_Config.GetIsStatUniformSpeed())
            bullet_stats_UI_ += CONSTANTS_UI.UI_BULLET_STAT_UNI;
        if (Bullet_Config.GetIsStatIncreaseHealth())
            bullet_stats_UI_ += CONSTANTS_UI.UI_BULLET_STAT_HP;
        if (Bullet_Config.GetIsStatIncreasedDamage())
            bullet_stats_UI_ += CONSTANTS_UI.UI_BULLET_STAT_DAM;
    }

    public void StringFormatter()
    {
        string mess = "[ ]";
        if (bullet_stats_UI_ != null || bullet_type_UI_ != null)
            mess = "[ " + bullet_stats_UI_ + bullet_type_UI_ + " ]";
        bullet_UI_ = mess;
    }
    public void StringFormatter_OneLiner()
    {
        bullet_UI_ = $"[ {(bullet_stats_UI_ ?? string.Empty)}{(bullet_type_UI_ ?? string.Empty)} ]";
    }
    public override void Update_UI()
    {
        UpdateBullet_Type_UI();
        UpdateBullet_Stats_UI();
        StringFormatter();
        Update_UI_Text(bullet_UI_);
    }
}
