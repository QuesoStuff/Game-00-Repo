using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Main : Main
{
    [SerializeField] public Door_Controller door_Controller_;
    [SerializeField] public Collision door_Collision_;
    [SerializeField] public Door_Sound sound_Sound_;
    [SerializeField] public Move door_Move_;
    [SerializeField] public Health door_Health_;
    [SerializeField] public Door_Config door_Config_;
    [SerializeField] public Direction door_Direction_;
    [SerializeField] public Color_General door_Color_;
    [SerializeField] internal Transform teleport_;

    void Start()
    {
        TriggerEvents.OnGamePausedChanged += door_Controller_.EventTrigger_PauseFading;
        FadeInOut();
        door_Collision_.Congfigure_CollisionTables();
        RepeatStart();
    }

    void Update()
    {

    }
    public override void RepeatStart()
    {
        door_Config_.Config_Random();
    }

}
