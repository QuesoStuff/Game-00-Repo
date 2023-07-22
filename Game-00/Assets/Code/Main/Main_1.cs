using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_1 : MonoBehaviour
{
    // Start is called before the first frame update
    public static Main_1 instance_;


    private void Awake()
    {
        GENERIC.MakeSingleton(ref instance_, this, this.gameObject, true);
        //SetOffAllGameObjects();

    }

    void Start()
    {
        GameState.Init_Main_1();

    }


    // Update is called once per frame

}
