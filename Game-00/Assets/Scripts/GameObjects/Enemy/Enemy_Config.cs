using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Config : MonoBehaviour
{
    [SerializeField] public Enemy_Main enemy_Main_;

    private float x_, y_;
    [SerializeField] private Transform target_Transform_;
    [SerializeField] private float proxy_;
    private List<Func<bool>> methods;

    public void Config_Chaos()
    {
        methods = new List<Func<bool>>()
{
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
};
    }
    public void Chaos(Func<bool> conditionFunc)
    {
        if (conditionFunc())
        {
            x_ = (int)GENERIC.GetRandomNumberInRange(-1, 1);
            y_ = (int)GENERIC.GetRandomNumberInRange(-1, 1);
        }
        else
        {
            x_ = GENERIC.GetRandomNumberInRange(-1, 1);
            y_ = GENERIC.GetRandomNumberInRange(-1, 1);
        }

    }
    public void Chaos()
    {
        Func<bool> randomMethod = methods[UnityEngine.Random.Range(0, methods.Count)];
        Chaos(randomMethod);
    }

    public float Get_X()
    {
        return x_;
    }
    public float Get_Y()
    {
        return y_;
    }
}