using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Config : Config
{
    [SerializeField] public Player_Main player_Main_;
    [SerializeField] private float ConfigHP_ = CONSTANTS.DEFAULT_PLAYER_STARTER_HEALTH;
    [SerializeField] private float ConfigMaxHP_ = CONSTANTS.DEFAULT_MAX_HEALTH;
    [SerializeField] private float configSpeed = CONSTANTS.DEFAULT_SPEED;


    public override void Revive()
    {
        player_Main_.player_Controller_.Revive();
    }

    public override void Config_OnDeath()
    {
        OnDeath_ = () =>
        {
            //LoadingScene.instance_.LoadStartScene;
            //player_Main_.player_Health_.Set_HP(CONSTANTS.DEFAULT_STARTER_HEALTH);
            //UI_Main.instance_.UI_Health_.Update_UI();
        };
    }


    // Start is called before the first frame update
    public override void Init_Values()
    {
        player_Main_.player_Color_.SetCurrentColor_SetColor();
        player_Main_.player_Health_.Set_HP(ConfigHP_);
        player_Main_.player_Health_.Set_Max_HP(ConfigMaxHP_);
        player_Main_.player_Move_.SetCurrentSpeed(configSpeed);

        player_Main_.player_Controller_.InitDash();
        player_Main_.player_UI_.SetComponents();
    }

    public override void Config_Init()
    {
        Init_Values();
        Config_OnDeath();
        player_Main_.player_Health_.AddToAction_OnDeath(OnDeath_);
        player_Main_.player_Health_.AddToAction_OnMaxHeal(player_Main_.player_Sound_.FullHealth);
        player_Main_.player_Collision_.Congfigure_table_OnCollisionEnter2D();
        player_Main_.player_Collision_.Congfigure_table_OnCollisionExit2D();
        player_Main_.player_Collision_.Congfigure_table_OnTriggerEnter2D();
        player_Main_.player_Collision_.Congfigure_table_OnTriggerExit2D();



    }

}
