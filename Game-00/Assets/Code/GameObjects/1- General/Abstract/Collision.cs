using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collision : MonoBehaviour
{

    protected Dictionary<string, Action> table_OnCollisionEnter2D_;
    protected Dictionary<string, Action> table_OnCollisionStay2D_;
    protected Dictionary<string, Action> table_OnCollisionExit2D_;
    protected Dictionary<string, Action> table_OnTriggerEnter2D_;
    protected Dictionary<string, Action> table_OnTriggerStay2D_;
    protected Dictionary<string, Action> table_OnTriggerExit2D_;




    public virtual void Congfigure_table_OnCollisionEnter2D()
    {
        throw new System.NotImplementedException();
    }
    public virtual void Congfigure_table_OnCollisionExit2D()
    {
        throw new System.NotImplementedException();
    }
    public virtual void Congfigure_table_OnTriggerEnter2D()
    {
        throw new System.NotImplementedException();
    }
    public virtual void Congfigure_table_OnTriggerExit2D()
    {
        throw new System.NotImplementedException();
    }
    public virtual void Congfigure_table_OnCollisionStay2D()
    {
        throw new System.NotImplementedException();
    }
    public virtual void Congfigure_table_OnTriggerStay2D()
    {
        throw new System.NotImplementedException();
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

    public void Add(ref Dictionary<string, Action> actionTable, string key, Action method)
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

