using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{

    private Vector2 currPosition_;
    private Vector2 prevPosition_;
    [SerializeField] public Transform target_;


    public void SetPosition()
    {
        prevPosition_ = currPosition_;
        currPosition_ = target_.position;
        Debug.Log("Curr Position: " + currPosition_);
    }


    public Vector2 GetPosition()
    {
        return currPosition_;
    }
    public Vector2 GetPositionPrev()
    {
        return prevPosition_;
    }
}
