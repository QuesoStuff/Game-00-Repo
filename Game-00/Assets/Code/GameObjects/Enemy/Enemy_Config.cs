using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy_Config : MonoBehaviour
{
    [SerializeField] public Enemy_Main enemy_Main_;
    private Vector2 currInput_;
    protected List<Func<bool>> methods_ = new List<Func<bool>>();
    private List<Vector2> inputPairs_ = new List<Vector2>();


    public abstract void ConfigureMethods();


    public virtual void AssignMovement()
    {
        inputPairs_ = new List<Vector2>(methods_.Count);
        foreach (var _ in methods_)
        {
            System.Random rand = new System.Random();
            float x = rand.Next(-1, 2);
            float y;

            if (x == 0)
            {
                // If x is 0, y can be either -1 or 1, but not 0.
                int randomValue = rand.Next(2);
                if (randomValue == 0)
                {
                    y = -1;
                }
                else
                {
                    y = 1;
                }
            }
            else
            {
                // If x is not 0, y can be -1, 0 or 1.
                y = rand.Next(-1, 2);
            }

            inputPairs_.Add(new Vector2(x, y));
        }
    }


    public void InputValid()
    {
        currInput_ = Vector2.zero;
        for (int i = 0; i < methods_.Count; i++)
        {
            if (methods_[i]())
            {
                currInput_ = inputPairs_[i];
                break;
            }
        }
    }

    public Vector2 Get_Input()
    {
        return currInput_;
    }

    public void Config_Color()
    {
        int hp = (int)enemy_Main_.enemy_Health_.GetCurrHP();
        Color randomColor = GENERIC.RandomColor();
        enemy_Main_.enemy_Color_.color_Range_ = new ColorRange(randomColor, Color.white, (int)hp);
        enemy_Main_.enemy_Color_.SetNextColor();
    }




}
