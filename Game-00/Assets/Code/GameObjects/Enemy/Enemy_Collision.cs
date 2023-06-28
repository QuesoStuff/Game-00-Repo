using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Collision : Collision
{
    [SerializeField] public Enemy_Main enemy_Main_;


    public override void Congfigure_table_OnCollisionEnter2D()
    {
        Add(table_OnCollisionEnter2D_, CONSTANTS.Wall_Tag, enemy_Main_.enemy_Sound_.BumpIntoWall);
        //Add(table_OnCollisionEnter2D_, CONSTANTS.Player_Tag, enemy_Main_.enemy_Move_.KnockBack);
        Add(table_OnCollisionEnter2D_, CONSTANTS.Player_Tag, enemy_Main_.enemy_Config_.SetCurrMethods);

    }

    public override void Congfigure_table_OnTriggerEnter2D()
    {
        Add(table_OnTriggerEnter2D_, CONSTANTS.Bullet_Tag, enemy_Main_.enemy_Color_.HoldColor);
        Add(table_OnTriggerEnter2D_, CONSTANTS.Bullet_Tag, enemy_Main_.enemy_Health_.Damage);
        Add(table_OnTriggerEnter2D_, CONSTANTS.Bullet_Tag, enemy_Main_.enemy_Sound_.BumpIntoWall);
        Add(table_OnTriggerEnter2D_, CONSTANTS.Bullet_Tag, () => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionHurt(transform.position, enemy_Main_.spriterender_.color));

    }


}
