


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Options : Menu_SingleList_Vertical
{
    public void TimeMode()
    {
        if (selectedSubIndex_ == 0)
        {
            GameState.SetTimeMode(CONSTANTS_ENUM.TIME_MODE.CLOCK_MODE);
        }
        else if (selectedSubIndex_ == 1)
        {
            GameState.SetTimeMode(CONSTANTS_ENUM.TIME_MODE.TIMER_MODE);
        }
    }

    public override void HandleSelection()
    {

        // TimeMode();
        method_?.Invoke();
    }

}
