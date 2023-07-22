using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour //, I_Move Mathf.Sqrt(2);
{
    [SerializeField] public Rigidbody2D rb2d_;
    [SerializeField] protected float currSpeed_;
    protected float x_;
    protected float y_;
    protected Vector2 currVelocity_;
    [SerializeField] protected float knockbackDuration_ = CONSTANTS.DEFAULT_KNOCKBACK_DURATION;
    [SerializeField] protected float knockbackPower_ = CONSTANTS.DEFAULT_KNOCKBACK;
    private Coroutine currCoroutine_;
    [SerializeField] protected float dashSpeed_ = CONSTANTS.DEFAULT_SPEED_DASH;
    protected bool isDashing_;
    protected float x_Previous_;
    protected float y_Previous_;
    protected Vector2 prevVelocity_;
    protected float acceleratation_;
    protected bool IsMoving_ = true;
    protected bool CanDash_ = true;
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

        try
        {
            yield return currCoroutine_;
        }
        finally
        {
            isDashing_ = false;
            StartCoroutine(CooldownCoroutine(cooldownTime, method));
        }
    }
    private IEnumerator CooldownCoroutine(float cooldownTime, Action method)
    {
        yield return new WaitForSeconds(cooldownTime);
        CanDash_ = true;
        try
        {
            method?.Invoke();
        }
        catch (Exception ex)
        {
            // Handle or log exception
            Debug.LogException(ex);
        }
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

        try
        {
            yield return currCoroutine_;
        }
        finally
        {
            IsMoving_ = true;
            method?.Invoke();
        }
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