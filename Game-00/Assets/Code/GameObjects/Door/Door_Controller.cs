using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Controller : MonoBehaviour
{
    [SerializeField] public Door_Main door_Main_;

    public void EventTrigger_PauseFading(bool isPlay)
    {
        if (isPlay)
        {
            door_Main_.FadeInOut();
        }
        else
        {
            door_Main_.StopCurrentCoroutine();
        }
    }
    public void Collision_With_Player()
    {
        Player_Main.instance_.transform.position = door_Main_.teleport_.position;
    }
}
