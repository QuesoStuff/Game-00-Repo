
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The I_Spawning interface defines the expected behaviors for spawning objects.
/// It includes methods to spawn a GameObject at a certain position with a specific color and 
/// rotation settings.
/// </summary>
public interface I_Spawning
{
    /// <summary>
    /// Spawns a given GameObject at a specified position and color, with options for rotation and lifetime and duration constants.
    /// </summary>
    /// <param name="obj">The GameObject to spawn.</param>
    /// <param name="startPosition">The position at which to spawn the object.</param>
    /// <param name="startColor">The initial color of the object.</param>
    /// <param name="shouldRotate">Whether the object should be rotated.</param>
    /// <param name="constantLifetimeAndDuration">Whether the object's lifetime and duration should be constant.</param>
    void Spawn(GameObject obj, Vector2 startPosition, Color startColor, bool shouldRotate, bool constantLifetimeAndDuration);
}
