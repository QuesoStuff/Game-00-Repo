using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player_Controller : Controller
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
            player_Main_.player_Color_.HoldColor(CONSTANTS_COLOR.DEFAULT_FLASH_COLOR, 0.5f);
        }
        );
    }
    private void ShootProjectile()
    {
        Vector2 direction = player_Main_.player_Direction_.GetDirection();
        Vector3 offset = Offset(direction);
        Spawning_Main.instance_.spawning_GameObjects_.Spawn_Bullet(transform.position + offset, transform.rotation, direction, IsSoloCharged_);
    }

    public override Vector3 Offset(Vector2 position)
    {
        float playerRadius = transform.localScale.magnitude / 2;
        Vector3 offset = position.normalized * playerRadius;
        return offset;
    }



    public void Control_Move()
    {
        if (INPUT.Input_Move_Up())
        {
            player_Main_.player_Move_.Move_Up();
        }
        else if (INPUT.Input_Move_Down())
        {
            player_Main_.player_Move_.Move_Down();
        }
        else if (INPUT.Input_Move_Left())
        {
            player_Main_.player_Move_.Move_Left();
        }
        else if (INPUT.Input_Move_Right())
        {
            player_Main_.player_Move_.Move_Right();
        }
        else if (INPUT.Input_Idle())
        {
            player_Main_.player_Move_.Move_None();
        }
        if (INPUT.Input_Move_Any())
        {
            player_Main_.player_Direction_.SetDirection();
            if (!isTeleport_)
                Record_Main.UpdateDistanceTraveled();
            UI_Main.instance_.UI_Traveled_.Update_UI();
            player_Main_.player_Direction_.Turn();
        }
    }

    public void Control_Shoot()
    {
        if (INPUT.Input_Charged_Valid() && !IsChargedReady_)
        {
            IsChargedReady_ = true;
            player_Main_.player_Color_.HoldColor(CONSTANTS_COLOR.DEFAULT_PLAYER_CHARGING_COLOR, 0.5f);
            IsSoloCharged_ = true;
        }
        if (INPUT.Input_Shot_Charged() || INPUT.Input_Trigger_Pulled())
        {
            ShootProjectile();
            player_Main_.player_Color_.HoldColor(CONSTANTS_COLOR.DEFAULT_PLAYER_CHARGSHOT_COLOR, 0.5f);
            Record_Main.UpdateBulletCount();
            UI_Main.instance_.UI_BulletCount_.Update_UI();
            IsChargedReady_ = false;
        }
        if (INPUT.Input_Trigger_Release())
        {
            IsSoloCharged_ = false;
        }

    }
    public void Item_Dash(float duration)
    {
        if (ActiveItems.GetIsDashing())
        {
            //player_Main_.player_Move_.StopMoveCoroutine();
            CameraControl.instance_.Toggle();
            player_Main_.player_Color_.SetColor(CONSTANTS_COLOR.DEFAULT_PLAYER_DASH_2);
            StartCoroutine(player_Main_.player_Move_.Dash(() =>
            {
                player_Main_.player_Color_.HoldColor(CONSTANTS_COLOR.DEFAULT_PLAYER_DASH_2, 0.5f);
                CameraControl.instance_.Toggle();
            }, duration, 10));
        }
    }

    public void Move_Dash()
    {
        if (INPUT.Input_Dash_Move() && player_Main_.player_Move_.GetCanDash())
        {
            //player_Main_.player_Move_.StopMoveCoroutine();
            CameraControl.instance_.Toggle();
            StartCoroutine(player_Main_.player_Move_.Dash(() =>
            {
                player_Main_.player_Color_.HoldColor(CONSTANTS_COLOR.DEFAULT_PLAYER_DASH, 0.5f);
                CameraControl.instance_.Toggle();
            }));
        }
    }


    public void Control()
    {
        if (!ActiveItems.GetIsTypeMissle())
        {
            Control_Move();
            Move_Dash();
        }
        Control_Shoot();
    }



    public void Controller_Player()
    {
        if (player_Main_.player_Move_.GetIsMoving() && GameState.GetGameState() == CONSTANTS_ENUM.GAME_STATE.PLAY)
        {
            player_Main_.player_Controller_.Control();
        }
    }
    public void Controller_Player_Dashing()
    {
        if ((player_Main_.player_Move_.GetIsDashing()) && INPUT.Input_Move_Any())
        {
            if (!isAlreadyDashing_) // we start dashing
            {
                isAlreadyDashing_ = true;
                StartCoroutine(DashAndSpawn(() => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDeath(transform.position, spriterender_.color)));
            }
        }
        else
        {
            isAlreadyDashing_ = false; // we stop dashing
        }
    }
}
