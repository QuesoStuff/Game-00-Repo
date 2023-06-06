using System; // needed for Unity Action Events (Type of Delegate)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, I_Health
{
    private float hpCurr_ = 2;
    private float hpMax_ = 10;
    private float hpDamage_;
    private float hpHeal_;
    public event Action OnDeath;
    public event Action OnHeal_Extra;
    public event Action OnMaxHeal;
    public event Action OnFullHeal;
    public event Action OnExtraMaxHP;

    public float GetCurrHP()
    {
        return hpCurr_;
    }
    public float GetMaxHP()
    {
        return hpMax_;
    }
    public float Damage(float damage, float boundaryMaxDamage, float boundaryTriggerMethod, Action method)
    {
        float damageTaken = damage;
        if (hpCurr_ - damage <= boundaryMaxDamage) // subject to change
            damageTaken = hpCurr_ - boundaryMaxDamage;
        hpCurr_ -= damageTaken;
        if (hpCurr_ <= boundaryTriggerMethod) // subject to change
            method?.Invoke();
        return damageTaken;
    }
    public float Damage(float damage, float boundaryTriggerMethod, Action method)
    {
        return Damage(damage, 0, boundaryTriggerMethod, method);
    }
    public float Damage(float damage, Action method)
    {
        return Damage(damage, CONSTANTS.HP_DEFAULT_MAXLIFE, method);
    }
    public float Damage(float damage)
    {
        return Damage(damage, 0, Death);
    }
    public void Damage()
    {
        Damage(CONSTANTS.HP_DEFAULT_DAMAGE);
    }
    public float Heal(float heal, float BoundaryMaxHeal, float boundaryTriggerMethod, Action method)
    {
        float healTaken = heal;
        if (hpCurr_ + heal >= BoundaryMaxHeal) // subject to change
            healTaken = BoundaryMaxHeal - hpCurr_;
        hpCurr_ += healTaken;
        if (hpCurr_ >= boundaryTriggerMethod) // subject to change
            method?.Invoke();
        return healTaken;
    }
    public float Heal(float heal, float boundaryTriggerMethod, Action method)
    {
        return Heal(heal, hpMax_, boundaryTriggerMethod, method);
    }
    public float Heal(float heal, Action method)
    {
        return Heal(heal, 0, method);
    }
    public float Heal(float heal)
    {
        return Heal(heal, hpMax_, OnMaxHeal);
    }
    public void Heal()
    {
        Heal(CONSTANTS.HP_DEFAULT_HEAL);
    }
    // More complex
    public float heal_unbounded(float hp, float boundaryTriggerMethod, Action method)
    {
        return Heal(hp, CONSTANTS.HP_DEFAULT_MAXLIFE, boundaryTriggerMethod, method);
    }
    public float heal_unbounded(float hp, Action method)
    {
        return heal_unbounded(hp, 0, method);
    }
    public float heal_unbounded(float hp)
    {
        return heal_unbounded(hp, OnHeal_Extra);
    }
    public float heal_unbounded()
    {
        return heal_unbounded(CONSTANTS.HP_DEFAULT_HEAL);
    }
    // Setters
    public void Set_HP(float hp)
    {
        hpCurr_ = hp;
    }
    public void Set_Damage(float damage)
    {
        hpDamage_ = damage;
    }
    public void Set_Heal(float heal)
    {
        hpHeal_ = heal;
    }
    public void Set_Max_HP(float maxHp)
    {
        hpMax_ = maxHp;
    }
    // Fancy setters 
    public float Full_Restore_HP(Action method)
    {
        return Heal(hpMax_, 0, method);
    }
    public float Full_Restore_HP()
    {
        return Full_Restore_HP(OnFullHeal);
    }
    public void Increase_Max_HP(float extraHearts, Action method)
    {
        hpMax_ += extraHearts;
        method?.Invoke();
    }
    public void Increase_Max_HP(float extraHearts)
    {
        Increase_Max_HP(extraHearts, OnExtraMaxHP);
    }
    public void Increase_Max_HP()
    {
        Increase_Max_HP(CONSTANTS.HP_DEFAULT_HEAL);
    }
    public float Inrease_Max_And_Full_Restore_HP(float extraHearts, Action method)
    {
        Increase_Max_HP(extraHearts, method);
        return Full_Restore_HP();
    }
    public float Inrease_Max_And_Full_Restore_HP(float extraHearts)
    {
        Increase_Max_HP(extraHearts);
        return Full_Restore_HP();
    }
    public float Inrease_Max_And_Full_Restore_HP()
    {
        Increase_Max_HP();
        return Full_Restore_HP();
    }
    // Boundary checking
    public bool Is_HP_Equal_or_Below(float hpThreshold)
    {
        return GENERIC.Is_X_Below_or_Equal_Y(hpCurr_, hpThreshold);
    }
    public bool Is_HP_Below(float hpThreshold)
    {
        return GENERIC.Is_X_Below_Y(hpCurr_, hpThreshold);
    }
    public bool Is_HP_Zero()
    {
        return GENERIC.Is_X_Below_or_Equal_Y(hpCurr_, 0);
    }
    // When you are dead
    public void Death(Action method)
    {
        // Trigger the OnDeath event if there are subscribers
        method?.Invoke();
    }
    public void Death()
    {
        // Trigger the OnDeath event if there are subscribers
        OnDeath?.Invoke();
    }
}
