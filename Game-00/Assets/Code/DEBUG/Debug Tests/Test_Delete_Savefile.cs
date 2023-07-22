using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Test_Delete_Savefile
{

    public static void Delete_SaveFile()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Load_Save.DeleteSaveFile();
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- DELETE --");
        }
    }
}