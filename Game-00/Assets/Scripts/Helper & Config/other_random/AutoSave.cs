using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class AutoSave
{
    private const int saveIntervalMinutes = 5; // Set the auto-save interval in minutes

    static AutoSave()
    {
        EditorApplication.playModeStateChanged += AutoSaveOnPlayModeChanged;
    }

    private static void AutoSaveOnPlayModeChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredPlayMode)
        {
            EditorApplication.update += AutoSaveUpdate;
        }
        else if (state == PlayModeStateChange.ExitingPlayMode)
        {
            EditorApplication.update -= AutoSaveUpdate;
        }
    }

    private static void AutoSaveUpdate()
    {
        if (EditorApplication.timeSinceStartup % (saveIntervalMinutes * 60) < Time.deltaTime)
        {
            Debug.Log("Auto-saving project...");
            EditorSceneManager.SaveOpenScenes();
            AssetDatabase.SaveAssets();
        }
    }
}
