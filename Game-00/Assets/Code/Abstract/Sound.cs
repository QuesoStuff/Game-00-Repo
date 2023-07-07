using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sound : MonoBehaviour
{
    [SerializeField] protected AudioSource audioSourcea_;
    [SerializeField] protected AudioClip[] audioClips_;
    protected int currIndex_;

    public void PlaySound(int index)
    {
        if (GENERIC.IsValidIndex(audioClips_, index))
        {
            audioSourcea_.clip = audioClips_[index];
            audioSourcea_.Play();
            currIndex_ = index;
        }
    }

    public void PauseSound()
    {
        audioSourcea_.Pause();
    }

    public void StopSound()
    {
        audioSourcea_.Stop();
    }

    public void PlayRandomSound()
    {
        int randomIndex = (int)GENERIC.GetRandomNumberInRange(0, audioClips_.Length);
        PlaySound(randomIndex);
    }
    public void PlayAllSoundsRandomlyOnce()
    {
        StartCoroutine(PlayAllSoundsRandomlyOnceCoroutine());
    }

    private IEnumerator PlayAllSoundsRandomlyOnceCoroutine()
    {
        List<int> indices = new List<int>();
        for (int i = 0; i < audioClips_.Length; i++)
        {
            indices.Add(i);
        }

        while (indices.Count > 0)
        {
            int randomIndex = Random.Range(0, indices.Count);
            PlaySound(indices[randomIndex]);
            indices.RemoveAt(randomIndex);

            while (audioSourcea_.isPlaying)
            {
                yield return null;
            }
        }
    }


}
