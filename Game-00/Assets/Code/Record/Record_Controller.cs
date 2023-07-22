using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Record_Controller
{

    public static void TriggerPulled()
    {
        int currBulletCount = Record_Main.GetBulletCount();
        Record_Main.SetBulletCount(currBulletCount + 1);
    }

    public static void Traveling()
    {
        float newRecordDistance = Vector3.Distance(Record_Main.GetCurrPosition(), Record_Main.GetPrevPosition());
        float totalDistance = Record_Main.GetDistanceTraveled();
        Record_Main.SetDistanceTraveled(totalDistance + newRecordDistance);
    }


    public static void HighScore()
    {
        float currScore = ScoreManager.GetScore();
        if (currScore > Record_Main.GetHighScore())
            Record_Main.SetHighScore(currScore);
    }

    public static void KillCount()
    {
        int currKillCount = Record_Main.GetKillCount();
        Record_Main.SetKillCount(currKillCount + 1);

    }

    public static void Time(CONSTANTS_ENUM.TIME_MODE timeMode, CONSTANTS_ENUM.TIME_MODE currMode)
    {
        if (timeMode == currMode)
        {
            float runningTime = Time_Main.GetRunningTime();
            Record_Main.SetClockMax(runningTime);
        }
    }
    public static void ClockTIme()
    {
        Time(Time_Main.GetMode(), CONSTANTS_ENUM.TIME_MODE.CLOCK_MODE);
    }
    public static void TimerTime()
    {
        Time(Time_Main.GetMode(), CONSTANTS_ENUM.TIME_MODE.TIMER_MODE);
    }

    public static void AddToTotoalDamage(float value = CONSTANTS.DEFAULT_HP_HEAL)
    {
        float currDamge = Record_Main.GetTotalDamage();
        Record_Main.SetTotalHeal(currDamge + value);
    }
    public static void AddToTotalHeal(float value = CONSTANTS.DEFAULT_HP_DAMAGE)
    {
        float currDamge = Record_Main.GetTotalHeal();
        Record_Main.SetTotalHeal(currDamge + value);
    }

}
