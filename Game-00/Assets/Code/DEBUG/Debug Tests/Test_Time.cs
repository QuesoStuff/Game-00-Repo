using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Test_Time
{
    public static void TimeStuff()
    {
        Time_Main.Running();
        UI_Main.instance_.UI_Time_.Update_UI();
        if (Input.GetKeyDown(KeyCode.T))
        {
            Time_Main.ToggleTimeMode();
        }
    }
}
