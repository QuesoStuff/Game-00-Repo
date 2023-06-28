using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning_Object : Spawning
{
    [SerializeField] public GameObject bullet_;

    public void Spawn_Bullet(Vector3 position, Quaternion rotation, Vector3 velocity, bool Spawn_Bullet = false)
    {
        Bullet_Main.Static_Create(position, rotation, velocity, bullet_, Spawn_Bullet);
    }

}