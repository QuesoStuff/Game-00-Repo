using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Or TMPro if you're using TextMeshPro

public class UI_Health : UI
{
    [SerializeField] internal Health target_Health_;
    private float currHP_;
    private float maxHP_;
    private string colorCode_;

    public override void Update_UI()
    {
        GetHealth();
        Update_UI_Health_Text();
        GENERIC.ColorText(textBox, "", currHP_.ToString(), "/" + maxHP_.ToString(), colorCode_);
    }
    public void GetHealth()
    {
        //currHP_ = Player_Main.instance_.player_Health_.GetCurrHP();
        //maxHP_ = Player_Main.instance_.player_Health_.GetMaxHP();

        currHP_ = target_Health_.GetCurrHP();
        maxHP_ = target_Health_.GetMaxHP();
    }

    void Update_UI_Health_Text()
    {
        colorCode_ = "#FFFFFFFF"; // Default to white
        if (currHP_ == maxHP_)
            colorCode_ = "#00FF00FF"; // Green
        else if (currHP_ / maxHP_ < 0.35f) // Red 
            colorCode_ = "#FF0000FF";
        else if (currHP_ / maxHP_ < 0.70f) // Yellow
            colorCode_ = "#FFFF00FF";
    }
}
