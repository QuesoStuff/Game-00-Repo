using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawning_Level : Pooling_Spawning
{
    [SerializeField] protected List<GameObject> prefabs_;
    protected GameObject currPrefab_;
    protected Main currMain_;

    protected static int totalSpawnedAcrossAll_ = 0;
    protected static int totalActiveAcrossAll_ = 0;
    protected static int totalDestroyedAcrossAll_ = 0;

    ///protected Queue<GameObject> pool_ = new Queue<GameObject>();
    //protected List<GameObject> entities_ = new List<GameObject>();
    protected int activeEntitiesCount_ = 0;
    protected int totalEntitiesSpawnedLocally_ = 0;
    protected int destroyedEntitiesCountLocally_ = 0;
    protected float spawnDelay_ = 1f;
    protected float startingTime_ = CONSTANTS.DEFAULT_SPAWN_DELAY;
    [SerializeField] protected Transform target_;  // Target reference
    [SerializeField] protected float minDistance_;
    [SerializeField] protected float maxDistance_;
    [SerializeField] protected float default_MinDistance_ = CONSTANTS.SPAWN_MIN_DISTANCE_FROM_PLAYER;
    [SerializeField] protected float default_MaxDistance_ = CONSTANTS.SPAWN_MAX_DISTANCE_FROM_PLAYER;
    protected float delayByTime_;
    protected float delayByActiveLocally_;
    protected float delayByActiveTotal_;
    protected float delayByTotalSpawnedLocally_;
    protected float delayByTotalSpawnedTotal_;
    protected float delayByDestroyedLocally_;
    protected float delayByDestroyedTotal_;
    protected float delayByPlayerHealth_;
    protected float delayByFrameRate_;

    protected Coroutine spawnCoroutine_;

    public abstract GameObject RandomPickEntity();
    public virtual void AdjustDelayByTime()
    {
        return;
    }

    public virtual void AdjustDelayByActiveLocally()
    {
        return;
    }

    public virtual void AdjustDelayByActiveTotal()
    {
        return;
    }

    public virtual void AdjustDelayByTotalSpawnedLocally()
    {
        return;
    }

    public virtual void AdjustDelayByTotalSpawnedTotal()
    {
        return;
    }

    public virtual void AdjustDelayByDestroyedLocally()
    {
        return;
    }

    public virtual void AdjustDelayByDestroyedTotal()
    {
        return;
    }
    public virtual void AdjustDelayByPlayerHealth()
    {
        return;
    }
    public virtual void AdjustDelayByFrameRate()
    {
        float frameRate = PerformanceMonitor.instance_.GetFrameRate();
        if (frameRate < 30) // If framerate drops below 30
        {
            delayByFrameRate_ = 25; // Increase delay to decrease spawn rate
        }
        else if (frameRate >= 30 && frameRate < 60) // If framerate is between 30 and 60
        {
            delayByFrameRate_ = 5; // Keep moderate delay
        }
        else // If framerate is above 60
        {
            delayByFrameRate_ = 0; // Decrease delay to increase spawn rate
        }
    }
    public virtual IEnumerator GameObject_Config()
    {
        currMain_ = currPrefab_.GetComponent<Main>();
        if (currMain_ != null)
        {
            currMain_.Revive();
            yield return new WaitUntil(() => currPrefab_.activeInHierarchy);
            currMain_.RepeatStart();
        }
        else if (currPrefab_.tag != CONSTANTS.Wall_Tag)
            Debug.LogError("NO MAIN");
        yield return null;
    }



    public void StopSpawningRoutine()
    {
        GENERIC.StopCurrentCoroutine(this, ref spawnCoroutine_);
    }

    public int GetActiveCountLocally()
    {
        return activeEntitiesCount_;
    }

    public int GetActiveCountTotal()
    {
        return totalActiveAcrossAll_;
    }

    public int GetTotalSpawnedCountLocally()
    {
        return totalEntitiesSpawnedLocally_;
    }

    public int GetTotalSpawnedCountTotal()
    {
        return totalSpawnedAcrossAll_;
    }

    public int GetTotalDestroyedCountLocally()
    {
        return destroyedEntitiesCountLocally_;
    }



    public void StartSpawn()
    {
        if (spawnCoroutine_ != null)
            StopCoroutine(spawnCoroutine_);
        spawnCoroutine_ = StartCoroutine(SpawnEntities());
    }

    public virtual IEnumerator SpawnEntities()
    {
        while (true)
        {
            CleanUpEntities();
            if (GetActiveCountLocally() < maxEntities_)
            {
                yield return SpawnEntity();
            }
            AdjustSpawnTime();
            yield return new WaitForSeconds(spawnDelay_);
        }
    }
    public virtual bool IsInBound(Vector3 position)
    {
        Debug.Log(Border_Main.instance_.currentBorder_ == null);
        return Border_Main.instance_.currentBorder_.IsWithinBounds(position);
    }
    public override void CleanUpEntities()
    {
        // for each iteration could cause
        for (int i = entities_.Count - 1; i >= 0; i--)
        {
            var entity = entities_[i];
            if (entity == null)
            {
                entities_.RemoveAt(i);
                continue;
            }

            if (!entity.activeInHierarchy)
            {
                pool_.Enqueue(entity);
                entities_.RemoveAt(i);
                activeEntitiesCount_--;
                totalActiveAcrossAll_--;
                totalDestroyedAcrossAll_++;
            }
        }
    }


    public virtual Vector3 RandomPosition()
    {
        float randomDirection = Random.Range(0, 360);
        float randomDistance = Random.Range(minDistance_, maxDistance_);
        Vector3 direction = Quaternion.Euler(0, 0, randomDirection) * Vector3.up;
        Vector3 randomPos = target_.position + direction * randomDistance;

        if (!IsInBound(randomPos))
        {
            maxDistance_ = randomDistance; // decrease maxDistance_ to current randomDistance
        }

        return randomPos;
    }
    public virtual IEnumerator SpawnEntity()
    {
        currPrefab_ = RandomPickEntity();
        Vector3 position = Respawn();
        ResetMinMaxDistance();  // Reset distances after finding a valid position

        GameObject entity;

        if (pool_.Count > 0)
        {
            entity = pool_.Dequeue();
            entity.transform.position = position;
            entity.SetActive(true);
        }
        else
        {
            entity = Instantiate(currPrefab_, position, Quaternion.identity);
            currPrefab_ = entity;
            yield return GameObject_Config();
            entities_.Add(entity);
            totalEntitiesSpawnedLocally_++;
            totalSpawnedAcrossAll_++;
        }

        activeEntitiesCount_++;
        totalActiveAcrossAll_++;
    }

    public void ResetMinMaxDistance()
    {
        // Replace with your original min and max values
        minDistance_ = default_MinDistance_;
        maxDistance_ = default_MaxDistance_;
    }

    public virtual void AdjustSpawnTime()
    {
        AdjustDelayByTime();
        AdjustDelayByActiveLocally();
        AdjustDelayByActiveTotal();
        AdjustDelayByTotalSpawnedLocally();
        AdjustDelayByTotalSpawnedTotal();
        AdjustDelayByDestroyedLocally();
        AdjustDelayByDestroyedTotal();
        AdjustDelayByFrameRate();
        spawnDelay_ = startingTime_ + delayByTime_ + delayByActiveLocally_ + delayByActiveTotal_ + delayByTotalSpawnedLocally_ + delayByTotalSpawnedTotal_ + delayByDestroyedLocally_ + delayByDestroyedTotal_ + delayByPlayerHealth_;
    }
    public Vector3 Respawn()
    {

        Vector3 position;
        for (int i = 0; i < CONSTANTS.LOOP_LIMIT; i++)
        {
            position = RandomPosition();
            if (IsInBound(position))
            {
                return position;
            }
        }
        Debug.LogWarning("Could not find a valid position after " + CONSTANTS.LOOP_LIMIT + " attempts.");

        return Border_Main.instance_.currentBorder_.GetCenter();
    }

}
