using UnityEngine;

public class FadeOutTransition : FadeTransition
{
    new void Awake()
    {
        base.Awake();
        startColor = new Color(screenCover_.color.r, screenCover_.color.g, screenCover_.color.b, 1);
        endColor = new Color(screenCover_.color.r, screenCover_.color.g, screenCover_.color.b, 0);
    }
}
