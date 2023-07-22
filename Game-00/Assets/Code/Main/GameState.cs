using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState
{
    private static CONSTANTS_ENUM.GAME_STATE gameState_ = CONSTANTS_ENUM.GAME_STATE.PLAY;

    private static CONSTANTS_ENUM.TIME_MODE timeMode_ = CONSTANTS_ENUM.TIME_MODE.CLOCK_MODE;
    private static float gameDuration_ = 15;//CONSTANTS.DEFAULT_TIME_DURATION;
    private static CONSTANTS_ENUM.BORDER_TYPE shape_ = CONSTANTS_ENUM.BORDER_TYPE.RECTANGLE;
    private static float shapeSize_ = CONSTANTS.DEFAULT_NORMAL_SIZE_FACTOR;
    private static bool startTime_ = false;


    public static void Pause_Resume_Game()
    {
        if (INPUT.Input_Pause_Resume())
        {
            if (gameState_ == CONSTANTS_ENUM.GAME_STATE.PLAY)
            {
                SetGameMode(CONSTANTS_ENUM.GAME_STATE.PAUSE);
            }
            else if (gameState_ == CONSTANTS_ENUM.GAME_STATE.PAUSE)
            {
                SetGameMode(CONSTANTS_ENUM.GAME_STATE.PLAY);
            }
        }
    }

    public static void SetGameMode(CONSTANTS_ENUM.GAME_STATE mode)
    {
        gameState_ = mode;
        if (gameState_ == CONSTANTS_ENUM.GAME_STATE.PLAY)
        {
            Play();
        }
        else if (gameState_ == CONSTANTS_ENUM.GAME_STATE.PAUSE)
        {
            Pause();
        }
    }

    public static CONSTANTS_ENUM.GAME_STATE GetGameState()
    {
        return gameState_;
    }

    private static void Play()
    {
        PlayGame();
        Menu_Main_2.instance_.menuPause_.ResumeGame();
    }
    public static void PlayGame()
    {
        Time.timeScale = 1f;
        GameMusic_Main.instance_.gameMusic_OST_.ChangeMusic();
    }
    public static void PauseGame()
    {
        Time.timeScale = 0f;
        GameMusic_Main.instance_.gameMusic_OST_.ChangeMusic();
    }
    private static void Pause()
    {
        PauseGame();
        Menu_Main_2.instance_.menuPause_.PauseGame();
    }


    public static void Toggle()
    {
        gameState_ = GENERIC.ToggleEnum<CONSTANTS_ENUM.GAME_STATE>(gameState_);
    }

    public static void SaveGameOnExit()
    {
        UI_Main.instance_.UI_Stats_All_.Update_UI_Text(CONSTANTS_STRING.UI_GAME_STATE_MESSAGE_EXIT);
        Load_Save.SaveData();
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
    public static CONSTANTS_ENUM.TIME_MODE GetTimeMode()
    {
        return timeMode_;
    }

    public static float GetGameDuration()
    {
        return gameDuration_;
    }

    public static CONSTANTS_ENUM.BORDER_TYPE GetShape()
    {
        return shape_;
    }

    public static float GetShapeSize()
    {
        return shapeSize_;
    }

    // Setters
    public static void SetTimeMode(CONSTANTS_ENUM.TIME_MODE timeMode)
    {
        timeMode_ = timeMode;
    }

    public static void SetGameDuration(float gameDuration)
    {
        gameDuration_ = gameDuration * CONSTANTS.MIN;
    }

    public static void SetShape(CONSTANTS_ENUM.BORDER_TYPE shape)
    {
        shape_ = shape;
    }
    public static bool GetStartTime()
    {
        return startTime_;
    }

    public static void SetShapeSize(float shapeSize)
    {
        shapeSize_ = shapeSize;
    }
    public static void Init_UpdateTIme()
    {
        Time_Main.Running();
        UI_Main.instance_.UI_Time_.Update_UI();
    }

    public static void Init_UI()
    {
        UI_Main.instance_.Init_Config();
    }
    public static void ResetGame()
    {

    }
    public static void Init_Main_0()
    {
        LoadingScene.instance_.LoadStartScene();
    }
    public static void Init_Main_1()
    {
        GameMusic_Main.instance_.gameMusic_OST_.SetModeRepeat();
        GameMusic_Main.instance_.gameMusic_OST_.PlayMenuMusic();
    }
    public static void Init_Main_2(MonoBehaviour mono)
    {
        Init_Game_TImer();
        Init_Game_Border();
        Init_Game_SaveFile();
        Init_Game_Music_Level();
        Init_Player(mono);
        PrevFile.LoadFile();
    }
    public static void Init_Game_Music_Level()
    {
        GameMusic_Main.instance_.gameMusic_OST_.SetModeRandom();
        GameMusic_Main.instance_.gameMusic_OST_.PlayOSTMusic();
    }
    public static void Init_Game_State()
    {
        SetGameMode(CONSTANTS_ENUM.GAME_STATE.PLAY);
    }
    public static void Init_Game_Border_Shape()
    {
        switch (shape_)
        {
            case CONSTANTS_ENUM.BORDER_TYPE.RECTANGLE:
                Border_Main.instance_.SetRectangle();
                break;
            case CONSTANTS_ENUM.BORDER_TYPE.PENTAGON:
                Border_Main.instance_.SetPentagon();
                break;
            case CONSTANTS_ENUM.BORDER_TYPE.CIRCLE:
                Border_Main.instance_.SetCircle();
                break;
            case CONSTANTS_ENUM.BORDER_TYPE.SQUARE:
                Border_Main.instance_.SetSquare();
                break;
            //... Repeat this pattern for the other types in the enum.
            case CONSTANTS_ENUM.BORDER_TYPE.HEXAGON:
                Border_Main.instance_.SetHexagon();
                break;
            case CONSTANTS_ENUM.BORDER_TYPE.STAR:
                Border_Main.instance_.SetStar();
                break;
            case CONSTANTS_ENUM.BORDER_TYPE.RANDOM:
                Border_Main.instance_.SetRandomShape();
                break;
            default:
                //Debug.LogWarning("No valid shape was provided.");
                break;
        }
    }

    public static void Init_Game_Border_Size()
    {
        Border_Main.instance_.SetDefaultParameters(shapeSize_);
    }
    public static void Init_Game_SaveFile()
    {
        PrevFile.LoadFile();
    }
    public static void Init_Game_Border()
    {
        Init_Game_Border_Size();
        Init_Game_Border_Shape();
    }
    public static void Init_Method_OnStart()
    {
        startTime_ = true;
        Spawning_Level_Main.instance_.StartSpawners();
        //GameState.instance_.SetGameMode(CONSTANTS_ENUM.GAME_STATE.PLAY);
    }
    public static void Init_Game_TImer()
    {
        System.Action method = UI_Main.instance_.UI_Time_.Update_UI;
        method += UI_Main.instance_.UI_Time_.StopBlinking;
        method += PauseGame;
        method += Menu_Main_2.instance_.RoundOver;
        Time_Main.SetTimeMode(timeMode_, gameDuration_, method);
    }
    public static void Init_Player(MonoBehaviour mono)
    {
        Player_Main.instance_.transform.position = CONSTANTS.DEFAULT_START_POINT;
        UI_Stats_1 countDown = (UI_Stats_1)UI_Main.instance_.UI_Stats_All_;
        countDown.Update_UI_CountDown(Init_Method_OnStart, CONSTANTS.DEFAULT_START_COUNTDOWN);
        mono.StartCoroutine(INPUT.DisableInputForDuration());
    }
}
