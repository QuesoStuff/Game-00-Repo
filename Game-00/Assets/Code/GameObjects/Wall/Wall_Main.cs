using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Main : Main
{

    [SerializeField] public Wall_Controller wall_Controller_;
    [SerializeField] public Collision wall_Collision_;
    [SerializeField] public Wall_Sound wall_Sound_;
    [SerializeField] public MovePlus wall_Move_;
    [SerializeField] public Health wall_Health_;
    [SerializeField] public Wall_Config wall_Config_;
    [SerializeField] public Direction wall_Direction_;
    [SerializeField] public Color_General wall_Color_;




    void Awake()
    {
        wall_Config_.Config_Init();

        wall_Controller_.SetComponents();
        SetComponents();
    }

    void Start()
    {
        //wall_Config_.Config_Init();

    }
    void Update()
    {

        // rest of Update code...
    }

    void FixedUpdate()
    {
        if (wall_Config_.GetIsMoving())
        {
            wall_Move_.Moving();
            wall_Move_.Moving_Accelarate();
        }

    }
    public override void SetComponents()
    {
        wall_Controller_ = GetComponent<Wall_Controller>();
        wall_Collision_ = GetComponent<Collision>();
        wall_Sound_ = GetComponent<Wall_Sound>();
        wall_Move_ = GetComponent<MovePlus>();
        wall_Health_ = GetComponent<Health>();
        wall_Config_ = GetComponent<Wall_Config>();
        wall_Direction_ = GetComponent<Direction>();
        wall_Color_ = GetComponent<Color_General>();
    }
}
