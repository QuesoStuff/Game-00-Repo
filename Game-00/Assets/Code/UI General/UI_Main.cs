using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Main : MonoBehaviour
{
    public static UI_Main instance_;
    [SerializeField] public UI UI_Time;
    [SerializeField] public UI UI_Score_;
    [SerializeField] public UI UI_BulletCount_;
    [SerializeField] public UI UI_Health_;
    [SerializeField] public UI UI_KillCount_;
    [SerializeField] public UI UI_Pause_Resume_;
    [SerializeField] public UI_CountDownStart UI_CountDownStart_;
    [SerializeField] public UI UI_Traveled_;
    [SerializeField] public UI UI_Debug_;
    [SerializeField] public UI UI_Item_;
    [SerializeField] public UI UI_Bullet_Stat_;

    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject);
        UI_Time.Init();
        UI_Health_.Init();

    }
    void Start()
    {
        UI_Time.SetComponents();
        UI_Score_.SetComponents();
        UI_BulletCount_.SetComponents();
        UI_Health_.SetComponents();
        UI_KillCount_.SetComponents();
        UI_Pause_Resume_.SetComponents();
        UI_CountDownStart_.SetComponents();
        UI_Traveled_.SetComponents();
        UI_Debug_.SetComponents();
        UI_Item_.SetComponents();
        UI_Bullet_Stat_.SetComponents();
    }


}
