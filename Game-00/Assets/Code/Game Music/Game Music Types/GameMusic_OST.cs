using UnityEngine;

public class GameMusic_OST : Sound
{
    [SerializeField] private AudioClip[] SoundtrackClips_;
    [SerializeField] private AudioClip[] pauseClips_;
    [SerializeField] private AudioClip[] menuClips_;
    [SerializeField] private int currOST_;
    [SerializeField] private float currOST_timeStamp_;

    private CONSTANTS_ENUM.MUISC_MODE musicMode_ = CONSTANTS_ENUM.MUISC_MODE.QUEUE;
    private CONSTANTS_ENUM.MUISC_TYPE musicType_;




    public void PlayNextClip()
    {
        switch (musicMode_)
        {
            case CONSTANTS_ENUM.MUISC_MODE.QUEUE:
                currIndex_ = (currIndex_ + 1) % audioClips_.Length; // Prevents going out of index by wrapping around
                break;
            case CONSTANTS_ENUM.MUISC_MODE.RANDOM:
                currIndex_ = Random.Range(0, audioClips_.Length);
                break;
                //case CONSTANTS_ENUM.MUISC_MODE.REPEAT:
                // Just play the current song again
                //break;
        }

        PlaySound(currIndex_);
    }

    public void SetModeQueue()
    {
        musicMode_ = CONSTANTS_ENUM.MUISC_MODE.QUEUE;
    }

    public void SetModeRandom()
    {
        musicMode_ = CONSTANTS_ENUM.MUISC_MODE.RANDOM;
    }

    public void SetModeRepeat()
    {
        musicMode_ = CONSTANTS_ENUM.MUISC_MODE.REPEAT;
    }

    public void ChangeMusic()
    {
        if (musicType_ == CONSTANTS_ENUM.MUISC_TYPE.OST)
        {
            Record_OST();
            ChangeToPauseMusic();
        }
        else if (musicType_ == CONSTANTS_ENUM.MUISC_TYPE.PAUSE)
        {
            ChangeBackTo_OST();
        }
    }
    public void Record_OST()
    {
        currOST_ = currIndex_;
        currOST_timeStamp_ = GetTime();
    }
    public void PlayPauseMusic()
    {
        audioClips_ = pauseClips_;
        PlayNextClip();
        musicType_ = CONSTANTS_ENUM.MUISC_TYPE.PAUSE;
    }
    public void ChangeToPauseMusic()
    {
        audioClips_ = pauseClips_;
        musicType_ = CONSTANTS_ENUM.MUISC_TYPE.PAUSE;
        PlaySound_Start(0);
    }

    public void PlayMenuMusic()
    {
        audioClips_ = menuClips_;
        PlayNextClip();
        musicType_ = CONSTANTS_ENUM.MUISC_TYPE.MENU;
    }

    public void PlayOSTMusic()
    {
        audioClips_ = SoundtrackClips_;
        PlayNextClip();
        musicType_ = CONSTANTS_ENUM.MUISC_TYPE.OST;
    }

    public void ChangeBackTo_OST()
    {
        audioClips_ = SoundtrackClips_;
        currIndex_ = currOST_;
        musicType_ = CONSTANTS_ENUM.MUISC_TYPE.OST;
        SetTime(currOST_timeStamp_);
        PlayNextClip();
    }
}
