using UnityEngine;

public static class PerformanceMonitor
{
    private static float frameRate_;
    private static float frameRateUpdateInterval_ = 0.5f;
    private static float timeSinceLastUpdate_ = 0;

    public static float GetFrameRate()
    {
        return frameRate_;
    }
    public static void Target_FrameRate(int target = 60)
    {
        Application.targetFrameRate = target;
    }


    public static void MonitorFrameRate()
    {
        frameRate_ = 1 / Time.deltaTime;

        timeSinceLastUpdate_ += Time.deltaTime;
        if (timeSinceLastUpdate_ > frameRateUpdateInterval_)
        {
            timeSinceLastUpdate_ -= frameRateUpdateInterval_;
        }
    }


}
