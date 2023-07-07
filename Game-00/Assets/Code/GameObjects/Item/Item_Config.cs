using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Config : MonoBehaviour
{


    protected float itemScore_;
    protected float itemHP_;

    [SerializeField] public Item_Main item_Main_;
    [SerializeField] public ActiveItems ActiveItems_;
    protected CONSTANTS.ITEM_TYPE currItemConfig_;
    protected Action methodStart_;
    protected Action methodBlinking_;
    protected Action methodEnd_;
    protected float duration_ = 3;
    protected float blinkingTime_ = 1;


    public void SetItemConfig(CONSTANTS.ITEM_TYPE newType)
    {
        currItemConfig_ = newType;
    }
    public CONSTANTS.ITEM_TYPE GetItemConfig()
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

    public abstract void Config_Init();
    public abstract void Collision_With_Player();

    public virtual void Configure_Item_Config_Accelarate()
    {
        StartCoroutine(ActiveItems_.SelectConfig(CONSTANTS.ActiveItems_CONFIG.ACCELARATE, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));

    }

    public virtual void Configure_Item_Config_BulletDamage()
    {
        StartCoroutine(ActiveItems_.SelectConfig(CONSTANTS.ActiveItems_CONFIG.INCREASE_DAMAGE, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));

    }

    public virtual void Configure_Item_Config_BulletHealth()
    {
        StartCoroutine(ActiveItems_.SelectConfig(CONSTANTS.ActiveItems_CONFIG.INCREASE_HEALTH, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));

    }

    public virtual void Configure_Item_Config_ChargedShot()
    {
        StartCoroutine(ActiveItems_.SelectConfig(CONSTANTS.ActiveItems_CONFIG.CHARGED_SHOT, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));

    }

    public virtual void Configure_Item_Config_Dash()
    {
        StartCoroutine(ActiveItems_.SelectConfig(CONSTANTS.ActiveItems_CONFIG.DASH, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));

    }

    public virtual void Configure_Item_Config_Frozen()
    {
        StartCoroutine(ActiveItems_.SelectConfig(CONSTANTS.ActiveItems_CONFIG.FROZEN, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));

    }

    public virtual void Configure_Item_Config_HP_Score()
    {
        ScoreManager.instance_.ScoreIncrease(itemScore_);
        Player_Main.instance_.player_Health_.Heal(itemHP_);
        Record_Main.instance_.records_Controller_.HighScore();
        UI_Main.instance_.UI_Health_.Update_UI();
        UI_Main.instance_.UI_Score_.Update_UI();
        item_Main_.item_Health_.Damage();
    }

    public virtual void Configure_Item_Config_HP()
    {
        Player_Main.instance_.player_Health_.Heal(itemHP_);
        UI_Main.instance_.UI_Health_.Update_UI();
        item_Main_.item_Health_.Damage();
    }

    public virtual void Configure_Item_Config_Lazer()
    {
        StartCoroutine(ActiveItems_.SelectConfig(CONSTANTS.ActiveItems_CONFIG.LAZER, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));

    }

    public virtual void Configure_Item_Config_Missile()
    {
        StartCoroutine(ActiveItems_.SelectConfig(CONSTANTS.ActiveItems_CONFIG.MISSLE, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));

    }

    public virtual void Configure_Item_Config_Random()
    {
        Action BackUpConditionIfFull = null;
        if (GENERIC.CoinToss(20, 80))
            BackUpConditionIfFull = Configure_Item_Config_HP_Score;
        else
        {
            if (GENERIC.CoinToss())
                BackUpConditionIfFull = Configure_Item_Config_HP;
            else
                BackUpConditionIfFull = Configure_Item_Config_HP_Score;
        }
        StartCoroutine(ActiveItems_.SelectConfigRandom(BackUpConditionIfFull, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));
    }

    public virtual void Configure_Item_Config_Score()
    {
        ScoreManager.instance_.ScoreIncrease(itemScore_);
        Record_Main.instance_.records_Controller_.HighScore();
        UI_Main.instance_.UI_Score_.Update_UI();
        item_Main_.item_Health_.Damage();
    }

    public virtual void Configure_Item_Config_UniformSpeed()
    {
        StartCoroutine(ActiveItems_.SelectConfig(CONSTANTS.ActiveItems_CONFIG.UNIFORM_SPEED, methodStart_, methodBlinking_, methodEnd_, duration_, blinkingTime_));

    }


}
