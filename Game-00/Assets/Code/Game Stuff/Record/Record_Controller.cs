using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record_Controller : MonoBehaviour
{
    [SerializeField] internal Position target_Position_;
    [SerializeField] internal Record_Main records_Main_;
    [SerializeField] internal Health target_health_;

    // Increases the bullet count in the record
    public void TriggerPulled()
    {
        int currBulletCount = records_Main_.GetBulletCount();
        records_Main_.SetBulletCount(currBulletCount + 1);
    }

    // Updates the traveled distance in the record
    public void Traveling()
    {
        float newRecordDistance = GENERIC.Distance(records_Main_.GetDistanceTraveled(), target_Position_.GetPosition(), target_Position_.GetPositionPrev());
        records_Main_.SetDistanceTraveled(newRecordDistance);
    }

    // Updates the total damage in the record
    public void TotalDamage()
    {
        float addedDamage = 0;
        float currHP = target_health_.GetCurrHP();
        if (currHP - CONSTANTS.HP_DEFAULT_DAMAGE > 0)
            addedDamage = CONSTANTS.HP_DEFAULT_DAMAGE;
        float currDamage = records_Main_.GetTotalDamage();
        records_Main_.SetTotalDamage(currDamage + addedDamage);
    }

    // Updates the total heal in the record
    public void TotalHeal()
    {
        float addedHealth = 0;
        float currHP = target_health_.GetCurrHP();
        float maxHP = target_health_.GetMaxHP();

        if (currHP + CONSTANTS.HP_DEFAULT_HEAL <= maxHP)
            addedHealth = CONSTANTS.HP_DEFAULT_HEAL;
        float currHeal = records_Main_.GetTotalHeal();
        records_Main_.SetTotalHeal(currHeal + addedHealth);
    }

    // Updates the high score in the record
    public void HighScore()
    {
        float currScore = ScoreManager.instance_.GetScore();
        if (currScore > records_Main_.GetHighScore())
            records_Main_.SetHighScore(currScore);
    }

    public void KillCount()
    {
        int currKillCount = records_Main_.GetKillCount();
        records_Main_.SetKillCount(currKillCount + 1);
    }

    public void Clock()
    {
        if (Time_Manager.instance_.GetMode() == CONSTANTS.TIME_MODE.CLOCK_MODE)
        {
            float clock = Time_Manager.instance_.GetTime();
            records_Main_.SetClockMax(clock);
        }
    }
    public void TImer()
    {
        if (Time_Manager.instance_.GetMode() == CONSTANTS.TIME_MODE.TIMER_MODE)
        {
            float clock = Time_Manager.instance_.GetTime();
            records_Main_.SetClockMax(clock);
        }
    }
}
