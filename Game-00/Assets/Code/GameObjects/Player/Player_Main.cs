using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Main : Main
{

    [SerializeField] public Player_Controller player_Controller_;
    [SerializeField] public Collision player_Collision_;
    [SerializeField] public Player_Sound player_Sound_;
    [SerializeField] public Health player_Health_;
    [SerializeField] public MovePlus player_Move_;
    [SerializeField] public Direction player_Direction_;
    [SerializeField] public Color_General player_Color_;
    [SerializeField] public Player_Config player_Config_;
    [SerializeField] public UI_GameObject player_UI_;


    public static Player_Main instance_;


    void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject, false);
        SetComponents();
        player_Controller_.SetComponents();
    }


    void Start()
    {
        player_Config_.Config_Init();



    }

    void Update()
    {
        player_Controller_.Controller_Player();
        player_Controller_.Controller_Player_Dashing();


    }



    public override void SetComponents()
    {
        player_Controller_ = GetComponent<Player_Controller>();
        player_Collision_ = GetComponent<Collision>();
        player_Sound_ = GetComponent<Player_Sound>();
        player_Health_ = GetComponent<Health>();
        player_Move_ = GetComponent<MovePlus>();
        player_Direction_ = GetComponent<Direction>();
        player_Color_ = GetComponent<Color_General>();
        player_Config_ = GetComponent<Player_Config>();
        player_UI_ = GetComponentInChildren<UI_GameObject>();
    }

    void FixedUpdate()
    {
        if (ActiveItems.GetIsTypeMissle())
            player_Move_.Move_None();
        player_Move_.Moving();
        player_Move_.Moving_Accelarate();
    }
}
