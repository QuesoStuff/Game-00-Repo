using UnityEngine;

public class GameMusic_Main : MonoBehaviour
{
    [SerializeField] public GameMusic_SFX gameMusic_SFX_;
    [SerializeField] public GameMusic_OST gameMusic_OST_;
    public static GameMusic_Main instance_;

    void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject, true);
    }
    void Start()
    {
    }


    private void Update()
    {
        if (!gameMusic_OST_.GetAudioSource().isPlaying)
        {
            gameMusic_OST_.PlayNextClip();
        }
    }

}
