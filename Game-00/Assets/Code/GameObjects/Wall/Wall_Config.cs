using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Wall_Config : Config
{
    [SerializeField] public Wall_Main wall_Main_;

    [SerializeField] protected bool isNormal_;
    [SerializeField] protected bool isMoving_;
    [SerializeField] protected bool isBreakable_;
    protected float currHP_;
    protected float currWallSpeed_;
    protected float currWallAcc_;
    protected Color startingColor_;
    protected Color endColor_;

    public override void Revive()
    {
        wall_Main_.wall_Controller_.Revive();
    }

    public void Config_RandomValues()
    {
        isNormal_ = GENERIC.CoinToss(90, 10);
        isMoving_ = GENERIC.CoinToss(30, 70);
        isBreakable_ = GENERIC.CoinToss(30, 70);
        currWallSpeed_ = 2.3f;
        currWallAcc_ = 0;
        currHP_ = 3;
        startingColor_ = CONSTANTS_COLOR.DEFAULT_WALL_COLOR;
        endColor_ = CONSTANTS_COLOR.DEFAULT_WALL_COLOR_2;
    }
    public void Config_MovingValues()
    {
        isNormal_ = false;
        isMoving_ = true;
        isBreakable_ = false;
        currWallSpeed_ = 2.3f;
        currWallAcc_ = 0;
        currHP_ = 2.3f;
        startingColor_ = CONSTANTS_COLOR.DEFAULT_WALL_COLOR;
        endColor_ = CONSTANTS_COLOR.DEFAULT_WALL_COLOR_2;
    }

    public void Config_BreakableValues()
    {
        isNormal_ = false;
        isMoving_ = false;
        isBreakable_ = true;
        currWallSpeed_ = 0;
        currWallAcc_ = 0;
        currHP_ = 3;
        startingColor_ = CONSTANTS_COLOR.DEFAULT_WALL_COLOR;
        endColor_ = CONSTANTS_COLOR.DEFAULT_WALL_COLOR_2;
    }

    public void Config_AllValues()
    {
        isNormal_ = false;
        isMoving_ = true;
        isBreakable_ = true;
        currWallSpeed_ = 2.3f;
        currWallAcc_ = 0;
        currHP_ = 3;
        startingColor_ = CONSTANTS_COLOR.DEFAULT_WALL_COLOR;
        endColor_ = CONSTANTS_COLOR.DEFAULT_WALL_COLOR_2;
    }

    public void Init_Random_Values()
    {
        isNormal_ = GENERIC.CoinToss(90, 10);
        isMoving_ = GENERIC.CoinToss(30, 70);
        isBreakable_ = GENERIC.CoinToss(30, 70);
        // FIND A SETUP
        currWallSpeed_ = 2.3f;
        currWallAcc_ = 0;
        currHP_ = 3;
        startingColor_ = CONSTANTS_COLOR.DEFAULT_WALL_COLOR;
        endColor_ = CONSTANTS_COLOR.DEFAULT_WALL_COLOR_2;
    }
    public override void Config_OnDeath()
    {
        OnDeath_ = () =>
{
    Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDeath(transform.position, Color.white);
    wall_Main_.wall_Controller_.FakeKill();
};
    }
    public override void Config_Init()
    {
        Init_Values();
        Init_WallConfig(currHP_, currWallSpeed_, currWallAcc_);
        Init_Color(currHP_);
        wall_Main_.wall_Collision_.Congfigure_table_OnTriggerEnter2D();
        wall_Main_.wall_Collision_.Congfigure_table_OnCollisionStay2D();
        wall_Main_.wall_Collision_.Congfigure_table_OnCollisionExit2D();
    }
    public void Init_Color(float steps = 3)
    {
        wall_Main_.wall_Color_.color_Range_ = new ColorRange(startingColor_, endColor_, (int)steps);
        wall_Main_.wall_Color_.SetNextColor();
    }

    public void Init_WallConfig(float hp = 3, float speed = 2.3f, float acc = 0)
    {
        if (wall_Main_.wall_Config_.GetIsNormal())
        {
            wall_Main_.enabled = false;
            return;
        }
        if (wall_Main_.wall_Config_.GetIsMoving())
        {
            if (GENERIC.CoinToss(40, 60))
                acc = CONSTANTS.DEFAULT_SPEED_ACC_SMALL;
            wall_Main_.wall_Move_.SetCurrentSpeed(speed);
            wall_Main_.wall_Move_.Set_AccelerateSpeed(acc);
            wall_Main_.wall_Move_.Set(speed * Direction.GenerateRandomDirection());
        }
        if (wall_Main_.wall_Config_.GetIsBreakable())
        {
            wall_Main_.wall_Health_.Set_HP(hp);
            Config_OnDeath();
            wall_Main_.wall_Health_.AddToAction_OnDeath(OnDeath_);
            //wall_Main_.wall_Health_.AddToAction_OnDeath(() => wall_Main_.Kill());
        }
    }




    // Getter methods for the boolean fields
    public bool GetIsNormal()
    {
        return isNormal_;
    }

    public bool GetIsMoving()
    {
        return isMoving_;
    }

    public bool GetIsBreakable()
    {
        return isBreakable_;
    }

}
