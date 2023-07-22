using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Test_Player_and_UI
{
    // Start is called before the first frame update

    public static void Player_UI()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            UI_Main.instance_.UI_KillCount_.BlinkTextIndefinitely();
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- BLINK? --");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            UI_Main.instance_.UI_KillCount_.StopBlinking();
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- STOP Flash/Blink --");
        }
    }
    public static void UI_Blinking()
    {
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
    }

    public static void UI_Testing()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ScoreManager.ScoreIncrease();
            Record_Controller.HighScore();
            UI_Main.instance_.UI_Score_.Update_UI();
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- score up --");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Player_Main.instance_.player_Health_.Heal();
            Record_Controller.AddToTotalHeal();
            UI_Main.instance_.UI_Health_.Update_UI();
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- HP++ --");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Player_Main.instance_.player_Health_.Damage();
            Record_Controller.AddToTotalHeal();
            UI_Main.instance_.UI_Health_.Update_UI();
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- HP-- --");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Record_Controller.KillCount();
            UI_Main.instance_.UI_KillCount_.Update_UI();
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- KILL --");
        }
    }

}
