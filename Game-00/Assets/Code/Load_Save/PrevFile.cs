using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PrevFile
{
    private static FileData highestRecord_;



    public static void LoadFile()
    {
        highestRecord_ = Load_Save.LoadFileData();
        if (highestRecord_ == null)
        {
            highestRecord_ = new FileData();
        }
    }

    public static bool CompareDistanceTraveled()
    {
        return Record_Main.GetDistanceTraveled() > highestRecord_.DistanceTraveled_;
    }

    public static bool CompareBulletCount()
    {
        return Record_Main.GetBulletCount() > highestRecord_.BulletCount_;
    }

    static public bool CompareKillCount()
    {
        return Record_Main.GetKillCount() > highestRecord_.KillCount_;
    }

    static public bool CompareTotalDamage()
    {
        return Record_Main.GetTotalDamage() > highestRecord_.TotalDamage_;
    }

    static public bool CompareTotalHeal()
    {
        return Record_Main.GetTotalHeal() > highestRecord_.TotalHeal_;
    }

    static public bool CompareHighScore()
    {
        return Record_Main.GetHighScore() > highestRecord_.HighScore_;
    }

    static public bool CompareTimerTime()
    {
        return Record_Main.GetTimerMax() < highestRecord_.TimerTimeMax_;
    }

    static public bool CompareClockTime()
    {
        return Record_Main.GetClockMax() > highestRecord_.ClockTImeMax_;
    }
}
