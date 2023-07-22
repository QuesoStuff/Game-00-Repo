

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class FadeTransition : Transition
{
    protected Color startColor;
    protected Color endColor;

    new void Awake()
    {
        base.Awake();
    }
    public override IEnumerator TransitionCoroutine()
    {

        Visible(true);

        float t = 0;
        while (t < transitionTime_)
        {
            t += Time.deltaTime;
            screenCover_.color = Color.Lerp(startColor, endColor, t / transitionTime_);
            yield return null;
        }

    }

}
