using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Retry : Menu_SingleList_Vertical
{

    public override void HandleSelection()
    {
        if (selectedSubIndex_ == 0)  // "Resume" option
        {
            LoadingScene.instance_.ReloadScene();
        }
        else if (selectedSubIndex_ == 1)  // "Main Menu" option
        {
            LoadingScene.instance_.LoadStartScene();
            Menu_Main_1.instance_.gameObject.SetActive(true);
        }
        SetActive(false);
        Time.timeScale = 1f;
    }
}