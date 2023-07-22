using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class LoadingScene : MonoBehaviour
{
    public static LoadingScene instance_;


    [SerializeField] private TransitionPair currTransition_;

    public void LoadScene(int sceneIndex)
    {
        // GENERIC.LoadSceneAsyncStartCoroutine(this, sceneIndex, onLoad_.TransitionCoroutine, onComplete_.BeginTransition);
        currTransition_.gameObject.SetActive(true);
        GENERIC.LoadSceneAsyncStartCoroutine(this, sceneIndex, currTransition_.StartCoroutine, currTransition_.EndTransition);
    }




    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject, true);
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        LoadScene(nextSceneIndex);
    }

    public void LoadPreviousScene()
    {
        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        if (previousSceneIndex < 0)
        {
            previousSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        }
        LoadScene(previousSceneIndex);
    }

    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        LoadScene(currentSceneIndex);
    }

    public void LoadStartScene()
    {
        //LoadScene(0);
        //Load_Save.SaveData();
        //GameState.ResetGame();
        LoadScene(0);

    }
}
