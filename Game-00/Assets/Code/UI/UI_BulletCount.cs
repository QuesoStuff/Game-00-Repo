using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BulletCount : UI
{
    [SerializeField] internal Record_Main records_;

    public override void Update_UI()
    {
        string mess = PrintBulletCOunt();
        if (PrevFile.instance_.CompareBulletCount())
            Update_UI_Color();
        Update_UI_Text(mess);
    }

    public string PrintBulletCOunt()
    {
        int shotCount = records_.GetBulletCount();
        //int shotCount = Record_Main.instance_.GetBulletCount();
        return shotCount.ToString();
    }
}

