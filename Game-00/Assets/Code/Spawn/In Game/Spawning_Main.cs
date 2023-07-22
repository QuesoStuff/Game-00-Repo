using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning_Main : MonoBehaviour
{
    [SerializeField] public Spawning_Object spawning_GameObjects_;
    [SerializeField] public Spawning_SFX spawning_SFX_;
    public static Spawning_Main instance_;

    void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject, false);
    }
    IEnumerator RoutineClean()
    {
        while (true)
        {
            yield return new WaitForSeconds(30);
            spawning_GameObjects_.CleanUpEntities();
            spawning_SFX_.CleanUpEntities();
        }
    }
    void Start()
    {
        StartCoroutine(RoutineClean());
    }


}
