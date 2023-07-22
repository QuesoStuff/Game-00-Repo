using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlus : Move
{
    [SerializeField] private float normalSpeed_ = CONSTANTS.DEFAULT_SPEED;
    [SerializeField] private float maxSpeed_ = CONSTANTS.DEFAULT_SPEED_FAST;
    [SerializeField] private float lowestSpeed_ = CONSTANTS.DEFAULT_SPEED_SLOW;
    [SerializeField] private float diagnolSpeed_;
    [SerializeField] private float diagnolSlowSpeed_;
    [SerializeField] private float diagnolFastSpeed_;
    [SerializeField] private float accelerate_Speed_ = CONSTANTS.DEFAULT_SPEED_ACC;


    public float GetNormalSpeed()
    {
        return maxSpeed_;
    }
    public float GetFastSpeed()
    {
        return lowestSpeed_;
    }

    public float Get_AccelerateSpeed()
    {
        return accelerate_Speed_;
    }
    public void Set_AccelerateSpeed(float newAcc)
    {
        accelerate_Speed_ = newAcc;
    }

    public void Move_Up_Slow()
    {
        Set(0f, lowestSpeed_);
    }

    public void Move_Down_Slow()
    {
        Set(0f, -lowestSpeed_);
    }

    public void Move_Left_Slow()
    {
        Set(-lowestSpeed_, 0f);
    }

    public void Move_Right_Slow()
    {
        Set(lowestSpeed_, 0f);
    }

    public void Move_Up_Normal()
    {
        Set(0f, normalSpeed_);
    }

    public void Move_Down_Normal()
    {
        Set(0f, -normalSpeed_);
    }

    public void Move_Left_Normal()
    {
        Set(-normalSpeed_, 0f);
    }

    public void Move_Right_Normal()
    {
        Set(normalSpeed_, 0f);
    }

    public void Move_Up_Fast()
    {
        Set(0f, maxSpeed_);
    }

    public void Move_Down_Fast()
    {
        Set(0f, -maxSpeed_);
    }

    public void Move_Left_Fast()
    {
        Set(-maxSpeed_, 0f);
    }

    public void Move_Right_Fast()
    {
        Set(maxSpeed_, 0f);
    }

    public void Move_45()
    {
        Set(diagnolSpeed_, diagnolSpeed_);
    }

    public void Move_135()
    {
        Set(diagnolSpeed_, -diagnolSpeed_);
    }

    public void Move_225()
    {
        Set(-diagnolSpeed_, -diagnolSpeed_);
    }

    public void Move_315()
    {
        Set(-diagnolSpeed_, diagnolSpeed_);
    }

    public void Move_45_Slow()
    {
        Set(diagnolSlowSpeed_, diagnolSlowSpeed_);
    }

    public void Move_135_Slow()
    {
        Set(diagnolSlowSpeed_, -diagnolSlowSpeed_);
    }

    public void Move_225_Slow()
    {
        Set(-diagnolSlowSpeed_, -diagnolSlowSpeed_);
    }

    public void Move_315_Slow()
    {
        Set(-diagnolSlowSpeed_, diagnolSlowSpeed_);
    }

    public void Move_45_Fast()
    {
        Set(diagnolFastSpeed_, diagnolFastSpeed_);
    }

    public void Move_135_Fast()
    {
        Set(diagnolFastSpeed_, -diagnolFastSpeed_);
    }

    public void Move_225_Fast()
    {
        Set(-diagnolFastSpeed_, -diagnolFastSpeed_);
    }

    public void Move_315_Fast()
    {
        Set(-diagnolFastSpeed_, diagnolFastSpeed_);
    }


    public Vector2 Moving_Accelarate()
    {
        return GENERIC.Accelerate_GameObject(x_, y_, rb2d_, accelerate_Speed_);
    }

    public void Set_Random_Speed()
    {
        currSpeed_ = GENERIC.GetRandomNumberInRange((int)lowestSpeed_, (int)maxSpeed_);

    }

}