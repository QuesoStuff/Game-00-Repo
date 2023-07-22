using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet_Config : Config
{
    [SerializeField] public Bullet_Main bullet_Main_;
    [SerializeField] public static float static_shared_Speed_;
    [SerializeField] public static float static_shared_accelarate_;

    protected float configHP_;
    protected float configDamage_;
    protected float configSPeed_;
    protected float configAcc_;
    protected Color startColor_;
    [SerializeField] private float sizeScale_;
    [SerializeField] private float sizeDuration_;
    [SerializeField] private float lazerLength_;
    private bool is_Type_Still_Charged_;
    private bool doneCharging_;
    private static int ActiveItemsBulletCount_;
    private static int maxBulletCount = 20;
    public static CollectionRange<int, Color> colorRange_;
    public static CollectionRange<int, float> speedRange_;

    private float configBulletSpeed_;
    private float configBulletAccelerate_;

    public override void Config_Init()
    {
        throw new System.NotImplementedException();
    }


    public float GetCurrBulletSpeed()
    {
        return configBulletSpeed_;
    }

    public void SetCurrBulletSpeed(float configBulletSpeed)
    {
        configBulletSpeed_ = configBulletSpeed;
    }


    public float GetCurrBulletAccelerate()
    {
        return configBulletAccelerate_;
    }

    public void SetCurrBulletAccelerate(float configBulletAccelerate)
    {
        configBulletAccelerate_ = configBulletAccelerate;
    }




    public static bool LimitBullet(bool IsSoloCharged = false)
    {
        bool totalCount = GENERIC.CheckLimit<int>(() => true, ActiveItemsBulletCount_, maxBulletCount);
        bool missile = GENERIC.CheckLimit<int>(() => ActiveItems.GetIsTypeMissle(), ActiveItemsBulletCount_, 2);
        bool chargedShot = GENERIC.CheckLimit<int>(() => ActiveItems.GetIsTypeCharged(), ActiveItemsBulletCount_, 3);
        bool valid = totalCount && missile && chargedShot;
        return valid;
    }



    public static float Get_StaticSpeed()
    {
        return static_shared_Speed_;
    }
    public static void Set_StaticSpeed(float staticSpeed)
    {
        static_shared_Speed_ = staticSpeed;
    }



    public static void SetBulletCount(int newCOunt)
    {
        ActiveItemsBulletCount_ = newCOunt;
    }
    public static int GetBulletCount()
    {
        return ActiveItemsBulletCount_;
    }
    public bool GetStillCharging()
    {
        return is_Type_Still_Charged_;
    }
    public bool GetDoneCharging()
    {
        return doneCharging_;
    }
    public void Config_Lazer(float scale)
    {
        GENERIC.ChangeScale(transform, bullet_Main_.bullet_Direction_.GetDirection(), scale);
    }
    public void Config_ChargedShot(Vector3 targetScale, float duration)
    {
        StartCoroutine(ConfigChargedShotCoroutine(targetScale, duration));
    }

    private IEnumerator ConfigChargedShotCoroutine(Vector3 targetScale, float duration)
    {
        is_Type_Still_Charged_ = true;
        doneCharging_ = false;
        Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDash(transform.position, bullet_Main_.bullet_Color_.GetCurrentColor());
        yield return GENERIC.ScaleOverTime(this, this.gameObject, Vector3.zero, targetScale, duration);
        is_Type_Still_Charged_ = false;
        doneCharging_ = true;
    }

    public float Bullet_Speed()
    {
        float speed = configBulletSpeed_;
        speed = speed * speedRange_.GetResultBasedOnThreshold(ActiveItemsBulletCount_);
        static_shared_Speed_ = speed;
        static_shared_accelarate_ = configBulletAccelerate_;
        return speed;
    }

    public Color BulletColor()
    {
        Color bulletColor = colorRange_.GetResultBasedOnThreshold(ActiveItemsBulletCount_);
        bulletColor = GENERIC.ChangeOpacity(bulletColor, 1 - (float)ActiveItemsBulletCount_ / maxBulletCount);
        return bulletColor;
    }



    public void BulletConfigurate_Lazer()
    {
        configDamage_ /= 2;
        configBulletSpeed_ *= 2;

    }
    public void BulletConfigurate_ChargedShot()
    {
        configDamage_ *= 5; ;
        configHP_ += 2;
        configBulletSpeed_ /= 2;
        configBulletAccelerate_ = configBulletSpeed_ / 2;
    }
    public void BulletConfigurate_MIssile()
    {
        configDamage_ /= 2;
        configBulletSpeed_ *= 3;
        configBulletAccelerate_ = configBulletSpeed_ / 10;
    }


    public override void Revive()
    {
        bullet_Main_.bullet_Controller_.Revive();
    }

    public void BulletConfigurate_General(bool IsSoloCharged = false)
    {
        configHP_ = CONSTANTS.DEFAULT_BULLET_STARTER_HEALTH;
        configDamage_ = CONSTANTS.DEFAULT_HP_DAMAGE;

        configBulletSpeed_ = CONSTANTS.DEFAULT_BULLET_SPEED;
        configBulletAccelerate_ = CONSTANTS.DEFAULT_SPEED_ACC;
    }
    public void BulletConfigurate_Audio(bool IsSoloCharged = false)
    {
        if (ActiveItems.GetIsTypeCharged() || IsSoloCharged)
        {
            bullet_Main_.Bullet_Sound_.PlayRandomSound();
        }
        else
            bullet_Main_.Bullet_Sound_.ChargedShot();
    }
    public void BulletConfigurate_Extra_Accelerate(float addedAcc = 5)
    {
        configBulletAccelerate_ += addedAcc;
    }
    public void BulletConfigurate_Extra_UniformSpeed()
    {
        BulletColor();
        static_shared_Speed_ = Bullet_Speed();
        bullet_Main_.bullet_Move_.Set_AccelerateSpeed(static_shared_accelarate_);
        bullet_Main_.bullet_Move_.Set(static_shared_Speed_);
    }
    public void BulletConfigurate_Extra_IncreasedHP(float extraHP = 2)
    {
        configHP_ += extraHP;
    }
    public void BulletConfigurate_Extra_IncreasedDamage(float extraDamage = 3)
    {
        configDamage_ += extraDamage;
    }
    public override void Config_OnDeath()
    {
        OnDeath_ = () =>
{
    ActiveItemsBulletCount_--;
    UI_Main.instance_.UI_Debug_.Update_UI_Text(ActiveItemsBulletCount_);
    bullet_Main_.bullet_Controller_.FakeKill();
};
    }
    public override void Init_Values()
    {
        throw new System.NotImplementedException();
    }
    public void ConfigureBullet(Vector2 direction, bool IsSoloCharged = false)
    {
        if (direction == Vector2.zero)
            direction = Direction.GenerateRandomDirection();
        ActiveItemsBulletCount_++;
        bullet_Main_.bullet_Move_.Set(direction);
        bullet_Main_.bullet_Direction_.SetDirection();
        bullet_Main_.bullet_Direction_.StartingRotation();
        bullet_Main_.bullet_Collision_.Congfigure_table_OnTriggerEnter2D();
        bullet_Main_.bullet_Collision_.Congfigure_table_OnTriggerStay2D();
        Config_OnDeath();
        bullet_Main_.bullet_Controller_.DelayMethod(CONSTANTS.DEFSULT_BULLET_LIFETIME, OnDeath_);
        bullet_Main_.bullet_Health_.AddToAction_OnDeath(OnDeath_);
        bullet_Main_.bullet_Color_.color_Range_ = new ColorRange(CONSTANTS_COLOR.DEFAULT_BULLET_COLOR_1, CONSTANTS_COLOR.DEFAULT_BULLET_COLOR_2, 5);
        colorRange_ = new CollectionRange<int, Color>(new List<int> { 1, 3, 7, 11 }, bullet_Main_.bullet_Color_.color_Range_.GetColors());
        speedRange_ = new CollectionRange<int, float>(new List<int> { 1, 3, 7, 11 }, new List<float> { 5f, 1, 0.5f, 0.25f });
        Bullet_Configuration(IsSoloCharged);
        float curSpeed = Bullet_Speed();
        startColor_ = BulletColor();
        BulletConfigurate_Audio(IsSoloCharged);
        bullet_Main_.bullet_Color_.SetCurrentColor_SetColor(Color.white);
        bullet_Main_.bullet_Move_.Set(curSpeed);
        bullet_Main_.bullet_Move_.Set_AccelerateSpeed(configAcc_);
        bullet_Main_.bullet_Health_.Set_HP(configHP_);
        bullet_Main_.bullet_Health_.Set_Damage(configDamage_);
    }


    public void Bullet_Configuration_Stat()
    {
        if (ActiveItems.GetIsStatAccelerate())
        {
            BulletConfigurate_Extra_Accelerate();
        }
        if (ActiveItems.GetIsStatIncreasedDamage())
        {
            BulletConfigurate_Extra_IncreasedDamage();
        }
        if (ActiveItems.GetIsStatIncreaseHealth())
        {
            BulletConfigurate_Extra_IncreasedHP();
        }
        if (ActiveItems.GetIsStatUniformSpeed())
        {
            BulletConfigurate_Extra_UniformSpeed();
        }

    }
    public void Bullet_Configuration_Type(bool IsSoloCharged = false)
    {
        if (ActiveItems.GetIsTypeCharged() || IsSoloCharged)
        {
            BulletConfigurate_ChargedShot();
            Config_ChargedShot(transform.localScale * sizeScale_, sizeDuration_);
            if (!ActiveItems.GetIsTypeLazer())
                bullet_Main_.bullet_Controller_.ChangeSprite();
        }
        if (ActiveItems.GetIsTypeLazer())
        {
            BulletConfigurate_Lazer();
            Config_Lazer(lazerLength_);
        }
        if (ActiveItems.GetIsTypeMissle())
        {
            BulletConfigurate_MIssile();
        }
    }

    public void Bullet_Configuration(bool IsSoloCharged = false)
    {
        BulletConfigurate_General();
        Bullet_Configuration_Type(IsSoloCharged);
        Bullet_Configuration_Stat();
        bullet_Normal_Bullet(IsSoloCharged);
    }


    public void bullet_Normal_Bullet(bool IsSoloCharged = false)
    {
        if (ActiveItems.GetIsEmpty() || IsSoloCharged)
        {
            if (GENERIC.CoinToss(20, 80))
                configHP_ = CONSTANTS.DEFAULT_BULLET_STARTER_HEALTH_PLUS;
        }
    }


}



