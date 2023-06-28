using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Sound : Sound
{
    [SerializeField] public Bullet_Main bullet_Main_;

    public void ShootingSound()
    {
        PlayRandomSound();
    }
    public void CollideSound()
    {
        PlaySound(0);
    }
    public void ChargedShot()
    {
        PlaySound(1);

    }
}
