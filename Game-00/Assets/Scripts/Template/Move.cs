using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb2d;

    // Speed variables
    [SerializeField] private float normalSpeed_ = 5f;
    [SerializeField] private float maxSpeed_ = 10f;
    [SerializeField] private float lowestSpeed_ = 2.5f;
    [SerializeField] private float diagnolSpeed_ = 2.5f;
    [SerializeField] private float diagnolSlowSpeed_ = 1.25f;
    [SerializeField] private float diagnolFastSpeed_ = 5f;
    [SerializeField] private float dashSpeed_ = 25;

    // Movement variables
    [SerializeField] private float currSpeed_;
    private float x_;
    private float y_;
    private Vector2 currVelocity_;

    // Previous movement variables
    private float x_Previous_;
    private float y_Previous_;
    private Vector2 prevVelocity_;
    private float acceleratation_;

    // Dashing flag
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

    public bool GetisDashing()
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
        // Store previous movement values
        x_Previous_ = this.x_;
        y_Previous_ = this.y_;

        // Set new movement values
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
    public void SetVelocity()
    {
        currVelocity_ = new Vector2(x_, y_);
        prevVelocity_ = new Vector2(x_Previous_, y_Previous_);
    }

    // Basic cardinal movement methods
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
    // Basic cardinal slow movement methods
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

    // Basic cardinal normal movement methods
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

    // Basic cardinal fast movement methods
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

    // Diagonal movement methods
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

    // Diagonal slow movement methods
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

    // Diagonal fast movement methods
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


    // Moving the Rigidbody2D
    public Vector2 Moving()
    {
        SetVelocity();
        return GENERIC.Move_GameObject(x_, y_, rb2d);
    }
    public Vector2 Moving(float max, float acc)
    {
        SetVelocity();
        return GENERIC.Move_GameObject(x_, y_, rb2d, max, acc);
    }

    public IEnumerator StartDash(float dashDuration, float coolDownDuration)
    {
        float startTime = Time.time;
        float defaultSpeed = currSpeed_;
        isDashing_ = true;
        currSpeed_ = dashSpeed_;

        while (UnityEngine.Time.time < startTime + dashDuration)
        {
            yield return null;
        }

        //this.SetWithDelay(defaultSpeed, SetCurrentSpeed, 5f);
        currSpeed_ = defaultSpeed;
        //isDashing_ = false;
    }
    // Dashing coroutine
    public IEnumerator StartDash(float dashDuration)
    {
        return StartDash(dashDuration, 0);
    }

    public IEnumerator StartDash()
    {
        return StartDash(CONSTANTS.DEFAULT_DASHING_TIME, 5f);
    }
}
