using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{

    [SerializeField] public Move target_Velocity_;
    private Vector2 currDirection_;
    private Vector2 prevDirection_;
    private Vector2 initDirection_;

    public void SetDirection()
    {
        if (initDirection_ == Vector2.zero)
        {
            initDirection_ = currDirection_;
        }

        prevDirection_ = currDirection_;
        currDirection_ = target_Velocity_.GetVelocity().normalized;
    }
    public Vector2 GetDirection()
    {
        return currDirection_;
    }

    public Vector2 GetInitDirection()
    {
        return initDirection_;
    }
    public void Turn()
    {
        Vector2 absCurrDirection = new Vector2(Mathf.Abs(currDirection_.x), Mathf.Abs(currDirection_.y));
        Vector2 absPrevDirection = new Vector2(Mathf.Abs(prevDirection_.x), Mathf.Abs(prevDirection_.y));

        if (absCurrDirection != absPrevDirection)
        {
            GENERIC.UpdateRotation(transform, GetInitDirection(), currDirection_);
        }
    }
    public void StartingRotation()
    {
        if (currDirection_.y != 0)
            transform.rotation = Quaternion.Euler(0f, 0f, 0);
        else if (currDirection_.x != 0)
            transform.rotation = Quaternion.Euler(0f, 0f, 180);
    }







}
