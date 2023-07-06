using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Main : MonoBehaviour_Plus
{

    [SerializeField] public Wall_Controller wall_Controller_;
    [SerializeField] public Collision wall_Collision_;
    [SerializeField] public Wall_Sound wall_Sound_;
    [SerializeField] public Move wall_Move_;
    [SerializeField] public Health wall_Health_;
    [SerializeField] public Wall_Config wall_Config_;
    [SerializeField] public Direction wall_Direction_;
    [SerializeField] public Color_General wall_Color_;

    void Awake()
    {


    }
    void Start()
    {
        wall_Config_.Config_Init();
        wall_Controller_.ConfigureWall();
        wall_Collision_.Congfigure_CollisionTables();
        wall_Color_.SetCurrentColor(spriterender_.color);
        wall_Health_.AddToAction_OnDeath(() => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDeath(transform.position, spriterender_.color));
        wall_Health_.AddToAction_OnDeath(() => Kill());

        void Update()
        {

            // rest of Update code...
        }

        void FixedUpdate()
        {
            if (wall_Config_.GetIsMoving())
            {
                wall_Move_.Moving();
                wall_Move_.Moving_Accelarate();
            }

        }
    }
}
