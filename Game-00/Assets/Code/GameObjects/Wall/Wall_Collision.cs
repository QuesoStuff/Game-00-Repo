using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Collision : Collision
{
    [SerializeField] public Wall_Main wall_Main_;

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == CONSTANTS.Bullet_Tag)
        {
            Bullet_Main bullet_Main = other.gameObject.GetComponent<Bullet_Main>();
            float bulletDamage = bullet_Main.bullet_Health_.Get_Damage();
            wall_Main_.wall_Controller_.Collision_With_Bullet(bulletDamage);
        }
        base.OnTriggerEnter2D(other);
    }
    public override void Congfigure_table_OnTriggerEnter2D()
    {
        Add(table_OnTriggerEnter2D_, CONSTANTS.Bullet_Tag, wall_Main_.wall_Color_.WhiteFlash);
    }
    public override void Congfigure_table_OnCollisionStay2D()
    {
        Add(table_OnCollisionStay2D_, CONSTANTS.Wall_Tag, wall_Main_.wall_Move_.FlipVelocity);
    }

    public override void Congfigure_table_OnCollisionExit2D()
    {
        Add(table_OnCollisionExit2D_, CONSTANTS.Enemy_Tag, wall_Main_.wall_Controller_.Redirection);
        //Add(table_OnCollisionExit2D_, CONSTANTS.Enemy_Tag, wall_Main_.ToggleSprite);
    }
}
