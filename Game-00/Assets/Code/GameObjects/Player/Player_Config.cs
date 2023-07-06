using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Config : MonoBehaviour
{
    [SerializeField] public Player_Main player_Main_;

    // Start is called before the first frame update
    public void Config_Init()
    {
        player_Main_.player_Health_.Set_HP(15);
        UI_Main.instance_.UI_Health_.Update_UI();
        player_Main_.player_Controller_.InitDash();
    }

}
