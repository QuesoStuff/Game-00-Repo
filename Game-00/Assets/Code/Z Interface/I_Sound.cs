using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The I_Sound interface outlines the basic methods required to manage sounds, 
/// including playing, pausing, stopping, and playing a random sound from a collection.
/// </summary>
public interface I_Sound
{
    /// <summary>
    /// Plays a sound given its index in the audioClips array.
    /// </summary>
    /// <param name="index">The index of the sound to play in the array.</param>
    void PlaySound(uint index);

    /// <summary>
    /// Pauses the currently playing sound.
    /// </summary>
    void PauseSound();

    /// <summary>
    /// Stops the currently playing sound.
    /// </summary>
    void StopSound();

    /// <summary>
    /// Plays a random sound from the audioClips array.
    /// </summary>
    void PlayRandomSound();
}
