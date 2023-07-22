using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Config : Config, I_SetComponents
{


    protected float itemScore_;
    protected float itemHP_;

    [SerializeField] public Item_Main item_Main_;
    [SerializeField] public ActiveItems ActiveItems_;
    protected CONSTANTS_ENUM.ITEM_TYPE currItemConfig_;
    protected Action methodStart_;
    protected Action methodBlinking_;
    protected Action methodEnd_;
    protected float duration_ = CONSTANTS.DEFAULT_DURATION_ITEM_LIFETIME;
    protected float blinkingTime_ = CONSTANTS.DEFAULT_DURATION_BLINKING_UI;
    public override void Revive()
    {
        item_Main_.item_Controller_.Revive();
    }


    public void SetComponents()
    {
        GameObject activeItemsGameObject = GameObject.FindGameObjectWithTag(CONSTANTS_STRING.ActiveItems_Tag);
        ActiveItems_ = activeItemsGameObject.GetComponent<ActiveItems>();
    }

    public override void Config_OnDeath()
    {
        OnDeath_ = () =>
     {
         item_Main_.item_Controller_.FakeKill();
     };
    }
    public override void Config_Init()
    {
        Init_Values();
        if (currItemConfig_ != CONSTANTS_ENUM.ITEM_TYPE.SCORE &&
        currItemConfig_ != CONSTANTS_ENUM.ITEM_TYPE.HP &&
        currItemConfig_ != CONSTANTS_ENUM.ITEM_TYPE.HP_AND_SCORE)
            SetComponents();

        Config_OnDeath();
        item_Main_.item_Color_.SetRandomColor();
        item_Main_.item_Health_.AddToAction_OnDeath(OnDeath_);

        item_Main_.item_Collision_.Congfigure_table_OnTriggerEnter2D();
        item_Main_.item_Collision_.Congfigure_table_OnTriggerStay2D();
        item_Main_.item_Controller_.ConfigStartRotate();
        item_Main_.item_Controller_.ConfigRotateSpeed();
        item_Main_.item_Controller_.SideRotate();

    }
    public void SetItemConfig(CONSTANTS_ENUM.ITEM_TYPE newType)
    {
        currItemConfig_ = newType;
    }
    public CONSTANTS_ENUM.ITEM_TYPE GetItemConfig()
    {
        return currItemConfig_;
    }

    public void SetItemScore(float score)
    {
        itemScore_ = score;
    }
    public float GetItemScore()
    {
        return itemScore_;
    }
    public void SetItemHP(float hp)
    {
        itemHP_ = hp;
    }
    public float GetItemHP()
    {
        return itemHP_;
    }

    public abstract void Collision_With_Player();

    public virtual void Collision_Item_Config_Accelarate()
    {
        StartCoroutine(ActiveItems_.SelectConfig(CONSTANTS_ENUM.ACTIVE_ITEM_CONFIG.ACCELARATE, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));

    }

    public virtual void Collision_Item_Config_BulletDamage()
    {
        StartCoroutine(ActiveItems_.SelectConfig(CONSTANTS_ENUM.ACTIVE_ITEM_CONFIG.INCREASE_DAMAGE, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));

    }

    public virtual void Collision_Item_Config_BulletHealth()
    {
        StartCoroutine(ActiveItems_.SelectConfig(CONSTANTS_ENUM.ACTIVE_ITEM_CONFIG.INCREASE_HEALTH, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));

    }

    public virtual void Collision_Item_Config_ChargedShot()
    {
        StartCoroutine(ActiveItems_.SelectConfig(CONSTANTS_ENUM.ACTIVE_ITEM_CONFIG.CHARGED_SHOT, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));

    }

    public virtual void Collision_Item_Config_Dash()
    {
        StartCoroutine(ActiveItems_.SelectConfig(CONSTANTS_ENUM.ACTIVE_ITEM_CONFIG.DASH, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));

    }

    public virtual void Collision_Item_Config_Frozen()
    {
        StartCoroutine(ActiveItems_.SelectConfig(CONSTANTS_ENUM.ACTIVE_ITEM_CONFIG.FROZEN, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));

    }

    public virtual void Collision_Item_Config_HP_Score()
    {
        ScoreManager.ScoreIncrease(itemScore_);
        Player_Main.instance_.player_Health_.Heal(itemHP_);
        Record_Controller.AddToTotalHeal(itemHP_);

        Record_Controller.HighScore();
        UI_Main.instance_.UI_Health_.Update_UI();
        UI_Main.instance_.UI_Score_.Update_UI();
        item_Main_.item_Health_.Damage();
    }

    public virtual void Collision_Item_Config_HP()
    {
        Player_Main.instance_.player_Health_.Heal(itemHP_);
        Record_Controller.AddToTotalHeal(itemHP_);

        UI_Main.instance_.UI_Health_.Update_UI();
        item_Main_.item_Health_.Damage();
    }

    public virtual void Collision_Item_Config_Lazer()
    {
        StartCoroutine(ActiveItems_.SelectConfig(CONSTANTS_ENUM.ACTIVE_ITEM_CONFIG.LAZER, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));

    }

    public virtual void Collision_Item_Config_Missile()
    {
        StartCoroutine(ActiveItems_.SelectConfig(CONSTANTS_ENUM.ACTIVE_ITEM_CONFIG.MISSLE, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));

    }

    public virtual void Collision_Item_Config_Random()
    {
        Action BackUpConditionIfFull = null;
        if (GENERIC.CoinToss(20, 80))
            BackUpConditionIfFull = Collision_Item_Config_HP_Score;
        else
        {
            if (GENERIC.CoinToss())
                BackUpConditionIfFull = Collision_Item_Config_HP;
            else
                BackUpConditionIfFull = Collision_Item_Config_HP_Score;
        }
        StartCoroutine(ActiveItems_.SelectConfigRandom(BackUpConditionIfFull, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));
    }

    public virtual void Collision_Item_Config_Score()
    {
        ScoreManager.ScoreIncrease(itemScore_);
        Record_Controller.HighScore();
        UI_Main.instance_.UI_Score_.Update_UI();
        item_Main_.item_Health_.Damage();
    }

    public virtual void Collision_Item_Config_UniformSpeed()
    {
        StartCoroutine(ActiveItems_.SelectConfig(CONSTANTS_ENUM.ACTIVE_ITEM_CONFIG.UNIFORM_SPEED, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));

    }

    public void Init_Values_UniformSpeed()
    {
        currItemConfig_ = CONSTANTS_ENUM.ITEM_TYPE.UNIFORM_SPEED;
        methodStart_ = UI_Main.instance_.UI_Bullet_Mod_.Update_UI;
        methodBlinking_ = UI_Main.instance_.UI_Bullet_Mod_.BlinkTextIndefinitely;
        methodEnd_ = UI_Main.instance_.UI_Bullet_Mod_.Update_UI;
        methodEnd_ += () => item_Main_.item_Health_.Damage();
    }

    public void Init_Values_Score()
    {
        currItemConfig_ = CONSTANTS_ENUM.ITEM_TYPE.SCORE;
        itemScore_ = ScoreManager.AssignScore(CONSTANTS.DEFAULT_SCORE_EXTRA);
    }

    public void Init_Values_Random()
    {
        methodStart_ = UI_Main.instance_.UI_Item_.Update_UI;
        methodStart_ += () => TriggerEvents.TriggerEvent_FrozenEnemy(true);
        methodBlinking_ = UI_Main.instance_.UI_Item_.BlinkTextIndefinitely;
        methodEnd_ = UI_Main.instance_.UI_Item_.StopBlinking;
        methodEnd_ += UI_Main.instance_.UI_Item_.Update_UI;
        methodEnd_ += () => item_Main_.item_Health_.Damage();
        methodEnd_ += () => TriggerEvents.TriggerEvent_FrozenEnemy(false);

    }
    public void Config_Init_Missile()
    {
        currItemConfig_ = CONSTANTS_ENUM.ITEM_TYPE.MISSLE;
        methodStart_ = UI_Main.instance_.UI_Bullet_Mod_.Update_UI;

        methodBlinking_ = UI_Main.instance_.UI_Bullet_Mod_.BlinkTextIndefinitely;

        methodEnd_ = UI_Main.instance_.UI_Bullet_Mod_.StopBlinking;
        methodEnd_ += UI_Main.instance_.UI_Bullet_Mod_.Update_UI;
        methodEnd_ += () => item_Main_.item_Health_.Damage();

    }

    public void Config_Init_Lazer()
    {
        currItemConfig_ = CONSTANTS_ENUM.ITEM_TYPE.LAZER;

        methodStart_ = UI_Main.instance_.UI_Bullet_Mod_.Update_UI;

        methodBlinking_ = UI_Main.instance_.UI_Bullet_Mod_.BlinkTextIndefinitely;

        methodEnd_ = UI_Main.instance_.UI_Bullet_Mod_.StopBlinking;
        methodEnd_ += UI_Main.instance_.UI_Bullet_Mod_.Update_UI;
        methodEnd_ += () => item_Main_.item_Health_.Damage();

    }

    public void Config_Init_HP()
    {
        currItemConfig_ = CONSTANTS_ENUM.ITEM_TYPE.HP;
        itemHP_ = item_Main_.item_Health_.Get_Heal();
    }

    public void Config_Init_HP_Score()
    {
        currItemConfig_ = CONSTANTS_ENUM.ITEM_TYPE.HP_AND_SCORE;
        itemScore_ = ScoreManager.AssignScore();
        itemHP_ = item_Main_.item_Health_.Get_Heal();
    }

    public void Config_Init_Frozen()
    {
        currItemConfig_ = CONSTANTS_ENUM.ITEM_TYPE.FROZEN;
        methodStart_ = UI_Main.instance_.UI_Item_.Update_UI;
        methodStart_ += () => TriggerEvents.TriggerEvent_FrozenEnemy(true);

        methodBlinking_ = UI_Main.instance_.UI_Item_.BlinkTextIndefinitely;

        methodEnd_ = UI_Main.instance_.UI_Item_.StopBlinking;
        methodEnd_ += UI_Main.instance_.UI_Item_.Update_UI;
        methodEnd_ += () => item_Main_.item_Health_.Damage();
        methodEnd_ += () => TriggerEvents.TriggerEvent_FrozenEnemy(false);

    }

    public void Config_Init_Dash()
    {
        currItemConfig_ = CONSTANTS_ENUM.ITEM_TYPE.DASH;
        methodStart_ = UI_Main.instance_.UI_Item_.Update_UI;
        methodStart_ += () => Player_Main.instance_.player_Controller_.Item_Dash(15 - 3);


        methodBlinking_ = UI_Main.instance_.UI_Item_.BlinkTextIndefinitely;

        methodEnd_ = UI_Main.instance_.UI_Item_.StopBlinking;
        methodEnd_ += UI_Main.instance_.UI_Item_.Update_UI;
        methodEnd_ += () => item_Main_.item_Health_.Damage();

    }

    public void Config_Init_ChargedShot()
    {
        currItemConfig_ = CONSTANTS_ENUM.ITEM_TYPE.CHARGED_SHOT;
        methodStart_ = UI_Main.instance_.UI_Bullet_Mod_.Update_UI;

        methodBlinking_ = UI_Main.instance_.UI_Bullet_Mod_.BlinkTextIndefinitely;

        methodEnd_ = UI_Main.instance_.UI_Bullet_Mod_.StopBlinking;
        methodEnd_ += UI_Main.instance_.UI_Bullet_Mod_.Update_UI;
        methodEnd_ += () => item_Main_.item_Health_.Damage();
    }

    public void Config_Init_BulletHealth()
    {
        currItemConfig_ = CONSTANTS_ENUM.ITEM_TYPE.INCREASE_HEALTH;
        methodStart_ = UI_Main.instance_.UI_Bullet_Mod_.Update_UI;

        methodBlinking_ = UI_Main.instance_.UI_Bullet_Mod_.BlinkTextIndefinitely;

        methodEnd_ = UI_Main.instance_.UI_Bullet_Mod_.StopBlinking;
        methodEnd_ += UI_Main.instance_.UI_Bullet_Mod_.Update_UI;
        methodEnd_ += () => item_Main_.item_Health_.Damage();
    }

    public void Config_Init_BulletDamage()
    {
        currItemConfig_ = CONSTANTS_ENUM.ITEM_TYPE.INCREASE_DAMAGE;
        methodStart_ = UI_Main.instance_.UI_Bullet_Mod_.Update_UI;

        methodBlinking_ = UI_Main.instance_.UI_Bullet_Mod_.BlinkTextIndefinitely;

        methodEnd_ = UI_Main.instance_.UI_Bullet_Mod_.StopBlinking;
        methodEnd_ += UI_Main.instance_.UI_Bullet_Mod_.Update_UI;
        methodEnd_ += () => item_Main_.item_Health_.Damage();

    }

    public void Config_Init_Accelarat()
    {
        currItemConfig_ = CONSTANTS_ENUM.ITEM_TYPE.ACCELARATE;
        methodStart_ = UI_Main.instance_.UI_Bullet_Mod_.Update_UI;

        methodBlinking_ = UI_Main.instance_.UI_Bullet_Mod_.BlinkTextIndefinitely;

        methodEnd_ = UI_Main.instance_.UI_Bullet_Mod_.StopBlinking;
        methodEnd_ += UI_Main.instance_.UI_Bullet_Mod_.Update_UI;

        methodEnd_ += () => item_Main_.item_Health_.Damage();

    }
}
