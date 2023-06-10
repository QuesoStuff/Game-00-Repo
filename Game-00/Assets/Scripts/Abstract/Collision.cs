using System; // needed for Unity Action Events (Type of Delegate)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collision : MonoBehaviour
{

    protected Dictionary<string, List<Action>> table_OnCollisionEnter2D_;
    protected Dictionary<string, List<Action>> table_OnCollisionExit2D_;
    protected Dictionary<string, List<Action>> table_OnTriggerEnter2D_;
    protected Dictionary<string, List<Action>> table_OnTriggerExit2D_;

    public abstract void Congfigure_table_OnCollisionEnter2D();
    public abstract void Congfigure_table_OnCollisionExit2D();
    public abstract void Congfigure_table_OnTriggerEnter2D();
    public abstract void Congfigure_table_OnTriggerExit2D();
    public void Congfigure_CollisionTables()
    {
        Congfigure_table_OnCollisionEnter2D();
        Congfigure_table_OnCollisionExit2D();
        Congfigure_table_OnTriggerEnter2D();
        Congfigure_table_OnTriggerExit2D();
    }

    private event Action OnCollisionEnter2D_Method;
    private event Action OnCollisionExit2D_Method;
    private event Action OnTriggerEnter2D_Method;
    private event Action OnTriggerExit2D_Method;

    /*
        public void AddToAction_OnCollisionEnter2D(Action addAction)
        {
            GENERIC.AddToAction(ref OnCollisionEnter2D_Method, addAction);
        }
        public void AddToAction_OnCollisionExit2(Action addAction)
        {
            GENERIC.AddToAction(ref OnCollisionEnter2D_Method, addAction);
        }
        public void AddToAction_OnTriggerEnter2D(Action addAction)
        {
            GENERIC.AddToAction(ref OnCollisionEnter2D_Method, addAction);
        }
        public void AddToAction_OnTriggerExit2D(Action addAction)
        {
            GENERIC.AddToAction(ref OnCollisionEnter2D_Method, addAction);
        }
    */

    // 2D collision enter
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Lookup_OnCollisionEnter2D(collision.gameObject);
    }

    // 2D collision exit
    public virtual void OnCollisionExit2D(Collision2D collision)
    {
        Lookup_OnCollisionExit2D(collision.gameObject);
    }

    // 2D trigger enter
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        Lookup_OnTriggerEnter2D(other.gameObject);
    }

    // 2D trigger exit
    public virtual void OnTriggerExit2D(Collider2D other)
    {
        Lookup_OnTriggerExit2D(other.gameObject);
    }

    public void Lookup_Collision(Dictionary<string, List<Action>> actionTable, GameObject other)
    {
        GENERIC.TableLookUp<string>(actionTable, other.tag);
    }

    public void Lookup_OnCollisionEnter2D(GameObject other)
    {
        Lookup_Collision(table_OnCollisionEnter2D_, other);
    }
    public void Lookup_OnCollisionExit2D(GameObject other)
    {
        Lookup_Collision(table_OnCollisionExit2D_, other);

    }
    public void Lookup_OnTriggerEnter2D(GameObject other)
    {
        Lookup_Collision(table_OnTriggerEnter2D_, other);

    }
    public void Lookup_OnTriggerExit2D(GameObject other)
    {
        Lookup_Collision(table_OnTriggerExit2D_, other);

    }

    public void Add(Dictionary<string, List<Action>> actionTable, string key, Action method)
    {

        if (actionTable.ContainsKey(key))
        {
            actionTable[key].Add(method);
        }
        else
        {
            actionTable[key] = new List<Action> { method };
        }
    }

}

