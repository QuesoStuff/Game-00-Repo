using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{



    [SerializeField] private float followSpeed_ = CONSTANTS.DEFAULT_CAMERA_FOLLOWSPEED;
    [SerializeField] private float trackingSpeed_ = CONSTANTS.DEFAULT_CAMERA_TRACKSPEED;

    [SerializeField] private float yOffset_ = CONSTANTS.DEFAULT_CAMERA_OFFSET_Y;

    [SerializeField] private float zOffset_ = CONSTANTS.DEFAULT_CAMERA_OFFSET_Z;
    [SerializeField] public Transform target_Transform_;
    [SerializeField] public Move target_Movement_;
    [SerializeField] private float zoom_ = CONSTANTS.DEFAULT_CAMERA_ZOOM;

    private CONSTANTS_ENUM.CAMERA_FOLLOW_MODE cameraMode_;
    public static CameraControl instance_;
    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject, false);
    }
    public void FindTarget()
    {
        GameObject target_Object_ = GameObject.FindGameObjectWithTag(CONSTANTS_STRING.Player_Tag);
        if (target_Object_ != null)
        {
            target_Transform_ = target_Object_.transform;
            target_Movement_ = target_Object_.GetComponent<Move>();
        }
    }
    public void Start()
    {


        SetZoom();
    }

    public void SetZoom(float? zoom = null)
    {
        zoom ??= zoom_;

        Camera.main.orthographicSize = zoom.Value;
    }


    public void ConfigureTarget()
    {
        target_Transform_ = GameObject.FindWithTag(CONSTANTS_STRING.Player_Tag).transform;
    }

    public void ChangeMode(CONSTANTS_ENUM.CAMERA_FOLLOW_MODE newMode)
    {
        cameraMode_ = newMode;
    }
    public void Toggle()
    {
        cameraMode_ = GENERIC.ToggleEnum<CONSTANTS_ENUM.CAMERA_FOLLOW_MODE>(cameraMode_);
    }

    public void CameraFollow()
    {
        if (target_Transform_ != null)
        {
            if (cameraMode_ == CONSTANTS_ENUM.CAMERA_FOLLOW_MODE.CAMERA_FIXED_SPEED)
            {
                CameraFollowFixedSpeed();
            }
            else if (cameraMode_ == CONSTANTS_ENUM.CAMERA_FOLLOW_MODE.CAMERA_TRACKING_TARGET)
            {
                CameraFollowTracking();
            }
        }
    }
    public void Update()
    {
        CameraFollow();
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
