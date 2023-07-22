using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Config_Duration : Menu_SingleList_Horizontal
{



    public override void HandleSelection()
    {
        // HandleDurationSelection();
        method_?.Invoke();
    }

    public void HandleDurationSelection()
    {
        int duration = 0;
        if (selectedIndex_ == 0)  // "3 min" option
        {
            duration = 3;
        }
        else if (selectedIndex_ == 1)  // "5 min" option
        {
            duration = 5;
        }
        else if (selectedIndex_ == 2)  // "7 min" option
        {
            duration = 7;
        }
        GameState.SetGameDuration(duration);

    }
}
