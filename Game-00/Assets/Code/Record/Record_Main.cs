using UnityEngine;

public class Record_Main : MonoBehaviour, I_Record_Main
{
    private float distanceTraveled_;
    private uint bulletCount_;
    private uint killCount_;
    private float totalDamage_;
    private float totalHeal_;
    private float high_Score_;
    private float clockTime_Max_;
    private float timerTime_Max_;

    public void SetClockMax(float newTIme)
    {
        clockTime_Max_ = newTIme;
    }
    public void SetTimerMax(float newTIme)
    {
        timerTime_Max_ = newTIme;
    }

    public float GetClockMax()
    {
        return clockTime_Max_;
    }
    public float GetTimerMax()
    {
        return timerTime_Max_;
    }
    [SerializeField] public Record_Controller records_Controller_;

    public static Record_Main instance_;

    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject);
    }

    public void UpdateDistanceTraveled()
    {
        records_Controller_.target_Position_.SetPosition();
        records_Controller_.Traveling();
    }

    public void UpdateBulletCount()
    {
        records_Controller_.TriggerPulled();
    }

    public float GetDistanceTraveled()
    {
        return distanceTraveled_;
    }

    public void SetDistanceTraveled(float newDistanceTraveled)
    {
        distanceTraveled_ = newDistanceTraveled;
    }

    public uint GetBulletCount()
    {
        return bulletCount_;
    }

    public void SetBulletCount(uint newCount)
    {
        bulletCount_ = newCount;
    }

    public uint GetKillCount()
    {
        return killCount_;
    }

    public void SetKillCount(uint newCount)
    {
        killCount_ = newCount;
    }

    public float GetTotalDamage()
    {
        return totalDamage_;
    }

    public void SetTotalDamage(float value)
    {
        totalDamage_ = value;
    }

    public float GetTotalHeal()
    {
        return totalHeal_;
    }

    public void SetTotalHeal(float value)
    {
        totalHeal_ = value;
    }

    public float GetHighScore()
    {
        return high_Score_;
    }

    public void SetHighScore(float newScore)
    {
        high_Score_ = newScore;
    }
}
