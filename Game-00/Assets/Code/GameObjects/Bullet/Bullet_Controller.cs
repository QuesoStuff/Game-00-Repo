using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : Controller
{
    [SerializeField] public Bullet_Main bullet_Main_;




    public void Bullet_Missle_Controls()
    {
        bool move = INPUT.Input_Move_Any();
        if (INPUT.Input_Tap_Up())
        {
            bullet_Main_.bullet_Move_.Move_Up();
        }
        else if (INPUT.Input_Tap_Down())
        {
            bullet_Main_.bullet_Move_.Move_Down();
        }
        else if (INPUT.Input_Tap_Left())
        {
            bullet_Main_.bullet_Move_.Move_Left();
        }
        else if (INPUT.Input_Tap_Right())
        {
            bullet_Main_.bullet_Move_.Move_Right();
        }
        if (move)
        {
            bullet_Main_.bullet_Direction_.SetDirection();
            bool newDireciont = bullet_Main_.bullet_Direction_.Turn();
            Vector3 offset = Offset(-bullet_Main_.bullet_Direction_.GetDirection());
            if (newDireciont)
                Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionHurt(transform.position + offset);
        }
    }
    public void Controller_Missile()
    {
        if (ActiveItems.GetIsTypeMissle())
        {
            Bullet_Missle_Controls();
        }
    }
    public void Controller_Uniform()
    {
        if (ActiveItems.GetIsStatUniformSpeed())
        {
            bullet_Main_.bullet_Config_.BulletConfigurate_Extra_UniformSpeed();
        }
    }

    public void Controller_ChargingBullet()
    {
        if (bullet_Main_.bullet_Config_.GetStillCharging())
        {
            Vector3 offset = bullet_Main_.bullet_Controller_.Offset(-bullet_Main_.bullet_Direction_.GetDirection());
            Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionHurt(transform.position + offset, spriterender_.color);

            // we start spawning
            if (!isAlreadyDashing_) // we start spawning
            {
                isAlreadyDashing_ = true;
                StartCoroutine(DashAndSpawn(() =>
                {
                    Vector3 offset = Offset(-bullet_Main_.bullet_Direction_.GetDirection());
                    Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionHurt(transform.position + offset, spriterender_.color);
                }));
            }
        }
        else
        {
            isAlreadyDashing_ = false; // we stop spawning
        }
        if (bullet_Main_.bullet_Config_.GetDoneCharging())
        {
            if (ActiveItems.GetIsTypeLazer())
            {
                Vector3 offset = Offset(-bullet_Main_.bullet_Direction_.GetDirection());
                Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionHurt(transform.position + offset, spriterender_.color);
            }
            else
                Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDeath(transform.position, spriterender_.color);
        }
    }

    public override Vector3 Offset(Vector2 direction)
    {
        // Assuming the scale is uniform, use x or y size of the sprite's bounds as the "radius"
        float bulletRadius = spriterender_.sprite.bounds.size.x * transform.localScale.x / 2;
        Vector3 offset = direction.normalized * bulletRadius;
        return offset;
    }

}
