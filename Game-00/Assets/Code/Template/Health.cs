using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, I_Health
{
    [SerializeField] private float hpCurr_ = 2;
    [SerializeField] private float hpMax_ = 10;
    [SerializeField] private float hpDamage_;
    [SerializeField] private float hpHeal_;
    private event Action OnDeath_;
    private event Action OnHeal_Extra_;
    private event Action OnMaxHeal_;
    private event Action OnFullHeal_;
    private event Action OnExtraMaxHP_;


    public void AddToAction_OnDeath(Action addAction)
    {
        OnDeath_ += addAction;
    }
    public void AddToAction_OnHeal_Extra(Action addAction)
    {
        OnHeal_Extra_ += addAction;
    }
    public void AddToAction_OnMaxHeal(Action addAction)
    {
        OnMaxHeal_ += addAction;
    }
    public void AddToAction_OnFullHeal(Action addAction)
    {
        OnFullHeal_ += addAction;
    }
    public void AddToAction_OnExtraMaxHP(Action addAction)
    {
        OnExtraMaxHP_ += addAction;
    }
    public float GetCurrHP()
    {
        return hpCurr_;
    }
    public float GetMaxHP()
    {
        return hpMax_;
    }
    public float Damage(float damage = CONSTANTS.HP_DEFAULT_DAMAGE, float boundaryMaxDamage = 0, float boundaryTriggerMethod = CONSTANTS.HP_DEFAULT_MAXLIFE, Action method = null)
    {
        float damageTaken = damage;
        if (hpCurr_ - damage <= boundaryMaxDamage)
            damageTaken = hpCurr_ - boundaryMaxDamage;
        hpCurr_ -= damageTaken;
        if (hpCurr_ <= boundaryTriggerMethod)
            method?.Invoke();
        return damageTaken;
    }

    public float Heal(float heal = CONSTANTS.HP_DEFAULT_HEAL, float? BoundaryMaxHeal = null, float boundaryTriggerMethod = 0, Action method = null)
    {
        float actualMaxHeal = BoundaryMaxHeal ?? hpMax_;

        float healTaken = heal;
        if (hpCurr_ + heal >= actualMaxHeal)
            healTaken = actualMaxHeal - hpCurr_;
        hpCurr_ += healTaken;
        if (hpCurr_ >= boundaryTriggerMethod)
            method?.Invoke();
        return healTaken;
    }



    public float heal_unbounded(float hp = CONSTANTS.HP_DEFAULT_HEAL, float boundaryTriggerMethod = 0, Action method = null)
    {
        hpCurr_ += hp;

        if (hpCurr_ >= boundaryTriggerMethod)
        {
            method?.Invoke();
        }

        return hp;
    }
    public void Heal()
    {
        float healed = Heal(CONSTANTS.HP_DEFAULT_HEAL, boundaryTriggerMethod: hpMax_, method: OnMaxHeal_);
    }

    public void Damage()
    {
        float damaged = Damage(CONSTANTS.HP_DEFAULT_DAMAGE, boundaryTriggerMethod: 0, method: OnDeath_);
    }
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
    public float Full_Restore_HP(Action method = null)
    {
        return Heal(hpMax_);
    }
    public float Full_Restore_HP()
    {
        return Full_Restore_HP(OnFullHeal_);
    }
    public void Increase_Max_HP(float extraHearts = CONSTANTS.HP_DEFAULT_HEAL, Action method = null)
    {
        hpMax_ += extraHearts;
        method?.Invoke();
    }


    public void Death(Action method)
    {
        method?.Invoke();
    }
    public void Death()
    {
        OnDeath_?.Invoke();
    }
}
