using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class SlideInLeftTransition : SlideTransition
{
    new void Awake()
    {
        base.Awake();
        startPos_ = new Vector2(Screen.width, 0);  // start from the right
        endPos_ = new Vector2(0, 0);  // end at the center
    }
}
