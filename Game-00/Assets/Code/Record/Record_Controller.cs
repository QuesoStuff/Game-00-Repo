using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record_Controller : MonoBehaviour //I_Record_Controller
{
    [SerializeField] public Record_Main records_Main_;
    [SerializeField] public Health target_health_;

    public void TriggerPulled()
    {
        int currBulletCount = records_Main_.GetBulletCount();
        records_Main_.SetBulletCount(currBulletCount + 1);
    }

    public void Traveling()
    {
        float newRecordDistance = Vector3.Distance(records_Main_.GetCurrPosition(), records_Main_.GetPrevPosition());
        float totalDistance = records_Main_.GetDistanceTraveled();
        records_Main_.SetDistanceTraveled(totalDistance + newRecordDistance);
    }

    public void TotalDamage()
    {
        float addedDamage = 0;
        float currHP = target_health_.GetCurrHP();
        if (currHP - CONSTANTS.HP_DEFAULT_DAMAGE > 0)
            addedDamage = CONSTANTS.HP_DEFAULT_DAMAGE;
        float currDamage = records_Main_.GetTotalDamage();
        records_Main_.SetTotalDamage(currDamage + addedDamage);
    }

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

    public void Time() // works for clock and timer
    {
        if (Time_Manager.instance_.GetMode() == CONSTANTS.TIME_MODE.CLOCK_MODE)
        {
            float runningTime = Time_Manager.instance_.GetRunningTime();
            records_Main_.SetClockMax(runningTime);
        }
    }

}
