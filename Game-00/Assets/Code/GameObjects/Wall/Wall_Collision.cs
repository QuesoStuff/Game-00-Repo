using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Wall_Collision : Collision
{
    [SerializeField] public Wall_Main wall_Main_;

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == CONSTANTS_STRING.Bullet_Tag)
        {
            Bullet_Main bullet_Main = other.gameObject.GetComponent<Bullet_Main>();
            float bulletDamage = bullet_Main.bullet_Health_.Get_Damage();
            wall_Main_.wall_Controller_.Collision_With_Bullet(bulletDamage);
        }
        base.OnTriggerEnter2D(other);
    }
    public override void Congfigure_table_OnTriggerEnter2D()
    {
        if (table_OnTriggerEnter2D_ == null)
        {
            table_OnTriggerEnter2D_ = new Dictionary<string, Action>();
            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Bullet_Tag, wall_Main_.wall_Color_.WhiteFlash);
        }
    }
    public override void Congfigure_table_OnCollisionStay2D()
    {
        if (table_OnCollisionStay2D_ == null)
        {
            table_OnCollisionStay2D_ = new Dictionary<string, Action>();
            Add(ref table_OnCollisionStay2D_, CONSTANTS_STRING.Wall_Tag, wall_Main_.wall_Move_.FlipVelocity);
        }
    }

    public override void Congfigure_table_OnCollisionExit2D()
    {
        if (table_OnCollisionExit2D_ == null)
        {
            table_OnCollisionExit2D_ = new Dictionary<string, Action>();
            Add(ref table_OnCollisionExit2D_, CONSTANTS_STRING.Enemy_Tag, wall_Main_.wall_Controller_.Redirection);
        }
    }
}
