using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collision : MonoBehaviour
{

    protected Dictionary<string, Action> table_OnCollisionEnter2D_ = new Dictionary<string, Action>();
    protected Dictionary<string, Action> table_OnCollisionStay2D_ = new Dictionary<string, Action>();
    protected Dictionary<string, Action> table_OnCollisionExit2D_ = new Dictionary<string, Action>();
    protected Dictionary<string, Action> table_OnTriggerEnter2D_ = new Dictionary<string, Action>();
    protected Dictionary<string, Action> table_OnTriggerStay2D_ = new Dictionary<string, Action>();
    protected Dictionary<string, Action> table_OnTriggerExit2D_ = new Dictionary<string, Action>();

    protected event Action action_OnCollisionEnter2D_;
    protected event Action action_OnCollisionStay2D_;
    protected event Action action_OnCollisionExit2D_;
    protected event Action action_OnTriggerEnter2D_;
    protected event Action action_OnTriggerStay2D_;
    protected event Action action_OnTriggerExit2D_;



    public void AddToAction_OnCollisionEnter2D(Action addAction)
    {
        action_OnCollisionEnter2D_ += addAction;
    }
    public void AddToAction_OnCollisionExit2D(Action addAction)
    {
        action_OnCollisionExit2D_ += addAction;
    }
    public void AddToAction_OnTriggerEnter2D(Action addAction)
    {
        action_OnTriggerEnter2D_ += addAction;
    }
    public void AddToAction_OnTriggerExit2D(Action addAction)
    {
        action_OnTriggerExit2D_ += addAction;
    }
    public virtual void Congfigure_table_OnCollisionEnter2D()
    {
    }
    public virtual void Congfigure_table_OnCollisionExit2D()
    {
    }
    public virtual void Congfigure_table_OnTriggerEnter2D()
    {
    }
    public virtual void Congfigure_table_OnTriggerExit2D()
    {
    }
    public virtual void Congfigure_table_OnCollisionStay2D()
    {
    }
    public virtual void Congfigure_table_OnTriggerStay2D()
    {
    }
    public void Congfigure_CollisionTables()
    {
        Congfigure_table_OnCollisionEnter2D();
        Congfigure_table_OnCollisionStay2D();
        Congfigure_table_OnCollisionExit2D();
        Congfigure_table_OnTriggerEnter2D();
        Congfigure_table_OnTriggerStay2D();
        Congfigure_table_OnTriggerExit2D();
    }





    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Lookup_OnCollisionEnter2D(collision.gameObject);
    }

    public virtual void OnCollisionExit2D(Collision2D collision)
    {
        Lookup_OnCollisionExit2D(collision.gameObject);
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        Lookup_OnTriggerEnter2D(other.gameObject);
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        Lookup_OnTriggerExit2D(other.gameObject);
    }
    public virtual void OnCollisionStay2D(Collision2D collision)
    {
        Lookup_OnCollisionStay2D(collision.gameObject);
    }

    public virtual void OnTriggerStay2D(Collider2D other)
    {
        Lookup_OnTriggerStay2D(other.gameObject);
    }

    public void Lookup_OnCollisionStay2D(GameObject other)
    {
        Lookup_Collision(table_OnCollisionStay2D_, other);
    }

    public void Lookup_OnTriggerStay2D(GameObject other)
    {
        Lookup_Collision(table_OnTriggerStay2D_, other);
    }

    public void Lookup_Collision(Dictionary<string, Action> actionTable, GameObject other)
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

    public void Add(Dictionary<string, Action> actionTable, string key, Action method)
    {
        if (actionTable.ContainsKey(key))
        {
            actionTable[key] += method;
        }
        else
        {
            actionTable[key] = method;
        }
    }


}

