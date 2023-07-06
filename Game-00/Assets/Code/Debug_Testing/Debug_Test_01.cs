using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Test_01 : MonoBehaviour
{


    public void BorderBuilds()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Rectangle Build Border: ");
            Border_Main.instance_.SetMaze_Easy();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Square  Build Border: ");
            Border_Main.instance_.SetMaze_Medium();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Circle Build Border: ");
            Border_Main.instance_.SetMaze_Hard();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Elipse Build Border: ");
            Border_Main.instance_.SetPill();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Diamond Build Border: ");
            Border_Main.instance_.SetTrapezoid();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Trap Build Border: ");
            Border_Main.instance_.SetRectangle();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("--Triangle Build Border: ");
            Border_Main.instance_.SetSquare();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-Pentagon- Build Border: ");
            Border_Main.instance_.SetSemiCircleRight();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-Pentagon- Build Border: ");
            Border_Main.instance_.SetMaze_Easy();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-Pentagon- Build Border: ");
            Border_Main.instance_.SetMaze_Easy();
        }
    }
    void Awake()
    {
    }
    void Start()
    {
        // Spawning_Level_Main.instance_.SetMaxTime();
        //Spawning_Level_Main.instance_.StartSpawners();
        //Time_Manager.instance_.SetTimeMode(CONSTANTS.TIME_MODE.TIMER_MODE, Spawning_Level_Main.instance_.GetMaxTime());
        Border_Main.instance_.SetSquare();
        Border_Main.instance_.SetRectangle();

        Spawning_Level_Main.instance_.SetMaxTime();
        Time_Manager.instance_.SetTimeMode(CONSTANTS.TIME_MODE.TIMER_MODE, Spawning_Level_Main.instance_.GetMaxTime());
        Spawning_Level_Main.instance_.StartSpawners();
    }
    void Shoot_type()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ACTIVE.SetIsTypeCharged(false);
            ACTIVE.SetIsTypeLazer(false);
            ACTIVE.SetIsTypeMissle(false);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- All bullet types reset --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            ACTIVE.SetIsTypeCharged(true);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Charged --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            ACTIVE.SetIsTypeLazer(true);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Lazer --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            ACTIVE.SetIsTypeMissle(true);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Missile --");
        }
    }

    void Shoot_Stat()
    {

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            ACTIVE.SetIsStatAccelerate(false);
            ACTIVE.SetIsStatUniformSpeed(false);
            ACTIVE.SetIsStatIncreaseHealth(false);
            ACTIVE.SetIsStatIncreasedDamage(false);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- All bullet stats reset --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ACTIVE.SetIsStatAccelerate(true);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Accelerate --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ACTIVE.SetIsStatUniformSpeed(true);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Uniform Speed --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ACTIVE.SetIsStatIncreaseHealth(true);
            UI_Main.instance_.UI_Debug_.Update_UI_Text("-- Increase Health --");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ACTIVE.SetIsStatIncreasedDamage(true);
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
        Time_Manager.instance_.Running();
        UI_Main.instance_.UI_Time.Update_UI();
        if (Input.GetKeyDown(KeyCode.T))
        {
            Time_Manager.instance_.ToggleTimeMode();
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
            ScoreManager.instance_.ScoreIncrease();
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
        if (Input.GetKeyDown(KeyCode.M))
        {
            bool inBound = Border_Main.instance_.IsInBounds(Player_Main.instance_.transform.position);
            UI_Main.instance_.UI_Debug_.Update_UI_Text(inBound.ToString());
        }



        // BorderBuilds();
    }
}
