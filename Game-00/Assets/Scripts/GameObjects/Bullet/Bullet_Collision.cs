using System; // needed for Unity Action Events (Type of Delegate)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Collision : Collision
{
    [SerializeField] internal Bullet_Main bullet_Main_;

    // Start is called before the first frame update
    public override void Congfigure_table_OnCollisionEnter2D()
    {

    }
    public override void Congfigure_table_OnCollisionExit2D()
    {

    }
    public override void Congfigure_table_OnTriggerEnter2D()
    {
        table_OnTriggerEnter2D_ = new Dictionary<string, Action>();
        table_OnTriggerEnter2D_.Add(CONSTANTS.Wall_Tag, Player_Main.instance_.player_Sound_.BumpIntoWall);
    }
    public override void Congfigure_table_OnTriggerExit2D()
    {
        table_OnTriggerExit2D_ = new Dictionary<string, Action>();
        table_OnTriggerExit2D_.Add(CONSTANTS.Wall_Tag, null);
    }

}