using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Config_Shape : Menu_SingleList_Horizontal
{



    public override void HandleSelection()
    {
        //HandleShapeSelection();
        method_?.Invoke();
    }


    public void HandleShapeSelection()
    {
        if (selectedIndex_ == 0)  // "Square" option
        {
            GameState.SetShape(CONSTANTS_ENUM.BORDER_TYPE.SQUARE);
        }
        else if (selectedIndex_ == 1)  // "Circle" option
        {
            GameState.SetShape(CONSTANTS_ENUM.BORDER_TYPE.CIRCLE);
        }
        else if (selectedIndex_ == 2)  // "Random" option
        {
            GameState.SetShape(CONSTANTS_ENUM.BORDER_TYPE.RANDOM);
        }
    }
}
