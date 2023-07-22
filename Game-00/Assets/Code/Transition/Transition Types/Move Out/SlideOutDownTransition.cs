using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class SlideOutDownTransition : SlideTransition
{
    new void Awake()
    {
        base.Awake();
        startPos_ = Vector2.zero;  // start from the center
        endPos_ = new Vector2(0, -Screen.height);  // end at the top
    }
}
