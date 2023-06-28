using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Manager : MonoBehaviour, I_Time_Manager
{
    private CONSTANTS.TIME_MODE currentMode_;
    private Time_Mode currTimeSetup_;

    public static Time_Manager instance_;


    public void ToggleTimeMode(float duration)
    {
        if (currentMode_ == CONSTANTS.TIME_MODE.TIMER_MODE)
        {
            currentMode_ = CONSTANTS.TIME_MODE.CLOCK_MODE;
        }
        else if (currentMode_ == CONSTANTS.TIME_MODE.CLOCK_MODE)
        {
            currentMode_ = CONSTANTS.TIME_MODE.TIMER_MODE;
        }

        SetTimeMode(currentMode_, duration);
    }

    public void ToggleTimeMode()
    {
        ToggleTimeMode(GetDuration());
    }
    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject);
    }

    public float GetTime()
    {
        return currTimeSetup_.GetTime();
    }
    public float GetDuration()
    {
        return currTimeSetup_.GetDuration();
    }
    public CONSTANTS.TIME_MODE GetMode()
    {
        return currentMode_;
    }

    public void SetTimeMode(CONSTANTS.TIME_MODE mode, float duration)
    {
        StopTimeIfRunning();
        if (mode == CONSTANTS.TIME_MODE.TIMER_MODE)
        {
            currTimeSetup_ = new Timer(duration);
        }
        else if (mode == CONSTANTS.TIME_MODE.CLOCK_MODE)
        {
            currTimeSetup_ = new Clock(duration);
        }
        else
        {
            Debug.LogError("Invalid time mode");
            return;
        }
        currTimeSetup_.AddToAction_OnDeath(UI_Main.instance_.UI_Time.Update_UI); // to get last value before stopping Blinking
        currTimeSetup_.AddToAction_OnDeath(UI_Main.instance_.UI_Time.StopBlinking);
        currTimeSetup_.StartTime();
        currentMode_ = mode;
    }


    private void StopTimeIfRunning()
    {
        if (currTimeSetup_ != null && currTimeSetup_.GetIsRunning())
        {
            currTimeSetup_.Stop();
        }
    }
    public void Running()
    {
        if (GetIsRunning())
        {
            currTimeSetup_.Running();
        }
    }
    public bool GetIsRunning()
    {
        return currTimeSetup_.GetIsRunning();

    }


}
