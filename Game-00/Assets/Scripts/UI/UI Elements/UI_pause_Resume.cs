using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_pause_Resume : UI
{
    public override void Update_UI()
    {
        CONSTANTS.GAME_STATE currState = GameState.instance_.GetGameState();

        string mess = "";
        if (currState == CONSTANTS.GAME_STATE.PLAY)
        {
            mess = CONSTANTS_UI.GAME_STATE_MESSAGE_PLAY;
        }
        else if (currState == CONSTANTS.GAME_STATE.PAUSE)
        {
            mess = CONSTANTS_UI.GAME_STATE_MESSAGE_PAUSE;
        }
        Update_UI_Text(mess);
    }

}
