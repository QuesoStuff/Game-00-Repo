using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Collision : Collision
{
    [SerializeField] public Bullet_Main bullet_Main_;


    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.Lookup_OnTriggerEnter2D(other.gameObject);
        bullet_Main_.bullet_Color_.SetColorBlank();
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        base.Lookup_OnTriggerExit2D(other.gameObject);
        bullet_Main_.bullet_Color_.SetColor();

    }
    public override void Congfigure_table_OnTriggerEnter2D()
    {
        Add(table_OnTriggerEnter2D_, CONSTANTS.Wall_Tag, Player_Main.instance_.player_Sound_.BumpIntoWall);
        Add(table_OnTriggerEnter2D_, CONSTANTS.Wall_Tag, bullet_Main_.bullet_Health_.Damage);
        Add(table_OnTriggerEnter2D_, CONSTANTS.Wall_Tag, () => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionBullet(transform.position, bullet_Main_.spriterender_.color));

    }

    public override void Congfigure_table_OnTriggerExit2D()
    {
        Add(table_OnTriggerExit2D_, CONSTANTS.Wall_Tag, () => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionBullet(transform.position, bullet_Main_.spriterender_.color));
        Add(table_OnTriggerExit2D_, CONSTANTS.Enemy_Tag, () => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionBullet(transform.position, bullet_Main_.spriterender_.color));
        Add(table_OnTriggerExit2D_, CONSTANTS.Player_Tag, () => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionBullet(transform.position, Player_Main.instance_.spriterender_.color));


    }
}
