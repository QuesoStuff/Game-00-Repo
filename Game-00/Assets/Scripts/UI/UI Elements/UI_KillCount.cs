using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_KillCount : UI
{
    [SerializeField] public Record_Main records_;

    public override void Update_UI()
    {
        string mess = PrintKillCount();
        if (PrevFile.instance_.CompareKillCount())
            Update_UI_Color();
        Update_UI_Text(mess);
    }
    public string PrintKillCount()
    {
        //int shotCount = Record_Main.instance_.GetKillCount();
        int shotCount = records_.GetKillCount();

        return shotCount.ToString();
    }
}
