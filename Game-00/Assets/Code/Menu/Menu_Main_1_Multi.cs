



using System.Collections.Generic;
using UnityEngine;
using System;

public class Menu_Main_1_Multi : MonoBehaviour
{
    public Menu_Start startMenu_;  // Initialize these in Unity
    public Menu_Options optionsMenu_;  // Initialize these in Unity
    public Menu_Config configMenu_;  // Initialize these in Unity
    private List<Menu> menus_;
    private int currentMenuIndex_;
    public static Menu_Main_1_Multi instance_;


    public void Init_Method(ref Action method, Action action = null)
    {
        action ??= MoveToNextMenu;
        method = action;
    }
    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject, false);
    }
    void Start()
    {
        menus_ = new List<Menu>() { startMenu_, optionsMenu_, configMenu_ };
        ResetAllMenus();
        currentMenuIndex_ = 0;
        Init_Method(ref startMenu_.method_);
        Init_Method(ref optionsMenu_.method_);
        Init_Method(ref configMenu_.method_, LoadingScene.instance_.LoadNextScene);
        SetActiveMenu(currentMenuIndex_);  // Set the initial active menu to StartMenu
    }

    void SetActiveMenu(int newMenuIndex)
    {
        if (newMenuIndex >= 0 && newMenuIndex < menus_.Count)
        {
            if (currentMenuIndex_ >= 0 && currentMenuIndex_ < menus_.Count)
            {
                menus_[currentMenuIndex_].SetActive(false);
            }

            currentMenuIndex_ = newMenuIndex;
            menus_[currentMenuIndex_].SetActive(true);
        }
    }


    public void MoveToNextMenu()
    {
        int nextMenuIndex = (currentMenuIndex_ + 1) % menus_.Count;
        SetActiveMenu(nextMenuIndex);
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
