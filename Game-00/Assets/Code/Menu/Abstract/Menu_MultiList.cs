using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class Menu_MultiList : Menu
{


    protected void UpdateColors()
    {
        var currentList = complexOptionsWrappers_[selectedIndex_].uiList;

        // Reset all options in the current list to their default color
        foreach (var option in currentList)
        {
            option.Update_UI_Color(Color.blue); // Replace with the appropriate default color
        }

        // Set the current selected option in the current list to the desired color
        currentList[selectedSubIndex_].Update_UI_Color(Color.red);
    }


    protected override void HandleMoveUpDown()
    {
        bool isMoved = false;
        if (INPUT.Input_Tap_Up())
        {
            isMoved = true;
            StopBlinking(selectedIndex_, selectedSubIndex_);
            selectedIndex_ = (selectedIndex_ - 1 + complexOptionsWrappers_.Count) % complexOptionsWrappers_.Count;
            StartBlinking(selectedIndex_, selectedSubIndex_);
        }
        else if (INPUT.Input_Tap_Down())
        {
            isMoved = true;
            StopBlinking(selectedIndex_, selectedSubIndex_);
            selectedIndex_ = (selectedIndex_ + 1) % complexOptionsWrappers_.Count;
            StartBlinking(selectedIndex_, selectedSubIndex_);
        }
        if (isMoved)
            GameMusic_Main.instance_.gameMusic_SFX_.IconMove();

    }

    protected override void HandleMoveLeftRight()
    {
        var complexOptions_ = complexOptionsWrappers_[selectedIndex_].uiList;
        bool isMoved = false;
        if (INPUT.Input_Tap_Left())
        {
            isMoved = true;
            StopBlinking(selectedIndex_, selectedSubIndex_);
            selectedSubIndex_ = (selectedSubIndex_ - 1 + complexOptions_.Count) % complexOptions_.Count;
            StartBlinking(selectedIndex_, selectedSubIndex_);
        }
        else if (INPUT.Input_Tap_Right())
        {
            isMoved = true;
            StopBlinking(selectedIndex_, selectedSubIndex_);
            selectedSubIndex_ = (selectedSubIndex_ + 1) % complexOptions_.Count;
            StartBlinking(selectedIndex_, selectedSubIndex_);
        }
        if (isMoved)
            GameMusic_Main.instance_.gameMusic_SFX_.IconMove();
    }


}
