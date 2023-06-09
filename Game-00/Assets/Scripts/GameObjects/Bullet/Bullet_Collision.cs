using System; // needed for Unity Action Events (Type of Delegate)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Collision : Collision
{
    [SerializeField] public Bullet_Main bullet_Main_;
    private bool isCollision_ = false;


    // Start is called before the first frame update
    public override void Congfigure_table_OnCollisionEnter2D()
    {

    }
    public override void Congfigure_table_OnCollisionExit2D()
    {

    }
    public override void Congfigure_table_OnTriggerEnter2D()
    {
        table_OnTriggerEnter2D_ = new Dictionary<string, List<Action>>();
        Add(table_OnTriggerEnter2D_, CONSTANTS.Wall_Tag, Player_Main.instance_.player_Sound_.BumpIntoWall);
        Add(table_OnTriggerEnter2D_, CONSTANTS.Wall_Tag, bullet_Main_.bullet_Health_.Damage);

    }
    public override void Congfigure_table_OnTriggerExit2D()
    {
        table_OnTriggerExit2D_ = new Dictionary<string, List<Action>>();
        table_OnTriggerExit2D_.Add(CONSTANTS.Wall_Tag, null);
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        isCollision_ = false;
    }
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (!isCollision_)
        {
            base.OnTriggerEnter2D(other);
        }
        isCollision_ = true;
    }

}
