



using System.Collections.Generic;
using UnityEngine;
using System;

public class Menu_Main_2 : MonoBehaviour
{
    public Menu_Pause menuPause_;  // Initialize these in Unity
    public Menu_Retry menuRetry_;  // Initialize these in Unity
    public static Menu_Main_2 instance_;

    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject, false);
    }
    public void RoundOver()
    {
        menuPause_.SetActive(false);
        menuRetry_.SetActive(true);
    }
}
