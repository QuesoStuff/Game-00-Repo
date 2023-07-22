using System.Collections;
using UnityEngine;

public abstract class SlideTransition : Transition
{
    [SerializeField]
    protected Vector2 startPos_;
    protected Vector2 endPos_;

    new void Awake()
    {
        base.Awake();
    }
    public void Reset(Vector2 startPos)
    {
        Visible(false);
        screenCover_.rectTransform.anchoredPosition = startPos;
    }
    public override IEnumerator TransitionCoroutine()
    {
        Visible(true);


        float t = 0;
        while (t < transitionTime_)
        {
            t += Time.deltaTime;
            screenCover_.transform.localPosition = Vector3.Lerp(startPos_, endPos_, t / transitionTime_);
            yield return null;
        }
    }
}
