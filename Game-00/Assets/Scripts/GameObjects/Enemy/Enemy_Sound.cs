using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sound : Sound
{
    [SerializeField] public Enemy_Main enemy_Main_;
    public void Clash()
    {
        PlaySound(1);
    }
    public void BumpIntoWall()
    {
        PlaySound(0);
    }
}
