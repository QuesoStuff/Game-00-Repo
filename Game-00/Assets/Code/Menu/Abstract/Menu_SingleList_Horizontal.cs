
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class Menu_SingleList_Horizontal : Menu_SingleList
{
    public override void ResetMenu()
    {
        selectedIndex_ = 0;
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
