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
        if (other.tag == CONSTANTS_STRING.Bullet_Tag)
        {
            Bullet_Main bullet_Main = other.gameObject.GetComponent<Bullet_Main>();
            if (bullet_Main != null)
            {
                RandomDamageRotate_ = UnityEngine.Random.Range(0, 360);
                recoilRotate_ = UnityEngine.Random.Range(0, 5);
                float bulletDamage = bullet_Main.bullet_Health_.Get_Damage();
                enemy_Main_.enemy_Controller_.Collision_With_Bullet(bulletDamage);
                StartCoroutine(enemy_Main_.enemy_UI_.ShowHPChange(bulletDamage, false));
            }
        }
        base.OnTriggerEnter2D(other);
    }
    public override void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == CONSTANTS_STRING.Wall_Tag)
        {
            Wall_Main wall_Main = collision.gameObject.GetComponent<Wall_Main>();
            if (wall_Main == null) return;
            Color wallColor = wall_Main.wall_Color_.GetCurrentColor();
            enemy_Main_.enemy_Color_.SetColor(wallColor);
        }

        base.OnCollisionStay2D(collision);
    }
    public override void Congfigure_table_OnCollisionEnter2D()
    {
        if (table_OnCollisionEnter2D_ == null)
        {
            table_OnCollisionEnter2D_ = table_OnCollisionEnter2D_ = new Dictionary<string, Action>();
            Add(ref table_OnCollisionEnter2D_, CONSTANTS_STRING.Wall_Tag, enemy_Main_.enemy_Sound_.BumpIntoWall);
            Add(ref table_OnCollisionEnter2D_, CONSTANTS_STRING.Player_Tag, enemy_Main_.enemy_Config_.AssignMovement);
        }

    }

    public override void Congfigure_table_OnTriggerEnter2D()
    {
        if (table_OnTriggerEnter2D_ == null)
        {
            table_OnTriggerEnter2D_ = new Dictionary<string, Action>();
            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Bullet_Tag, enemy_Main_.enemy_Color_.WhiteFlash);
            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Bullet_Tag, () => enemy_Main_.enemy_Health_.Damage());
            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Bullet_Tag, enemy_Main_.enemy_Sound_.BumpIntoWall);
            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Bullet_Tag, () => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionHurt(transform.position, enemy_Main_.enemy_Color_.GetCurrentColor()));
            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Bullet_Tag, () => enemy_Main_.enemy_Controller_.SideRotate(RandomDamageRotate_));
        }
    }
    public override void Congfigure_table_OnTriggerExit2D()
    {
        if (table_OnTriggerExit2D_ == null)
        {
            table_OnTriggerExit2D_ = new Dictionary<string, Action>(); Add(ref table_OnTriggerExit2D_, CONSTANTS_STRING.Bullet_Tag, () => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDeath(transform.position));
            Add(ref table_OnTriggerExit2D_, CONSTANTS_STRING.Bullet_Tag, () => enemy_Main_.enemy_Controller_.SideRotate(-RandomDamageRotate_ + recoilRotate_));
        }


    }


}
