using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Time : UI
{
    [SerializeField] public Time_Manager time_;
    private float elapsedTime_;

    public override void Init()
    {
        List<float> thresholds = new List<float> { 0.33f, 0.66f };
        List<Color> values = new List<Color> { Color.red, Color.yellow, Color.white };
        colorRange_ = new CollectionRange<float, Color>(thresholds, values);
    }


    public override void Update_UI()
    {
        if (time_.GetIsRunning())
        {
            elapsedTime_ = Time_Manager.instance_.GetElapsedTime();
            duration_ = Time_Manager.instance_.GetDuration();
            string mess = PrintTime();
            Update_UI_Color();
            Update_UI_Blinking();
            Update_UI_Text(mess);
        }
    }

    public string PrintTime(float elapsedTime)
    {
        int min = (int)(elapsedTime / 60);
        int sec = (int)Mathf.Round(elapsedTime % 60); // to handle rounding errors for the Clock once Stop
        string timeFormattedString = min.ToString() + " : " + GENERIC.FormatSingleDigit(sec);
        return timeFormattedString;
    }

    public string PrintTime()
    {
        return PrintTime(elapsedTime_);
    }




    public void Update_UI_Clock_Blinking()
    {
        if (elapsedTime_ / duration_ > colorRange_.GetThresholds()[colorRange_.GetThresholds().Count - 1] && !GetIsBlinking())
        {
            BlinkTextIndefinitely();
        }
    }

    public new void Update_UI_Color()
    {
        CONSTANTS.TIME_MODE mode = Time_Manager.instance_.GetMode();
        if (mode == CONSTANTS.TIME_MODE.TIMER_MODE)
            Update_UI_Timer_Color();
        else if (mode == CONSTANTS.TIME_MODE.CLOCK_MODE)
            Update_UI_Clock_Color();
    }

    public void Update_UI_Blinking()
    {
        CONSTANTS.TIME_MODE mode = Time_Manager.instance_.GetMode();
        if (mode == CONSTANTS.TIME_MODE.TIMER_MODE)
            Update_UI_Timer_Blinking();
        else if (mode == CONSTANTS.TIME_MODE.CLOCK_MODE)
            Update_UI_Clock_Blinking();
    }



    public void Update_UI_Clock_Color()
    {
        float ratio = elapsedTime_ / duration_;
        Color color = colorRange_.GetResultBasedOnThreshold(1 - ratio);
        Update_UI_Color(color);
    }

    public void Update_UI_Timer_Color()
    {
        float ratio = elapsedTime_ / duration_;
        Color color = colorRange_.GetResultBasedOnThreshold(ratio);
        Update_UI_Color(color);
    }

    public void Update_UI_Timer_Blinking()
    {

        float ratio = elapsedTime_ / duration_;
        if (ratio <= colorRange_.GetThresholds()[0] && !GetIsBlinking())
        {
            BlinkTextIndefinitely();
        }
    }

}


