using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour //, I_Move
{
    [SerializeField] public Rigidbody2D rb2d_;
    [SerializeField] private float normalSpeed_ = 5f;
    [SerializeField] private float maxSpeed_ = 10f;
    [SerializeField] private float lowestSpeed_ = 2.5f;
    [SerializeField] private float diagnolSpeed_ = 2.5f;
    [SerializeField] private float diagnolSlowSpeed_ = 1.25f;
    [SerializeField] private float diagnolFastSpeed_ = 5f;
    [SerializeField] private float dashSpeed_ = 25;
    [SerializeField] private float accelerate_Speed_ = 0;

    [SerializeField] private float currSpeed_;
    private float x_;
    private float y_;
    private Vector2 currVelocity_;
    [SerializeField] private float knockbackDuration_ = 1;
    [SerializeField] private float knockbackPower_ = 250;
    private Coroutine currCoroutine_;


    private float x_Previous_;
    private float y_Previous_;
    private Vector2 prevVelocity_;
    private float acceleratation_;
    private bool IsMoving_ = true;
    private bool CanDash_ = true;
    public bool GetIsMoving()
    {
        return IsMoving_;
    }
    public void SetCanDash(bool newValue)
    {
        CanDash_ = newValue;
    }

    public bool GetCanDash()
    {
        return CanDash_;
    }

    public void SetIsMoving(bool state)
    {
        IsMoving_ = state;
    }
    private bool isDashing_;
    public float GetNormalSpeed()
    {
        return maxSpeed_;
    }
    public float GetFastSpeed()
    {
        return lowestSpeed_;
    }
    public void SetCurrentSpeed(float newSpeed)
    {
        currSpeed_ = newSpeed;
    }
    public void SetIsDashing(bool newState)
    {
        isDashing_ = newState;
    }

    public bool GetIsDashing()
    {
        return isDashing_;
    }

    public Vector2 GetVelocity()
    {
        return new Vector2(x_, y_);
    }

    public float GetCurrSpeed()
    {
        return currSpeed_;
    }
    public float Get_AccelerateSpeed()
    {
        return accelerate_Speed_;
    }
    public void Set_AccelerateSpeed(float newAcc)
    {
        accelerate_Speed_ = newAcc;
    }
    public void Set(float x, float y)
    {
        x_Previous_ = this.x_;
        y_Previous_ = this.y_;

        this.x_ = x;
        this.y_ = y;

        SetVelocity();
    }
    public void Set(Vector2 velocity)
    {
        float x = velocity.x;
        float y = velocity.y;
        Set(x, y);
    }
    public void Set(float scale)
    {
        float x = x_ * scale;
        float y = y_ * scale;
        Set(x, y);
    }
    public void FlipVelocity()
    {
        Set(-1);
    }
    public void SetVelocity()
    {
        currVelocity_ = new Vector2(x_, y_);
        prevVelocity_ = new Vector2(x_Previous_, y_Previous_);
    }

    public void Move_Up()
    {
        Set(0f, currSpeed_);
    }

    public void Move_Down()
    {
        Set(0f, -currSpeed_);
    }

    public void Move_Left()
    {
        Set(-currSpeed_, 0f);
    }

    public void Move_Right()
    {
        Set(currSpeed_, 0f);
    }

    public void Move_None()
    {
        Set(0, 0);
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

    public Vector2 Moving(float scale)
    {
        Set(scale);
        SetVelocity();
        return GENERIC.Move_GameObject(x_, y_, rb2d_);
    }
    public Vector2 Moving()
    {
        SetVelocity();
        return GENERIC.Move_GameObject(x_, y_, rb2d_);
    }
    public Vector2 Moving_Accelarate()
    {
        return GENERIC.Accelerate_GameObject(x_, y_, rb2d_, accelerate_Speed_);
    }
    public Vector2 StopMoving()
    {
        SetVelocity();
        return GENERIC.Move_GameObject(0, 0, rb2d_);
    }




    public IEnumerator Dash(Action method = null, float DashDuration = CONSTANTS.DEFAULT_DASHING_TIME, float cooldownTime = 5)
    {
        StopMoveCoroutine();
        isDashing_ = true;
        CanDash_ = false;
        currCoroutine_ = StartCoroutine(StartDashCoroutine(DashDuration));
        yield return currCoroutine_;
        isDashing_ = false;
        yield return new WaitForSeconds(cooldownTime);
        CanDash_ = true;
        method?.Invoke();
        yield return null;
    }



    public IEnumerator StartDashCoroutine(float dashDuration = CONSTANTS.DEFAULT_DASHING_TIME)
    {
        float startTime = Time.time;
        float defaultSpeed = currSpeed_;
        currSpeed_ = dashSpeed_;
        while (UnityEngine.Time.time < startTime + dashDuration)
        {
            yield return null;
        }
        currSpeed_ = defaultSpeed;
        yield return null;
    }


    public IEnumerator KnockBack(Action method = null)
    {
        StopMoveCoroutine();
        IsMoving_ = false;
        currCoroutine_ = StartCoroutine(GENERIC.Knockback(rb2d_, knockbackPower_, knockbackDuration_));
        yield return currCoroutine_;
        IsMoving_ = true;
        method?.Invoke();
        yield return null;
    }

    public void Set_Random_Speed()
    {
        currSpeed_ = GENERIC.GetRandomNumberInRange((int)lowestSpeed_, (int)maxSpeed_);

    }

    public void StopMoveCoroutine()
    {
        GENERIC.StopCurrentCoroutine(this, ref currCoroutine_);
    }


    public void Turn_90_Right()
    {
        Vector2 turn = GENERIC.Turn_90(x_, y_);
        Set(turn);
    }
    public void Turn_90_Left()
    {
        Vector2 turn = GENERIC.Turn_90(x_, y_, -1);
        Set(turn);
    }
}