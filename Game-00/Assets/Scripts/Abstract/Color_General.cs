using System.Collections;
using UnityEngine;

public abstract class GameObjectColor : MonoBehaviour
{
    [SerializeField] protected Color currentColor_;
    [SerializeField] protected Color defaultColor_;
    [SerializeField] protected float blinkingDuration_;
    [SerializeField] protected float speed_;

    // add method that allows object to change color and then return it after some time , kind of like blink
    // but not blinking . think of hit daamge (Mega-Man)

    public abstract void SetColor();
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
        this.FlashColorIndefinitely(defaultColor_, speed_, () => true, SetCurrentColor, GetCurrentColor);
    }

    public void BlinkColor()
    {
        this.FlashColorWithDuration(defaultColor_, blinkingDuration_, speed_, SetCurrentColor, GetCurrentColor);
    }
    public void HoldColor()
    {
        // GENERIC.HoldColorCoroutine(Color holdColor, float holdDuration, Action<Color> setColor, Func<Color> getOriginalColor, Action onComplete = null)
    }


}
