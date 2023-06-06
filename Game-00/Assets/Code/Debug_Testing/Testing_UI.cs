using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing_UI : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {
        //this.ScaleOverTime(Player_Main.instance_.gameObject, 1.2f, 5);
        //this.ScaleOverTime(UI_Main.instance_.UI_Debug_.gameObject, 5, 5);
        Time_Manager.instance_.SetTimeMode(CONSTANTS.TIME_MODE.CLOCK_MODE, 15);

    }
    void Update()
    {
        Time_Manager.instance_.Running(); // Call the Running method of the current time mode
        UI_Main.instance_.UI_Time.Update_UI();
        if (Input.GetKeyDown(KeyCode.T))
        {
            Time_Manager.instance_.ToggleTimeMode(); // Call the Running method of the current time mode
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Load_Save.DeleteSaveFile();
            UI_Main.instance_.UI_Pause_Resume_.Update_UI_Text("-- DELETE --");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ScoreManager.instance_.ScoreIncrease(CONSTANTS.DEFAULT_SCORE);
            Record_Main.instance_.records_Controller_.HighScore();
            UI_Main.instance_.UI_Score_.Update_UI();
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- score up --");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Player_Main.instance_.player_Health_.Heal();
            Record_Main.instance_.records_Controller_.TotalHeal();
            UI_Main.instance_.UI_Health_.Update_UI();
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- HP++ --");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Player_Main.instance_.player_Health_.Damage();
            Record_Main.instance_.records_Controller_.TotalDamage();
            UI_Main.instance_.UI_Health_.Update_UI();
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- HP-- --");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Record_Main.instance_.records_Controller_.KillCount();
            UI_Main.instance_.UI_KillCount_.Update_UI();
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- KILL --");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            UI_Main.instance_.UI_KillCount_.BlinkTextIndefinitely();
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- BLINK? --");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            UI_Main.instance_.UI_KillCount_.StopBlinking();
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- STOP Flash/Blink --");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            UI_Main.instance_.UI_KillCount_.BlinkText();
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Flash? --");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("");
        }

    }
}
