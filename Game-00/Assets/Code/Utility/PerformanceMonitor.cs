using UnityEngine;

public class PerformanceMonitor : MonoBehaviour
{
    private float frameRate_;
    private float frameRateUpdateInterval_ = 0.5f;
    private float timeSinceLastUpdate_ = 0;

    public static PerformanceMonitor instance_;

    void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject);
    }
    void Update()
    {
        MonitorFrameRate();
    }

    void MonitorFrameRate()
    {
        frameRate_ = 1 / Time.deltaTime;

        timeSinceLastUpdate_ += Time.deltaTime;
        if (timeSinceLastUpdate_ > frameRateUpdateInterval_)
        {
            timeSinceLastUpdate_ -= frameRateUpdateInterval_;
        }
    }

    public float GetFrameRate()
    {
        return frameRate_;
    }
}
