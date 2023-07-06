using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning_Level_Door : Spawning_Level
{

    public override bool IsInBound(Vector3 position)
    {
        // First, check if the new position of the parent object is within bounds.
        if (!Border_Main.instance_.currentBorder_.IsWithinBounds(position))
        {
            return false;
        }

        // If the parent's new position is within bounds, check the potential positions of all the children.
        foreach (Transform child in currPrefab_.transform)
        {
            Vector3 childPotentialPosition = position + child.localPosition;

            if (!Border_Main.instance_.currentBorder_.IsWithinBounds(childPotentialPosition))
            {
                return false;  // If any child's potential new position is out of bounds, return false.
            }
        }

        // If all checks passed, return true.
        return true;
    }

    public override GameObject RandomPickEntity()
    {
        if (prefabs_ == null || prefabs_.Count == 0)
        {
            Debug.LogError("No prefabs to spawn");
            return null;
        }
        int randomIndex = UnityEngine.Random.Range(0, prefabs_.Count);

        return prefabs_[randomIndex];
    }




}
