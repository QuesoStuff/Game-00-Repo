using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Collision : Collision
{
    [SerializeField] public Bullet_Main bullet_Main_;
    [SerializeField] private bool inside_ = false;


    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        bullet_Main_.bullet_Color_.SetColorBlank();
        bullet_Main_.bullet_Health_.Damage();

    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        bullet_Main_.bullet_Color_.SetColor();
        Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionBullet(transform.position, bullet_Main_.spriterender_.color);
        inside_ = false;
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
        Add(table_OnTriggerEnter2D_, CONSTANTS.Wall_Tag, Player_Main.instance_.player_Sound_.BumpIntoWall);

        Add(table_OnTriggerEnter2D_, CONSTANTS.Wall_Tag, () => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionBullet(transform.position, bullet_Main_.spriterender_.color));
        Add(table_OnTriggerEnter2D_, CONSTANTS.Door_Tag, () => bullet_Main_.bullet_Health_.Heal());
        Add(table_OnTriggerEnter2D_, CONSTANTS.Door_Exit_Tag, () => bullet_Main_.bullet_Health_.Heal());

        Add(table_OnTriggerEnter2D_, CONSTANTS.Door_Tag, bullet_Main_.bullet_Move_.FlipVelocity);
        Add(table_OnTriggerEnter2D_, CONSTANTS.Door_Tag, bullet_Main_.bullet_Direction_.SetDirection);
        Add(table_OnTriggerEnter2D_, CONSTANTS.Player_Tag, () => bullet_Main_.bullet_Health_.Heal());

    }

    public override void Congfigure_table_OnTriggerStay2D()
    {
        Add(table_OnTriggerStay2D_, CONSTANTS.Wall_Tag, bullet_Main_.bullet_Color_.SetColorBlank);

    }
}
