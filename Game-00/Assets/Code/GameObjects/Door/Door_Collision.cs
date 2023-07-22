using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Collision : Collision
{
    [SerializeField] public Door_Main door_Main_;


    public override void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.transform.position = door_Main_.door_Controller_.teleport_.position;
    }
}
