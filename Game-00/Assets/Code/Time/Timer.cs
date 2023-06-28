using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : Time_Mode
{
    public Timer(float duration) : base(duration)
    {
        this.elapsedTime_ = duration;
    }

    protected override void CalculateTime()
    {
        elapsedTime_ -= Time.deltaTime;
        if (elapsedTime_ <= 0)
        {
            elapsedTime_ = 0;
            Stop();
        }
    }
}

