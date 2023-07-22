using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Main : Main
{
    [SerializeField] public Enemy_Controller enemy_Controller_;
    [SerializeField] public Collision enemy_Collision_;
    [SerializeField] public Enemy_Sound enemy_Sound_;
    [SerializeField] public MovePlus enemy_Move_;
    [SerializeField] public Health enemy_Health_;
    [SerializeField] public Enemy_Config enemy_Config_;
    [SerializeField] public Direction enemy_Direction_;
    [SerializeField] public Color_General enemy_Color_;
    [SerializeField] public UI_GameObject enemy_UI_;




    void Awake()
    {
        enemy_Controller_.SetComponents();
        SetComponents();
    }
    void Start()
    {
        TriggerEvents.OnGameFrozenChanged += enemy_Controller_.EventTrigger_FrozenEnemyColor;
        enemy_Config_.Config_Init();
    }


    void Update()
    {

        enemy_Controller_.Controller_Enemy();


    }

    void FixedUpdate()
    {
        if (!ActiveItems.GetIsFrozen())
        {
            enemy_Move_.Moving();
            enemy_Move_.Moving_Accelarate();
        }
        else
            enemy_Move_.StopMoving();
    }
    public override void SetComponents()
    {
        enemy_Controller_ = GetComponent<Enemy_Controller>();
        enemy_Collision_ = GetComponent<Collision>();
        enemy_Sound_ = GetComponent<Enemy_Sound>();
        enemy_Move_ = GetComponent<MovePlus>();
        enemy_Health_ = GetComponent<Health>();
        enemy_Config_ = GetComponent<Enemy_Config>();
        enemy_Direction_ = GetComponent<Direction>();
        enemy_Color_ = GetComponent<Color_General>();
        enemy_UI_ = GetComponentInChildren<UI_GameObject>();
    }

}
