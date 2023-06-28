using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Score : UI
{

    public override void Update_UI()
    {

        string mess = PrintScore();
        if (PrevFile.instance_.CompareHighScore())
            Update_UI_Color();
        Update_UI_Text(mess);
    }


    public string PrintScore()
    {
        float score = ScoreManager.instance_.GetScore();
        return score.ToString();
    }
}
