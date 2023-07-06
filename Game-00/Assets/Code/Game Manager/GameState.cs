using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance_;
    [SerializeField] private CONSTANTS.GAME_STATE gameState_;


    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject);
    }

    private void Start()
    {
        SetGameMode(CONSTANTS.GAME_STATE.PLAY);
        LoadGame();
    }

    private void Update()
    {
        HandleInput();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SaveGameOnExit();
        }
    }


    public void HandleInput()
    {
        if (INPUT.instance_.Input_Pause_Resume())
        {
            if (gameState_ == CONSTANTS.GAME_STATE.PLAY)
            {
                SetGameMode(CONSTANTS.GAME_STATE.PAUSE);
            }
            else if (gameState_ == CONSTANTS.GAME_STATE.PAUSE)
            {
                SetGameMode(CONSTANTS.GAME_STATE.PLAY);
            }
        }
    }


    private void SetGameMode(CONSTANTS.GAME_STATE mode)
    {
        gameState_ = mode;

        if (gameState_ == CONSTANTS.GAME_STATE.PLAY)
        {
            Play();

        }
        else if (gameState_ == CONSTANTS.GAME_STATE.PAUSE)
        {
            Pause();
        }
        ACTIVE.TriggerEvent_DoorFlashing(gameState_ == CONSTANTS.GAME_STATE.PLAY);
    }

    public CONSTANTS.GAME_STATE GetGameState()
    {
        return gameState_;
    }

    private void Play()
    {
        Time.timeScale = 1f;
        UI_Main.instance_.UI_Pause_Resume_.Update_UI();
        UI_Main.instance_.UI_Pause_Resume_.StopBlinking();
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        UI_Main.instance_.UI_Pause_Resume_.Update_UI();
        UI_Main.instance_.UI_Pause_Resume_.BlinkTextIndefinitely();
    }

    public void Toggle()
    {
        gameState_ = GENERIC.ToggleEnum<CONSTANTS.GAME_STATE>(gameState_);
    }

    private void LoadGame()
    {
        PrevFile.instance_.LoadFile();
    }
    public void Restart()
    {
        GENERIC.RestartScene();
    }
    public void SaveGameOnExit()
    {
        UI_Main.instance_.UI_Pause_Resume_.Update_UI_Text("-- EXIT --");
        Load_Save.SaveData(Record_Main.instance_);
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }

}
