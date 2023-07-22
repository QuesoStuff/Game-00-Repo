using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_2 : MonoBehaviour
{
    // Start is called before the first frame update
    public static Main_2 instance_;
    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject, false);
    }


    void Start()
    {
        GameState.Init_Main_2(this);
    }

    void Update()
    {
        if (GameState.GetStartTime())
            GameState.Init_UpdateTIme();
        else
            UI_Main.instance_.UI_Time_.Update_UI();
        GameState.Pause_Resume_Game();


        PerformanceMonitor.MonitorFrameRate();

    }
}
