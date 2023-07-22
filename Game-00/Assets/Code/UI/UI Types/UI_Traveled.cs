using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Traveled : UI
{

    public override void Update_UI()
    {

        string mess = PrintistanceTraveled();
        if (PrevFile.CompareDistanceTraveled())
            Update_UI_Color();
        Update_UI_Text(CONSTANTS_STRING.DEFAULT_UI_DISTANCE + mess + "m");

    }

    public string PrintistanceTraveled()
    {
        float distance = Record_Main.GetDistanceTraveled() / CONSTANTS.DEFAULT_TRAVEL_COEFFICIENT;
        return distance.ToString("F2");
    }
}





