using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet_Collision : Collision
{
    [SerializeField] public Bullet_Main bullet_Main_;
    [SerializeField] private bool inside_ = false;


    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != CONSTANTS_STRING.Player_Tag && other.tag != CONSTANTS_STRING.Bullet_Tag)
        {
            base.OnTriggerEnter2D(other);
            bullet_Main_.bullet_Color_.SetColorBlank();
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag != CONSTANTS_STRING.Player_Tag && other.tag != CONSTANTS_STRING.Bullet_Tag)
        {
            base.OnTriggerExit2D(other);
            bullet_Main_.bullet_Color_.SetColor();
            Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionBullet(transform.position, bullet_Main_.bullet_Color_.GetCurrentColor());
            inside_ = false;
        }
    }
    public override void OnTriggerStay2D(Collider2D other)
    {
        if (!inside_)
        {
            base.OnTriggerStay2D(other);
            inside_ = true;
        }
    }

    public override void Congfigure_table_OnTriggerEnter2D()
    {
        if (table_OnTriggerEnter2D_ == null)
        {
            table_OnTriggerEnter2D_ = new Dictionary<string, Action>();
            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Wall_Tag, Player_Main.instance_.player_Sound_.BumpIntoWall);

            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Wall_Tag, () => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionBullet(transform.position, bullet_Main_.bullet_Color_.GetCurrentColor()));
            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Door_Tag, () => bullet_Main_.bullet_Health_.Heal());
            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Door_Exit_Tag, () => bullet_Main_.bullet_Health_.Heal());

            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Door_Tag, bullet_Main_.bullet_Move_.FlipVelocity);
            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Door_Tag, bullet_Main_.bullet_Direction_.SetDirection);
        }
    }

    public override void Congfigure_table_OnTriggerStay2D()
    {
        if (table_OnTriggerStay2D_ == null)
        {
            table_OnTriggerStay2D_ = new Dictionary<string, Action>();
            Add(ref table_OnTriggerStay2D_, CONSTANTS_STRING.Wall_Tag, bullet_Main_.bullet_Color_.SetColorBlank);
        }
    }
}
