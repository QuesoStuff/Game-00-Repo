using UnityEngine;

public abstract class MonoBehaviour_Plus : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] public Rigidbody2D rb2d;
    [SerializeField] public SpriteRenderer spriterender;

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
