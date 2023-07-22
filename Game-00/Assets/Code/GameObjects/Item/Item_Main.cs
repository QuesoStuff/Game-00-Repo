using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Main : Main
{


    [SerializeField] public Item_Controller item_Controller_;
    [SerializeField] public Collision item_Collision_;
    [SerializeField] public Item_Sound item_Sound_;
    [SerializeField] public MovePlus item_Move_;
    [SerializeField] public Health item_Health_;
    [SerializeField] public Item_Config item_Config_;
    [SerializeField] public Direction item_Direction_;
    [SerializeField] public Color_General item_Color_;




    void Awake()
    {
        item_Controller_.SetComponents();
        SetComponents();
    }

    void Start()
    {
        item_Config_.Config_Init();


    }

    void Update()
    {
        item_Controller_.Rotate();
    }

    public override void SetComponents()
    {
        item_Controller_ = GetComponent<Item_Controller>();
        item_Collision_ = GetComponent<Collision>();
        item_Sound_ = GetComponent<Item_Sound>();
        item_Move_ = GetComponent<MovePlus>();
        item_Health_ = GetComponent<Health>();
        item_Config_ = GetComponent<Item_Config>();
        item_Direction_ = GetComponent<Direction>();
        item_Color_ = GetComponent<Color_General>();
    }
}
