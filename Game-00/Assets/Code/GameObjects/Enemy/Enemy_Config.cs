using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Config : MonoBehaviour
{
    [SerializeField] public Enemy_Main enemy_Main_;

    [SerializeField] private Vector2 currInput_;

    [SerializeField] private Transform target_Transform_;
    [SerializeField] private float proxy_;
    private List<Func<bool>> methods_;
    private HashSet<Func<bool>> currMethod_ = new HashSet<Func<bool>>();
    [SerializeField] private int currMethodCount_ = 4;

    private List<Vector2> inputPairs_;

    public void Config_Chaos()
    {
        methods_ = new List<Func<bool>>()
        {
            INPUT.instance_.Input_Move_Up,
            INPUT.instance_.Input_Move_Down,
            INPUT.instance_.Input_Move_Left,
            INPUT.instance_.Input_Move_Right,
            // ... rest of the methods
                /*
    INPUT.instance_.Input_Tap_Up,
    INPUT.instance_.Input_Tap_Down,
    INPUT.instance_.Input_Tap_Left,
    INPUT.instance_.Input_Tap_Right,
    INPUT.instance_.Input_Move_Up,
    INPUT.instance_.Input_Move_Down,
    INPUT.instance_.Input_Move_Left,
    INPUT.instance_.Input_Move_Right,
    INPUT.instance_.Input_Move_Up_Stop,
    INPUT.instance_.Input_Move_Down_Stop,
    INPUT.instance_.Input_Move_Left_Stop,
    INPUT.instance_.Input_Move_Right_Stop,
    INPUT.instance_.Input_Trigger_Pulled,
    INPUT.instance_.Input_Trigger_Release,
    INPUT.instance_.Input_Trigger_Rapid,
    INPUT.instance_.Input_Idle,
    INPUT.instance_.Input_Dash_Move,
    INPUT.instance_.Input_Shot_Rapid,
    INPUT.instance_.Input_Shot_Charged,
    INPUT.instance_.Input_Charged_Valid,
    INPUT.instance_.Input_Pause_Resume
    */
        };

        inputPairs_ = new List<Vector2>(methods_.Count);
        foreach (var _ in methods_)
        {
            System.Random rand = new System.Random();
            float x = rand.Next(-1, 2);
            float y;
            if (x == 0)
            {
                y = rand.Next(2) * 2 - 1;
            }
            else
            {
                int weightedRand = rand.Next(100);

                if (weightedRand < 10)
                {
                    y = 0;
                }
                else if (weightedRand < 55)
                {
                    y = 1;
                }
                else
                {
                    y = -1;
                }
            }
            inputPairs_.Add(new Vector2(x, y));
        }
    }

    public void Chaos_Update()
    {
        currInput_ = Vector2.zero;
        foreach (var method in currMethod_)
        {
            if (method())
            {
                int index = methods_.IndexOf(method);
                currInput_ = inputPairs_[index];
                break;
            }
        }
        enemy_Main_.enemy_Move_.Set(currInput_.x, currInput_.y);
    }

    public void SetCurrMethods()
    {
        currMethod_.Clear();

        while (currMethod_.Count < currMethodCount_)
        {
            var randomMethod = methods_[UnityEngine.Random.Range(0, methods_.Count)];
            currMethod_.Add(randomMethod);
        }
    }

    public Vector2 Get_Input()
    {
        return currInput_;
    }
}



