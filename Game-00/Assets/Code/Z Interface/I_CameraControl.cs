using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface I_CameraControl
{
    /// <summary>
    /// Sets the zoom level of the camera using a specified zoom value.
    /// </summary>
    /// <param name="zoom">Zoom value to set for the camera.</param>
    void SetZoom(float zoom);

    /// <summary>
    /// Sets the zoom level of the camera using the predefined zoom value.
    /// </summary>
    void SetZoom();

    /// <summary>
    /// Configures the target that the camera should follow.
    /// </summary>
    void ConfigureTarget();

    /// <summary>
    /// Changes the camera follow mode to a new specified mode.
    /// </summary>
    /// <param name="newMode">New camera follow mode to set.</param>
    void ChangeMode(CONSTANTS.CAMERA_FOLLOW_MODE newMode);

    /// <summary>
    /// Toggles the camera follow mode.
    /// </summary>
    void Toggle();

    /// <summary>
    /// Follows the target with a fixed speed, adjusting the camera's position accordingly.
    /// </summary>
    void CameraFollowFixedSpeed();

    /// <summary>
    /// Follows the target by tracking its movement, adjusting the camera's position based on the target's speed.
    /// </summary>
    void CameraFollowTracking();
}
