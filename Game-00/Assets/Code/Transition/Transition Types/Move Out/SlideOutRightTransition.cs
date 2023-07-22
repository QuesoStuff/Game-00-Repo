using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class SlideOutRightTransition : SlideTransition
{
    new void Awake()
    {
        base.Awake();
        startPos_ = Vector2.zero;  // start from the center
        endPos_ = new Vector2(Screen.width, 0);  // end at the top
    }
}
