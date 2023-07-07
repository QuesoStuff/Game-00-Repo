using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Bullet_Config : MonoBehaviour
{
    [SerializeField] public Bullet_Main bullet_Main_;
    [SerializeField] private static float static_shared_Speed_;
    [SerializeField] private static float static_shared_accelarate_;

    private bool is_Type_Still_Charged_;
    private bool doneCharging_;
    private static int ActiveItemsBulletCount_;
    private static int maxBulletCount = 20;
    public static CollectionRange<int, Color> colorRange_;
    public static CollectionRange<int, float> speedRange_;

    private float currBulletSpeed_;
    private float currBulletSpeed_Mod;
    private float currBulletAccelerate_;
    private float currBulletAccelerate_Mod;




    public float GetCurrBulletSpeed()
    {
        return currBulletSpeed_;
    }

    public void SetCurrBulletSpeed(float currBulletSpeed)
    {
        currBulletSpeed_ = currBulletSpeed;
    }

    public float GetCurrBulletSpeedMod()
    {
        return currBulletSpeed_Mod;
    }

    public void SetCurrBulletSpeedMod(float currBulletSpeedMod)
    {
        currBulletSpeed_Mod = currBulletSpeedMod;
    }
    public float GetCurrBulletAccelerate()
    {
        return currBulletAccelerate_;
    }

    public void SetCurrBulletAccelerate(float currBulletAccelerate)
    {
        currBulletAccelerate_ = currBulletAccelerate;
    }

    public float GetCurrBulletAccelerateMod()
    {
        return currBulletAccelerate_Mod;
    }

    public void SetCurrBulletAccelerateMod(float currBulletAccelerateMod)
    {
        currBulletAccelerate_Mod = currBulletAccelerateMod;
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
        UI_Main.instance_.UI_Debug_.Update_UI_Text(ActiveItemsBulletCount_);
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
        Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDash(bullet_Main_.transform.position, bullet_Main_.spriterender_.color);
        yield return GENERIC.ScaleOverTime(this, this.gameObject, Vector3.zero, targetScale, duration);
        is_Type_Still_Charged_ = false;
        doneCharging_ = true;
    }

    public float Bullet_Speed()
    {
        float speed = currBulletSpeed_;
        currBulletSpeed_Mod = speed * speedRange_.GetResultBasedOnThreshold(ActiveItemsBulletCount_);
        static_shared_Speed_ = currBulletSpeed_Mod;
        static_shared_accelarate_ = currBulletAccelerate_;
        return currBulletSpeed_Mod;
    }

    public Color BulletColor()
    {
        Color bulletColor = colorRange_.GetResultBasedOnThreshold(ActiveItemsBulletCount_);
        bulletColor = GENERIC.ChangeOpacity(bulletColor, 1 - (float)ActiveItemsBulletCount_ / maxBulletCount);
        bullet_Main_.bullet_Color_.SetCurrentColor(bulletColor);
        bullet_Main_.bullet_Color_.SetColor();
        return bulletColor;
    }



    public void BulletConfigurate_Lazer()
    {
        float currDamage = bullet_Main_.bullet_Health_.Get_Damage();
        float currHP = bullet_Main_.bullet_Health_.GetCurrHP();

        bullet_Main_.bullet_Health_.Set_Damage(currDamage / 2);
        currBulletSpeed_ *= 2;
        bullet_Main_.bullet_Health_.Set_HP(2 * currHP);

    }
    public void BulletConfigurate_ChargedShot()
    {
        float currHP = bullet_Main_.bullet_Health_.GetCurrHP();
        bullet_Main_.bullet_Health_.Set_HP(currHP + 2);
        float currDamage = bullet_Main_.bullet_Health_.Get_Damage();
        bullet_Main_.bullet_Health_.Set_Damage(5 * currDamage);
        currBulletSpeed_ /= 2;
        currBulletAccelerate_ = currBulletSpeed_ / 2;
    }
    public void BulletConfigurate_MIssile()
    {
        float currDamage = bullet_Main_.bullet_Health_.Get_Damage();
        bullet_Main_.bullet_Health_.Set_Damage(currDamage / 2);
        currBulletSpeed_ *= 3;
        currBulletAccelerate_ = currBulletSpeed_ / 10;
    }




    public void BulletConfigurate_General(bool IsSoloCharged = false)
    {
        bullet_Main_.bullet_Health_.Set_HP(1);
        bullet_Main_.bullet_Health_.Set_Damage(1);
        currBulletSpeed_ = 15;
        currBulletAccelerate_ = 0;
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
        currBulletAccelerate_ += addedAcc;
    }
    public void BulletConfigurate_Extra_UniformSpeed()
    {
        BulletColor();
        Bullet_Speed();
        bullet_Main_.bullet_Move_.Set_AccelerateSpeed(static_shared_accelarate_);
        bullet_Main_.bullet_Move_.Set(static_shared_Speed_);
    }
    public void BulletConfigurate_Extra_IncreasedHP(float extraHP = 2)
    {
        float currHP = bullet_Main_.bullet_Health_.GetCurrHP();
        bullet_Main_.bullet_Health_.Set_HP(currHP + extraHP);
    }
    public void BulletConfigurate_Extra_IncreasedDamage(float extraDamage = 3)
    {
        float currDamage = bullet_Main_.bullet_Health_.Get_Damage();
        bullet_Main_.bullet_Health_.Set_Damage(currDamage + extraDamage);
    }
}



