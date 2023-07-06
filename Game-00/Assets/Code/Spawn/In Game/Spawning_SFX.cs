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

    public void Spawn_ExplosionDeath(Vector2 startPosition, Color startColor)
    {
        bool shouldRotate = UnityEngine.Random.value > 0.5f;
        bool constantLifetimeAndDuration = UnityEngine.Random.value > 0.5f;
        Spawn(explosion_Death_, startPosition, startColor, shouldRotate, constantLifetimeAndDuration);
    }
    public void Spawn_ExplosionDash(Vector2 startPosition, Color startColor)
    {
        bool shouldRotate = UnityEngine.Random.value > 0.5f;
        bool constantLifetimeAndDuration = UnityEngine.Random.value > 0.5f;
        Spawn(explosion_Dash_, startPosition, startColor, shouldRotate, constantLifetimeAndDuration);
    }
    public void Spawn_ExplosionDeath_Item(Vector2 startPosition, Color startColor)
    {
        bool shouldRotate = UnityEngine.Random.value > 0.5f;
        bool constantLifetimeAndDuration = UnityEngine.Random.value > 0.5f;
        Spawn(explosion_Death_Item_, startPosition, startColor, shouldRotate, constantLifetimeAndDuration);
    }
    public void Spawn_ExplosionHurt(Vector2 startPosition, Color startColor)
    {
        bool shouldRotate = UnityEngine.Random.value > 0.5f;
        bool constantLifetimeAndDuration = UnityEngine.Random.value > 0.5f;
        Spawn(explosion_Hurt_, startPosition, startColor, shouldRotate, constantLifetimeAndDuration);
    }
    public void Spawn_ExplosionBullet(Vector2 startPosition, Color startColor)
    {
        bool shouldRotate = UnityEngine.Random.value > 0.5f;
        bool constantLifetimeAndDuration = UnityEngine.Random.value > 0.5f;
        Spawn(explosion_Bullet_Wall_Collision_, startPosition, startColor, shouldRotate, constantLifetimeAndDuration);
    }



    public void Spawn_ExplosionDeath(Vector2 startPosition)
    {
        Spawn(explosion_Death_, startPosition);
    }
    public void Spawn_ExplosionDash(Vector2 startPosition)
    {
        Spawn(explosion_Dash_, startPosition);
    }
    public void Spawn_ExplosionDeath_Item(Vector2 startPosition)
    {
        Spawn(explosion_Death_Item_, startPosition);
    }
    public void Spawn_ExplosionHurt(Vector2 startPosition)
    {
        Spawn(explosion_Hurt_, startPosition);
    }
    public void Spawn_ExplosionBullet(Vector2 startPosition)
    {
        Spawn(explosion_Bullet_Wall_Collision_, startPosition);
    }
}
