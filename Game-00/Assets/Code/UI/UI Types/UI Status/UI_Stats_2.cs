using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Stats_2 : UI_Stats_1
{

    public void Update_UI_Pause_Resume()
    {
        CONSTANTS_ENUM.GAME_STATE currState = GameState.GetGameState();
        string mess = "";
        if (currState == CONSTANTS_ENUM.GAME_STATE.PLAY)
        {
            mess = CONSTANTS_STRING.UI_GAME_STATE_MESSAGE_PLAY;
        }
        else if (currState == CONSTANTS_ENUM.GAME_STATE.PAUSE)
        {
            mess = CONSTANTS_STRING.UI_GAME_STATE_MESSAGE_PAUSE;
        }
        Update_UI_Text(mess);
    }

}
