using UnityEngine;

public class Record_Main : MonoBehaviour
{
    private float distanceTraveled_;
    private int bulletCount_;
    private int killCount_;
    private float totalDamage_;
    private float totalHeal_;
    private float high_Score_;
    private float clockTime_Max_;
    private float timerTime_Max_;
    [SerializeField] public Record_Controller records_Controller_;
    [SerializeField] private Transform target_;
    public Vector3 target_CurrPosition_;
    public Vector3 target_PrevPosition_;

    [SerializeField] public Record_Main records_Main_;
    [SerializeField] public Health target_health_;
    public static Record_Main instance_;
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
    public Vector3 GetCurrPosition()
    {
        return target_CurrPosition_;
    }
    public Vector3 GetPrevPosition()
    {
        return target_PrevPosition_;
    }
    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject);
    }

    public void UpdateDistanceTraveled()
    {
        target_PrevPosition_ = target_CurrPosition_;
        target_CurrPosition_ = target_.position;
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

    public int GetBulletCount()
    {
        return bulletCount_;
    }

    public void SetBulletCount(int newCount)
    {
        bulletCount_ = newCount;
    }

    public int GetKillCount()
    {
        return killCount_;
    }

    public void SetKillCount(int newCount)
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
