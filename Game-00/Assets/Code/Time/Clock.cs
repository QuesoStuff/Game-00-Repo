using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Time_Mode
{
    public Clock(float duration) : base(duration) { }

    /*
        elapsedTime_ += Time.deltaTime;
        if (elapsedTime_ >= duration_)
        {
            elapsedTime_ = duration_;
            Stop();
        }
    */
    protected override void CalculateTime()
    {
        CalculateTime(time => time + Time.deltaTime, duration_);
    }
    public override float GetRunningTime()
    {
        return elapsedTime_;
    }
}

