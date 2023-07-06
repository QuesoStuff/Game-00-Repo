using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Config : MonoBehaviour
{


    protected float itemScore_;
    protected float itemHP_;

    [SerializeField] public Item_Main item_Main_;
    [SerializeField] protected ACTIVE active_;
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




}
