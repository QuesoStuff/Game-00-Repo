using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player_Controller : MonoBehaviour
{
    [SerializeField] public Player_Main player_Main_;
    private bool IsChargedReady_ = false;
    private bool IsSoloCharged = false;

    private void ShootProjectile()
    {
        float bulletSpeed = player_Main_.player_Move_.GetCurrSpeed() * 2;
        Vector2 direction = player_Main_.player_Direction_.GetDirection();
        Vector2 velocity = direction * bulletSpeed;
        Spawning_Main.instance_.spawning_GameObjects_.Spawn_Bullet(transform.position, transform.rotation, velocity, IsSoloCharged);
    }

    public void Control_Move()
    {
        if (INPUT.instance_.Input_Move_Up())
        {
            player_Main_.player_Move_.Move_Up();
            player_Main_.player_Direction_.SetDirection();
            Record_Main.instance_.UpdateDistanceTraveled();
            UI_Main.instance_.UI_Traveled_.Update_UI();
            player_Main_.player_Direction_.Turn();
        }
        else if (INPUT.instance_.Input_Move_Down())
        {
            player_Main_.player_Move_.Move_Down();
            player_Main_.player_Direction_.SetDirection();
            Record_Main.instance_.UpdateDistanceTraveled();
            UI_Main.instance_.UI_Traveled_.Update_UI();
            player_Main_.player_Direction_.Turn();
        }
        else if (INPUT.instance_.Input_Move_Left())
        {
            player_Main_.player_Move_.Move_Left();
            player_Main_.player_Direction_.SetDirection();
            Record_Main.instance_.UpdateDistanceTraveled();
            UI_Main.instance_.UI_Traveled_.Update_UI();
            player_Main_.player_Direction_.Turn();
        }
        else if (INPUT.instance_.Input_Move_Right())
        {
            player_Main_.player_Move_.Move_Right();
            player_Main_.player_Direction_.SetDirection();
            Record_Main.instance_.UpdateDistanceTraveled();
            UI_Main.instance_.UI_Traveled_.Update_UI();
            player_Main_.player_Direction_.Turn();
        }
        else if (INPUT.instance_.Input_Idle())
        {
            player_Main_.player_Move_.Move_None();
            Record_Main.instance_.UpdateDistanceTraveled();
        }
    }

    public void Control_Shoot()
    {
        if (INPUT.instance_.Input_Charged_Valid() && !IsChargedReady_)
        {
            IsChargedReady_ = true;
            player_Main_.player_Color_.HoldColor(Color.yellow, 0.5f);
            IsSoloCharged = true;
        }
        if (INPUT.instance_.Input_Shot_Charged() || INPUT.instance_.Input_Trigger_Pulled())
        {
            ShootProjectile();
            Record_Main.instance_.UpdateBulletCount();
            UI_Main.instance_.UI_BulletCount_.Update_UI();
            IsChargedReady_ = false;
        }
        if (INPUT.instance_.Input_Trigger_Release())
        {
            IsSoloCharged = false;
        }

    }

    public void Move_Dash()
    {
        if (INPUT.instance_.Input_Dash_Move() && player_Main_.player_Move_.GetCanDash())
        {
            StartCoroutine(player_Main_.player_Move_.StartDash());
        }
    }

    public void Control()
    {
        //Control_Move();
        //Control_Shoot();
        //Move_Dash();

        Control_Move();
        if (!Bullet_Config.GetIsTypeMissle())
            Move_Dash();
        Control_Shoot();
    }
}
