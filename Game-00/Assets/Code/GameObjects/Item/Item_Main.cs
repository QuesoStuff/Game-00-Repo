using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Main : MonoBehaviour_Plus
{


    [SerializeField] public Item_Controller item_Controller_;
    [SerializeField] public Collision item_Collision_;
    [SerializeField] public Item_Sound item_Sound_;
    [SerializeField] public Move item_Move_;
    [SerializeField] public Health item_Health_;
    [SerializeField] public Item_Config item_Config_;
    [SerializeField] public Direction item_Direction_;
    [SerializeField] public Color_General item_Color_;




    void Awake()
    {
    }


    void Start()
    {
        //item_Health_.AddToAction_OnDeath(() => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDeath_Item(transform.position, spriterender_.color));

        item_Health_.AddToAction_OnDeath(() => Kill());
        item_Collision_.Congfigure_CollisionTables();
        item_Config_.Config_Init();
        ConfigStartRotate();
        ConfigRotateSpeed();
        SideRotate(currRotateAngle_);
        item_Color_.SetCurrentColor(spriterender_.color);

    }

    void Update()
    {
        Rotate(currRotationSpeed_);
    }
}
