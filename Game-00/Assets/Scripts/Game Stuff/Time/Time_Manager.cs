using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Manager : MonoBehaviour
{
    private CONSTANTS.TIME_MODE currentMode_;
    //[SerializeField] private Timer timer_;
    //[SerializeField] private Clock clock_;
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
        // Singleton pattern
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject);
    }

    public float GetTime()
    {
        return currTimeSetup_.GetTime(); // Use polymorphism to get the current time
    }
    public float GetDuration()
    {
        return currTimeSetup_.GetDuration(); // Use polymorphism to get the current time
    }
    public CONSTANTS.TIME_MODE GetMode()
    {
        return currentMode_;
    }

    public void SetTimeMode(CONSTANTS.TIME_MODE mode, float duration)
    {
        StopTimeIfRunning(); // Stop the current time mode if running

        if (mode == CONSTANTS.TIME_MODE.TIMER_MODE)
        {
            currTimeSetup_ = new Timer(duration); // Create a new Timer instance
        }
        else if (mode == CONSTANTS.TIME_MODE.CLOCK_MODE)
        {
            currTimeSetup_ = new Clock(duration); // Create a new Clock instance
        }
        else
        {
            Debug.LogError("Invalid time mode");
            return;
        }

        currTimeSetup_.StartTime(); // Start the new time mode
        currentMode_ = mode;
    }

    private void StopTimeIfRunning()
    {
        if (currTimeSetup_ != null && currTimeSetup_.GetIsRunning())
        {
            currTimeSetup_.Stop(); // Stop the current time mode
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
