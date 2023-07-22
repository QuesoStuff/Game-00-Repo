using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Config : MonoBehaviour, I_Init_Values
{
    protected Action OnDeath_;

    public abstract void Revive();
    public abstract void Config_Init();
    public abstract void Config_OnDeath();
    public abstract void Init_Values();


    void Start()
    {
        TriggerEvents.OnGameRestarted += Config_Init;


    }

}
