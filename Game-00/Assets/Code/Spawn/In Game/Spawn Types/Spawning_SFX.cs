using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning_SFX : Spawning
{


    [SerializeField] public GameObject explosion_Death_;
    [SerializeField] public GameObject explosion_Death_Item_;
    [SerializeField] public GameObject explosion_Hurt_;
    [SerializeField] public GameObject explosion_Dash_;
    [SerializeField] public GameObject explosion_Bullet_Wall_Collision_;

    private Queue<GameObject> explosion_Death_Pool_ = new Queue<GameObject>();
    private Queue<GameObject> explosion_Death_Item_Pool_ = new Queue<GameObject>();
    private Queue<GameObject> explosion_Hurt_Pool_ = new Queue<GameObject>();
    private Queue<GameObject> explosion_Dash_Pool_ = new Queue<GameObject>();
    private Queue<GameObject> explosion_Bullet_Wall_Collision_Pool_ = new Queue<GameObject>();

    public void Spawn_Explosion(Vector3 position, Quaternion rotation, CONSTANTS_ENUM.EXPLOSION_TYPES explosionType, Color? color = null)
    {
        color ??= Color.white;
        Queue<GameObject> currentPool = null;
        GameObject explosionPrefab = null;

        switch (explosionType)
        {
            case CONSTANTS_ENUM.EXPLOSION_TYPES.DEATH:
                currentPool = explosion_Death_Pool_;
                explosionPrefab = explosion_Death_;
                break;
            case CONSTANTS_ENUM.EXPLOSION_TYPES.DEATH_ITEM:
                currentPool = explosion_Death_Item_Pool_;
                explosionPrefab = explosion_Death_Item_;
                break;
            case CONSTANTS_ENUM.EXPLOSION_TYPES.HURT:
                currentPool = explosion_Hurt_Pool_;
                explosionPrefab = explosion_Hurt_;
                break;
            case CONSTANTS_ENUM.EXPLOSION_TYPES.DASH:
                currentPool = explosion_Dash_Pool_;
                explosionPrefab = explosion_Dash_;
                break;
            case CONSTANTS_ENUM.EXPLOSION_TYPES.BULLET_WALL_COLLISION:
                currentPool = explosion_Bullet_Wall_Collision_Pool_;
                explosionPrefab = explosion_Bullet_Wall_Collision_;
                break;
            default:
                Debug.Log("Invalid explosion type");
                return;
        }

        GameObject explosion;
        if (currentPool != null && currentPool.Count > 0)
        {
            explosion = currentPool.Dequeue();
            explosion.SetActive(true);
            explosion.transform.position = position;
            explosion.transform.rotation = rotation;

            // set color of explosion - you might need to change this to suit your specific requirements...
            var spriteRenderer = explosion.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = color.Value;
            }
        }
        else
        {
            explosion = Instantiate(explosionPrefab, position, rotation);
            // apply color to the new explosion
            var spriteRenderer = explosion.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = color.Value;
            }

            entities_.Add(explosion);
        }
    }

    public void Spawn_ExplosionDeath(Vector2 startPosition, Color? color = null)
    {
        color ??= Color.white;
        Spawn_Explosion(startPosition, Quaternion.identity, CONSTANTS_ENUM.EXPLOSION_TYPES.DEATH, color.Value);
    }

    public void Spawn_ExplosionDash(Vector2 startPosition, Color? color = null)
    {
        color ??= Color.white;
        Spawn_Explosion(startPosition, Quaternion.identity, CONSTANTS_ENUM.EXPLOSION_TYPES.DASH, color.Value);
    }

    public void Spawn_ExplosionDeath_Item(Vector2 startPosition, Color? color = null)
    {
        color ??= Color.white;
        Spawn_Explosion(startPosition, Quaternion.identity, CONSTANTS_ENUM.EXPLOSION_TYPES.DEATH_ITEM, color.Value);
    }

    public void Spawn_ExplosionHurt(Vector2 startPosition, Color? color = null)
    {
        color ??= Color.white;
        Spawn_Explosion(startPosition, Quaternion.identity, CONSTANTS_ENUM.EXPLOSION_TYPES.HURT, color.Value);
    }

    public void Spawn_ExplosionBullet(Vector2 startPosition, Color? color = null)
    {
        color ??= Color.white;
        Spawn_Explosion(startPosition, Quaternion.identity, CONSTANTS_ENUM.EXPLOSION_TYPES.BULLET_WALL_COLLISION, color.Value);
    }

    public override void CleanUpEntities()
    {
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
                switch (entity.name)
                {
                    case "explosion_Death_":
                        explosion_Death_Pool_.Enqueue(entity);
                        break;
                    case "explosion_Death_Item_":
                        explosion_Death_Item_Pool_.Enqueue(entity);
                        break;
                    case "explosion_Hurt_":
                        explosion_Hurt_Pool_.Enqueue(entity);
                        break;
                    case "explosion_Dash_":
                        explosion_Dash_Pool_.Enqueue(entity);
                        break;
                    case "explosion_Bullet_Wall_Collision_":
                        explosion_Bullet_Wall_Collision_Pool_.Enqueue(entity);
                        break;
                }
                entities_.RemoveAt(i);
            }
        }
    }
}
