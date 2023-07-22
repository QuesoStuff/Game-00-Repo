using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : Collision
{
    [SerializeField] public Player_Main player_Main_;

    public override void Congfigure_table_OnCollisionEnter2D()
    {
        if (table_OnCollisionEnter2D_ == null)
        {
            table_OnCollisionEnter2D_ = new Dictionary<string, Action>();
            Add(ref table_OnCollisionEnter2D_, CONSTANTS_STRING.Enemy_Tag, () => StartCoroutine(player_Main_.player_Move_.KnockBack()));
            Add(ref table_OnCollisionEnter2D_, CONSTANTS_STRING.Enemy_Tag, player_Main_.player_Color_.WhiteFlash);
            Add(ref table_OnCollisionEnter2D_, CONSTANTS_STRING.Enemy_Tag, UI_Main.instance_.UI_Health_.Update_UI);
        }
    }
    public override void Congfigure_table_OnCollisionExit2D()
    {
        if (table_OnCollisionEnter2D_ == null)
        {
            table_OnCollisionEnter2D_ = new Dictionary<string, Action>();
            Add(ref table_OnCollisionEnter2D_, CONSTANTS_STRING.Enemy_Tag, player_Main_.player_UI_.Update_UI);
        }
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == CONSTANTS_STRING.Enemy_Tag)
        {
            Enemy_Main enemy_Main = collision.gameObject.GetComponent<Enemy_Main>();
            float enemyDamage = enemy_Main.enemy_Health_.Get_Damage();
            Record_Controller.AddToTotoalDamage(enemyDamage);
            player_Main_.player_Health_.Damage(enemyDamage);
            StartCoroutine(player_Main_.player_UI_.ShowHPChange(enemyDamage, false));

        }
        base.OnCollisionEnter2D(collision);
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == CONSTANTS_STRING.Item_Tag)
        {
            Item_Main item_Main = other.gameObject.GetComponent<Item_Main>();
            float itemHeal = item_Main.item_Health_.Get_Heal();
            if (itemHeal != 0)
            {
                Record_Controller.AddToTotalHeal(itemHeal);
                StartCoroutine(player_Main_.player_UI_.ShowHPChange(itemHeal, true));
            }
        }
        base.OnTriggerEnter2D(other);
    }


    public override void Congfigure_table_OnTriggerEnter2D()
    {
        if (table_OnTriggerEnter2D_ == null)
        {
            table_OnTriggerEnter2D_ = new Dictionary<string, Action>();
            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Door_Tag, player_Main_.player_Sound_.BumpIntoWall);
            Add(ref table_OnTriggerEnter2D_, CONSTANTS_STRING.Door_Tag, () => player_Main_.player_Controller_.SetIsTeleport(true));
        }
    }
    public override void Congfigure_table_OnTriggerExit2D()
    {
        if (table_OnTriggerExit2D_ == null)
        {
            table_OnTriggerExit2D_ = new Dictionary<string, Action>();
            Add(ref table_OnTriggerExit2D_, CONSTANTS_STRING.Door_Exit_Tag, () => player_Main_.player_Controller_.SetIsTeleport(false));
        }

    }
}
