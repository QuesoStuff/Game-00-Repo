using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The I_Time_Manager interface defines the expected behaviors for time managers.
/// It includes methods to get and set the current time mode, toggle the time mode, and to get the elapsed time, duration and running state.
/// </summary>
public interface I_Time_Manager
{
    /// <summary>
    /// Toggles the current time mode and sets a new duration.
    /// </summary>
    void ToggleTimeMode(float duration);

    /// <summary>
    /// Toggles the current time mode.
    /// </summary>
    void ToggleTimeMode();

    /// <summary>
    /// Gets the current time.
    /// </summary>
    float GetTime();

    /// <summary>
    /// Gets the current duration.
    /// </summary>
    float GetDuration();

    /// <summary>
    /// Gets the current time mode.
    /// </summary>
    CONSTANTS.TIME_MODE GetMode();

    /// <summary>
    /// Sets the current time mode and a new duration.
    /// </summary>
    void SetTimeMode(CONSTANTS.TIME_MODE mode, float duration);

    /// <summary>
    /// A method for running the time calculation. Specific implementation to be provided by the class.
    /// </summary>
    void Running();

    /// <summary>
    /// Gets the running state of the time manager.
    /// </summary>
    bool GetIsRunning();
}
