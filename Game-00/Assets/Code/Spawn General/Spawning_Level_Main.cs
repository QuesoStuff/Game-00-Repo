using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning_Level_Main : MonoBehaviour
{
    [SerializeField] public Spawning_Level_Enemy enemySpawner_;
    [SerializeField] public Spawning_Level_Item itemSpawner_;
    [SerializeField] public Spawning_Level_Wall wallSpawner_;
    [SerializeField] public Spawning_Level_Door doorSpawner_;

    [SerializeField] private float Max_Time_;
    public static Spawning_Level_Main instance_;



    private const int MaxTotalEntities_ = CONSTANTS.DEFAULT_MAX_SPAWNING_COUNT;

    private bool spawningIsActive_ = true;

    private int GetActiveCountLocally()
    {
        return enemySpawner_.GetActiveCountLocally()
            + itemSpawner_.GetActiveCountLocally()
            + wallSpawner_.GetActiveCountLocally()
            + doorSpawner_.GetActiveCountLocally();
    }
    public float GetMaxTime()
    {
        return Max_Time_;
    }
    public void SetMaxTime(float newTIme = 3)
    {
        Max_Time_ = newTIme * CONSTANTS.MIN_TO_SEC;
    }
    void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject);
    }




    public void StartSpawners()
    {
        enemySpawner_.StartSpawn();
        itemSpawner_.StartSpawn();
        wallSpawner_.StartSpawn();
        doorSpawner_.StartSpawn();
    }

    public void StopSpawners()
    {
        enemySpawner_.StopSpawningRoutine();
        itemSpawner_.StopSpawningRoutine();
        wallSpawner_.StopSpawningRoutine();
        doorSpawner_.StopSpawningRoutine();
        spawningIsActive_ = false;
    }

    void Update()
    {
        if (Time_Manager.instance_.GetRunningTime() > Max_Time_)
        {
            StopSpawners();
        }
        else if (spawningIsActive_ && GetActiveCountLocally() >= MaxTotalEntities_)
        {
            StopSpawners();
        }
        else if (!spawningIsActive_ && GetActiveCountLocally() <= 0.75 * MaxTotalEntities_)
        {
            StartSpawners();
            spawningIsActive_ = true;
        }
    }
}
