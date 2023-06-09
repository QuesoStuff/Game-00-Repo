using UnityEngine;

public abstract class MonoBehaviour_Plus : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] public Rigidbody2D rb2d;
    [SerializeField] public SpriteRenderer spriterender;

    public void Kill(float delay)
    {
        StopAllCoroutines();
        if (gameObject != null)
        {
            Destroy(gameObject, delay);
        }
    }

    public void Kill()
    {
        StopAllCoroutines();
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
