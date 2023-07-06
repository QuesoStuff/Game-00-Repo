using UnityEngine;

public abstract class MonoBehaviour_Plus : MonoBehaviour//, I_MonoBehaviourPlus
{
    [SerializeField] public Animator animator_;
    [SerializeField] public Rigidbody2D rb2d_;
    [SerializeField] public SpriteRenderer spriterender_;
    [SerializeField] public Sprite currSprite_;
    [SerializeField] public Sprite newSprite_;
    [SerializeField] public Collider2D collision_;
    protected Coroutine currCoroutine = null;
    protected float currRotationSpeed_;
    protected float currRotateAngle_;

    public void SetActive(bool value)
    {
        isActive_ = value;
    }
    //private Coroutine currentCoroutine_ = null;
    protected bool isActive_ = true;

    protected bool isDestroyed_ = false;

    public void FadeInOut(Color startColor)
    {
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0); // existing color with 0 alpha
        StopCurrentCoroutine();
        currCoroutine = StartCoroutine(GENERIC.FadeInOut(spriterender_, startColor, endColor, 1.5f, 0.5f));
    }
    public void FadeInOut()
    {
        FadeInOut(spriterender_.color);
    }
    public void AdjustChildDistance_All(float factor = 2)
    {
        GENERIC.AdjustChildDistance_All(transform, factor);
    }



    public void ConfigStartRotate()
    {
        System.Random random = new System.Random();
        currRotateAngle_ = random.Next(-25, 25);
    }
    public void ConfigRotateSpeed()
    {
        System.Random random = new System.Random();
        currRotationSpeed_ = random.Next(200, 400);
    }
    public void ChangeSprite()
    {
        GENERIC.ChangeSprite(spriterender_, newSprite_);
    }
    public void ToggleSprite()
    {
        if (spriterender_.sprite == currSprite_)
        {
            spriterender_.sprite = newSprite_;
        }
        else
        {
            spriterender_.sprite = currSprite_;
        }
    }
    public void ToggleStaticRigidbody2D()
    {
        if (rb2d_.bodyType == RigidbodyType2D.Dynamic)
        {
            rb2d_.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            rb2d_.bodyType = RigidbodyType2D.Dynamic;
        }
    }


    public void Kill(float delay = 0)
    {
        StopAllCoroutines();
        if (gameObject != null)
        {
            Destroy(gameObject, delay);
        }
    }
    public void FakeKill(bool state = true)
    {
        collision_.enabled = !state;
        spriterender_.enabled = !state;
    }
    public virtual Vector3 Offset(Vector2 position)
    {
        return transform.position;
    }


    public void Rotate(float rotationSpeed)
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
    public void SideRotate(float rotation)
    {
        Quaternion rotationQuaternion = Quaternion.Euler(0f, 0f, rotation);
        transform.rotation *= rotationQuaternion;
    }

    public void StopCurrentCoroutine()
    {
        GENERIC.StopCurrentCoroutine(this, ref currCoroutine);
    }

}


