using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    [SerializeField] public Bullet_Main bullet_Main_;
    [SerializeField] private Vector2 accelarte_;
    [SerializeField] private float damage_;
    [SerializeField] private float health_;
    [SerializeField] private float sizeScale_;
    [SerializeField] private float sizeDuration_;
    [SerializeField] private float lazerLength_;


    public void Bullet_Configuration_Stat()
    {
        if (Bullet_Config.GetIsStatAccelerate())
        {
            bullet_Main_.bullet_Config_.Stat_Accelarate(accelarte_);
        }
        if (Bullet_Config.GetIsStatIncreasedDamage())
        {
            bullet_Main_.bullet_Config_.IncreaseDamage(damage_);
        }
        if (Bullet_Config.GetIsStatIncreaseHealth())
        {
            bullet_Main_.bullet_Config_.IncreaseHealth(health_);
        }
        if (Bullet_Config.GetIsStatUniformSpeed())
        {
            bullet_Main_.bullet_Config_.Stat_UniformSpeed(Bullet_Config.Get_StaticSpeed());
        }
    }
    public void Bullet_Configuration_Type(bool IsSoloCharged = false)
    {
        if (Bullet_Config.GetIsTypeLazer())
        {
            bullet_Main_.bullet_Config_.Config_Lazer(lazerLength_);
        }
        if (Bullet_Config.GetIsTypeCharged() || IsSoloCharged)
        {
            bullet_Main_.bullet_Config_.Config_ChargedShot(transform.localScale * sizeScale_, sizeDuration_);
        }
    }
    public void Bullet_Missle_Controls()
    {
        if (INPUT.instance_.Input_Tap_Up())
        {
            bullet_Main_.bullet_Move_.Move_Up();
            bullet_Main_.bullet_Direction_.SetDirection();
            bullet_Main_.bullet_Direction_.Turn();
            Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDash(transform.position, Color.white);
        }
        else if (INPUT.instance_.Input_Tap_Down())
        {
            bullet_Main_.bullet_Move_.Move_Down();
            bullet_Main_.bullet_Direction_.SetDirection();
            bullet_Main_.bullet_Direction_.Turn();
            Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDash(transform.position, Color.white);
        }
        else if (INPUT.instance_.Input_Tap_Left())
        {
            bullet_Main_.bullet_Move_.Move_Left();
            bullet_Main_.bullet_Direction_.SetDirection();
            bullet_Main_.bullet_Direction_.Turn();
            Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDash(transform.position, Color.white);
        }
        else if (INPUT.instance_.Input_Tap_Right())
        {
            bullet_Main_.bullet_Move_.Move_Right();
            bullet_Main_.bullet_Direction_.SetDirection();
            bullet_Main_.bullet_Direction_.Turn();
            Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDash(transform.position, Color.white);
        }
    }

    public void Bullet_Configuration(bool IsSoloCharged = false)
    {
        Bullet_Configuration_Type(IsSoloCharged);
        Bullet_Configuration_Stat();
    }




}

