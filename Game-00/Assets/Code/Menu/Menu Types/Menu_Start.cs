
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Start : Menu_SingleList
{



    public override void HandleSelection()
    {
        method_?.Invoke();

    }

}

