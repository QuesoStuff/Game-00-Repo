using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrevFile : MonoBehaviour
{
    public static PrevFile instance_;
    private FileData highestRecord;

    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject);
    }

    public void LoadFile()
    {
        highestRecord = Load_Save.LoadFileData();
        if (highestRecord == null)
        {
            highestRecord = new FileData(); // Initialize with default values
        }
    }

    public bool CompareDistanceTraveled()
    {
        return Record_Main.instance_.GetDistanceTraveled() > highestRecord.DistanceTraveled;
    }

    public bool CompareBulletCount()
    {
        return Record_Main.instance_.GetBulletCount() > highestRecord.BulletCount;
    }

    public bool CompareKillCount()
    {
        return Record_Main.instance_.GetKillCount() > highestRecord.KillCount;
    }

    public bool CompareTotalDamage()
    {
        return Record_Main.instance_.GetTotalDamage() > highestRecord.TotalDamage;
    }

    public bool CompareTotalHeal()
    {
        return Record_Main.instance_.GetTotalHeal() > highestRecord.TotalHeal;
    }

    public bool CompareHighScore()
    {
        return Record_Main.instance_.GetHighScore() > highestRecord.HighScore;
    }

    public bool CompareTimerTIme() // the smaller the timer value the longer you lived
    {
        return Record_Main.instance_.GetTimerMax() < highestRecord.TimerTimeMax;
    }

    public bool CompareClockTIme()
    {
        return Record_Main.instance_.GetClockMax() > highestRecord.ClockTImeMax;
    }
}
