using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UI : MonoBehaviour
{
    [SerializeField] internal Text textBox;

    protected float duration_ = 2;
    protected float speed_ = CONSTANTS.HALF_SECOND_BLINK_SPEED;
    protected Coroutine currentBlinkCoroutine_ = null;
    protected Color colorUpdate_ = Color.clear;
    protected Color colorNew_ = Color.yellow;
    protected Color originalColor_;
    protected bool indefBlink_;
    public CollectionRange<float, Color> colorRange_;

    private bool isBlinking_ = false;

    public void SetIsBlinking(bool state)
    {
        isBlinking_ = state;
    }
    public bool GetIsBlinking()
    {
        return isBlinking_;
    }

    public virtual void Init()
    {

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
        GENERIC.StopCurrentCoroutine(this, ref currentBlinkCoroutine_, () =>
        {
            textBox.color = originalColor_;
            isBlinking_ = false;
        });
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

    // to be consolidated later 
    protected IEnumerator FadeOverTime(float duration)
    {
        Color originalColor = textBox.color;
        for (float t = 0.01f; t < duration; t += Time.deltaTime)
        {
            Color color = textBox.color;
            color.a = Mathf.Lerp(originalColor.a, 0, t / duration);
            textBox.color = color;
            yield return null;
        }
    }

    protected IEnumerator ScaleOverTime(GameObject obj, Vector3 startSize, float endSize, float duration)
    {
        float timer = 0;
        while (timer < duration)
        {
            float progress = timer / duration;
            obj.transform.localScale = Vector3.Lerp(startSize, new Vector3(endSize, endSize, endSize), progress);
            timer += Time.deltaTime;
            yield return null;
        }

        obj.transform.localScale = new Vector3(endSize, endSize, endSize);
    }

    protected IEnumerator MoveUpOverTime(GameObject obj, float speed, float duration)
    {
        float timer = 0;
        while (timer < duration)
        {
            obj.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
