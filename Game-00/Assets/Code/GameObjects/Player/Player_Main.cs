using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Main : Main
{

    [SerializeField] public Player_Controller player_Controller_;
    [SerializeField] public Collision player_Collision_;
    [SerializeField] public Player_Sound player_Sound_;
    [SerializeField] public Health player_Health_;
    [SerializeField] public Move player_Move_;
    //[SerializeField] public Position player_Position_;
    [SerializeField] public Direction player_Direction_;
    [SerializeField] public Color_General player_Color_;
    [SerializeField] public Player_Config player_Config_;
    [SerializeField] public UI_GameObject player_UI_;


    public static Player_Main instance_;

    public override Vector3 Offset(Vector2 position)
    {
        float playerRadius = transform.localScale.magnitude / 2;
        Vector3 offset = position.normalized * playerRadius;
        return offset;
    }

    void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject);
        player_Health_.AddToAction_OnDeath(() => GENERIC.RestartScene());
        player_Health_.AddToAction_OnMaxHeal(player_Sound_.FullHealth);
    }
    void Start()
    {
        player_UI_.SetComponents();

        player_Collision_.Congfigure_CollisionTables();
        RepeatStart();

    }

    void Update()
    {
        if (player_Move_.GetIsMoving() && GameState.instance_.GetGameState() == CONSTANTS.GAME_STATE.PLAY)
        {
            player_Controller_.Control();
        }

        if ((player_Move_.GetIsDashing()) && INPUT.instance_.Input_Move_Any())
        {
            if (!isAlreadyDashing_) // we start dashing
            {
                isAlreadyDashing_ = true;
                StartCoroutine(DashAndSpawn(() => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDeath(transform.position, spriterender_.color)));
            }
        }
        else
        {
            isAlreadyDashing_ = false; // we stop dashing
        }
    }


    public override void RepeatStart()
    {
        player_Config_.Config_Init();
        player_Color_.SetCurrentColor(spriterender_.color);
    }



    void FixedUpdate()
    {
        if (ActiveItems.GetIsTypeMissle())
            player_Move_.Move_None();
        player_Move_.Moving();
        player_Move_.Moving_Accelarate();
    }
}
