using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Time : UI
{
    [SerializeField] public Time_Manager time_;
    private float elapsedTime_;

    public override void Update_UI()
    {
        if (time_.GetIsRunning())
        {
            elapsedTime_ = Time_Manager.instance_.GetTime();
            duration_ = Time_Manager.instance_.GetDuration();
            string mess = PrintTime();
            Update_UI_Color();
            Update_UI_Blinking();
            Update_UI_Text(mess);
        }
    }

    public string PrintTime(float elapsedTime)
    {
        uint min = (uint)(elapsedTime / 60);
        uint sec = (uint)Mathf.Round(elapsedTime % 60); // to handle rounding errors for the Clock once Stop
        string timeFormattedString = min.ToString() + " : " + GENERIC.FormatSingleDigit(sec);
        return timeFormattedString;
    }

    public string PrintTime()
    {
        return PrintTime(elapsedTime_);
    }

    public void Update_UI_Timer_Color()
    {
        if (elapsedTime_ / duration_ > 0.66f)
            Update_UI_Color(Color.white);
        else if (elapsedTime_ / duration_ > 0.33f)
            Update_UI_Color(Color.yellow);
        else
            Update_UI_Color(Color.red);
    }
    public void Update_UI_Timer_Blinking()
    {
        if (elapsedTime_ / duration_ <= 0.33f && !GetIsBlinking())
        {
            BlinkTextIndefinitely();
        }
    }

    public void Update_UI_Clock_Blinking()
    {
        if (elapsedTime_ / duration_ > 0.66f && !GetIsBlinking())
        {
            BlinkTextIndefinitely();
        }
    }

    public void Update_UI_Clock_Color()
    {
        if (elapsedTime_ / duration_ > 0.66f)
            Update_UI_Color(Color.red);
        else if (elapsedTime_ / duration_ > 0.33f)
            Update_UI_Color(Color.yellow);
        else
            Update_UI_Color(Color.white);
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
}
