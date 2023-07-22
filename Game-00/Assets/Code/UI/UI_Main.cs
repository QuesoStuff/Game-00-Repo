using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Main : MonoBehaviour, I_SetComponents, I_Init_Values
{
    public static UI_Main instance_;
    [SerializeField] public UI UI_Time_;
    [SerializeField] public UI UI_Score_;
    [SerializeField] public UI UI_BulletCount_;
    [SerializeField] public UI UI_Health_;
    [SerializeField] public UI UI_KillCount_;
    [SerializeField] public UI UI_Stats_All_;
    [SerializeField] public UI UI_Traveled_;
    [SerializeField] public UI UI_Debug_;
    [SerializeField] public UI UI_Item_;
    [SerializeField] public UI UI_Bullet_Mod_;


    public void SetComponents()
    {
        UI_Time_ = GetComponent<UI_Time>();
        UI_Score_ = GetComponent<UI_Score>();
        UI_BulletCount_ = GetComponent<UI_BulletCount>();
        UI_Health_ = GetComponent<UI_Health>();
        UI_KillCount_ = GetComponent<UI_KillCount>();
        UI_Stats_All_ = GetComponent<UI_Stats_All>();
        UI_Traveled_ = GetComponent<UI_Traveled>();
        UI_Debug_ = GetComponent<UI_Debug>();
        UI_Item_ = GetComponent<UI_Item>();
        UI_Bullet_Mod_ = GetComponent<UI_Bullet_Mod>();

    }
    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject, false);
        Init_Config();



    }
    public void Init_Config()
    {
        /*
        SetComponents();
        UI_Time_.SetComponents();
        UI_Score_.SetComponents();
        UI_BulletCount_.SetComponents();
        UI_Health_.SetComponents();
        UI_KillCount_.SetComponents();
        UI_Stats_All_.SetComponents();
        UI_Traveled_.SetComponents();
        UI_Debug_.SetComponents();
        UI_Item_.SetComponents();
        UI_Bullet_Mod_.SetComponents();
        // to be deleted
        */
        UI_Time_.Init();
        UI_Health_.Init();
    }
    void Start()
    {
    }
    public void Init_Values()
    {
        UI_Time_.Update_UI_Text(CONSTANTS_STRING.DEFAULT_UI_TIME_INIT);
        UI_Score_.Update_UI_Text(CONSTANTS_STRING.DEFAULT_UI_SCORE_INIT + "0");
        UI_BulletCount_.Update_UI_Text(CONSTANTS_STRING.DEFAULT_UI_BULLET_INIT + "0");
        UI_Health_.Update_UI_Text(CONSTANTS_STRING.DEFAULT_UI_HEALTH_INIT + "100");
        UI_KillCount_.Update_UI_Text(CONSTANTS_STRING.DEFAULT_UI_KILL_INIT + "0");
        UI_Stats_All_.Update_UI_Text(CONSTANTS_STRING.DEFAULT_UI_Stats_All_INIT);
        UI_Traveled_.Update_UI_Text(CONSTANTS_STRING.DEFAULT_UI_DISTANCE_INIT + "0m");
        UI_Debug_.Update_UI_Text(CONSTANTS_STRING.DEFAULT_UI_DEBUG_INIT);
        UI_Item_.Update_UI_Text(CONSTANTS_STRING.DEFAULT_UI_ITEM_INIT);
        UI_Bullet_Mod_.Update_UI_Text(CONSTANTS_STRING.DEFAULT_UI_BULLET_MOD_INIT);
        UI_Time_.Init();
        UI_Health_.Init();
        this.gameObject.SetActive(true);
    }

}
