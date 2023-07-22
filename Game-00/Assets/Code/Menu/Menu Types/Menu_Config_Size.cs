using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Config_Size : Menu_SingleList_Horizontal
{



    public override void HandleSelection()
    {
        // HandleSizeSelection();
        method_?.Invoke();
    }
    public void HandleSizeSelection()
    {
        float scale = 1;
        if (selectedIndex_ == 0)  // "Small" option
        {
            scale = CONSTANTS.DEFAULT_SMALL_SIZE_FACTOR;
        }
        else if (selectedIndex_ == 1)  // "Normal" option
        {
            scale = CONSTANTS.DEFAULT_NORMAL_SIZE_FACTOR;
        }
        else if (selectedIndex_ == 2)  // "Large" option
        {
            scale = CONSTANTS.DEFAULT_LARGE_SIZE_FACTOR;
        }
        GameState.SetShapeSize(scale);
    }


}
