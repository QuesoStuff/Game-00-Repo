using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Score : UI
{

    public override void Update_UI()
    {

        string mess = PrintScore();
        if (PrevFile.CompareHighScore())
            Update_UI_Color();
        Update_UI_Text(CONSTANTS_STRING.DEFAULT_UI_SCORE + mess);
    }


    public string PrintScore()
    {
        float score = ScoreManager.GetScore();
        return score.ToString();
    }
}
