using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Controller : Controller
{
    [SerializeField] public Door_Main door_Main_;
    [SerializeField] public Transform teleport_;

    public void EventTrigger_PauseFading(bool isPlay)
    {
        if (isPlay)
        {
            FadeInOut();
        }
        else

            StopCurrentCoroutine();
    }
}


