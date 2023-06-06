using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance_;
    public static CONSTANTS.GAME_STATE gameState_;


    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject);
    }

    private void Start()
    {
        SetGameMode(CONSTANTS.GAME_STATE.PLAY);
        LoadGame();
    }

    // Update is called once per frame
    private void Update()
    {
        HandleInput();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SaveGameOnExit();
        }

    }


    // Handles the input for pausing and resuming the game
    private void HandleInput()
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

    // Sets the game mode and performs corresponding actions
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
    }

    public CONSTANTS.GAME_STATE GetGameState()
    {
        return gameState_;
    }

    // Actions to perform when the game is in the "Play" mode
    private void Play()
    {
        Time.timeScale = 1f;
        UI_Main.instance_.UI_Pause_Resume_.Update_UI();
        UI_Main.instance_.UI_Pause_Resume_.StopBlinking();
    }

    // Actions to perform when the game is in the "Pause" mode
    private void Pause()
    {
        Time.timeScale = 0f;
        UI_Main.instance_.UI_Pause_Resume_.Update_UI();
        UI_Main.instance_.UI_Pause_Resume_.BlinkTextIndefinitely();

    }

    public void Toggle()
    {
        gameState_ = GENERIC.ToggleEnum<CONSTANTS.GAME_STATE>(gameState_); // Returns SecondValue
    }

    private void LoadGame()
    {
        // load the highest record file
        PrevFile.instance_.LoadFile();

        // load the main record
        //Load_Save.LoadData(recordMain_);
    }

    public void SaveGameOnExit()
    {
        UI_Main.instance_.UI_Pause_Resume_.Update_UI_Text("-- EXIT --");
        // save the main record
        Load_Save.SaveData(Record_Main.instance_);
        Debug.Log("Game saved on exit!");
        // you can call Application.Quit() here to quit the game
        // you can call Application.Quit() here to quit the game
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
