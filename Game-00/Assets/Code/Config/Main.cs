using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class Main : MonoBehaviour//, I_MonoBehaviourPlus
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
    protected bool isAlreadyDashing_ = false;
    protected float respawnRate_ = 0.001f;

    public void SetActiveItems(bool value)
    {
        isActiveItems_ = value;
    }
    //private Coroutine currentCoroutine_ = null;
    protected bool isActiveItems_ = true;

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


    protected IEnumerator DashAndSpawn(Action method)
    {
        yield return GENERIC.Spawn(method, () => isAlreadyDashing_, respawnRate_);
    }


    public void FakeKill()
    {
        if (collision_ != null)
        {
            collision_.enabled = false;
        }

        if (spriterender_ != null)
        {
            spriterender_.enabled = false;
        }

        StartCoroutine(DisableAfterComplete());
    }

    IEnumerator DisableAfterComplete()
    {
        yield return new WaitUntil(() => !IsInvoking() && (currCoroutine == null));
        gameObject.SetActive(false);
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

    public void Revive()
    {
        gameObject.SetActive(true);

        if (collision_ != null)
        {
            collision_.enabled = true;
        }

        if (spriterender_ != null)
        {
            spriterender_.enabled = true;
        }
    }
    public void StopMain()
    {
        enabled = false;
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

    public virtual void RepeatStart()
    {
        return;
    }



}


