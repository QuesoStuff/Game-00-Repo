using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Time_Mode
{
    public Clock(float duration) : base(duration) { }

    protected override void CalculateTime()
    {
        elapsedTime_ += Time.deltaTime;
        if (elapsedTime_ >= duration_)
        {
            elapsedTime_ = duration_;
            Stop();
        }
    }
}
