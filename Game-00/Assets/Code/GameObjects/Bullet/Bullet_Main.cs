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


    public static void Static_Create(Vector3 position, Quaternion rotation, Vector3 directoin, GameObject prefab, bool IsSoloCharged = false)
    {
        if (Bullet_Config.LimitBullet(IsSoloCharged))
        {
            GameObject bulletInstance = Instantiate(prefab, position, rotation);
            Bullet_Main bullet = bulletInstance.GetComponent<Bullet_Main>();
            bullet.Init(directoin, IsSoloCharged);
        }
    }


    void Init(Vector2 direction, bool IsSoloCharged = false)
    {
        if (direction == Vector2.zero)
            direction = Direction.GenerateRandomDirection();
        bullet_Move_.Set(direction);
        bullet_Direction_.SetDirection();
        bullet_Direction_.StartingRotation();
        Kill(4 * CONSTANTS.DEFSULT_BULLET_LIFE);
        bullet_Health_.AddToAction_OnDeath(() => Kill());
        Bullet_Config.SetBulletCount(Bullet_Config.GetBulletCount() + 1);
        bullet_Color_.color_Range_ = new ColorRange(Color.green, Color.red, 5);
        Bullet_Config.colorRange_ = new CollectionRange<int, Color>(new List<int> { 1, 3, 7, 11 }, bullet_Color_.color_Range_.GetColors());
        Bullet_Config.speedRange_ = new CollectionRange<int, float>(new List<int> { 1, 3, 7, 11 }, new List<float> { 5f, 1, 0.5f, 0.25f });
        bullet_Collision_.Congfigure_CollisionTables();
        bullet_Controller_.Bullet_Configuration(IsSoloCharged);
        bullet_Config_.Bullet_Speed();
        bullet_Config_.BulletColor();
        bullet_Color_.SetCurrentColor(spriterender_.color);
        bullet_Config_.BulletConfigurate_Audio(IsSoloCharged);
        bullet_Move_.Set(bullet_Config_.GetCurrBulletSpeedMod());
        bullet_Move_.Set_AccelerateSpeed(bullet_Config_.GetCurrBulletAccelerate());

    }

    public override Vector3 Offset(Vector2 direction)
    {
        // Assuming the scale is uniform, use x or y size of the sprite's bounds as the "radius"
        float bulletRadius = spriterender_.sprite.bounds.size.x * transform.localScale.x / 2;
        Vector3 offset = direction.normalized * bulletRadius;
        return offset;
    }

    void OnBecameInvisible()
    {
        Kill(CONSTANTS.DEFSULT_BULLET_LIFE);
    }
    void Update()
    {
        if (ACTIVE.GetIsTypeMissle())
        {
            bullet_Controller_.Bullet_Missle_Controls();
        }
        if (ACTIVE.GetIsStatUniformSpeed())
        {
            bullet_Config_.BulletConfigurate_Extra_UniformSpeed();
        }
        if (bullet_Config_.GetStillCharging())
        {
            Vector3 offset = Offset(-bullet_Direction_.GetDirection());
            Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionHurt(transform.position + offset, spriterender_.color);
        }
        if (bullet_Config_.GetDoneCharging())
        {
            if (ACTIVE.GetIsTypeLazer())
            {
                Vector3 offset = Offset(-bullet_Direction_.GetDirection());
                Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionHurt(transform.position + offset, spriterender_.color);
            }
            else
                Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDeath(transform.position, spriterender_.color);
        }
    }
    void FixedUpdate()
    {
        bullet_Move_.Moving();
        bullet_Move_.Moving_Accelarate();
    }
    void OnDestroy()
    {
        Bullet_Config.SetBulletCount(Bullet_Config.GetBulletCount() - 1);
    }
}
