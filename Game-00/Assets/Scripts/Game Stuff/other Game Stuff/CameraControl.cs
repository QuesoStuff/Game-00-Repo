using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float followSpeed_ = 2f;
    [SerializeField] private float trackingSpeed_ = 0.5f;
    [SerializeField] private float yOffset_ = 1f;
    [SerializeField] private float zOffset_ = -10f;
    [SerializeField] public Transform target_;
    [SerializeField] public Move target_Movement_;
    [SerializeField] private float zoom_ = 10;
    private CONSTANTS.CAMERA_FOLLOW_MODE cameraMode_;

    public void Start()
    {
        // Set the initial zoom level
        SetZoom();

        // Find the target object with the specified tag and get its transform component
        ConfigureTarget();
    }

    public void SetZoom(float zoom)
    {
        // Set the zoom level of the camera
        Camera.main.orthographicSize = zoom;
    }

    public void SetZoom()
    {
        // Set the zoom level to the predefined value
        SetZoom(zoom_);
    }

    public void ConfigureTarget()
    {
        // Find the target object with the specified tag and get its transform component
        target_ = GameObject.FindWithTag(CONSTANTS.Player_Tag).transform;
    }

    public void ChangeMode(CONSTANTS.CAMERA_FOLLOW_MODE newMode)
    {
        // Change the camera mode
        cameraMode_ = newMode;
    }
    public void Toggle()
    {
        cameraMode_ = GENERIC.ToggleEnum<CONSTANTS.CAMERA_FOLLOW_MODE>(cameraMode_); // Returns SecondValue
    }

    public void Update()
    {
        // Update the camera movement based on the current camera mode
        if (cameraMode_ == CONSTANTS.CAMERA_FOLLOW_MODE.CAMERA_FIXED_SPEED)
            CameraFollowFixedSpeed();
        else if (cameraMode_ == CONSTANTS.CAMERA_FOLLOW_MODE.CAMERA_TRACKING_TARGET)
            CameraFollow();
    }

    public void CameraFollowFixedSpeed()
    {
        // Make the camera follow the target at a fixed speed
        GENERIC.FollowTarget(transform, target_, 0, yOffset_, zOffset_, followSpeed_);
    }

    public void CameraFollowTracking(float trackingSpeed)
    {
        // Make the camera follow the target with a speed based on the target's movement speed
        GENERIC.FollowTarget(transform, target_, 0, yOffset_, zOffset_, target_Movement_.GetCurrSpeed() * trackingSpeed);
    }

    public void CameraFollow()
    {
        // Make the camera follow the target with the default tracking speed
        CameraFollowTracking(trackingSpeed_);
    }
}
