using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Pause : Menu_SingleList_Vertical
{
    private bool gameIsPaused_ = false;



    public void SetGamePaused(bool val)
    {
        gameIsPaused_ = val;
    }


    public override void HandleSelection()
    {
        if (selectedSubIndex_ == 0)  // "Resume" option
        {
            ResumeGame();
            GameState.SetGameMode(CONSTANTS_ENUM.GAME_STATE.PLAY);
        }
        else if (selectedSubIndex_ == 1)  // "Main Menu" option
        {
            LoadingScene.instance_.LoadStartScene();
            Menu_Main_1.instance_.gameObject.SetActive(true);
        }
    }

    public void PauseGame()
    {
        gameIsPaused_ = true;
        ResetMenu();
        SetActive(true);
    }

    public void ResumeGame()
    {
        gameIsPaused_ = false;
        SetActive(false);
    }
    public void ExitGame()
    {
        ResumeGame();
        Time.timeScale = 1f;
        LoadingScene.instance_.LoadStartScene();
    }
}
