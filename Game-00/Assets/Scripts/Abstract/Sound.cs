using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sound : MonoBehaviour
{
    [SerializeField] internal AudioSource audioSourcea_;
    [SerializeField] internal AudioClip[] audioClips_;
    private int currIndex_;

    // Plays a sound clip at the specified index
    public void PlaySound(int index)
    {
        if (GENERIC.IsValidIndex(audioClips_, index))
        {
            audioSourcea_.clip = audioClips_[index];
            audioSourcea_.Play();
            currIndex_ = index;
        }
    }

    // Pauses the currently playing sound
    public void PauseSound()
    {
        audioSourcea_.Pause();
    }

    // Stops the currently playing sound
    public void StopSound()
    {
        audioSourcea_.Stop();
    }

    // Plays a random sound clip from the available clips
    public void PlayRandomSound()
    {
        int randomIndex = GENERIC.GetRandomNumberInRange(0, audioClips_.Length);
        PlaySound(randomIndex);
    }
}
