using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BulletCount : UI
{

    public override void Update_UI()
    {
        string mess = PrintBulletCOunt();
        if (PrevFile.CompareBulletCount())
            Update_UI_Color();
        Update_UI_Text(CONSTANTS_STRING.DEFAULT_UI_BULLET + mess);
    }

    public string PrintBulletCOunt()
    {
        int shotCount = Record_Main.GetBulletCount();
        return shotCount.ToString();
    }
}

