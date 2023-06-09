using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Config : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Bullet_Main bullet_Main_;
    [SerializeField] private CONSTANTS.BULLET_TYPE bullet_Type_;
    [SerializeField] private CONSTANTS.BULLET_STAT bullet_Stat_;
    [SerializeField] private Vector2 accelerate_Speed_;
    [SerializeField] private static float static_shared_Speed;

    private static bool is_Type_Charged_;
    private static bool is_Type_Lazer_;
    private static bool is_Type_Missle_;
    private static bool is_Stat_Accelarte_;
    private static bool is_Stat_UniformSpeed_;
    private static bool is_Stat_IncreaseHealth;
    private static bool is_Stat_IncreasedDamage_;

    private static int activeBulletCount_;


    private int[] thresholds = new int[] { 2, 5, 10 };
    private float[] multipliers = new float[] { 5f, 0.5f, 0.25f, 0.2f };

    public static bool LimitBullet_Missile(int count)
    {
        bool cond = true;
        if (is_Type_Missle_)
            cond = activeBulletCount_ < count;
        return cond;
    }
    public static bool LimitBullet()
    {
        bool misile = LimitBullet_Missile(2);
        return misile;
    }

    public static bool GetIsTypeCharged()
    {
        return is_Type_Charged_;
    }

    public static void SetIsTypeCharged(bool value)
    {
        is_Type_Charged_ = value;
    }

    public static bool GetIsTypeLazer()
    {
        return is_Type_Lazer_;
    }

    public static void SetIsTypeLazer(bool value)
    {
        is_Type_Lazer_ = value;
    }

    public static bool GetIsTypeMissle()
    {
        return is_Type_Missle_;
    }

    public static void SetIsTypeMissle(bool value)
    {
        is_Type_Missle_ = value;
    }

    public static bool GetIsStatAccelerate()
    {
        return is_Stat_Accelarte_;
    }

    public static void SetIsStatAccelerate(bool value)
    {
        is_Stat_Accelarte_ = value;
    }

    public static bool GetIsStatUniformSpeed()
    {
        return is_Stat_UniformSpeed_;
    }

    public static void SetIsStatUniformSpeed(bool value)
    {
        is_Stat_UniformSpeed_ = value;
    }

    public static bool GetIsStatIncreaseHealth()
    {
        return is_Stat_IncreaseHealth;
    }

    public static void SetIsStatIncreaseHealth(bool value)
    {
        is_Stat_IncreaseHealth = value;
    }

    public static bool GetIsStatIncreasedDamage()
    {
        return is_Stat_IncreasedDamage_;
    }

    public static void SetIsStatIncreasedDamage(bool value)
    {
        is_Stat_IncreasedDamage_ = value;
    }
    public static float Get_StaticSpeed()
    {
        return static_shared_Speed;
    }
    public static void Set_StaticSpeed(float staticSpeed)
    {
        static_shared_Speed = staticSpeed;
    }
    public void Set_Accelerate(Vector2 newAcc)
    {
        accelerate_Speed_ = newAcc;
    }
    public void Set_Accelerate(float newAcc)
    {
        Set_Accelerate(new Vector2(newAcc, newAcc));
    }
    public void Set_Bullet_Stat(CONSTANTS.BULLET_STAT stat)
    {
        bullet_Stat_ = stat;
        is_Stat_Accelarte_ = bullet_Stat_ == CONSTANTS.BULLET_STAT.ACCELARATE;
        is_Stat_IncreasedDamage_ = bullet_Stat_ == CONSTANTS.BULLET_STAT.INCREASE_DAMAGE;
        is_Stat_IncreaseHealth = bullet_Stat_ == CONSTANTS.BULLET_STAT.INCREASE_HEALTH;
        is_Stat_UniformSpeed_ = bullet_Stat_ == CONSTANTS.BULLET_STAT.UNIFORM_SPEED;

        if (bullet_Stat_ == CONSTANTS.BULLET_STAT.NORMAL)
        {
            is_Stat_Accelarte_ = false;
            is_Stat_UniformSpeed_ = false;
            is_Stat_IncreaseHealth = false;
            is_Stat_IncreasedDamage_ = false;
        }
    }

    public void Set_Bullet_Type(CONSTANTS.BULLET_TYPE type)
    {
        bullet_Type_ = type;
        is_Type_Charged_ = bullet_Type_ == CONSTANTS.BULLET_TYPE.CHARGED_SHOT;
        is_Type_Lazer_ = bullet_Type_ == CONSTANTS.BULLET_TYPE.LAZER;
        is_Type_Missle_ = bullet_Type_ == CONSTANTS.BULLET_TYPE.MISSLE;
        if (bullet_Type_ == CONSTANTS.BULLET_TYPE.NORMAL)
        {
            is_Type_Charged_ = false;
            is_Type_Lazer_ = false;
            is_Type_Missle_ = false;
        }
    }

    public CONSTANTS.BULLET_STAT Get_Bullet_Stat()
    {
        return bullet_Stat_;
    }
    public CONSTANTS.BULLET_TYPE Get_Bullet_Type()
    {
        return bullet_Type_;
    }

    public Vector2 Get_Accelerate()
    {
        return accelerate_Speed_;
    }
    public static void SetBulletCount(int newCOunt)
    {
        activeBulletCount_ = newCOunt;
        UI_Main.instance_.UI_Debug_.Update_UI_Text(activeBulletCount_);
    }
    public static int GetBulletCount()
    {
        return activeBulletCount_;
    }

    public void Config_Lazer(float scale)
    {
        GENERIC.ChangeScale(transform, bullet_Main_.bullet_Direction_.GetDirection(), scale);
    }
    public void Config_ChargedShot(Vector3 targetScale, float duration)
    {
        GENERIC.ScaleOverTime(this, this.gameObject, Vector3.zero, targetScale, duration);
    }
    public float Bullet_Speed()
    {
        float normalSpeed = bullet_Main_.bullet_Move_.GetCurrSpeed();
        for (int i = 0; i < thresholds.Length; i++)
        {
            if (activeBulletCount_ < thresholds[i])
            {
                normalSpeed = normalSpeed * multipliers[i];
                break;
            }
        }
        // Set the new speed
        bullet_Main_.bullet_Move_.SetCurrentSpeed(normalSpeed);
        static_shared_Speed = normalSpeed;
        return normalSpeed;
    }
    public void Stat_Accelarate(Vector2 acc)
    {
        accelerate_Speed_ = acc;
    }
    public void Stat_UniformSpeed(float sharedSpeed)
    {
        bullet_Main_.bullet_Move_.SetCurrentSpeed(sharedSpeed);
    }
    public void IncreaseDamage(float damage)
    {
        //float currDamage =  bullet_Main_.bullet_Health_.Get_Damage();
        bullet_Main_.bullet_Health_.Set_Damage(damage);
    }
    public void IncreaseHealth(float hp)
    {
        //float currHP =  bullet_Main_.bullet_Health_.Get_Heal();
        bullet_Main_.bullet_Health_.Set_HP(hp);

    }
}
