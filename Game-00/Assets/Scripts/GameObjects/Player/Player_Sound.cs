using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sound : Sound
{
    [SerializeField] public Player_Main player_Main_;


    public void FullHealth()
    {
        PlaySound(0);
    }
    public void BumpIntoWall()
    {
        PlaySound(1);
    }
    public void ChargedShooting()
    {
        PlaySound(2);
    }

}
