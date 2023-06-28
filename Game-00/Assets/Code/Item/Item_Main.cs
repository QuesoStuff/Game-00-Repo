using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Main : MonoBehaviour_Plus
{


    [SerializeField] public Item_Controller item_Controller_;
    [SerializeField] public Collision item_Collision_;
    [SerializeField] public Item_Sound item_Sound_;
    [SerializeField] public Move item_Move_;
    [SerializeField] public Health item_Health_;
    [SerializeField] public Item_Config item_Config_;
    [SerializeField] public Direction item_Direction_;
    [SerializeField] public Color_General item_Color_;



    void Awake()
    {
        // Get a random number between 0 and 3
        float randomValue = UnityEngine.Random.Range(0, 3);
        randomValue = 2.75f;
        // Check if the random value is less than 1, in which case assign one tag, otherwise assign the other
        if (randomValue < 1)
        {
            gameObject.tag = CONSTANTS.Item_Score_Tag;
        }
        else if (randomValue < 2)
        {
            gameObject.tag = CONSTANTS.Item_Health_Tag;
        }
        else
        {
            gameObject.tag = CONSTANTS.Item_Special_Tag;
        }

    }


    void Start()
    {
        item_Health_.AddToAction_OnDeath(() => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDeath_Item(transform.position, spriterender_.color));

        item_Health_.AddToAction_OnDeath(Kill);
        item_Collision_.Congfigure_CollisionTables();

    }

    void Update()
    {
        Rotate(250);
    }
}
