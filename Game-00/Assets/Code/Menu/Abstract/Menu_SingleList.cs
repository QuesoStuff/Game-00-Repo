
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class Menu_SingleList : Menu
{
    public override void ResetMenu()
    {
        selectedIndex_ = 0;
    }

    protected override void HandleMoveUpDown()
    {
        return;
    }

    protected override void HandleMoveLeftRight()
    {
        return;
    }



}
