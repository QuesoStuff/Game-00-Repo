using System; // needed for Unity Action Events (Type of Delegate)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_Collision
{
    void Congfigure_table_OnCollisionEnter2D();
    void Congfigure_table_OnCollisionExit2D();
    void Congfigure_table_OnTriggerEnter2D();
    void Congfigure_table_OnTriggerExit2D();
    void Congfigure_CollisionTables();
    void Lookup_OnCollisionEnter2D(GameObject other);
    void Lookup_OnCollisionExit2D(GameObject other);
    void Lookup_OnTriggerEnter2D(GameObject other);
    void Lookup_OnTriggerExit2D(GameObject other);

    void Lookup_Collision(Dictionary<string, Action> actionTable, GameObject other);

}
