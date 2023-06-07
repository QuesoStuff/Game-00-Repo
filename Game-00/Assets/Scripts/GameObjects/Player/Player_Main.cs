using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Main : MonoBehaviour_Plus
{

    [SerializeField] public Player_Controller player_Controller_;
    [SerializeField] public Collision player_Collision_;
    [SerializeField] public Player_Sound player_Sound_;
    [SerializeField] public Health player_Health_;
    [SerializeField] public Move player_Move_;
    [SerializeField] public Position player_Position_;
    [SerializeField] public Direction player_Direction_;

    public static Player_Main instance_;


    void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject);
        player_Collision_.Congfigure_CollisionTables();
        player_Health_.AddToAction_OnDeath(GENERIC.RestartScene);
        player_Health_.AddToAction_OnMaxHeal(player_Sound_.FullHealth);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame()
    void Update()
    {
        if (GameState.instance_.GetGameState() == CONSTANTS.GAME_STATE.PLAY)
            player_Controller_.Move_Four_Directions();
    }
    void FixedUpdate()
    {
        player_Move_.Moving();
    }
}
