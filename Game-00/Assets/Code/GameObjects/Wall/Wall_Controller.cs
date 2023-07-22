using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Controller : Controller
{
    [SerializeField] public Wall_Main wall_Main_;


    public void Collision_With_Bullet(float damage = 1)
    {
        wall_Main_.wall_Health_.Damage(damage);
        for (int i = 0; i < damage; i++)
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
