using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_KillCount : UI
{

    public override void Update_UI()
    {
        string mess = PrintKillCount();
        if (PrevFile.CompareKillCount())
            Update_UI_Color();
        Update_UI_Text(CONSTANTS_STRING.DEFAULT_UI_KILL + mess);
    }
    public string PrintKillCount()
    {
        int shotCount = Record_Main.GetKillCount();

        return shotCount.ToString();
    }
}
