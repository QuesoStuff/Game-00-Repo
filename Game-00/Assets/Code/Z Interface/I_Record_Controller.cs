using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The I_Record_Controller interface outlines the methods required to update various game records.
/// These include bullet count, distance traveled, total damage and heal, high score, kill count, clock and timer settings, among others.
/// </summary>
public interface I_Record_Controller
{
    /// <summary>
    /// Updates the bullet count whenever the trigger is pulled.
    /// </summary>
    void TriggerPulled();

    /// <summary>
    /// Updates the distance traveled by the player.
    /// </summary>
    void Traveling();

    /// <summary>
    /// Updates the total damage caused by the player.
    /// </summary>
    void TotalDamage();

    /// <summary>
    /// Updates the total healing done by the player.
    /// </summary>
    void TotalHeal();

    /// <summary>
    /// Updates the high score of the player.
    /// </summary>
    void HighScore();

    /// <summary>
    /// Updates the kill count of the player.
    /// </summary>
    void KillCount();

    /// <summary>
    /// Updates the maximum clock time, if the current time mode is clock.
    /// </summary>
    void Clock();

    /// <summary>
    /// Updates the maximum timer time, if the current time mode is timer.
    /// </summary>
    void TImer();
}
