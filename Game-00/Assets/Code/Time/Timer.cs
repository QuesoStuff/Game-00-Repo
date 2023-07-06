using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : Time_Mode
{
    public Timer(float duration) : base(duration)
    {
        this.elapsedTime_ = duration;
    }


    /*
    elapsedTime_ -= Time.deltaTime;
    if (elapsedTime_ <= 0)
    {
        elapsedTime_ = 0;
        Stop();
    }
    */
    protected override void CalculateTime()
    {
        CalculateTime(time => time - Time.deltaTime, 0);
    }
    public override float GetRunningTime()
    {
        return duration_ - elapsedTime_;
    }
}

