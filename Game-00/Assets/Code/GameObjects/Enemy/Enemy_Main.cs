using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Main : MonoBehaviour_Plus
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


    private void OnEnable()
    {
        ACTIVE.OnGameFrozenChanged += HandleGameFrozenChanged;
    }

    private void OnDisable()
    {
        ACTIVE.OnGameFrozenChanged -= HandleGameFrozenChanged;
    }

    private void HandleGameFrozenChanged(bool isFrozen)
    {
        if (isFrozen)
        {
            enemy_Color_.SetColor(Color.white);
        }
        else
        {
            enemy_Color_.SetColor();
        }
    }

    private void Awake()
    {

    }

    void Start()
    {
        enemy_Config_.ConfigureMethods();
        enemy_Health_.Set_Random_Health();
        enemy_Move_.Set_Random_Speed();


        enemy_Health_.AddToAction_OnDeath(() => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDeath(transform.position, spriterender_.color));
        enemy_Health_.AddToAction_OnDeath(() => Kill());
        enemy_Health_.AddToAction_OnDeath(Record_Main.instance_.records_Controller_.KillCount);
        enemy_Health_.AddToAction_OnDeath(UI_Main.instance_.UI_KillCount_.Update_UI);
        enemy_Health_.AddToAction_OnDeath(ScoreManager.instance_.ScoreIncrease);
        enemy_Health_.AddToAction_OnDeath(UI_Main.instance_.UI_Score_.Update_UI);

        enemy_Config_.AssignMovement();
        enemy_Config_.Config_Color();

        enemy_Collision_.Congfigure_CollisionTables();
        StartCoroutine(enemy_Controller_.InvokeMovement());
        ACTIVE.OnGameFrozenChanged += enemy_Controller_.EventTrigger_FrozenEnemyColor;
    }


    void Update()
    {

        if (ACTIVE.GetIsFrozen())
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
        if (!ACTIVE.GetIsFrozen())
        {
            enemy_Move_.Moving();
            enemy_Move_.Moving_Accelarate();
        }
        else
            enemy_Move_.StopMoving();
    }


}
