using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Sound : Sound
{
    // Start is called before the first frame update
    [SerializeField] internal Bullet_Main bullet_Main_;

    public void ShootingSound()
    {
        PlayRandomSound();
    }
    public void CollideSound()
    {
        PlaySound(0);
    }
}
