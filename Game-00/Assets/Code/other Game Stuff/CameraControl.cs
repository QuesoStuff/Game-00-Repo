using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour, I_CameraControl
{

    [SerializeField] private float followSpeed_ = 2f;
    [SerializeField] private float trackingSpeed_ = 0.5f;
    [SerializeField] private float yOffset_ = 1f;
    [SerializeField] private float zOffset_ = -10f;
    [SerializeField] public Transform target_Transform_;
    [SerializeField] public Move target_Movement_;
    [SerializeField] private float zoom_ = 10;
    private CONSTANTS.CAMERA_FOLLOW_MODE cameraMode_;

    public void Start()
    {
        SetZoom();

    }

    public void SetZoom(float zoom)
    {
        Camera.main.orthographicSize = zoom;
    }

    public void SetZoom()
    {
        SetZoom(zoom_);
    }

    public void ConfigureTarget()
    {
        target_Transform_ = GameObject.FindWithTag(CONSTANTS.Player_Tag).transform;
    }

    public void ChangeMode(CONSTANTS.CAMERA_FOLLOW_MODE newMode)
    {
        cameraMode_ = newMode;
    }
    public void Toggle()
    {
        cameraMode_ = GENERIC.ToggleEnum<CONSTANTS.CAMERA_FOLLOW_MODE>(cameraMode_);
    }

    public void Update()
    {
        if (target_Transform_ != null)
        {
            if (cameraMode_ == CONSTANTS.CAMERA_FOLLOW_MODE.CAMERA_FIXED_SPEED)
            {
                CameraFollowFixedSpeed();
            }
            else if (cameraMode_ == CONSTANTS.CAMERA_FOLLOW_MODE.CAMERA_TRACKING_TARGET)
            {
                CameraFollowTracking();
            }
        }
    }


    public void CameraFollowFixedSpeed()
    {
        GENERIC.FollowTarget(transform, target_Transform_, followSpeed_, yOffset: yOffset_, zOffset: zOffset_);
    }

    public void CameraFollowTracking()
    {
        GENERIC.FollowTarget(transform, target_Transform_, target_Movement_.GetCurrSpeed() * trackingSpeed_, yOffset: yOffset_, zOffset: zOffset_);
    }


}
