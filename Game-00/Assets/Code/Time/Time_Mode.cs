using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Time_Mode : I_Time_Mode
{
    [SerializeField] protected float duration_;
    [SerializeField] protected float elapsedTime_;
    [SerializeField] protected bool isRunning_;
    private event Action OnTimeDone_;

    public void AddToAction_OnDeath(Action addAction)
    {
        OnTimeDone_ += addAction;
    }
    public Time_Mode(float duration)
    {
        this.duration_ = duration;
    }
    public bool GetIsRunning()
    {
        return isRunning_;
    }
    public void StartTime()
    {
        isRunning_ = true;
    }

    public void Pause()
    {
        isRunning_ = false;
    }

    public void Resume()
    {
        isRunning_ = true;
    }

    public void Stop()
    {
        //elapsedTime_ = 0;
        isRunning_ = false;
        OnTimeDone_?.Invoke();
    }

    public float GetTime()
    {
        return elapsedTime_;
    }
    public float GetDuration()
    {
        return duration_;
    }

    protected abstract void CalculateTime();
    public void Running()
    {
        if (isRunning_)
        {
            CalculateTime();
        }

    }


}