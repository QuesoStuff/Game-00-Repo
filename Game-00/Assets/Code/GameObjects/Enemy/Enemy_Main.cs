using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Main : Main
{
    [SerializeField] public Enemy_Controller enemy_Controller_;
    [SerializeField] public Collision enemy_Collision_;
    [SerializeField] public Enemy_Sound enemy_Sound_;
    [SerializeField] public Move enemy_Move_;
    [SerializeField] public Health enemy_Health_;
    [SerializeField] public Enemy_Config enemy_Config_;
    [SerializeField] public Direction enemy_Direction_;
    [SerializeField] public Color_General enemy_Color_;
    [SerializeField] public UI_GameObject enemy_UI_;




    private void Awake()
    {

    }
    public override void RepeatStart()
    {
        enemy_Config_.ConfigureMethods();
        enemy_Health_.Set_Random_Health();
        enemy_Move_.Set_Random_Speed();
        enemy_Config_.AssignMovement();
        enemy_Config_.Config_Color();
        StartCoroutine(enemy_Controller_.InvokeMovement());

    }
    void Start()
    {




        enemy_Health_.AddToAction_OnDeath(() => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDeath(transform.position, spriterender_.color));
        enemy_Health_.AddToAction_OnDeath(() => FakeKill());
        enemy_Health_.AddToAction_OnDeath(Record_Main.instance_.records_Controller_.KillCount);
        enemy_Health_.AddToAction_OnDeath(UI_Main.instance_.UI_KillCount_.Update_UI);
        enemy_Health_.AddToAction_OnDeath(ScoreManager.instance_.ScoreIncrease);
        enemy_Health_.AddToAction_OnDeath(UI_Main.instance_.UI_Score_.Update_UI);


        enemy_Collision_.Congfigure_CollisionTables();
        TriggerEvents.OnGameFrozenChanged += enemy_Controller_.EventTrigger_FrozenEnemyColor;
        RepeatStart();
    }


    void Update()
    {

        if (ActiveItems.GetIsFrozen())
        {
            enemy_Color_.SetColor(Color.white);
        }
        else
        {
            enemy_Controller_.UpdateMovement();
        }


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


}
