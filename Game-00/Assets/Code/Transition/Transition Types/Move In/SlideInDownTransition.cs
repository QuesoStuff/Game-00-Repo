using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class SlideInDownTransition : SlideTransition
{
    new void Awake()
    {
        base.Awake();
        startPos_ = new Vector2(0, -Screen.height);  // start from the bottom
        endPos_ = new Vector2(0, 0);  // end at the center
    }
}
