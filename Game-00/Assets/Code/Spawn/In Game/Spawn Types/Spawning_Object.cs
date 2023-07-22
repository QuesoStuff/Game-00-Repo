using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning_Object : Spawning
{
    [SerializeField] private GameObject bullet_;
    private Bullet_Config currConfig_;
    private Queue<GameObject> bullet_Pool_ = new Queue<GameObject>();

    public void Spawn_Bullet(Vector3 position, Quaternion rotation, Vector3 direction, bool IsSoloCharged = false)
    {
        if (Bullet_Config.LimitBullet(IsSoloCharged))
        {
            GameObject bullet;
            if (bullet_Pool_.Count > 0)
            {
                bullet = bullet_Pool_.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = position;
                bullet.transform.rotation = rotation;
                currConfig_ = bullet.GetComponent<Bullet_Config>();
                currConfig_.Revive();
                currConfig_.ConfigureBullet(direction, IsSoloCharged);
                Debug.Log("POOL SHOT");
            }
            else
            {
                bullet = Bullet_Main.Static_Create(position, rotation, direction, bullet_, IsSoloCharged);
                entities_.Add(bullet);
            }
        }
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
                bullet_Pool_.Enqueue(entity);
                entities_.RemoveAt(i);
            }
        }
    }
}
