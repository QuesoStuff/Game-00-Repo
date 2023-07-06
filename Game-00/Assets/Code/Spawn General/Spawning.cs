using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawning : MonoBehaviour
{
    public void Spawn(GameObject obj, Vector2 startPosition, Color startColor, bool shouldRotate, bool constantLifetimeAndDuration)
    {
        GENERIC.ExplosionCreate(obj, startPosition, startColor, shouldRotate, constantLifetimeAndDuration);
    }
    public void Spawn(GameObject obj, Vector2 startPosition, Color? color = null)
    {
        color ??= Color.white;
        GENERIC.ExplosionCreate(obj, startPosition, color.Value);
    }
    public void Spawn(GameObject obj, Vector3 position, Quaternion rotation)
    {
        Instantiate(obj, position, rotation);
    }
}
