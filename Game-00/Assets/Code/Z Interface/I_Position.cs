using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The I_Position interface outlines the methods required for managing the position of a GameObject.
/// </summary>
public interface I_Position
{
    /// <summary>
    /// Updates the current and previous positions of the GameObject.
    /// </summary>
    void SetPosition();

    /// <summary>
    /// Retrieves the current position of the GameObject.
    /// </summary>
    /// <returns>The current position of the GameObject as a Vector2.</returns>
    Vector2 GetPosition();

    /// <summary>
    /// Retrieves the previous position of the GameObject.
    /// </summary>
    /// <returns>The previous position of the GameObject as a Vector2.</returns>
    Vector2 GetPositionPrev();
}
