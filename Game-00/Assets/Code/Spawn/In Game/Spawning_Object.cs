using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning_Object : Spawning
{
    [SerializeField] private GameObject bullet_;
    private Bullet_Main currMain_;
    private Queue<GameObject> bullet_Pool_ = new Queue<GameObject>();

    public void Spawn_Bullet(Vector3 position, Quaternion rotation, Vector3 direction, bool IsSoloCharged = false)
    {
        GameObject bullet;
        if (bullet_Pool_.Count > 0)
        {
            bullet = bullet_Pool_.Dequeue();
            bullet.SetActive(true);
            bullet.transform.position = position;
            bullet.transform.rotation = rotation;
            // configure other properties of the bullet based on direction and other parameters...
            currMain_ = bullet.GetComponent<Bullet_Main>();
            currMain_.Revive();
            currMain_.Init(direction, IsSoloCharged);
        }
        else
        {
            bullet = Bullet_Main.Static_Create(position, rotation, direction, bullet_, IsSoloCharged);
            entities_.Add(bullet);
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
