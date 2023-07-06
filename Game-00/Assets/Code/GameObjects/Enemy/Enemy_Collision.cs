using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Collision : Collision
{
    [SerializeField] public Enemy_Main enemy_Main_;
    private float RandomDamageRotate_;
    private float recoilRotate_;



    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == CONSTANTS.Bullet_Tag)
        {
            Bullet_Main bullet_Main = other.gameObject.GetComponent<Bullet_Main>();
            if (bullet_Main == null) return;
            RandomDamageRotate_ = UnityEngine.Random.Range(0, 360);
            recoilRotate_ = UnityEngine.Random.Range(0, 5);
            float bulletDamage = bullet_Main.bullet_Health_.Get_Damage();
            enemy_Main_.enemy_Controller_.Collision_With_Bullet(bulletDamage);
            enemy_Main_.enemy_UI_.ShowHPChange(bulletDamage);
        }
        base.OnTriggerEnter2D(other);
    }
    public override void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == CONSTANTS.Wall_Tag)
        {
            Wall_Main wall_Main = other.gameObject.GetComponent<Wall_Main>();
            if (wall_Main == null) return;
            Color wallColor = wall_Main.spriterender_.color;
            enemy_Main_.enemy_Color_.SetColor(wallColor);
        }

        base.OnCollisionStay2D(other);
    }
    public override void Congfigure_table_OnCollisionEnter2D()
    {
        Add(table_OnCollisionEnter2D_, CONSTANTS.Wall_Tag, enemy_Main_.enemy_Sound_.BumpIntoWall);
        Add(table_OnCollisionEnter2D_, CONSTANTS.Player_Tag, enemy_Main_.enemy_Config_.AssignMovement);

    }

    public override void Congfigure_table_OnTriggerEnter2D()
    {
        Add(table_OnTriggerEnter2D_, CONSTANTS.Bullet_Tag, enemy_Main_.enemy_Color_.WhiteFlash);
        Add(table_OnTriggerEnter2D_, CONSTANTS.Bullet_Tag, () => enemy_Main_.enemy_Health_.Damage());
        Add(table_OnTriggerEnter2D_, CONSTANTS.Bullet_Tag, enemy_Main_.enemy_Sound_.BumpIntoWall);
        Add(table_OnTriggerEnter2D_, CONSTANTS.Bullet_Tag, () => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionHurt(transform.position, enemy_Main_.spriterender_.color));
        Add(table_OnTriggerEnter2D_, CONSTANTS.Bullet_Tag, () => enemy_Main_.SideRotate(RandomDamageRotate_));

    }
    public override void Congfigure_table_OnTriggerExit2D()
    {
        Add(table_OnTriggerExit2D_, CONSTANTS.Bullet_Tag, () => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDeath(transform.position));
        Add(table_OnTriggerExit2D_, CONSTANTS.Bullet_Tag, () => enemy_Main_.SideRotate(-RandomDamageRotate_ + recoilRotate_));



    }


}
