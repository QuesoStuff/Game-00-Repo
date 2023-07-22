using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Config : Menu_MultiList
{
    private bool[] selectedConfigs;
    protected void Awake()
    {
        selectedConfigs = new bool[complexOptionsWrappers_.Count];
    }

    public bool AllConfigsSelected()
    {
        for (int i = 0; i < selectedConfigs.Length; i++)
        {
            if (selectedConfigs[i] == false)
                return false;
        }
        return true;
    }


    public override void HandleSelection()
    {
        method_?.Invoke();
        /*
        if (selectedIndex_ == 0)
        {
            HandleDurationSelection();
        }
        else if (selectedIndex_ == 1)
        {
            HandleShapeSelection();
        }
        else if (selectedIndex_ == 2)
        {
            HandleSizeSelection();
        }
        selectedConfigs[selectedIndex_] = true; // add this line
        UpdateColors(); // Update colors after handling the current selection
        Debug.Log("List: " + selectedIndex_);
        Debug.Log("Index: " + selectedSubIndex_);

        if (AllConfigsSelected())
        {
            method_?.Invoke();
        }
        */
    }

    private void HandleDurationSelection()
    {
        int duration = 0;
        if (selectedSubIndex_ == 0)  // "3 min" option
        {
            duration = 3;
        }
        else if (selectedSubIndex_ == 1)  // "5 min" option
        {
            duration = 5;
        }
        else if (selectedSubIndex_ == 2)  // "7 min" option
        {
            duration = 7;
        }
        SetDuration(duration);
        GameState.SetGameDuration(duration);

    }

    private void SetDuration(int minutes)
    {
        // Handle duration selection
        var currentList = complexOptionsWrappers_[selectedIndex_].uiList;
        Debug.Log("Duration selected: " + currentList[selectedSubIndex_].GetTextBoxString());
    }

    private void HandleSizeSelection()
    {
        float scale = 1;
        if (selectedSubIndex_ == 0)  // "Small" option
        {
            SetSize("Small");
            scale = CONSTANTS.DEFAULT_SMALL_SIZE_FACTOR;
        }
        else if (selectedSubIndex_ == 1)  // "Normal" option
        {
            SetSize("Normal");
            scale = CONSTANTS.DEFAULT_NORMAL_SIZE_FACTOR;
        }
        else if (selectedSubIndex_ == 2)  // "Large" option
        {
            SetSize("Large");
            scale = CONSTANTS.DEFAULT_LARGE_SIZE_FACTOR;
        }
        GameState.SetShapeSize(scale);
    }

    private void SetSize(string size)
    {
        var currentList = complexOptionsWrappers_[selectedIndex_].uiList;
        Debug.Log("Size selected:  " + currentList[selectedSubIndex_].GetTextBoxString());
    }

    private void HandleShapeSelection()
    {

        if (selectedSubIndex_ == 0)  // "Square" option
        {
            SetShape("Square");
            GameState.SetShape(CONSTANTS_ENUM.BORDER_TYPE.SQUARE);
        }
        else if (selectedSubIndex_ == 1)  // "Circle" option
        {
            SetShape("Circle");
            GameState.SetShape(CONSTANTS_ENUM.BORDER_TYPE.CIRCLE);
        }
        else if (selectedSubIndex_ == 2)  // "Random" option
        {
            SetShape("Random");
            GameState.SetShape(CONSTANTS_ENUM.BORDER_TYPE.RANDOM);
        }
    }

    private void SetShape(string shape)
    {
        // Handle shape selection
        var currentList = complexOptionsWrappers_[selectedIndex_].uiList;
        Debug.Log("Shape selected:  " + currentList[selectedSubIndex_].GetTextBoxString());
    }

}
