using UnityEngine;

/// <summary>
/// The I_MonoBehaviourPlus interface defines the functionality for a MonoBehaviour 
/// with additional features such as Kill and Rotate.
/// </summary>
public interface I_MonoBehaviourPlus
{
    /// <summary>
    /// This method is used to destroy the GameObject this script is attached to after a certain delay.
    /// It also stops all coroutines on this script to prevent errors.
    /// </summary>
    /// <param name="delay">Delay in seconds before the GameObject is destroyed.</param>
    void Kill(float delay);

    /// <summary>
    /// This method is used to rotate the GameObject this script is attached to.
    /// </summary>
    /// <param name="rotationSpeed">The speed at which the GameObject should rotate.</param>
    void Rotate(float rotationSpeed);

    /// <summary>
    /// This method is used to destroy the GameObject this script is attached to immediately.
    /// </summary>
    void Kill();
}
