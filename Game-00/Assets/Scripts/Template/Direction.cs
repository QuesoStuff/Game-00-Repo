using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    [SerializeField] internal Move target_Velocity_;
    private Vector2 currDirection_;
    private Vector2 prevDirection_;

    public void SetDirection()
    {
        prevDirection_ = currDirection_;
        currDirection_ = GENERIC.GetDirection(target_Velocity_.GetVelocity());
    }
    public Vector2 GetDirection()
    {
        return currDirection_;
    }
}
