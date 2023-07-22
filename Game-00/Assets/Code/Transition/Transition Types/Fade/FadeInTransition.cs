using UnityEngine;

public class FadeInTransition : FadeTransition
{
    new void Awake()
    {
        base.Awake();
        startColor = new Color(screenCover_.color.r, screenCover_.color.g, screenCover_.color.b, 0);
        endColor = new Color(screenCover_.color.r, screenCover_.color.g, screenCover_.color.b, 1);
    }
}
