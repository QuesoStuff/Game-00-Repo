using UnityEngine;

public abstract class MonoBehaviour_Plus : MonoBehaviour, I_MonoBehaviourPlus
{
    [SerializeField] public Animator animator_;
    [SerializeField] public Rigidbody2D rb2d_;
    [SerializeField] public SpriteRenderer spriterender_;
    //private Coroutine currentCoroutine_ = null;

    protected bool isDestroyed = false;

    public void Kill(float delay)
    {
        StopAllCoroutines();
        if (gameObject != null)
        {
            Destroy(gameObject, delay);
        }
    }


    public void Rotate(float rotationSpeed)
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
    public void Kill()
    {
        Kill(0);
    }
}


