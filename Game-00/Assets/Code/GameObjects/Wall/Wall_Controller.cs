using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Controller : MonoBehaviour
{
    [SerializeField] public Wall_Main wall_Main_;


    public void Collision_With_Bullet(float damage = 1)
    {
        if (wall_Main_.wall_Config_.GetIsBreakable())
        {
            wall_Main_.wall_Health_.Damage(damage);
            for (int i = 0; i < damage; i++)
                wall_Main_.wall_Color_.SetNextColor();
        }

    }
    public void ConfigureWall(float hp = 3, float speed = 2.3f, float acc = 0)
    {
        if (wall_Main_.wall_Config_.GetIsNormal())
        {
            wall_Main_.StopMain();
            return;
        }
        if (wall_Main_.wall_Config_.GetIsMoving())
        {
            if (GENERIC.CoinToss(40, 60))
                acc = 0.3f;
            wall_Main_.wall_Move_.SetCurrentSpeed(speed);
            wall_Main_.wall_Move_.Set_AccelerateSpeed(acc);
            wall_Main_.wall_Move_.Set(speed * Direction.GenerateRandomDirection());
        }
        if (wall_Main_.wall_Config_.GetIsBreakable())
        {
            wall_Main_.wall_Health_.Set_HP(hp);
            wall_Main_.wall_Health_.AddToAction_OnDeath(() => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDeath(transform.position, Color.white));
            wall_Main_.wall_Health_.AddToAction_OnDeath(() => wall_Main_.Kill());
        }
        ConfigColor(hp = 3);

    }
    public void ConfigColor(float hp = 3)
    {
        Color start = GENERIC.HexToColor("EE9595");
        Color end = GENERIC.HexToColor("661A20");
        wall_Main_.wall_Color_.color_Range_ = new ColorRange(start, end, (int)hp);
        wall_Main_.wall_Color_.SetNextColor();
    }

    public void Redirection()
    {
        bool chance = GENERIC.CoinToss(70, 30);
        if (chance)
            wall_Main_.wall_Move_.FlipVelocity();
        else
        {
            chance = GENERIC.CoinToss(50, 50);
            if (chance)
                wall_Main_.wall_Move_.Turn_90_Right();
            else
                wall_Main_.wall_Move_.Turn_90_Left();
        }
    }
}
