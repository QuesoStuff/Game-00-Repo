using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Debug_FrameRate : UI
{
    public override void Update_UI()
    {
        float frameRate = PerformanceMonitor.GetFrameRate();
        Update_UI_Text("FPS: " + frameRate.ToString());
    }
    void Update()
    {
        Update_UI();
    }
}



