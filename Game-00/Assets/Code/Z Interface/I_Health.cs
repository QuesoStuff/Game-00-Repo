using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The I_Health interface provides the functionality for a health system in a game.
/// </summary>
public interface I_Health
{
    /// <summary>
    /// Adds a function to the OnDeath event, to be invoked when health reaches 0.
    /// </summary>
    void AddToAction_OnDeath(Action addAction);

    /// <summary>
    /// Adds a function to the OnHeal_Extra event, to be invoked when health exceeds maximum health.
    /// </summary>
    void AddToAction_OnHeal_Extra(Action addAction);

    /// <summary>
    /// Adds a function to the OnMaxHeal event, to be invoked when health is at maximum.
    /// </summary>
    void AddToAction_OnMaxHeal(Action addAction);

    /// <summary>
    /// Adds a function to the OnFullHeal event, to be invoked when health is fully restored.
    /// </summary>
    void AddToAction_OnFullHeal(Action addAction);

    /// <summary>
    /// Adds a function to the OnExtraMaxHP event, to be invoked when maximum health is increased.
    /// </summary>
    void AddToAction_OnExtraMaxHP(Action addAction);

    /// <summary>
    /// Gets the current health.
    /// </summary>
    float GetCurrHP();

    /// <summary>
    /// Gets the maximum health.
    /// </summary>
    float GetMaxHP();

    /// <summary>
    /// Damages the health by a certain amount, invoking a method if health falls below a boundary.
    /// </summary>
    float Damage(float damage = CONSTANTS.HP_DEFAULT_DAMAGE, float boundaryMaxDamage = 0, float boundaryTriggerMethod = CONSTANTS.HP_DEFAULT_MAXLIFE, Action method = null);

    /// <summary>
    /// Heals the health by a certain amount, invoking a method if health rises above a boundary.
    /// </summary>
    float Heal(float heal = CONSTANTS.HP_DEFAULT_HEAL, float? BoundaryMaxHeal = null, float boundaryTriggerMethod = 0, Action method = null);

    /// <summary>
    /// Heals the health by a certain amount, invoking a method if health rises above a boundary. There is no maximum health boundary.
    /// </summary>
    float heal_unbounded(float hp = CONSTANTS.HP_DEFAULT_HEAL, float boundaryTriggerMethod = 0, Action method = null);

    /// <summary>
    /// Sets the current health.
    /// </summary>
    void Set_HP(float hp);

    /// <summary>
    /// Sets the default damage value.
    /// </summary>
    void Set_Damage(float damage);

    /// <summary>
    /// Sets the default healing value.
    /// </summary>
    void Set_Heal(float heal);

    /// <summary>
    /// Sets the maximum health.
    /// </summary>
    void Set_Max_HP(float maxHp);

    /// <summary>
    /// Restores health to full, optionally invoking a method.
    /// </summary>
    float Full_Restore_HP(Action method = null);

    /// <summary>
    /// Increases the maximum health by a certain amount, optionally invoking a method.
    /// </summary>
    void Increase_Max_HP(float extraHearts = CONSTANTS.HP_DEFAULT_HEAL, Action method = null);

    /// <summary>
    /// Invokes the OnDeath event.
    /// </summary>
    void Death();
}
