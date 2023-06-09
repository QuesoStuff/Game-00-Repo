using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Test_01 : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {
        //this.ScaleOverTime(Player_Main.instance_.gameObject, 1.2f, 5);
        //this.ScaleOverTime(UI_Main.instance_.UI_Debug_.gameObject, 5, 5);
        Time_Manager.instance_.SetTimeMode(CONSTANTS.TIME_MODE.CLOCK_MODE, 15);
    }
    void Shoot_type()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Bullet_Config.SetIsTypeCharged(false);
            Bullet_Config.SetIsTypeLazer(false);
            Bullet_Config.SetIsTypeMissle(false);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- All bullet types reset --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Bullet_Config.SetIsTypeCharged(true);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Charged --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Bullet_Config.SetIsTypeLazer(true);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Lazer --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Bullet_Config.SetIsTypeMissle(true);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Missile --");
        }
    }

    void Shoot_Stat()
    {

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Bullet_Config.SetIsStatAccelerate(false);
            Bullet_Config.SetIsStatUniformSpeed(false);
            Bullet_Config.SetIsStatIncreaseHealth(false);
            Bullet_Config.SetIsStatIncreasedDamage(false);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- All bullet stats reset --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Bullet_Config.SetIsStatAccelerate(true);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Accelerate --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Bullet_Config.SetIsStatUniformSpeed(true);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Uniform Speed --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Bullet_Config.SetIsStatIncreaseHealth(true);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Increase Health --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Bullet_Config.SetIsStatIncreasedDamage(true);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Increased Damage --");
        }
    }

    public void ClearDebug()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("");
        }
    }
    public void TimeStuff()
    {
        Time_Manager.instance_.Running(); // Call the Running method of the current time mode
        UI_Main.instance_.UI_Time.Update_UI();
        if (Input.GetKeyDown(KeyCode.T))
        {
            Time_Manager.instance_.ToggleTimeMode(); // Call the Running method of the current time mode
        }
    }
    public void Delete_SaveFile()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Load_Save.DeleteSaveFile();
            UI_Main.instance_.UI_Pause_Resume_.Update_UI_Text("-- DELETE --");
        }
    }
    public void Blinking()
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
    public void UI_Tester()
    {
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
    }

    void Update()
    {
        TimeStuff();
        Delete_SaveFile();
        Blinking();
        UI_Tester();
        ClearDebug();
        Shoot_Stat();
        Shoot_type();
    }
}
