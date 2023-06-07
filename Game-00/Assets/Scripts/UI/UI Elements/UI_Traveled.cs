using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Traveled : UI
{
    [SerializeField] public Record_Main records_;

    public override void Update_UI()
    {

        string mess = PrintistanceTraveled();
        if (PrevFile.instance_.CompareDistanceTraveled())
            Update_UI_Color();
        Update_UI_Text(mess + "m");

    }

    public string PrintistanceTraveled()
    {
        //float distance = Record_Main.instance_.GetDistanceTraveled() / CONSTANTS.TRAVELING_DISTANCE_RATE;
        float distance = records_.GetDistanceTraveled() / CONSTANTS.TRAVELING_DISTANCE_RATE;
        return distance.ToString("F2");
    }
}





