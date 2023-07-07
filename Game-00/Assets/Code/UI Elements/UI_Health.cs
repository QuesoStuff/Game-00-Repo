using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Health : UI
{
    [SerializeField] public Health target_Health_;
    private float currHP_;
    private float maxHP_;
    private string colorCode_;

    public override void Init()
    {
        List<float> thresholds = new List<float> { 0.35f, 0.70f, 0.99f };
        List<Color> colors = new List<Color> { GENERIC.HexToColor("#FF0000FF"), GENERIC.HexToColor("#FFFF00FF"), GENERIC.HexToColor("FFFFFFFF"), GENERIC.HexToColor("#00FF00FF") };
        colorRange_ = new CollectionRange<float, Color>(thresholds, colors);
    }
    public override void Update_UI()
    {
        GetHealth();
        Update_UI_Health_Text();
        GENERIC.ColorText(textBox_, "", currHP_.ToString(), "/" + maxHP_.ToString(), colorCode_);
    }
    public void GetHealth()
    {
        currHP_ = target_Health_.GetCurrHP();
        maxHP_ = target_Health_.GetMaxHP();

    }

    void Update_UI_Health_Text()
    {
        float ratio = currHP_ / maxHP_;
        colorCode_ = GENERIC.ColorToHex(colorRange_.GetResultBasedOnThreshold(ratio));
    }

}
