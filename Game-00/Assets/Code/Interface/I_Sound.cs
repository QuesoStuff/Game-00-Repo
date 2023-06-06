using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_Sound
{
    void PlaySound(int index);
    void PauseSound();
    void StopSound();
    void PlayRandomSound();
}
