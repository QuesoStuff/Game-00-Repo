using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item_Collisiom : Collision
{
    [SerializeField] public Item_Main item_Main_;

    public override void Congfigure_table_OnTriggerEnter2D()
    {
        if (table_OnTriggerEnter2D_ == null)
        {
            table_OnTriggerEnter2D_ = new Dictionary<string, Action>();
            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Player_Tag, item_Main_.item_Config_.Collision_With_Player);
            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Player_Tag, item_Main_.item_Sound_.PlayRandomSound);
            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Player_Tag, () => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDeath_Item(transform.position, item_Main_.item_Color_.GetCurrentColor()));
            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Player_Tag, ScoreManager.ScoreIncrease);
            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Player_Tag, Record_Controller.HighScore);
            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Player_Tag, UI_Main.instance_.UI_Score_.Update_UI);
            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Player_Tag, () => item_Main_.item_Controller_.FakeKill());
        }
    }

    public override void Congfigure_table_OnTriggerStay2D()
    {
        if (table_OnTriggerStay2D_ == null)
        {
            table_OnTriggerStay2D_ = new Dictionary<string, Action>();
            Add(ref table_OnTriggerStay2D_, CONSTANTS_STRING.Wall_Tag, () => transform.position = Spawning_Level_Main.instance_.enemySpawner_.Respawn());
        }
    }

}
