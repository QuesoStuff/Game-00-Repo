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

    void Start()
    {

        enemy_Health_.AddToAction_OnDeath(() => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDeath(transform.position, spriterender_.color));
        enemy_Health_.AddToAction_OnDeath(Kill);
        enemy_Health_.AddToAction_OnDeath(Record_Main.instance_.records_Controller_.KillCount);
        enemy_Health_.AddToAction_OnDeath(UI_Main.instance_.UI_KillCount_.Update_UI);

        enemy_Config_.Config_Chaos();
        enemy_Controller_.Color();

        enemy_Collision_.Congfigure_CollisionTables();
        StartCoroutine(InvokeMovement());

    }
    IEnumerator InvokeMovement()
    {
        while (true)
        {
            enemy_Controller_.Randomize();
            yield return new WaitForSeconds(5);
        }
    }
    void Update()
    {
        enemy_Controller_.UpdateMovement();
    }

    void FixedUpdate()
    {
        enemy_Move_.Moving();
    }


}
