
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Test_Level
{
    // Start is called before the first frame update

    public static void ReloadLEvel()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            LoadingScene.instance_.ReloadScene();
        }
    }
}