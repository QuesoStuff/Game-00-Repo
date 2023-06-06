using System; // needed for Unity Action Events (Type of Delegate)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_Health
{
    // Simple  
    float Damage(float damage, float boundaryMaxDamage, float boundaryTriggerMethod, Action method);
    float Damage(float damage, float boundaryTriggerMethod, Action method);
    float Damage(float damage, Action Event);
    float Damage(float damage);
    //float Damage();
    void Damage();
    float Heal(float heal, float BoundaryMaxHeal, float boundaryTriggerMethod, Action method);
    float Heal(float heal, float boundaryTriggerMethod, Action method);
    float Heal(float heal, Action Event);
    float Heal(float heal);
    //float Heal();
    void Heal();
    // More complex
    float heal_unbounded(float hp, float boundaryTriggerMethod, Action method);
    float heal_unbounded(float hp, Action method);
    float heal_unbounded(float hp);
    float heal_unbounded();
    // Setters
    void Set_HP(float hp);
    void Set_Damage(float damage);
    void Set_Heal(float heal);
    void Set_Max_HP(float maxHp);
    // Fancy setters 
    float Full_Restore_HP(Action method);
    float Full_Restore_HP();
    void Increase_Max_HP(float extraHearts, Action method);
    void Increase_Max_HP(float extraHearts);
    void Increase_Max_HP();
    float Inrease_Max_And_Full_Restore_HP(float extraHearts, Action method);
    float Inrease_Max_And_Full_Restore_HP(float extraHearts);
    float Inrease_Max_And_Full_Restore_HP();
    // Boundary checking
    bool Is_HP_Equal_or_Below(float hpThreshold);
    bool Is_HP_Below(float hpThreshold);
    bool Is_HP_Zero();
    // When you are dead
    void Death(Action method);
    void Death();

}
