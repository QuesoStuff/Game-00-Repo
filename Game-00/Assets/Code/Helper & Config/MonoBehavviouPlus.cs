using UnityEngine;

public abstract class MonoBehaviour_Plus : MonoBehaviour
{
    [SerializeField] internal Animator animator;
    [SerializeField] internal Rigidbody2D rb2d;
    [SerializeField] internal SpriteRenderer spriterender;

    public Animator GetAnimator()
    {
        return animator;
    }

    public Rigidbody2D GetRigidbody2D()
    {
        return rb2d;
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return spriterender;
    }
}
