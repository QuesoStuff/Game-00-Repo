using System.Collections;
using UnityEngine;

public abstract class GameObjectColor : MonoBehaviour
{
    private Color currentColor_;
    private Color defaultColor_;
    private float blinkingDuration_;
    private float speed_;




    public void SetCurrentColor(Color color)
    {
        currentColor_ = color;
    }

    public Color GetCurrentColor()
    {
        return currentColor_;
    }

    public void SetDefaultColor(Color color)
    {
        defaultColor_ = color;
    }

    public Color GetDefaultColor()
    {
        return defaultColor_;
    }

    public void SetBlinkingDuration(float duration)
    {
        blinkingDuration_ = duration;
    }

    public float GetBlinkingDuration()
    {
        return blinkingDuration_;
    }

    public void SetSpeed(float speed)
    {
        speed_ = speed;
    }

    public float GetSpeed()
    {
        return speed_;
    }

    public void BlinkColorContinuos()
    {
        GENERIC.FlashColorIndefinitely(this, defaultColor_, speed_, () => true, SetCurrentColor, GetCurrentColor);
    }

    public void BlinkColor()
    {
        GENERIC.FlashColorWithDuration(this, defaultColor_, blinkingDuration_, speed_, SetCurrentColor, GetCurrentColor);
    }
}
