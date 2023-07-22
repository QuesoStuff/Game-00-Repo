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

    void Awake()
    {
        SetComponents();
        door_Controller_.SetComponents();
    }
    void Start()
    {
        TriggerEvents.OnGamePausedChanged += door_Controller_.EventTrigger_PauseFading;
        door_Config_.Config_Init();

    }

    void Update()
    {

    }

    public override void SetComponents()
    {
        door_Controller_ = GetComponent<Door_Controller>();
        door_Collision_ = GetComponent<Collision>();
        sound_Sound_ = GetComponent<Door_Sound>();
        door_Move_ = GetComponent<Move>();
        door_Health_ = GetComponent<Health>();
        door_Config_ = GetComponent<Door_Config>();
        door_Direction_ = GetComponent<Direction>();
        door_Color_ = GetComponent<Color_General>();
    }

}
