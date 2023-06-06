using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Main : MonoBehaviour
{
    public static UI_Main instance_;
    [SerializeField] internal UI UI_Time;
    [SerializeField] internal UI UI_Score_;
    [SerializeField] internal UI UI_BulletCount_;
    [SerializeField] internal UI UI_Health_;
    [SerializeField] internal UI UI_KillCount_;
    [SerializeField] internal UI UI_Pause_Resume_;
    [SerializeField] internal UI UI_Traveled_;
    [SerializeField] internal UI UI_Debug_;


    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject);
    }


}
