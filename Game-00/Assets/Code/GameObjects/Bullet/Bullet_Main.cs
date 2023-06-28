using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Main : MonoBehaviour_Plus
{
    [SerializeField] public Bullet_Controller bullet_Controller_;
    [SerializeField] public Collision bullet_Collision_;
    [SerializeField] public Bullet_Sound Bullet_Sound_;
    [SerializeField] public Move bullet_Move_;
    [SerializeField] public Health bullet_Health_;
    [SerializeField] public Bullet_Config bullet_Config_;
    [SerializeField] public Direction bullet_Direction_;
    [SerializeField] public Color_General bullet_Color_;



    public static void Static_Create(Vector3 position, Quaternion rotation, Vector3 velocity, GameObject prefab, bool IsSoloCharged = false)
    {
        if (Bullet_Config.LimitBullet())
        {
            GameObject bulletInstance = Instantiate(prefab, position, rotation);
            Bullet_Main bullet = bulletInstance.GetComponent<Bullet_Main>();
            bullet.Init(velocity, IsSoloCharged);
        }
    }


    void Init(Vector2 velocity, bool IsSoloCharged = false)
    {
        bullet_Move_.Set(velocity);
        bullet_Direction_.SetDirection();
        bullet_Direction_.StartingRotation();
        Kill(4 * CONSTANTS.DEFSULT_BULLET_LIFE);
        bullet_Health_.AddToAction_OnDeath(Kill);
        Bullet_Config.SetBulletCount(Bullet_Config.GetBulletCount() + 1);
        bullet_Collision_.Congfigure_CollisionTables();
        bullet_Config_.Bullet_Speed();
        bullet_Config_.BulletColor();
        bullet_Controller_.Bullet_Configuration(IsSoloCharged);
        if (Bullet_Config.GetIsTypeCharged() || IsSoloCharged)
        {
            Bullet_Sound_.ChargedShot();
        }
        else
            Bullet_Sound_.PlayRandomSound();
    }

    void OnBecameInvisible()
    {
        Kill(CONSTANTS.DEFSULT_BULLET_LIFE);
    }
    void Update()
    {
        if (Bullet_Config.GetIsTypeMissle())
        {
            bullet_Controller_.Bullet_Missle_Controls();
        }
        if (Bullet_Config.GetIsStatUniformSpeed())
        {
            bullet_Config_.Bullet_Speed();
        }
        if (Bullet_Config.GetIsStatUniformSpeed())
        {
            bullet_Move_.SetCurrentSpeed(Bullet_Config.Get_StaticSpeed());
            bullet_Config_.BulletColor();
        }
        if (bullet_Config_.GetStillCharging())
        {
            Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDash(transform.position, spriterender_.color);
        }
    }
    void FixedUpdate()
    {
        if (bullet_Config_.Get_Bullet_Stat() == CONSTANTS.BULLET_STAT.ACCELARATE)
        {
            bullet_Move_.Moving_Accelarate();
        }
        bullet_Move_.Moving();



    }
    void OnDestroy()
    {
        if (!isDestroyed)
        {
            Bullet_Config.SetBulletCount(Bullet_Config.GetBulletCount() - 1);
            isDestroyed = true;
        }
        bullet_Config_.Bullet_Speed();
        bullet_Config_.BulletColor();

    }
}
