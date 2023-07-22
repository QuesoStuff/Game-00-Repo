using UnityEngine;

public static class Record_Main
{
    private static float distanceTraveled_;
    private static int bulletCount_;
    private static int killCount_;
    private static float totalDamage_;
    private static float totalHeal_;
    private static float high_Score_;
    private static float clockTime_Max_;
    private static float timerTime_Max_;
    private static Transform target_ = Player_Main.instance_.transform;
    private static Vector3 target_CurrPosition_;
    private static Vector3 target_PrevPosition_;
    public static void SetClockMax(float newTIme)
    {
        clockTime_Max_ = newTIme;
    }
    public static void SetTimerMax(float newTIme)
    {
        timerTime_Max_ = newTIme;
    }

    public static float GetClockMax()
    {
        return clockTime_Max_;
    }
    public static float GetTimerMax()
    {
        return timerTime_Max_;
    }
    public static Vector3 GetCurrPosition()
    {
        return target_CurrPosition_;
    }
    public static Vector3 GetPrevPosition()
    {
        return target_PrevPosition_;
    }


    public static void UpdateDistanceTraveled()
    {
        target_PrevPosition_ = target_CurrPosition_;
        target_CurrPosition_ = target_.position;
        Record_Controller.Traveling();
    }

    public static void UpdateBulletCount()
    {
        Record_Controller.TriggerPulled();
    }

    public static float GetDistanceTraveled()
    {
        return distanceTraveled_;
    }

    public static void SetDistanceTraveled(float newDistanceTraveled)
    {
        distanceTraveled_ = newDistanceTraveled;
    }

    public static int GetBulletCount()
    {
        return bulletCount_;
    }

    public static void SetBulletCount(int newCount)
    {
        bulletCount_ = newCount;
    }

    public static int GetKillCount()
    {
        return killCount_;
    }

    public static void SetKillCount(int newCount)
    {
        killCount_ = newCount;
    }

    public static float GetTotalDamage()
    {
        return totalDamage_;
    }

    public static void SetTotalDamage(float value)
    {
        totalDamage_ = value;
    }


    public static float GetTotalHeal()
    {
        return totalHeal_;
    }

    public static void SetTotalHeal(float value)
    {
        totalHeal_ = value;
    }


    public static float GetHighScore()
    {
        return high_Score_;
    }

    public static void SetHighScore(float newScore)
    {
        high_Score_ = newScore;
    }
}
