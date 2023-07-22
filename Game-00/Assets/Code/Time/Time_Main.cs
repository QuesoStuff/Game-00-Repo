using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Time_Main
{
    private static CONSTANTS_ENUM.TIME_MODE currentMode_;
    private static Time_Mode currTimeSetup_;



    public static void ToggleTimeMode(float duration)
    {
        if (currentMode_ == CONSTANTS_ENUM.TIME_MODE.TIMER_MODE)
        {
            currentMode_ = CONSTANTS_ENUM.TIME_MODE.CLOCK_MODE;
        }
        else if (currentMode_ == CONSTANTS_ENUM.TIME_MODE.CLOCK_MODE)
        {
            currentMode_ = CONSTANTS_ENUM.TIME_MODE.TIMER_MODE;
        }

        SetTimeMode(currentMode_, duration);
    }
    public static float GetRunningTime()
    {
        return currTimeSetup_.GetRunningTime();
    }
    public static void ToggleTimeMode()
    {
        ToggleTimeMode(GetDuration());
    }

    public static bool IsTimeModeSet()
    {
        return currTimeSetup_ != null;
    }
    public static float GetElapsedTime()
    {
        return currTimeSetup_.GetElapsedTime();
    }
    public static float GetDuration()
    {
        return currTimeSetup_.GetDuration();
    }
    public static CONSTANTS_ENUM.TIME_MODE GetMode()
    {
        return currentMode_;
    }

    public static void SetTimeMode(CONSTANTS_ENUM.TIME_MODE mode, float duration = CONSTANTS.DEFAULT_TIME_DURATION, System.Action method = null)
    {
        StopTimeIfRunning();
        if (mode == CONSTANTS_ENUM.TIME_MODE.TIMER_MODE)
        {
            currTimeSetup_ = new Timer(duration);
        }
        else if (mode == CONSTANTS_ENUM.TIME_MODE.CLOCK_MODE)
        {
            currTimeSetup_ = new Clock(duration);
        }
        else
        {
            Debug.LogError("Invalid time mode");
            return;
        }
        currTimeSetup_.AddToAction_OnDeath(method); // to get last value before stopping Blinking
        currTimeSetup_.StartTime();
        currentMode_ = mode;
    }


    private static void StopTimeIfRunning()
    {
        if (currTimeSetup_ != null && currTimeSetup_.GetIsRunning())
        {
            currTimeSetup_.Stop();
        }
    }
    public static void Running()
    {
        if (GetIsRunning())
        {
            currTimeSetup_.Running();
        }
    }
    public static bool GetIsRunning()
    {
        return currTimeSetup_.GetIsRunning();

    }


}
