using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawning_Level : MonoBehaviour
{
    [SerializeField] protected List<GameObject> prefabs_;
    [SerializeField] protected GameObject currPrefab_;

    [SerializeField] protected int maxEntities_ = 100;
    protected static int totalSpawnedAcrossAll_ = 0;
    protected static int totalActiveAcrossAll_ = 0;
    protected static int totalDestroyedAcrossAll_ = 0;

    protected List<GameObject> entities_ = new List<GameObject>();
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
    //public abstract void GameObject_Config(GameObject newGameObject);



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

    public int GetTotalDestroyedCountTotal()
    {
        return totalDestroyedAcrossAll_;
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
                SpawnEntity();
            }
            AdjustSpawnTime();
            yield return new WaitForSeconds(spawnDelay_);
        }
    }
    public virtual bool IsInBound(Vector3 position)
    {
        return Border_Main.instance_.currentBorder_.IsWithinBounds(position);
    }
    public virtual void CleanUpEntities()
    {
        int beforeClean = activeEntitiesCount_;
        entities_.RemoveAll(item => item == null);
        int afterClean = entities_.Count;
        activeEntitiesCount_ = afterClean;
        totalActiveAcrossAll_ -= beforeClean - afterClean;
        int destroyedInThisCleanUp = beforeClean - afterClean;
        destroyedEntitiesCountLocally_ += destroyedInThisCleanUp;
        totalDestroyedAcrossAll_ += destroyedInThisCleanUp;
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
    public virtual void SpawnEntity()
    {
        currPrefab_ = RandomPickEntity();
        Vector3 position = Respawn();
        ResetMinMaxDistance();  // Reset distances after finding a valid position
        GameObject entity = Instantiate(currPrefab_, position, Quaternion.identity);
        //GameObject_Config(entity);
        entities_.Add(entity);
        activeEntitiesCount_++;
        totalEntitiesSpawnedLocally_++;
        totalSpawnedAcrossAll_++;
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
        spawnDelay_ = startingTime_ + delayByTime_ + delayByActiveLocally_ + delayByActiveTotal_ + delayByTotalSpawnedLocally_ + delayByTotalSpawnedTotal_ + delayByDestroyedLocally_ + delayByDestroyedTotal_ + delayByPlayerHealth_;
    }
    public Vector3 Respawn()
    {
        /*
        Vector3 position;
        int maxAttempts = 1000;
        for (int i = 0; i < maxAttempts; i++)
        {
            position = RandomPosition();
            if (IsInBound(position))
            {
                return position;
            }
        }
        Debug.LogWarning("Could not find a valid position after " + maxAttempts + " attempts.");
       */
        return Vector3.zero;  // Or return another default position
    }

}
