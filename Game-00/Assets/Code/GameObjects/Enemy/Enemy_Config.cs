using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy_Config : Config
{
    [SerializeField] public Enemy_Main enemy_Main_;
    private Vector2 currInput_;
    Color startColor_ = CONSTANTS_COLOR.DEFAULT_ENEMY_COLOR;

    protected List<Func<bool>> methods_ = new List<Func<bool>>();
    private List<Vector2> inputPairs_ = new List<Vector2>();


    public abstract void ConfigureMethods();
    public override void Revive()
    {
        enemy_Main_.enemy_Controller_.Revive();
    }

    public override void Config_OnDeath()
    {
        OnDeath_ = () =>
        {
            Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDeath(transform.position, enemy_Main_.enemy_Color_.GetCurrentColor());
            enemy_Main_.enemy_Controller_.FakeKill();
            Record_Controller.KillCount();
            UI_Main.instance_.UI_KillCount_.Update_UI();
            ScoreManager.ScoreIncrease();
            UI_Main.instance_.UI_Score_.Update_UI();
        };
    }
    public override void Init_Values()
    {
        enemy_Main_.enemy_Config_.ConfigureMethods();
        enemy_Main_.enemy_Health_.Set_Random_Health();
        enemy_Main_.enemy_Move_.Set_Random_Speed();
        enemy_Main_.enemy_Config_.AssignMovement();
        enemy_Main_.enemy_Config_.Config_Color();
    }
    public override void Config_Init()
    {
        Init_Values();
        StartCoroutine(enemy_Main_.enemy_Controller_.InvokeMovement());

        Config_OnDeath();
        enemy_Main_.enemy_Health_.AddToAction_OnDeath(OnDeath_);


        enemy_Main_.enemy_Collision_.Congfigure_table_OnCollisionEnter2D();

        enemy_Main_.enemy_Collision_.Congfigure_table_OnTriggerEnter2D();

        enemy_Main_.enemy_Collision_.Congfigure_table_OnTriggerExit2D();


    }

    public virtual void AssignMovement()
    {
        inputPairs_ = new List<Vector2>(methods_.Count);
        foreach (var _ in methods_)
        {
            System.Random rand = new System.Random();
            float x = rand.Next(-1, 2);
            float y;

            if (x == 0)
            {
                // If x is 0, y can be either -1 or 1, but not 0.
                int randomValue = rand.Next(2);
                if (randomValue == 0)
                {
                    y = -1;
                }
                else
                {
                    y = 1;
                }
            }
            else
            {
                // If x is not 0, y can be -1, 0 or 1.
                y = rand.Next(-1, 2);
            }

            inputPairs_.Add(new Vector2(x, y));
        }
    }


    public void InputValid()
    {
        currInput_ = Vector2.zero;
        for (int i = 0; i < methods_.Count; i++)
        {
            if (methods_[i]())
            {
                currInput_ = inputPairs_[i];
                break;
            }
        }
    }

    public Vector2 Get_Input()
    {
        return currInput_;
    }

    public void Config_Color()
    {
        int hp = (int)enemy_Main_.enemy_Health_.GetCurrHP();
        Color randomColor = GENERIC.RandomColor();
        enemy_Main_.enemy_Color_.color_Range_ = new ColorRange(startColor_, randomColor, (int)hp);
        enemy_Main_.enemy_Color_.SetNextColor();
    }



    public virtual void ConfigureMethods_All()
    {
        methods_ = new List<Func<bool>>()
        {
            INPUT.Input_Move_Up,
            INPUT.Input_Move_Down,
            INPUT.Input_Move_Left,
            INPUT.Input_Move_Right,
            INPUT.Input_Tap_Up,
            INPUT.Input_Tap_Down,
            INPUT.Input_Tap_Left,
            INPUT.Input_Tap_Right,
            INPUT.Input_Move_Up_Stop,
            INPUT.Input_Move_Down_Stop,
            INPUT.Input_Move_Left_Stop,
            INPUT.Input_Move_Right_Stop,
            INPUT.Input_Trigger_Pulled,
            INPUT.Input_Trigger_Release,
            INPUT.Input_Trigger_Rapid,
            INPUT.Input_Idle,
            INPUT.Input_Dash_Move,
            INPUT.Input_Shot_Rapid,
            INPUT.Input_Shot_Charged,
            INPUT.Input_Charged_Valid,
            INPUT.Input_Pause_Resume
        };
    }
    public virtual void ConfigureMethods_Bullet()
    {
        methods_ = new List<Func<bool>>()
        {
            INPUT.Input_Trigger_Pulled,
            INPUT.Input_Trigger_Release,
            INPUT.Input_Trigger_Rapid,
                        INPUT.Input_Shot_Charged,
            INPUT.Input_Charged_Valid,
                        INPUT.Input_Shot_Rapid
        };
    }
    public virtual void ConfigureMethods_BulletPlus()
    {
        methods_ = new List<Func<bool>>()
        {
            INPUT.Input_Trigger_Pulled,
            INPUT.Input_Trigger_Release,
            INPUT.Input_Trigger_Rapid,
                        INPUT.Input_Shot_Charged,
            INPUT.Input_Charged_Valid,
                        INPUT.Input_Shot_Rapid,
            INPUT.Input_Idle
        };
    }

    public virtual void ConfigureMethods_Idle()
    {
        methods_ = new List<Func<bool>>()
        {
            INPUT.Input_Idle
        };
    }
    public virtual void ConfigureMethods_Move()
    {
        methods_ = new List<Func<bool>>()
        {
            INPUT.Input_Move_Up,
            INPUT.Input_Move_Down,
            INPUT.Input_Move_Left,
            INPUT.Input_Move_Right,

        };
    }
    public virtual void ConfigureMethods_MovePlus()
    {
        methods_ = new List<Func<bool>>()
        {
            INPUT.Input_Move_Up,
            INPUT.Input_Move_Down,
            INPUT.Input_Move_Left,
            INPUT.Input_Move_Right,
            INPUT.Input_Idle

        };
    }
    public virtual void ConfigureMethods_Stop()
    {
        methods_ = new List<Func<bool>>()
        {
            INPUT.Input_Move_Up_Stop,
            INPUT.Input_Move_Down_Stop,
            INPUT.Input_Move_Left_Stop,
            INPUT.Input_Move_Right_Stop
        };
    }

    public virtual void ConfigureMethods_StopPlus()
    {
        methods_ = new List<Func<bool>>()
        {
            INPUT.Input_Move_Up_Stop,
            INPUT.Input_Move_Down_Stop,
            INPUT.Input_Move_Left_Stop,
            INPUT.Input_Move_Right_Stop,
            INPUT.Input_Idle

        };
    }
    public virtual void ConfigureMethods_Tap()
    {
        methods_ = new List<Func<bool>>()
        {
            INPUT.Input_Tap_Up,
            INPUT.Input_Tap_Down,
            INPUT.Input_Tap_Left,
            INPUT.Input_Tap_Right
        };
    }
    public virtual void ConfigureMethods_TapPlus()
    {
        methods_ = new List<Func<bool>>()
        {
            INPUT.Input_Tap_Up,
            INPUT.Input_Tap_Down,
            INPUT.Input_Tap_Left,
            INPUT.Input_Tap_Right,
                        INPUT.Input_Idle

        };
    }
}
