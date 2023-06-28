using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The I_Time_Mode interface defines the expected behaviors for time modes.
/// It includes methods to start, pause, resume, stop time and to get the elapsed time and duration.
/// </summary>
public interface I_Time_Mode
{
    /// <summary>
    /// Adds an action to the OnTimeDone event.
    /// </summary>
    void AddToAction_OnDeath(Action addAction);

    /// <summary>
    /// Gets the running state of the time mode.
    /// </summary>
    bool GetIsRunning();

    /// <summary>
    /// Starts the time.
    /// </summary>
    void StartTime();

    /// <summary>
    /// Pauses the time.
    /// </summary>
    void Pause();

    /// <summary>
    /// Resumes the time.
    /// </summary>
    void Resume();

    /// <summary>
    /// Stops the time and invokes the OnTimeDone event.
    /// </summary>
    void Stop();

    /// <summary>
    /// Gets the elapsed time.
    /// </summary>
    float GetTime();

    /// <summary>
    /// Gets the duration of the time mode.
    /// </summary>
    float GetDuration();

    /// <summary>
    /// A method for running the time calculation. Specific implementation to be provided by the class.
    /// </summary>
    void Running();
}
