using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawning : MonoBehaviour, I_Spawning
{
    public void Spawn(GameObject obj, Vector2 startPosition, Color startColor, bool shouldRotate, bool constantLifetimeAndDuration)
    {
        GENERIC.ExplosionCreate(obj, startPosition, startColor, shouldRotate, constantLifetimeAndDuration);
    }
}
