using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Main : Main
{
    [SerializeField] public Bullet_Controller bullet_Controller_;
    [SerializeField] public Collision bullet_Collision_;
    [SerializeField] public Bullet_Sound Bullet_Sound_;
    [SerializeField] public MovePlus bullet_Move_;
    [SerializeField] public Health bullet_Health_;
    [SerializeField] public Bullet_Config bullet_Config_;
    [SerializeField] public Direction bullet_Direction_;
    [SerializeField] public Color_General bullet_Color_;

    public static GameObject Static_Create(Vector3 position, Quaternion rotation, Vector3 direction, GameObject prefab, bool IsSoloCharged = false)
    {
        GameObject bulletInstance = null;

        bulletInstance = Instantiate(prefab, position, rotation);
        Bullet_Config bullet_Config = bulletInstance.GetComponent<Bullet_Config>();
        bullet_Config.ConfigureBullet(direction, IsSoloCharged);

        return bulletInstance;
    }



    void OnBecameInvisible()
    {
        this.DelayMethod(CONSTANTS.DEFAULT_OFFSCREEN_BULLET_LIFETIME_ADJUSTMENT, bullet_Config_.Config_OnDeath);
    }
    void Awake()
    {
        SetComponents();
        bullet_Controller_.SetComponents();
    }
    void Update()
    {
        bullet_Controller_.Controller_Missile();

        bullet_Controller_.Controller_Uniform();

        bullet_Controller_.Controller_ChargingBullet();

    }

    void FixedUpdate()
    {
        bullet_Move_.Moving();
        bullet_Move_.Moving_Accelarate();
    }



    public override void SetComponents()
    {
        bullet_Controller_ = GetComponent<Bullet_Controller>();
        bullet_Collision_ = GetComponent<Collision>();
        Bullet_Sound_ = GetComponent<Bullet_Sound>();
        bullet_Move_ = GetComponent<MovePlus>();
        bullet_Health_ = GetComponent<Health>();
        bullet_Config_ = GetComponent<Bullet_Config>();
        bullet_Direction_ = GetComponent<Direction>();
        bullet_Color_ = GetComponent<Color_General>();
    }
}
