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

    private bool isDestroyed = false;

    public static void Static_Create(Vector3 position, Quaternion rotation, Vector3 velocity, GameObject prefab)
    {
        if (Bullet_Config.LimitBullet())
        {
            GameObject bulletInstance = Instantiate(prefab, position, rotation);
            Bullet_Main bullet = bulletInstance.GetComponent<Bullet_Main>();
            bullet.Init(velocity);
        }
    }


    void Init(Vector2 velocity)
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
        bullet_Controller_.Bullet_Configuration();
    }

    void OnBecameInvisible()
    {
        Kill(CONSTANTS.DEFSULT_BULLET_LIFE);
    }
    // Update is called once per frame
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

        // recalc the uni speed here once you have the varialbes set 
    }
}
