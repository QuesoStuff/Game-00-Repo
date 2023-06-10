using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] public Player_Main player_Main_;
    //GameObject bulletPrefab = Resources.Load<GameObject>(CONSTANTS.Bullet_Tag);
    Object bulletPrefab;

    void Awake()
    {
        bulletPrefab = Resources.Load("Bullet");

    }
    private void ShootProjectile()
    {
        float bulletSpeed = player_Main_.player_Move_.GetCurrSpeed() * 2;
        Vector2 direction = player_Main_.player_Direction_.GetDirection();
        Vector2 velocity = direction * bulletSpeed;
        Bullet_Main.Static_Create(transform.position, transform.rotation, velocity, (GameObject)bulletPrefab);

    }
    public void Move_Four_Directions()
    {
        if (INPUT.instance_.Input_Dash_Move() && !player_Main_.player_Move_.GetisDashing())
        {
            StartCoroutine(player_Main_.player_Move_.StartDash());
            //UI_Main.instance_.UI_Debug_.Update_UI_Text("Dash");
        }
        else if (INPUT.instance_.Input_Charged_Valid())
        {
            //player_Main_.spriterender.color = Color.blue;
            player_Main_.player_Color_.HoldColor(Color.yellow, 0.5f);
        }
        else if (INPUT.instance_.Input_Move_Up())
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
        if (INPUT.instance_.Input_Shot_Charged() && !Bullet_Config.GetIsTypeCharged())
        {
            Bullet_Config.SetIsTypeCharged(true);
            // add bullet !! 
            ShootProjectile();
            // add bullet !! 
            Player_Main.instance_.player_Sound_.ChargedShooting();
            // update Record
            Record_Main.instance_.UpdateBulletCount();
            // update UI
            UI_Main.instance_.UI_BulletCount_.Update_UI();
            Bullet_Config.SetIsTypeCharged(false);

        }
        else if (INPUT.instance_.Input_Trigger_Pulled())
        {
            // add bullet !! 
            ShootProjectile();
            // update Record
            Record_Main.instance_.UpdateBulletCount();
            // update UI
            UI_Main.instance_.UI_BulletCount_.Update_UI();
        }
    }


}
