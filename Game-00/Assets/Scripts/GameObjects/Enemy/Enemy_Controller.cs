using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] public Enemy_Main enemy_Main_;


    public void Movement()
    {
        enemy_Main_.enemy_Config_.Chaos();
        float x = enemy_Main_.enemy_Config_.Get_X();
        float y = enemy_Main_.enemy_Config_.Get_Y();
        enemy_Main_.enemy_Move_.Set(x, y);
        enemy_Main_.enemy_Direction_.SetDirection();
        enemy_Main_.enemy_Direction_.Turn();
    }
    public void Color()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        enemy_Main_.enemy_Color_.SetCurrentColor(randomColor);
        enemy_Main_.enemy_Color_.SetColor();
    }


}


