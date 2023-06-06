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
    [SerializeField] internal Record_Controller records_Controller_;

    public static Record_Main instance_;

    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject);
        //LoadData();
    }

    // Updates the distance traveled in the record
    public void UpdateDistanceTraveled()
    {
        records_Controller_.target_Position_.SetPosition();
        records_Controller_.Traveling();
    }

    // Updates the bullet count in the record
    public void UpdateBulletCount()
    {
        records_Controller_.TriggerPulled();
    }

    // Gets the distance traveled
    public float GetDistanceTraveled()
    {
        return distanceTraveled_;
    }

    // Sets the distance traveled
    public void SetDistanceTraveled(float newDistanceTraveled)
    {
        distanceTraveled_ = newDistanceTraveled;
    }

    // Gets the bullet count
    public int GetBulletCount()
    {
        return bulletCount_;
    }

    // Sets the bullet count
    public void SetBulletCount(int newCount)
    {
        bulletCount_ = newCount;
    }

    // Gets the kill count
    public int GetKillCount()
    {
        return killCount_;
    }

    // Sets the kill count
    public void SetKillCount(int newCount)
    {
        killCount_ = newCount;
    }

    // Gets the total damage
    public float GetTotalDamage()
    {
        return totalDamage_;
    }

    // Sets the total damage
    public void SetTotalDamage(float value)
    {
        totalDamage_ = value;
    }

    // Gets the total heal
    public float GetTotalHeal()
    {
        return totalHeal_;
    }

    // Sets the total heal
    public void SetTotalHeal(float value)
    {
        totalHeal_ = value;
    }

    // Gets the high score
    public float GetHighScore()
    {
        return high_Score_;
    }

    // Sets the high score
    public void SetHighScore(float newScore)
    {
        high_Score_ = newScore;
    }
}
