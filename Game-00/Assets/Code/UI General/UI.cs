using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UI : MonoBehaviour, I_UI
{
    [SerializeField] internal Text textBox;

    protected float duration_ = 2;
    protected float speed_ = CONSTANTS.HALF_SECOND_BLINK_SPEED;
    protected Coroutine currentBlinkCoroutine_ = null;
    protected Color colorUpdate_ = Color.clear;
    protected Color colorNew_ = Color.yellow;
    protected Color originalColor_;
    protected bool indefBlink_;

    private bool isBlinking_ = false;

    public void SetIsBlinking(bool state)
    {
        isBlinking_ = state;
    }
    public bool GetIsBlinking()
    {
        return isBlinking_;
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

    public void BlinkText()
    {
        BlinkText(colorUpdate_);
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



    public void StopBlinking()
    {
        if (currentBlinkCoroutine_ != null)
        {
            StopCoroutine(currentBlinkCoroutine_);
            currentBlinkCoroutine_ = null;
            textBox.color = originalColor_;
        }
        SetIsBlinking(currentBlinkCoroutine_ == null);
        isBlinking_ = false;
    }



    public void BlinkText(Color color, Action onComplete = null)
    {
        StopBlinking();
        originalColor_ = textBox.color;
        currentBlinkCoroutine_ = this.FlashColorWithDuration(
            color,
            duration_,
            speed_,
            col => textBox.color = col,
            () => textBox.color,
            onComplete,
            () => Time.realtimeSinceStartup
        );
        isBlinking_ = true;
    }

    public void BlinkTextIndefinitely(Color color)
    {
        StopBlinking();
        originalColor_ = textBox.color;
        currentBlinkCoroutine_ = this.FlashColorIndefinitely(
            color,
            speed_,
            () => true,
            col => textBox.color = col,
            () => textBox.color,
            null,
            () => Time.realtimeSinceStartup
        );
        isBlinking_ = true;
    }

    public virtual void Update_UI()
    {

    }
}
