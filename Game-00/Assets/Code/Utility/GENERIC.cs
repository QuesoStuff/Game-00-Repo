using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class GENERIC
{
    private static System.Random random = new System.Random();
    private static float previousRealTime = 0;
    public delegate float TimeGetter();



    public static bool IsButtonHeld(KeyCode keyInput, ref float holdStartTime, float duration)
    {
        if (Input.GetKeyDown(keyInput))
        {
            holdStartTime = Time.time;
        }
        if (Input.GetKey(keyInput))
        {
            float currentDuration = Time.time - holdStartTime;
            if (currentDuration >= duration)
            {
                return true;
            }
        }
        return false;
    }

    public static bool Valid_Duration(ref float timer, float duration, Func<bool> conditionStart, Func<bool> conditionEnd)
    {
        if (conditionStart != null && conditionStart.Invoke())
        {
            timer = Time.time;
        }
        if (conditionEnd != null && conditionEnd.Invoke())
        {
            float elapsed = Time.time - timer;
            if (elapsed >= duration)
            {
                return true;
            }
        }
        return false;
    }


    public static bool Valid_DoubleTap(ref float timer, float duration, Func<bool> condition)
    {
        if (condition != null && condition.Invoke())
        {
            if (UnityEngine.Time.time - timer < duration)
            {
                timer = Time.time;
                return true;
            }
            else
            {
                timer = Time.time;
            }
        }
        return false;
    }


    public static Vector2 Move_GameObject(float x, float y, Rigidbody2D rb2d)
    {
        Vector2 direction = new Vector2(x, y);
        rb2d.velocity = direction;
        return direction;
    }
    public static Vector2 Accelerate_GameObject(float x, float y, Rigidbody2D rb2d, float acceleration)
    {
        Vector2 direction = new Vector2(x, y) * acceleration;
        rb2d.velocity += direction;
        return direction;
    }



    public static bool IsValidIndex<T>(ICollection<T> collection, uint index)
    {
        return index >= 0 && index < collection.Count;
    }


    public static int GetRandomNumberInRange(int min, int max)
    {
        return random.Next(min, max + 1);
    }


    public static void TableLookUp<TKey>(Dictionary<TKey, Action> actionTable, TKey key)
    {
        if (actionTable != null && actionTable.TryGetValue(key, out Action action))
        {
            action?.Invoke();
        }
    }



    public static void FollowTarget(Transform me, Transform target, float trackingSpeed, float xOffset = 0, float yOffset = 0, float zOffset = 0)
    {
        Vector3 playerPosition = new Vector3(target.position.x + xOffset, target.position.y + yOffset, zOffset);
        me.position = Vector3.Slerp(me.position, playerPosition, trackingSpeed * Time.deltaTime);
    }


    public static void FollowTarget(Rigidbody2D me, Transform target, float trackingSpeed, float xOffset = 0, float yOffset = 0, float zOffset = 0)
    {
        Vector3 targetPosition = new Vector3(target.position.x + xOffset, target.position.y + yOffset, zOffset);
        Vector3 smoothedPosition = Vector3.Slerp(me.position, targetPosition, trackingSpeed * Time.deltaTime);
        me.MovePosition(smoothedPosition);
    }

    public static string FormatSingleDigit(uint digit)
    {
        string formattedString = digit.ToString();
        if (digit < 10)
            formattedString = "0" + formattedString;
        return formattedString;
    }
    public static string FormatSingleDigit(int digit)
    {
        string formattedString = digit.ToString();
        if (digit < 10)
            formattedString = "0" + formattedString;
        return formattedString;
    }
    public static void MakeSingleton<T>(ref T instance, T thisInstance, GameObject thisGameObject) where T : class
    {
        if (instance == null)
        {
            instance = thisInstance;
            if (thisGameObject.transform.parent != null)
            {
                thisGameObject.transform.SetParent(null, false);
            }
            UnityEngine.Object.DontDestroyOnLoad(thisGameObject);
        }
        else
        {
            UnityEngine.Object.Destroy(thisGameObject);
        }
    }


    public static float Distance(Vector2 currPosition, Vector2 prevPosition, float distanceTraveled = 0)
    {
        distanceTraveled += Vector2.Distance(currPosition, prevPosition);
        return distanceTraveled;
    }


    public static T ToggleEnum<T>(T input) where T : Enum
    {
        var values = (T[])Enum.GetValues(input.GetType());
        uint currentIndex = (uint)Array.IndexOf(values, input);
        return values[(currentIndex + 1) % values.Length];
    }

    public static void ColorText(Text textComponent, string before, string colored, string after, string colorCode)
    {
        textComponent.text = $"{before}<color={colorCode}>{colored}</color>{after}";
    }

    private static IEnumerator FlashColorCoroutine(Color flashColor, float speed, Func<bool> condition, Action<Color> setColor, Func<Color> getColor, Action onComplete, TimeGetter getTime)
    {
        Color originalColor = getColor();
        float startTime = getTime();
        while (condition())
        {
            Color newColor;
            if (Mathf.Sin((getTime() - startTime) * speed) > 0)
                newColor = flashColor;
            else
                newColor = originalColor;
            setColor(newColor);
            yield return null;
        }
        setColor(originalColor);
        onComplete?.Invoke();
    }

    public static Coroutine FlashColorIndefinitely(this MonoBehaviour monoBehaviour, Color flashColor, float speed, Func<bool> shouldContinueFlashing, Action<Color> setColor, Func<Color> getColor, Action onComplete = null, TimeGetter getTime = null)
    {
        getTime ??= () => Time.time;
        return monoBehaviour.StartCoroutine(FlashColorCoroutine(flashColor, speed, shouldContinueFlashing, setColor, getColor, onComplete, getTime));
    }

    public static Coroutine FlashColorWithDuration(this MonoBehaviour monoBehaviour, Color flashColor, float duration, float speed, Action<Color> setColor, Func<Color> getColor, Action onComplete = null, TimeGetter getTime = null)
    {
        getTime ??= () => Time.time;
        var startTime = getTime();
        Func<bool> condition = () => getTime() < startTime + duration;
        return monoBehaviour.StartCoroutine(FlashColorCoroutine(flashColor, speed, condition, setColor, getColor, onComplete, getTime));
    }





    public static void Toggle(ref bool flip)
    {
        flip = !flip;
    }

    public static Coroutine SetWithDelay<T>(this MonoBehaviour monoBehaviour, T value, System.Action<T> setter, float delay)
    {
        return monoBehaviour.StartCoroutine(DelayedSetRoutine(value, setter, delay));
    }

    private static IEnumerator DelayedSetRoutine<T>(T value, System.Action<T> setter, float delay)
    {
        yield return new WaitForSeconds(delay);
        setter(value);
    }

    public static Coroutine ScaleOverTime(this MonoBehaviour monoBehaviour, GameObject obj, Vector3 initialScale, float targetScale, float duration)
    {
        Vector3 targetVectorScale = initialScale + new Vector3(targetScale, targetScale, targetScale);
        return monoBehaviour.StartCoroutine(ScaleRoutine(obj, initialScale, targetVectorScale, duration));
    }

    public static Coroutine ScaleOverTime(this MonoBehaviour monoBehaviour, GameObject obj, Vector3 initialScale, Vector3 targetScale, float duration)
    {
        return monoBehaviour.StartCoroutine(ScaleRoutine(obj, initialScale, targetScale, duration));
    }

    public static Coroutine ScaleOverTime(this MonoBehaviour monoBehaviour, GameObject obj, float targetScale, float duration)
    {
        Vector3 initialScale = obj.transform.localScale;
        Vector3 targetVectorScale = initialScale + new Vector3(targetScale, targetScale, targetScale);
        return monoBehaviour.StartCoroutine(ScaleRoutine(obj, initialScale, targetVectorScale, duration));
    }

    public static Coroutine ScaleOverTime(this MonoBehaviour monoBehaviour, GameObject obj, Vector3 targetScale, float duration)
    {
        Vector3 initialScale = obj.transform.localScale;
        return monoBehaviour.StartCoroutine(ScaleRoutine(obj, initialScale, targetScale, duration));
    }

    private static IEnumerator ScaleRoutine(GameObject obj, Vector3 initialScale, Vector3 targetScale, float duration)
    {
        obj.transform.localScale = initialScale;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            obj.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        obj.transform.localScale = targetScale;
    }



    public static void RestartScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public static GameObject SpawnGameObject(UnityEngine.Object newObject, Transform spawnPosition)
    {
        GameObject newGameObject = UnityEngine.Object.Instantiate(newObject as GameObject, spawnPosition.position, spawnPosition.rotation);
        return newGameObject;
    }
    public static GameObject SpawnGameObject(GameObject newObject, Transform spawnPosition, float lifeTime)
    {
        GameObject newGameObject = UnityEngine.Object.Instantiate(newObject as GameObject, spawnPosition.position, spawnPosition.rotation);
        UnityEngine.Object.Destroy(newGameObject, lifeTime);
        return newGameObject;
    }




    public static IEnumerator HoldColorCoroutine(this MonoBehaviour monoBehaviour, Color holdColor, float holdDuration, Action<Color> setColor, Func<Color> getOriginalColor, Action onComplete = null)
    {
        Color originalColor = getOriginalColor();
        setColor(holdColor);
        yield return new WaitForSeconds(holdDuration);
        setColor(originalColor);
        onComplete?.Invoke();
    }


    public static Vector3 ChangeScale(Transform transform, Vector2 direction, Vector2 scale)
    {
        Vector3 currentScale = transform.localScale;
        Vector3 newScale = currentScale;
        if (direction.x != 0 && direction.y == 0)
        {
            newScale.x = scale.x * currentScale.x;
        }
        else if (direction.x == 0 && direction.y != 0)
        {
            newScale.y = scale.y * currentScale.y;
        }
        else
        {
        }
        transform.localScale = newScale;
        return newScale;
    }

    public static Vector3 ChangeScale(Transform transform, Vector2 direction, float scale)
    {
        return ChangeScale(transform, direction, new Vector2(scale, scale));
    }


    public static void ChangeScale(Transform transform, float x, float y)
    {
        Vector2 newScale = new Vector2(x, y);
        transform.localScale = newScale;
    }
    public static void ChangeScale(Transform transform, Vector2 newScale)
    {
        transform.localScale = newScale;
    }


    public static void UpdateRotation_Left_Right(Transform transform, Vector2 direction)
    {
        if (direction.y > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90);
        }
        else if (direction.y < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90);
        }
        else if (direction.x > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0);
        }
        else if (direction.x < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180);
        }
    }


    public static void UpdateRotation_Up_Down(Transform transform, Vector2 direction)
    {
        if (direction.y > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0);
        }
        else if (direction.y < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180);
        }
        else if (direction.x > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90);
        }
        else if (direction.x < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90);
        }
    }


    public static void UpdateRotation(Transform transform, Vector2 initDirection, Vector2 currDirection)
    {
        Vector2 absInitDirection = new Vector2(Mathf.Abs(initDirection.x), Mathf.Abs(initDirection.y));

        if (absInitDirection == Vector2.up || absInitDirection == Vector2.down)
        {
            UpdateRotation_Up_Down(transform, currDirection);
        }
        else if (absInitDirection == Vector2.left || absInitDirection == Vector2.right)
        {
            UpdateRotation_Left_Right(transform, currDirection);
        }
        else
        {
            float angle = Mathf.Atan2(currDirection.y, currDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);
        }
    }

    public static IEnumerator Knockback(Rigidbody2D rb, float knockbackPower, float knockbackDuration)
    {
        Vector2 direction = Vector2.zero;

        if (Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y))
        {
            direction = rb.velocity.x > 0 ? Vector2.right : Vector2.left;
        }
        else
        {
            direction = rb.velocity.y > 0 ? Vector2.up : Vector2.down;
        }

        // Reset the object's velocity
        rb.velocity = Vector2.zero;

        float startTime = Time.time;

        while (Time.time < startTime + knockbackDuration)
        {
            rb.AddForce(-direction * knockbackPower);
            yield return null;
        }

        rb.velocity = Vector2.zero;
    }




    public static void ExplosionCreate(UnityEngine.Object ObjRef, Vector3 position, Color startColor, bool shouldRotate = false, bool constantLifetimeAndDuration = false)
    {
        GameObject explosionObject = (GameObject)UnityEngine.Object.Instantiate(ObjRef);
        explosionObject.transform.position = position;

        if (shouldRotate)
        {
            explosionObject.transform.rotation = UnityEngine.Random.rotation;
        }

        ParticleSystem explosion = explosionObject.GetComponent<ParticleSystem>();
        explosion.Stop();
        ParticleSystem.MainModule main = explosion.main;

        main.simulationSpeed = UnityEngine.Random.Range(CONSTANTS.BULLET_SIM_SPEED_MIN, CONSTANTS.BULLET_SIM_SPEED_MAX);
        main.startSize = UnityEngine.Random.Range(CONSTANTS.BULLET_SIM_START_SIZE_MIN, CONSTANTS.BULLET_SIM_START_SIZE_MAX);

        if (!constantLifetimeAndDuration)
        {
            main.startLifetime = UnityEngine.Random.Range(CONSTANTS.BULLET_END_LIFE_MIN, CONSTANTS.BULLET_END_LIFE_MAX);
            main.duration = UnityEngine.Random.Range(CONSTANTS.BULLET_DURATION_MIN, CONSTANTS.BULLET_DURATION_MAX);
        }

        main.startColor = startColor;
        explosion.Play();
    }



}







