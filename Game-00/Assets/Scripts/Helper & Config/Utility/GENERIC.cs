using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Or TMPro if you're using TextMeshPro
using UnityEngine.SceneManagement;

public static class GENERIC
{
    private static System.Random random = new System.Random();
    private static float previousRealTime = 0;

    // Duration-related functions

    public static void Initialize()
    {
        previousRealTime = Time.realtimeSinceStartup;
    }
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

    // Comparison functions

    public static bool Is_X_Below_or_Equal_Y(float x, float y)
    {
        return x <= y;
    }

    public static bool Is_X_Below_Y(float x, float y)
    {
        return x < y;
    }

    // Movement functions

    public static Vector2 Move_GameObject(float x, float y, Rigidbody2D rb2d)
    {
        Vector2 direction = new Vector2(x, y);
        rb2d.velocity = direction;
        return direction;
    }
    public static Vector2 Move_GameObject(float x, float y, Rigidbody2D rb2d, float maxSpeed, float acceleration)
    {
        Vector2 direction = new Vector2(x, y).normalized;

        // Calculate the target velocity based on the input direction and max speed
        Vector2 targetVelocity = direction * maxSpeed;

        // Apply acceleration
        Vector2 currentVelocity = rb2d.velocity;
        Vector2 velocityChange = (targetVelocity - currentVelocity) * acceleration * Time.fixedDeltaTime;
        rb2d.velocity = currentVelocity + velocityChange;

        return direction;
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

    // Collection functions

    public static bool IsValidIndex<T>(ICollection<T> collection, int index)
    {
        return index >= 0 && index < collection.Count;
    }

    // Random functions

    public static int GetRandomNumberInRange(int min, int max)
    {
        return random.Next(min, max + 1); // System.Random.Next's upper bound is exclusive, so add 1 to include max
    }

    // Action table functions

    public static void TableLookUp<TKey>(Dictionary<TKey, Action> actionTable, TKey key)
    {
        if (actionTable != null)
        {
            if (actionTable.TryGetValue(key, out Action action))
            {
                action?.Invoke();
            }
        }
    }

    // Target following functions

    public static void FollowTarget(Transform me, Transform target, float xOffset, float yOffset, float zOffset, float trackingSpeed)
    {
        Vector3 playerPosition = new Vector3(target.position.x + xOffset, target.position.y + yOffset, zOffset);
        me.position = Vector3.Slerp(me.position, playerPosition, trackingSpeed * Time.deltaTime);
    }

    public static void FollowTarget(Transform me, Transform target, float trackingSpeed)
    {
        FollowTarget(me, target, 0, 0, 0, trackingSpeed);
    }

    public static void FollowTarget(Rigidbody2D me, Transform target, float xOffset, float yOffset, float zOffset, float trackingSpeed)
    {
        Vector3 targetPosition = new Vector3(target.position.x + xOffset, target.position.y + yOffset, zOffset);
        Vector3 smoothedPosition = Vector3.Slerp(me.position, targetPosition, trackingSpeed * Time.deltaTime);
        me.MovePosition(smoothedPosition);
    }

    public static void FollowTarget(Rigidbody2D me, Transform target, float trackingSpeed)
    {
        FollowTarget(me, target, 0, 0, 0, trackingSpeed);
    }


    // Other utility functions

    public static string FormatSingleDigit(int digit)
    {
        string formattedString = digit.ToString();
        if (digit < 10)
            formattedString = "0" + formattedString;
        return formattedString;
    }
    /*
        public static void MakeSingleton<T>(ref T instance, T thisInstance, GameObject thisGameObject) where T : class
        {
            if (instance == null)
            {
                instance = thisInstance;
                UnityEngine.Object.DontDestroyOnLoad(thisGameObject);
            }
            else
            {
                UnityEngine.Object.Destroy(thisGameObject);
            }
        }
    */
    public static void MakeSingleton<T>(ref T instance, T thisInstance, GameObject thisGameObject) where T : class
    {
        if (instance == null)
        {
            instance = thisInstance;
            // Check if the GameObject has a parent transform
            if (thisGameObject.transform.parent != null)
            {
                // Detach the GameObject from its parent
                thisGameObject.transform.parent = null;
            }
            UnityEngine.Object.DontDestroyOnLoad(thisGameObject);
        }
        else
        {
            UnityEngine.Object.Destroy(thisGameObject);
        }
    }

    public static Vector2 GetDirection(Vector2 vector)
    {
        return vector.normalized;
    }

    public static float Distance(float distanceTraveled, Vector2 currPosition, Vector2 prevPosition)
    {
        distanceTraveled += Vector2.Distance(currPosition, prevPosition);
        return distanceTraveled;
    }

    public static float Distance(Vector2 currPosition, Vector2 prevPosition)
    {
        return Distance(0, currPosition, prevPosition);
    }

    // new 
    public static T ToggleEnum<T>(T input) where T : Enum
    {
        var values = (T[])Enum.GetValues(input.GetType());
        int currentIndex = Array.IndexOf(values, input);
        return values[(currentIndex + 1) % values.Length];
    }

    public static void ColorText(Text textComponent, string before, string colored, string after, string colorCode)
    {
        textComponent.text = $"{before}<color={colorCode}>{colored}</color>{after}";
    }
    /*
    private static IEnumerator FlashColorCoroutine(MonoBehaviour target, Color flashColor, float speed, Func<bool> condition, Action<Color> setColor, Func<Color> getColor, Action onComplete)
    {
        Color originalColor = getColor();
        while (condition())
        {
            Color newColor;
            if (Mathf.Sin(UnityEngine.Time.time * speed) > 0)
                newColor = flashColor;
            else
                newColor = originalColor;
            setColor(newColor);
            yield return null;
        }
        setColor(originalColor);
        onComplete?.Invoke();
    }
*/
    private delegate float TimeGetter();

    private static IEnumerator FlashColorCoroutine<T>(T target, Color flashColor, float speed, Func<bool> condition, Action<Color> setColor, Func<Color> getColor, Action onComplete, TimeGetter getTime) where T : MonoBehaviour
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

    public static Coroutine FlashColorIndefinitely<T>(this MonoBehaviour monoBehaviour, T target, Color flashColor, float speed, Func<bool> shouldContinueFlashing, Action<Color> setColor, Func<Color> getColor, Action onComplete = null) where T : MonoBehaviour
    {
        return monoBehaviour.StartCoroutine(FlashColorCoroutine(target, flashColor, speed, shouldContinueFlashing, setColor, getColor, onComplete, () => Time.realtimeSinceStartup));
    }

    public static Coroutine FlashColorWithDuration<T>(this MonoBehaviour monoBehaviour, T target, Color flashColor, float duration, float speed, Action<Color> setColor, Func<Color> getColor, Action onComplete = null) where T : MonoBehaviour
    {
        var startTime = Time.time;
        Func<bool> condition = () => Time.time < startTime + duration;
        return monoBehaviour.StartCoroutine(FlashColorCoroutine(target, flashColor, speed, condition, setColor, getColor, onComplete, () => Time.time));
    }

    public static Coroutine FlashColorIndefinitelyRealTime<T>(this MonoBehaviour monoBehaviour, T target, Color flashColor, float speed, Func<bool> shouldContinueFlashing, Action<Color> setColor, Func<Color> getColor, Action onComplete = null) where T : MonoBehaviour
    {
        return monoBehaviour.StartCoroutine(FlashColorCoroutine(target, flashColor, speed, shouldContinueFlashing, setColor, getColor, onComplete, () => Time.realtimeSinceStartup));
    }

    public static Coroutine FlashColorWithDurationRealTime<T>(this MonoBehaviour monoBehaviour, T target, Color flashColor, float duration, float speed, Action<Color> setColor, Func<Color> getColor, Action onComplete = null) where T : MonoBehaviour
    {
        var startTime = Time.realtimeSinceStartup;
        Func<bool> condition = () => Time.realtimeSinceStartup < startTime + duration;
        return monoBehaviour.StartCoroutine(FlashColorCoroutine(target, flashColor, speed, condition, setColor, getColor, onComplete, () => Time.realtimeSinceStartup));
    }

    public static void Set<T>(float delay, Action setAction, T value, MonoBehaviour singleton)
    {
        singleton.StartCoroutine(DelayedSetExecution(delay, setAction, value, singleton));
    }

    private static IEnumerator DelayedSetExecution<T>(float delay, Action setAction, T value, MonoBehaviour singleton)
    {
        yield return new WaitForSeconds(delay);
        setAction?.Invoke();
        Set(value);
    }

    private static void Set<T>(T value)
    {
        // Perform your Set() operation here
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

        // Ensure it's set to the target when done, as Lerp can sometimes not quite reach it
        obj.transform.localScale = targetScale;
    }



    public static void RestartScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void RestartScene()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public static GameObject SpawnGameObject(UnityEngine.Object newObject, Transform spawnPosition)
    {
        // Instantiate the prefab at the specified position and rotation
        GameObject newGameObject = UnityEngine.Object.Instantiate(newObject as GameObject, spawnPosition.position, spawnPosition.rotation);
        return newGameObject;
    }
    public static GameObject SpawnGameObject(GameObject newObject, Transform spawnPosition, float lifeTime)
    {
        // Instantiate the prefab at the specified position and rotation
        GameObject newGameObject = UnityEngine.Object.Instantiate(newObject as GameObject, spawnPosition.position, spawnPosition.rotation);
        UnityEngine.Object.Destroy(newGameObject, lifeTime);
        return newGameObject;
    }

    public static void AddToAction(ref Action existingAction, Action newAction)
    {
        existingAction += newAction;
    }



}
