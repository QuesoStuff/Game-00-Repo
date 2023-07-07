using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    [SerializeField] public Bullet_Main bullet_Main_;
    [SerializeField] private float accelarte_;
    [SerializeField] private float damage_;
    [SerializeField] private float health_;
    [SerializeField] private float sizeScale_;
    [SerializeField] private float sizeDuration_;
    [SerializeField] private float lazerLength_;


    public void Bullet_Configuration_Stat()
    {
        if (ActiveItems.GetIsStatAccelerate())
        {
            bullet_Main_.bullet_Config_.BulletConfigurate_Extra_Accelerate();
        }
        if (ActiveItems.GetIsStatIncreasedDamage())
        {
            bullet_Main_.bullet_Config_.BulletConfigurate_Extra_IncreasedDamage();
        }
        if (ActiveItems.GetIsStatIncreaseHealth())
        {
            bullet_Main_.bullet_Config_.BulletConfigurate_Extra_IncreasedHP();
        }
        if (ActiveItems.GetIsStatUniformSpeed())
        {
            bullet_Main_.bullet_Config_.BulletConfigurate_Extra_UniformSpeed();
        }

    }
    public void Bullet_Configuration_Type(bool IsSoloCharged = false)
    {
        if (ActiveItems.GetIsTypeCharged() || IsSoloCharged)
        {
            bullet_Main_.bullet_Config_.BulletConfigurate_ChargedShot();
            bullet_Main_.bullet_Config_.Config_ChargedShot(transform.localScale * sizeScale_, sizeDuration_);
            if (!ActiveItems.GetIsTypeLazer())
                bullet_Main_.ChangeSprite();
        }
        if (ActiveItems.GetIsTypeLazer())
        {
            bullet_Main_.bullet_Config_.BulletConfigurate_Lazer();
            bullet_Main_.bullet_Config_.Config_Lazer(lazerLength_);
        }
        if (ActiveItems.GetIsTypeMissle())
        {
            //bullet_Main_.bullet_Config_.BulletConfigurate_MIssile();
        }
    }
    public void Bullet_Missle_Controls()
    {
        bool move = INPUT.instance_.Input_Move_Any();
        if (INPUT.instance_.Input_Tap_Up())
        {
            bullet_Main_.bullet_Move_.Move_Up();
        }
        else if (INPUT.instance_.Input_Tap_Down())
        {
            bullet_Main_.bullet_Move_.Move_Down();
        }
        else if (INPUT.instance_.Input_Tap_Left())
        {
            bullet_Main_.bullet_Move_.Move_Left();
        }
        else if (INPUT.instance_.Input_Tap_Right())
        {
            bullet_Main_.bullet_Move_.Move_Right();
        }
        if (move)
        {
            bullet_Main_.bullet_Direction_.SetDirection();
            bool newDireciont = bullet_Main_.bullet_Direction_.Turn();
            Vector3 offset = bullet_Main_.Offset(-bullet_Main_.bullet_Direction_.GetDirection());
            if (newDireciont)
                Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionHurt(transform.position + offset);
        }
    }

    public void Bullet_Configuration(bool IsSoloCharged = false)
    {
        bullet_Main_.bullet_Config_.BulletConfigurate_General();
        Bullet_Configuration_Type(IsSoloCharged);
        Bullet_Configuration_Stat();
        bullet_Normal_Bullet(IsSoloCharged);
    }


    public void bullet_Normal_Bullet(bool IsSoloCharged = false)
    {
        if (ActiveItems.GetIsEmpty() || IsSoloCharged)
        {
            if (GENERIC.CoinToss(20, 80))
                bullet_Main_.bullet_Health_.Set_Damage(2);
        }
    }

}

