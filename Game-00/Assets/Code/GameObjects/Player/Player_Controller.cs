using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player_Controller : MonoBehaviour
{
    [SerializeField] public Player_Main player_Main_;
    private bool IsChargedReady_ = false;
    private bool IsSoloCharged_ = false;
    private bool isTeleport_ = false;


    public bool GetIsTeleport()
    {
        return isTeleport_;
    }

    public void SetIsTeleport(bool isTeleport)
    {
        isTeleport_ = isTeleport;
    }

    public void InitDash()
    {
        player_Main_.player_Move_.SetCanDash(false);

        player_Main_.player_Move_.DelayMethod(5, () =>
        {
            player_Main_.player_Move_.SetCanDash(true);
            player_Main_.player_Color_.HoldColor(Color.green, 0.5f);
        }
        );
    }
    private void ShootProjectile()
    {
        Vector2 direction = player_Main_.player_Direction_.GetDirection();
        Vector3 offset = player_Main_.Offset(direction);
        Spawning_Main.instance_.spawning_GameObjects_.Spawn_Bullet(transform.position + offset, transform.rotation, direction, IsSoloCharged_);
    }





    public void Control_Move()
    {
        if (INPUT.instance_.Input_Move_Up())
        {
            player_Main_.player_Move_.Move_Up();
        }
        else if (INPUT.instance_.Input_Move_Down())
        {
            player_Main_.player_Move_.Move_Down();
        }
        else if (INPUT.instance_.Input_Move_Left())
        {
            player_Main_.player_Move_.Move_Left();
        }
        else if (INPUT.instance_.Input_Move_Right())
        {
            player_Main_.player_Move_.Move_Right();
        }
        else if (INPUT.instance_.Input_Idle())
        {
            player_Main_.player_Move_.Move_None();
        }
        if (INPUT.instance_.Input_Move_Any())
        {
            player_Main_.player_Direction_.SetDirection();
            if (!isTeleport_)
                Record_Main.instance_.UpdateDistanceTraveled();
            UI_Main.instance_.UI_Traveled_.Update_UI();
            player_Main_.player_Direction_.Turn();
        }
    }

    public void Control_Shoot()
    {
        if (INPUT.instance_.Input_Charged_Valid() && !IsChargedReady_)
        {
            IsChargedReady_ = true;
            player_Main_.player_Color_.HoldColor(Color.yellow, 0.5f);
            IsSoloCharged_ = true;
        }
        if (INPUT.instance_.Input_Shot_Charged() || INPUT.instance_.Input_Trigger_Pulled())
        {
            ShootProjectile();
            player_Main_.player_Color_.HoldColor(Color.yellow, 0.5f);
            Record_Main.instance_.UpdateBulletCount();
            UI_Main.instance_.UI_BulletCount_.Update_UI();
            IsChargedReady_ = false;
        }
        if (INPUT.instance_.Input_Trigger_Release())
        {
            IsSoloCharged_ = false;
        }

    }
    public void Item_Dash(float duation)
    {
        if (ACTIVE.GetIsDashing())
        {
            CameraControl.instance_.Toggle();
            player_Main_.player_Color_.SetColor(new Color(1f, 0.5f, 0f, 1f));
            StartCoroutine(player_Main_.player_Move_.Dash(() =>
            {
                player_Main_.player_Color_.HoldColor(Color.green, 0.5f);
                CameraControl.instance_.Toggle();
            }, duation, 10));

        }
    }

    public void Move_Dash()
    {
        if (INPUT.instance_.Input_Dash_Move() && player_Main_.player_Move_.GetCanDash())
        {
            CameraControl.instance_.Toggle();
            StartCoroutine(player_Main_.player_Move_.Dash(() =>
            {
                player_Main_.player_Color_.HoldColor(Color.green, 0.5f);
                CameraControl.instance_.Toggle();
            }));
        }
    }

    public void Control()
    {
        if (!ACTIVE.GetIsTypeMissle())
        {
            Control_Move();
            Move_Dash();
        }
        Control_Shoot();
    }
}
