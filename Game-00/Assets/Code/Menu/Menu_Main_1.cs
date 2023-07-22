



using System.Collections.Generic;
using UnityEngine;
using System;

public class Menu_Main_1 : MonoBehaviour
{
    public Menu_Start startMenu_;  // Initialize these in Unity
    public Menu_Options optionsMenu_;  // Initialize these in Unity
    public Menu_Config_Duration configMenu_1_;  // Initialize these in Unity
    public Menu_Config_Shape configMenu_2_;  // Initialize these in Unity
    public Menu_Config_Size configMenu_3_;  // Initialize these in Unity

    private List<Menu> menus_;
    private int currentMenuIndex_;
    public static Menu_Main_1 instance_;


    public void Init_Method(ref Action method, Action action = null)
    {
        action ??= () => MoveToNextMenu(false);
        method = action;
    }
    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject, false);
    }
    void Start()
    {
        menus_ = new List<Menu>() { startMenu_, optionsMenu_, configMenu_1_, configMenu_2_, configMenu_3_ };
        ResetAllMenus();
        currentMenuIndex_ = 0;
        Init_Method(ref startMenu_.method_);
        Init_Method(ref optionsMenu_.method_);
        Init_Method(ref configMenu_1_.method_);
        Init_Method(ref configMenu_2_.method_);
        Init_Method(ref configMenu_3_.method_, LoadingScene.instance_.LoadNextScene);

        SetActiveMenu(currentMenuIndex_);  // Set the initial active menu to StartMenu
    }

    public void SetActiveMenusFrom(int startMenuIndex)
    {
        if (GENERIC.IsValidIndex(menus_, startMenuIndex))
        {
            for (int i = startMenuIndex; i < menus_.Count; i++)
            {
                menus_[i].SetActive(true);
            }
        }
        else
        {
            Debug.LogError("Invalid start menu index: " + startMenuIndex);
        }
    }
    void SetActiveMenu(int newMenuIndex, bool leaveOpen = false)
    {
        if (GENERIC.IsValidIndex(menus_, newMenuIndex))
        {
            if (GENERIC.IsValidIndex(menus_, currentMenuIndex_) && !leaveOpen)
            {
                menus_[currentMenuIndex_].SetActive(false);
            }
            currentMenuIndex_ = newMenuIndex;
            menus_[currentMenuIndex_].SetActive(true);
        }
    }

    public void MoveToNextMenu(bool leaveOpen = false)
    {
        //int nextMenuIndex = (currentMenuIndex_ + 1) % menus_.Count;
        int nextMenuIndex = (currentMenuIndex_ + 1);
        SetActiveMenu(nextMenuIndex, leaveOpen);
    }
    private void ResetAllMenus()
    {
        foreach (Menu menu in menus_)
        {
            menu.ResetMenu();
            menu.SetActive(false);
        }
    }
}
