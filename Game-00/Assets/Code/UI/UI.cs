using System; // needed for Unity Action Events (Type of Delegate)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UI : MonoBehaviour
{
    [SerializeField] internal Text textBox;

    private float duration_ = 2;
    private float speed_ = CONSTANTS.HALF_SECOND_BLINK_SPEED;
    private Coroutine currentBlinkCoroutine = null;
    private Color colorUpdate_ = Color.clear;
    private Color colorNew_ = Color.yellow;
    private Color originalColor_;

    private bool isBlinking_ = false;
    public void SetIsBlinking(bool state)
    {
        isBlinking_ = state;
    }
    public float GetDuration()
    {
        return duration_;
    }

    public void SetDuration(float duration)
    {
        duration_ = duration;
    }

    public float GetSpeed()
    {
        return speed_;
    }

    public void SetSpeed(float speed)
    {
        speed_ = speed;
    }

    public void Update_UI_Text(string input)
    {
        textBox.text = input;
    }
    public void Update_UI_Text(float input)
    {
        Update_UI_Text(input.ToString());
    }

    public void Update_UI_Color(Color newColor)
    {
        textBox.color = newColor;
    }

    public void Update_UI_Color()
    {
        Update_UI_Color(colorNew_);
    }
    //public abstrack void AfterBlink()

    public void BlinkText()
    {
        BlinkText(colorUpdate_);
    }
    public void BlinkText(Color color, Action onComplete = null)
    {
        StopBlinking();
        originalColor_ = textBox.color;
        currentBlinkCoroutine = GENERIC.FlashColorWithDurationRealTime(
            textBox,
            color,
            duration_,
            speed_,
            col => textBox.color = col,
            () => textBox.color,
            onComplete
        );
        SetIsBlinking(true);
    }

    public void BlinkTextIndefinitely()
    {
        BlinkTextIndefinitely(colorUpdate_);
    }
    public void SetTextSize(int newSize)
    {
        textBox.fontSize = newSize;
    }
    public void SetTextSize(Vector3 startSize, float newSize, float duration)
    {
        this.ScaleOverTime(this.gameObject, startSize, newSize, duration);
    }
    public void SetTextSize(float newSize, float duration)
    {
        this.ScaleOverTime(this.gameObject, newSize, duration);
    }
    public void BlinkTextIndefinitely(Color color)
    {
        StopBlinking();
        originalColor_ = textBox.color;
        currentBlinkCoroutine = GENERIC.FlashColorIndefinitelyRealTime(
            textBox,
            color,
            speed_,
            () => true,
            col => textBox.color = col,
            () => textBox.color
        );
        SetIsBlinking(true);

    }

    public void StopBlinking()
    {
        if (currentBlinkCoroutine != null)
        {
            StopCoroutine(currentBlinkCoroutine);
            currentBlinkCoroutine = null;
            textBox.color = originalColor_; // Reset the color back to original
        }
        SetIsBlinking(currentBlinkCoroutine == null);
    }

    public abstract void Update_UI();
}
