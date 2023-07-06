using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Collisiom : Collision
{
    [SerializeField] public Item_Main item_Main_;

    public override void Congfigure_table_OnTriggerEnter2D()
    {
        Add(table_OnTriggerEnter2D_, CONSTANTS.Player_Tag, item_Main_.item_Config_.Collision_With_Player);

        Add(table_OnTriggerEnter2D_, CONSTANTS.Player_Tag, item_Main_.item_Sound_.PlayRandomSound);
        Add(table_OnTriggerEnter2D_, CONSTANTS.Player_Tag, () => Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDeath_Item(transform.position, item_Main_.spriterender_.color));
        Add(table_OnTriggerEnter2D_, CONSTANTS.Player_Tag, ScoreManager.instance_.ScoreIncrease);
        Add(table_OnTriggerEnter2D_, CONSTANTS.Player_Tag, Record_Main.instance_.records_Controller_.HighScore);
        Add(table_OnTriggerEnter2D_, CONSTANTS.Player_Tag, UI_Main.instance_.UI_Score_.Update_UI);
        Add(table_OnTriggerEnter2D_, CONSTANTS.Player_Tag, () => item_Main_.FakeKill());

    }

    public override void Congfigure_table_OnTriggerStay2D()
    {
        //Add(table_OnTriggerStay2D_, CONSTANTS.Wall_Tag, () => item_Main_.item_Health_.Damage());
        // to be fixed , essentially if item spawns inside wall make it spaw n somewhere else
        Add(table_OnTriggerStay2D_, CONSTANTS.Wall_Tag, () => item_Main_.transform.position = Spawning_Level_Main.instance_.enemySpawner_.Respawn());
    }


}
