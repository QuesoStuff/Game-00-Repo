using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] public Enemy_Main enemy_Main_;

    public IEnumerator InvokeMovement(float timeDelay = 5)
    {
        while (true)
        {
            Randomize();
            yield return new WaitForSeconds(timeDelay);
        }
    }

    public void Collision_With_Bullet(float damage = 1)
    {
        enemy_Main_.enemy_Health_.Damage(damage);
        for (int i = 0; i < damage; i++)
            enemy_Main_.enemy_Color_.SetNextColor();
    }
    public void UpdateMovement()
    {
        enemy_Main_.enemy_Config_.InputValid();
        Vector2 direction = enemy_Main_.enemy_Config_.Get_Input();
        float speed = enemy_Main_.enemy_Move_.GetCurrSpeed();
        enemy_Main_.enemy_Move_.Set(speed * direction);
    }
    public void Randomize()
    {
        enemy_Main_.enemy_Config_.AssignMovement();
        enemy_Main_.enemy_Direction_.SetDirection();
    }

    public void EventTrigger_FrozenEnemyColor(bool isFrozen)
    {
        if (isFrozen)
        {
            enemy_Main_.enemy_Color_.SetColor(Color.white);
        }
        else
        {
            enemy_Main_.enemy_Color_.SetColor();
        }
    }
}


