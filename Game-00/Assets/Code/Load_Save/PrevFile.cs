using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrevFile : MonoBehaviour
{
    public static PrevFile instance_;
    private FileData highestRecord_;

    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject);
    }

    public void LoadFile()
    {
        highestRecord_ = Load_Save.LoadFileData();
        if (highestRecord_ == null)
        {
            highestRecord_ = new FileData();
        }
    }

    public bool CompareDistanceTraveled()
    {
        return Record_Main.instance_.GetDistanceTraveled() > highestRecord_.DistanceTraveled_;
    }

    public bool CompareBulletCount()
    {
        return Record_Main.instance_.GetBulletCount() > highestRecord_.BulletCount_;
    }

    public bool CompareKillCount()
    {
        return Record_Main.instance_.GetKillCount() > highestRecord_.KillCount_;
    }

    public bool CompareTotalDamage()
    {
        return Record_Main.instance_.GetTotalDamage() > highestRecord_.TotalDamage_;
    }

    public bool CompareTotalHeal()
    {
        return Record_Main.instance_.GetTotalHeal() > highestRecord_.TotalHeal_;
    }

    public bool CompareHighScore()
    {
        return Record_Main.instance_.GetHighScore() > highestRecord_.HighScore_;
    }

    public bool CompareTimerTime()
    {
        return Record_Main.instance_.GetTimerMax() < highestRecord_.TimerTimeMax_;
    }

    public bool CompareClockTime()
    {
        return Record_Main.instance_.GetClockMax() > highestRecord_.ClockTImeMax_;
    }
}
