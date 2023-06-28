using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] public Enemy_Main enemy_Main_;


    public void Color()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        enemy_Main_.enemy_Color_.SetCurrentColor(randomColor);
        enemy_Main_.enemy_Color_.SetColor();
    }

    public void UpdateMovement()
    {
        enemy_Main_.enemy_Config_.Chaos_Update();
        Vector2 direction = enemy_Main_.enemy_Config_.Get_Input();
        enemy_Main_.enemy_Move_.Set(direction);
    }
    public void Randomize()
    {
        enemy_Main_.enemy_Config_.SetCurrMethods();
        enemy_Main_.enemy_Config_.Config_Chaos();
        enemy_Main_.enemy_Move_.Set_Random_Speed();
        enemy_Main_.enemy_Direction_.SetDirection();
        enemy_Main_.enemy_Direction_.Turn();
    }


}


