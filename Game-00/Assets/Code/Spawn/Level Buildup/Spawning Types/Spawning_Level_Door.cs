using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning_Level_Door : Spawning_Level
{
    [SerializeField] public List<GameObject> currDoorPair_ = new List<GameObject>();

    public override IEnumerator SpawnEntity()
    {
        // Call base implementation to spawn an entity
        yield return base.SpawnEntity();

        // Add the spawned entity to the current pair
        currDoorPair_.Add(currPrefab_);
        // If we've spawned two entities, make a connection and clear the list
        if (currDoorPair_.Count == 2)
        {
            ConnectDoors(currDoorPair_[0], currDoorPair_[1]);
            currDoorPair_.Clear();
        }
    }
    /*
        private void ConnectDoors(GameObject door_A, GameObject door_B)
        {
            Door_Main door_Main_A = door_A.GetComponent<Door_Main>();
            Door_Main door_Main_B = door_B.GetComponent<Door_Main>();
            door_Main_A.door_Controller_.teleport_ = door_B.transform.GetChild(0);
            door_Main_B.door_Controller_.teleport_ = door_A.transform.GetChild(0);
            float distance = Vector3.Distance(door_A.transform.position, door_B.transform.position);
            door_Main_A.door_Config_.Init_Color(distance);
            door_Main_B.door_Config_.Init_Color(distance);
        }
        */
    private void ConnectDoors(GameObject door_A, GameObject door_B)
    {
        if (door_A == null || door_B == null)
        {
            //Debug.LogWarning("Door_A or Door_B is null in ConnectDoors function.");
            return;
        }

        Door_Main door_Main_A = door_A.GetComponent<Door_Main>();
        Door_Main door_Main_B = door_B.GetComponent<Door_Main>();

        if (door_Main_A == null || door_Main_B == null)
        {
            //Debug.LogWarning("Door_Main component missing on Door_A or Door_B in ConnectDoors function.");
            return;
        }

        Transform childA = door_A.transform.childCount > 0 ? door_A.transform.GetChild(0) : null;
        Transform childB = door_B.transform.childCount > 0 ? door_B.transform.GetChild(0) : null;

        if (childA == null || childB == null)
        {
            //Debug.LogWarning("Door_A or Door_B does not have a child object in ConnectDoors function.");
            return;
        }

        if (door_Main_A.door_Controller_ == null || door_Main_B.door_Controller_ == null)
        {
            //Debug.LogWarning("Door_Controller component missing on Door_Main_A or Door_Main_B in ConnectDoors function.");
            return;
        }

        door_Main_A.door_Controller_.teleport_ = childB;
        door_Main_B.door_Controller_.teleport_ = childA;
        float distance = Vector3.Distance(door_A.transform.position, door_B.transform.position);

        if (door_Main_A.door_Config_ == null || door_Main_B.door_Config_ == null)
        {
            //Debug.LogWarning("Door_Config component missing on Door_Main_A or Door_Main_B in ConnectDoors function.");
            return;
        }

        door_Main_A.door_Config_.Init_Color(distance);
        door_Main_B.door_Config_.Init_Color(distance);
    }

}