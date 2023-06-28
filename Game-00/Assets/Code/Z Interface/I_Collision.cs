using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The I_Collision interface provides the functionality for managing collision events in a game object.
/// </summary>
public interface I_Collision
{
    /// <summary>
    /// Adds a method to the OnCollisionEnter2D event.
    /// </summary>
    /// <param name="addAction">The method to be added to the event.</param>
    void AddToAction_OnCollisionEnter2D(Action addAction);

    /// <summary>
    /// Adds a method to the OnCollisionExit2D event.
    /// </summary>
    /// <param name="addAction">The method to be added to the event.</param>
    void AddToAction_OnCollisionExit2D(Action addAction);

    /// <summary>
    /// Adds a method to the OnTriggerEnter2D event.
    /// </summary>
    /// <param name="addAction">The method to be added to the event.</param>
    void AddToAction_OnTriggerEnter2D(Action addAction);

    /// <summary>
    /// Adds a method to the OnTriggerExit2D event.
    /// </summary>
    /// <param name="addAction">The method to be added to the event.</param>
    void AddToAction_OnTriggerExit2D(Action addAction);

    /// <summary>
    /// Configures the OnCollisionEnter2D event table.
    /// </summary>
    void Congfigure_table_OnCollisionEnter2D();

    /// <summary>
    /// Configures the OnCollisionExit2D event table.
    /// </summary>
    void Congfigure_table_OnCollisionExit2D();

    /// <summary>
    /// Configures the OnTriggerEnter2D event table.
    /// </summary>
    void Congfigure_table_OnTriggerEnter2D();

    /// <summary>
    /// Configures the OnTriggerExit2D event table.
    /// </summary>
    void Congfigure_table_OnTriggerExit2D();

    /// <summary>
    /// Configures all the collision event tables.
    /// </summary>
    void Congfigure_CollisionTables();

    /// <summary>
    /// Handler for the OnCollisionEnter2D event.
    /// </summary>
    /// <param name="collision">Collision2D object provided by the Unity engine.</param>
    void OnCollisionEnter2D(Collision2D collision);

    /// <summary>
    /// Handler for the OnCollisionExit2D event.
    /// </summary>
    /// <param name="collision">Collision2D object provided by the Unity engine.</param>
    void OnCollisionExit2D(Collision2D collision);

    /// <summary>
    /// Handler for the OnTriggerEnter2D event.
    /// </summary>
    /// <param name="other">Collider2D object provided by the Unity engine.</param>
    void OnTriggerEnter2D(Collider2D other);

    /// <summary>
    /// Handler for the OnTriggerExit2D event.
    /// </summary>
    /// <param name="other">Collider2D object provided by the Unity engine.</param>
    void OnTriggerExit2D(Collider2D other);

    /// <summary>
    /// Looks up the collision in the provided table and executes the corresponding action.
    /// </summary>
    /// <param name="actionTable">The table to look up the action.</param>
    /// <param name="other">The GameObject that collided.</param>
    void Lookup_Collision(Dictionary<string, Action> actionTable, GameObject other);

    /// <summary>
    /// Looks up the OnCollisionEnter2D event in the table and executes the corresponding action.
    /// </summary>
    /// <param name="other">The GameObject that collided.</param>
    void Lookup_OnCollisionEnter2D(GameObject other);

    /// <summary>
    /// Looks up the OnCollisionExit2D event in the table and executes the corresponding action.
    /// </summary>
    /// <param name="other">The GameObject that stopped colliding.</param>
    void Lookup_OnCollisionExit2D(GameObject other);

    /// <summary>
    /// Looks up the OnTriggerEnter2D event in the table and executes the corresponding action.
    /// </summary>
    /// <param name="other">The GameObject that entered the trigger.</param>
    void Lookup_OnTriggerEnter2D(GameObject other);

    /// <summary>
    /// Looks up the OnTriggerExit2D event in the table and executes the corresponding action.
    /// </summary>
    /// <param name="other">The GameObject that exited the trigger.</param>
    void Lookup_OnTriggerExit2D(GameObject other);

    /// <summary>
    /// Adds an action method to a collision table with a specific key.
    /// </summary>
    /// <param name="actionTable">The table to which the action should be added.</param>
    /// <param name="key">The key to associate with the action.</param>
    /// <param name="method">The action to be added.</param>
    void Add(Dictionary<string, Action> actionTable, string key, Action method);
}
