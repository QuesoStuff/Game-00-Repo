using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Main : MonoBehaviour_Plus
{
    [SerializeField] internal Bullet_Controller bullet_Controller_;
    [SerializeField] internal Collision bullet_Collision_;
    [SerializeField] internal Bullet_Sound Bullet_Sound_;
    [SerializeField] internal Move Bullet_Move_;
    [SerializeField] internal Health Bullet_Health_;

    void Awake()
    {
        //Bullet_Controller.activeBulletCount_++;
    }
    void Start()
    {
        Destroy(this.gameObject, 4 * CONSTANTS.DEFSULT_BULLET_LIFE);
        bullet_Controller_.SetBulletCount(bullet_Controller_.GetBulletCount() + 1);
        bullet_Collision_.Congfigure_CollisionTables();

    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject, CONSTANTS.DEFSULT_BULLET_LIFE);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        Vector2 currSpeed = Bullet_Move_.Moving(50, 2);
        rb2d.velocity += currSpeed;
    }
    void OnDestroy()
    {
        //Bullet_Controller.activeBulletCount_--;
        if (bullet_Controller_.GetBulletCount() - 1 >= 0)
            bullet_Controller_.SetBulletCount(bullet_Controller_.GetBulletCount() - 1);

    }
}