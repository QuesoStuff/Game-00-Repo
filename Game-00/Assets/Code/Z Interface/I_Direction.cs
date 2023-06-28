using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The I_Direction interface provides the functionality for managing the direction of a game object.
/// </summary>
public interface I_Direction
{
    /// <summary>
    /// Sets the direction of the game object based on its target velocity.
    /// </summary>
    void SetDirection();

    /// <summary>
    /// Gets the current direction of the game object.
    /// </summary>
    Vector2 GetDirection();

    /// <summary>
    /// Gets the initial direction of the game object.
    /// </summary>
    Vector2 GetInitDirection();

    /// <summary>
    /// Changes the direction of the game object.
    /// </summary>
    void Turn();

    /// <summary>
    /// Sets the initial rotation of the game object based on its current direction.
    /// </summary>
    void StartingRotation();
}
