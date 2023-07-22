using UnityEngine;

public class GameMusic_SFX : Sound
{
    public void IconMove()
    {
        PlaySound(0);
    }
    public void IconSelect()
    {
        PlaySound(1);
    }
    public void DoneLoading()
    {
        PlaySound(2);
    }
}
