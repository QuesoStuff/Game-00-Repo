using System;
using System.Collections;
using UnityEngine;

public class Color_General : MonoBehaviour, I_Color_General
{
    [SerializeField] protected Color currentColor_;
    [SerializeField] protected Color defaultColor_;
    [SerializeField] protected Color otherColor_;
    [SerializeField] protected ColorRange color_Range_;

    [SerializeField] public SpriteRenderer spriterender_;
    private Coroutine currentCoroutine_ = null;
    private Color originalColor_;
    [SerializeField] protected float duration_ = 2;
    [SerializeField] protected float speed_ = CONSTANTS.HALF_SECOND_BLINK_SPEED;
    private void Start()
    {
        originalColor_ = spriterender_.color;
    }
    public void SetColorFromRange(uint index)
    {
        Color colorFromRange = color_Range_.GetColor(index);
        SetColor(colorFromRange);
    }

    public void SetRandomColorFromRange()
    {
        Color randomColorFromRange = color_Range_.GetRandomColor();
        SetColor(randomColorFromRange);
    }

    public void SetColor(Color color)
    {
        spriterender_.color = color;
    }
    public void SetColor()
    {
        SetColor(currentColor_);
    }
    public void SetColorBlank()
    {
        SetColor(Color.clear);
    }
    public void SetCurrentColor(Color color)
    {
        currentColor_ = color;
    }

    public Color GetCurrentColor()
    {
        return currentColor_;
    }
    public void SetOtherColor(Color color)
    {
        otherColor_ = color;
    }

    public Color GetOtherColor()
    {
        return otherColor_;
    }
    public void SetDefaultColor(Color color)
    {
        defaultColor_ = color;
    }

    public Color GetDefaultColor()
    {
        return defaultColor_;
    }

    public void SetDuration(float duration)
    {
        duration_ = duration;
    }

    public float GetDuration()
    {
        return duration_;
    }

    public void SetSpeed(float speed)
    {
        speed_ = speed;
    }

    public float GetSpeed()
    {
        return speed_;
    }

    public void BlinkColor()
    {
        BlinkColor(Color.clear, duration_, speed_);
    }
    public void HoldColor()
    {
        HoldColor(Color.white, duration_ / 4);
    }
    public void BlinkColorIndefinitely()
    {
        BlinkColorIndefinitely(Color.clear, speed_);
    }


    public void BlinkColor(Color blinkColor, float duration, float speed)
    {
        StopBlinking();
        currentCoroutine_ = this.FlashColorWithDuration(blinkColor, duration, speed, SetColor, () => spriterender_.color, () => SetColor(originalColor_));
    }

    public void HoldColor(Color holdColor, float holdDuration)
    {
        StopBlinking();
        currentCoroutine_ = StartCoroutine(this.HoldColorCoroutine(holdColor, holdDuration, SetColor, () => spriterender_.color, () => SetColor(originalColor_)));
    }

    public void BlinkColorIndefinitely(Color blinkColor, float speed)
    {
        StopBlinking();
        currentCoroutine_ = this.FlashColorIndefinitely(blinkColor, speed, () => true, SetColor, () => spriterender_.color, () => SetColor(originalColor_));
    }

    public void StopBlinking()
    {
        if (currentCoroutine_ != null)
        {
            StopCoroutine(currentCoroutine_);
            currentCoroutine_ = null;
            SetColor(originalColor_);
        }
    }
    public ColorRange GetColorRange()
    {
        return color_Range_;
    }

    public void SetColorRange(ColorRange colorRange)
    {
        color_Range_ = colorRange;
    }

    public Color GetColorFromRange(uint index)
    {
        return color_Range_.GetColor(index);
    }

    public void SetCurrentColorFromRange(uint index)
    {
        currentColor_ = color_Range_.GetColor(index);
    }
}
