using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour  //, //I_Health
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

    public float Damage(float damage = CONSTANTS.DEFAULT_HP_DAMAGE, float? boundaryMaxDamage = null, float? boundaryTriggerMethod = null, Action method = null)
    {
        boundaryMaxDamage ??= 0;
        boundaryTriggerMethod ??= 0;
        method ??= OnDeath_;

        float damageTaken = damage;
        if (hpCurr_ - damage < boundaryMaxDamage.Value)
            damageTaken = hpCurr_ - boundaryMaxDamage.Value;

        hpCurr_ -= damageTaken;
        if ((hpCurr_ / hpMax_) <= boundaryTriggerMethod)
            method?.Invoke();
        return damageTaken;
    }

    public float Heal(float heal = CONSTANTS.DEFAULT_HP_HEAL, float? BoundaryMaxHeal = null, float? boundaryTriggerMethod = null, Action method = null)
    {
        BoundaryMaxHeal ??= hpMax_;
        boundaryTriggerMethod ??= 1;
        method ??= OnMaxHeal_;

        float healTaken = heal;
        if (hpCurr_ + heal > BoundaryMaxHeal.Value)
            healTaken = BoundaryMaxHeal.Value - hpCurr_;

        hpCurr_ += healTaken;
        if ((hpCurr_ / hpMax_) >= boundaryTriggerMethod)
            method?.Invoke();
        return healTaken;
    }


    public float heal_unbounded(float hp = CONSTANTS.DEFAULT_HP_HEAL, float boundaryTriggerMethod = 0, Action method = null)
    {
        hpCurr_ += hp;

        if (hpCurr_ >= boundaryTriggerMethod)
        {
            method?.Invoke();
        }

        return hp;
    }

    public void Set_HP(float hp)
    {
        hpCurr_ = hp;
    }
    public void Set_Damage(float damage)
    {
        hpDamage_ = damage;
    }
    public float Get_Damage()
    {
        return hpDamage_;
    }
    public float Get_Heal()
    {
        return hpHeal_;
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
    public void Increase_Max_HP(float extraHearts = CONSTANTS.DEFAULT_HP_HEAL, Action method = null)
    {
        hpMax_ += extraHearts;
        method?.Invoke();
    }
    public void Set_Random_Health()
    {
        hpCurr_ = GENERIC.GetRandomNumberInRange((int)0, (int)hpMax_);

    }
    public void Death(Action method = null)
    {
        method ??= OnDeath_;

        method?.Invoke();
    }
}
