using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneObjectManager
{
    private static List<List<GameObject>> sceneObjects_ = new List<List<GameObject>>();
    private static List<GameObject> inactiveObjects_ = new List<GameObject>();

    public static void Initialize(int sceneCount)
    {
        for (int i = 0; i < sceneCount; i++)
        {
            sceneObjects_.Add(new List<GameObject>());
        }
    }

    public static void AddObjectToScene(GameObject gameObject, int sceneIndex)
    {
        if (GENERIC.IsValidIndex(sceneObjects_, sceneIndex))
        {
            sceneObjects_[sceneIndex].Add(gameObject);
        }
    }

    public static void RemoveObjectFromScene(GameObject gameObject, int sceneIndex)
    {
        if (GENERIC.IsValidIndex(sceneObjects_, sceneIndex))
        {
            sceneObjects_[sceneIndex].Remove(gameObject);
        }
    }

    public static void AddAllObjectsInScene(int sceneIndex)
    {
        if (GENERIC.IsValidIndex(sceneObjects_, sceneIndex))
        {
            GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            foreach (GameObject obj in allObjects)
            {
                sceneObjects_[sceneIndex].Add(obj);
            }
        }
    }

    public static void DeleteAllObjectsInScene(int sceneIndex)
    {
        if (GENERIC.IsValidIndex(sceneObjects_, sceneIndex))
        {
            for (int i = sceneObjects_[sceneIndex].Count - 1; i >= 0; i--)
            {
                UnityEngine.Object.Destroy(sceneObjects_[sceneIndex][i]);
                sceneObjects_[sceneIndex].RemoveAt(i);
            }
        }
    }

    public static void ManageSceneObjects(int sceneIndex)
    {
        if (GENERIC.IsValidIndex(sceneObjects_, sceneIndex))
        {
            if (sceneObjects_[sceneIndex].Count == 0)
            {
                // This is the first time this scene is loaded, so add all GameObjects to the list.
                AddAllObjectsInScene(sceneIndex);
            }
            else
            {
                // This scene is being re-loaded, so instantiate all GameObjects from the list into the scene.
                ClearScene();
                foreach (GameObject obj in sceneObjects_[sceneIndex])
                {
                    GameObject.Instantiate(obj);
                }
            }
        }
    }

    private static void ClearScene()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            UnityEngine.Object.Destroy(obj);
        }
    }

    public static void DisableObjectsInScene(MonoBehaviour context, int sceneIndex)
    {
        if (GENERIC.IsValidIndex(sceneObjects_, sceneIndex))
        {
            context.StartCoroutine(DisableObjectsCoroutine(sceneIndex));
        }
    }

    private static IEnumerator DisableObjectsCoroutine(int sceneIndex)
    {
        foreach (GameObject obj in sceneObjects_[sceneIndex])
        {
            if (obj.activeInHierarchy)
            {
                inactiveObjects_.Add(obj);
                obj.SetActive(false);
            }
        }
        yield return null;
    }

    public static void EnableObjectsInScene(MonoBehaviour context)
    {
        context.StartCoroutine(EnableObjectsCoroutine());
    }

    private static IEnumerator EnableObjectsCoroutine()
    {
        foreach (GameObject obj in inactiveObjects_)
        {
            obj.SetActive(true);
        }
        inactiveObjects_.Clear();
        yield return null;
    }

    public static void DisableNonPersistentObjectsInScene(MonoBehaviour context, int sceneIndex)
    {
        if (GENERIC.IsValidIndex(sceneObjects_, sceneIndex))
        {
            context.StartCoroutine(DisableNonPersistentObjectsCoroutine(sceneIndex));
        }
    }

    private static IEnumerator DisableNonPersistentObjectsCoroutine(int sceneIndex)
    {
        foreach (GameObject obj in sceneObjects_[sceneIndex])
        {
            if (!obj.CompareTag("Persistent"))
            {
                if (obj.activeInHierarchy)
                {
                    inactiveObjects_.Add(obj);
                    obj.SetActive(false);
                }
            }
        }
        yield return null;
    }
}
