using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Time : UI
{
    private float runningTIme_;
    private float elapsedTime_;

    public override void Init()
    {
        List<float> thresholds = new List<float> { 0.33f, 0.66f };
        List<Color> values = new List<Color> { Color.red, Color.yellow, Color.white };
        collectionColorRange_ = new CollectionRange<float, Color>(thresholds, values);
    }


    public override void Update_UI()
    {

        if (Time_Main.GetIsRunning())
        {


            runningTIme_ = Time_Main.GetRunningTime();
            duration_ = Time_Main.GetDuration();
            elapsedTime_ = Time_Main.GetElapsedTime();
            string mess = PrintTime();
            float ratio = runningTIme_ / duration_;
            Update_UI_Color(ratio);
            Update_UI_Blinking(ratio);
            Update_UI_Text(mess);
        }
    }
    /* THis implemntation was used for hadnling timer going to zero before the game ends
        public string PrintTime(float elapsedTime)
        {
            int min = (int)(elapsedTime / CONSTANTS.MIN);
            int sec = (int)Mathf.Round(elapsedTime % 60); // to handle rounding errors for the Clock once Stop
            string timeFormattedString = min.ToString() + " : " + GENERIC.FormatSingleDigit(sec);
            return timeFormattedString;
        }
    */
    public string PrintTime(float elapsedTime)
    {
        int min = (int)(elapsedTime / CONSTANTS.MIN);
        int sec = (int)(elapsedTime % CONSTANTS.MIN); // to handle rounding errors for the Clock once Stop
        string timeFormattedString = min.ToString() + " : " + GENERIC.FormatSingleDigit(sec);
        return timeFormattedString;
    }


    public string PrintTime()
    {
        return PrintTime(elapsedTime_);
    }






    public void Update_UI_Color(float ratio)
    {
        Color color = collectionColorRange_.GetResultBasedOnThreshold(0.95f - ratio);
        Update_UI_Color(color);
    }

    public void Update_UI_Blinking(float ratio)
    {
        if (ratio > collectionColorRange_.GetThresholds()[collectionColorRange_.GetThresholds().Count - 1] && !GetIsBlinking())
        {
            BlinkTextIndefinitely();
        }
    }

}


