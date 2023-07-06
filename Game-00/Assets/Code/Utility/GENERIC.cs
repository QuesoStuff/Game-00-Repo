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



    public static bool Valid_Duration(ref float timer, float duration, Func<bool> conditionStart, Func<bool> conditionEnd, Action method = null)
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
                method?.Invoke();
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



    public static bool IsValidIndex<T>(ICollection<T> collection, int index)
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
        int currentIndex = (int)Array.IndexOf(values, input);
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






    public static Coroutine DelayMethod(this MonoBehaviour monoBehaviour, float delay = 5, Action method = null)
    {
        return monoBehaviour.StartCoroutine(DelayedMethodCoroutine(delay, method));
    }

    private static IEnumerator DelayedMethodCoroutine(float delay = 5, Action method = null)
    {
        yield return new WaitForSeconds(delay);
        method.Invoke();
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



    public static void RestartScene(string sceneName = null)
    {
        sceneName ??= SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public static GameObject SpawnGameObject(GameObject newObject, Transform spawnPosition, float lifeTime = float.PositiveInfinity)
    {
        GameObject newGameObject = UnityEngine.Object.Instantiate(newObject, spawnPosition.position, spawnPosition.rotation);

        if (!float.IsPositiveInfinity(lifeTime))
        {
            UnityEngine.Object.Destroy(newGameObject, lifeTime);
        }

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
        if (direction == Vector2.right || direction == Vector2.left)
        {
            newScale.x = scale.x * currentScale.x;
        }
        if (direction == Vector2.up || direction == Vector2.down)
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



    /*
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
    */

    public static void ChangeSprite(SpriteRenderer renderer, Sprite newSprite)
    {
        if (renderer != null)
        {
            renderer.sprite = newSprite;
        }
    }

    public static void ExplosionCreate(UnityEngine.Object ObjRef, Vector3 position, Color startColor, bool shouldRotate = false, bool constantLifetimeAndDuration = false)
    {
        GameObject explosionObject = (GameObject)UnityEngine.Object.Instantiate(ObjRef);
        explosionObject.transform.position = position;

        if (shouldRotate)
        {
            explosionObject.transform.rotation = UnityEngine.Random.rotation;
        }

        SetParticleProperties(explosionObject, startColor, constantLifetimeAndDuration);

        ParticleSystem explosion = explosionObject.GetComponent<ParticleSystem>();
        explosion.Play();
    }

    private static void SetParticleProperties(GameObject obj, Color startColor, bool constantLifetimeAndDuration)
    {
        ParticleSystem[] particleSystems = obj.GetComponentsInChildren<ParticleSystem>(true);

        foreach (ParticleSystem ps in particleSystems)
        {
            ps.Stop();
            ParticleSystem.MainModule main = ps.main;

            main.simulationSpeed = UnityEngine.Random.Range(CONSTANTS.BULLET_SIM_SPEED_MIN, CONSTANTS.BULLET_SIM_SPEED_MAX);
            main.startSize = UnityEngine.Random.Range(CONSTANTS.BULLET_SIM_START_SIZE_MIN, CONSTANTS.BULLET_SIM_START_SIZE_MAX);

            if (!constantLifetimeAndDuration)
            {
                main.startLifetime = UnityEngine.Random.Range(CONSTANTS.BULLET_END_LIFE_MIN, CONSTANTS.BULLET_END_LIFE_MAX);
                main.duration = UnityEngine.Random.Range(CONSTANTS.BULLET_DURATION_MIN, CONSTANTS.BULLET_DURATION_MAX);
            }

            main.startColor = startColor;
            ps.Play();
        }
    }


    public static Color RandomColor(float opacity = 1)
    {
        return new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, opacity);
    }

    public static IEnumerator FadeInOut(SpriteRenderer renderer, Color startColor, Color endColor, float duration, float delay = 0)
    {
        while (true)
        {
            // Ping pong time for smooth transition
            float t = 0;
            float time = 0;

            while (t <= 1.0f)
            {
                time += Time.deltaTime;
                t = time / duration;
                renderer.color = Color.Lerp(startColor, endColor, Mathf.PingPong(t, 1));
                yield return null;
            }

            // Wait for some time (delay) before starting the next cycle
            yield return new WaitForSeconds(delay);

            // Swap startColor and endColor for the reverse transition
            Color temp = startColor;
            startColor = endColor;
            endColor = temp;
        }
    }
    public static Color ColorFrom256(float red, float green, float blue, float opacity = 1)
    {
        float r = red / 255;
        float g = green / 255;
        float b = blue / 255;
        float a = opacity / 255;
        return new Color(r, g, b, a);
    }
    public static string ColorToHex(Color color)
    {
        int r = Mathf.RoundToInt(color.r * 255);
        int g = Mathf.RoundToInt(color.g * 255);
        int b = Mathf.RoundToInt(color.b * 255);
        int a = Mathf.RoundToInt(color.a * 255);
        return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", r, g, b, a);
    }
    public static Color HexToColor(string hex)
    {
        if (!hex.StartsWith("#"))
        {
            hex = "#" + hex;
        }

        byte r = byte.Parse(hex.Substring(1, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(5, 2), System.Globalization.NumberStyles.HexNumber);
        byte a = 255; // set default alpha

        // If the hex string includes alpha
        if (hex.Length >= 9)
            a = byte.Parse(hex.Substring(7, 2), System.Globalization.NumberStyles.HexNumber);

        return new Color32(r, g, b, a);
    }

    public static Color ChangeOpacity(Color color, float opacityLevel)
    {
        color.a = opacityLevel;
        return color;
    }
    public static T PerformOperationOnThreshold<T, U>(List<U> thresholds, List<T> results, U comparisonValue, Func<U, U, bool> comparisonOperator)
    {
        for (int i = 0; i < thresholds.Count; i++)
        {
            if (comparisonOperator(comparisonValue, thresholds[i]))
            {
                return results[i];
            }
        }
        return results[results.Count - 1];
    }

    public static bool CheckLimit<T>(Func<bool> predicate, T count, T limit, Func<T, T, bool> comparisonOperation = null) where T : IComparable<T>
    {
        if (comparisonOperation == null)
        {
            comparisonOperation = (a, b) => a.CompareTo(b) < 0;
        }

        if (predicate())
        {
            return comparisonOperation(count, limit);
        }
        return true;
    }


    public static bool CoinToss(int trueWeight = 50, int falseWeight = 50)
    {
        int totalWeight = trueWeight + falseWeight;
        int randomNumber = random.Next(0, totalWeight);

        if (randomNumber < trueWeight)
            return true;
        else
            return false;
    }

    public static Vector2 GetRandomDirection()
    {
        int choice = UnityEngine.Random.Range(0, 4);
        if (choice == 0)
            return Vector2.up;
        else if (choice == 1)
            return Vector2.down;
        else if (choice == 2)
            return Vector2.left;
        else if (choice == 3)
            return Vector2.right;
        else
            return Vector2.zero; // this should never happen
    }
    public static Vector2 Turn_90(float x, float y, float scale = 1)
    {
        return scale * new Vector2(y, x);
    }

    public static void DetachFromParent(this Transform childTransform)
    {
        if (childTransform.parent != null)
        {
            Vector3 currentLocalPosition = childTransform.localPosition;
            childTransform.SetParent(null);
            childTransform.position = childTransform.position + currentLocalPosition;
        }
    }

    public static void StopCurrentCoroutine(MonoBehaviour behaviour, ref Coroutine currentCoroutine, Action onComplete = null)
    {
        if (currentCoroutine != null)
        {
            behaviour.StopCoroutine(currentCoroutine);
            currentCoroutine = null;
            onComplete?.Invoke();
        }
    }

    public static Vector3[] AssignPoints_Triangle(float sideLength, Vector3 center)
    {
        Vector3[] vertices = new Vector3[4];
        float height = Mathf.Sqrt(sideLength * sideLength - (sideLength / 2) * (sideLength / 2));
        vertices[0] = new Vector3(center.x, center.y + height / 2, center.z); // Top
        vertices[1] = new Vector3(center.x - sideLength / 2, center.y - height / 2, center.z); // Bottom left
        vertices[2] = new Vector3(center.x + sideLength / 2, center.y - height / 2, center.z); // Bottom right
        vertices[3] = vertices[0]; // Close the loop
        return vertices;
    }
    public static Vector3[] AssignPoints_Star(float outerRadius, float innerRadius, Vector3 center)
    {
        Vector3[] vertices = new Vector3[11];
        for (int i = 0; i < 10; i++)
        {
            float radius = (i % 2 == 0) ? outerRadius : innerRadius;
            float angle_deg = 36 * i;
            float angle_rad = Mathf.PI / 180 * angle_deg;
            vertices[i] = new Vector3(center.x + radius * Mathf.Cos(angle_rad), center.y + radius * Mathf.Sin(angle_rad), center.z);
        }
        vertices[10] = vertices[0]; // Close the loop

        return vertices;
    }

    public static Vector3[] AssignPoints_Pentagon(Vector3 center, float sideLength)
    {
        int numberOfPoints = 5; // The number of points to make a pentagon
        Vector3[] vertices = new Vector3[numberOfPoints + 1];

        for (int i = 0; i < numberOfPoints; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfPoints;
            vertices[i] = new Vector3(center.x + Mathf.Cos(angle) * sideLength, center.y + Mathf.Sin(angle) * sideLength, center.z);
        }
        vertices[numberOfPoints] = vertices[0]; // Close the loop

        return vertices;
    }

    public static Vector3[] AssignPoints_Donut(int numberOfPoints, float innerRadius, float outerRadius, Vector3 center)
    {
        Vector3[] vertices = new Vector3[numberOfPoints * 2 + 2];

        for (int i = 0; i <= numberOfPoints; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfPoints;
            vertices[i] = new Vector3(center.x + Mathf.Cos(angle) * outerRadius, center.y + Mathf.Sin(angle) * outerRadius, center.z);
            vertices[i + numberOfPoints + 1] = new Vector3(center.x + Mathf.Cos(angle) * innerRadius, center.y + Mathf.Sin(angle) * innerRadius, center.z);
        }
        return vertices;
    }

    public static Vector3[] AssignPoints_Cross(float armLength, Vector3 center)
    {
        Vector3[] vertices = new Vector3[13];

        vertices[0] = new Vector3(center.x - armLength, center.y + armLength, center.z);
        vertices[1] = new Vector3(center.x - armLength, center.y, center.z);
        vertices[2] = new Vector3(center.x - 2 * armLength, center.y, center.z);
        vertices[3] = new Vector3(center.x - 2 * armLength, center.y - armLength, center.z);
        vertices[4] = new Vector3(center.x - armLength, center.y - armLength, center.z);
        vertices[5] = new Vector3(center.x - armLength, center.y - 2 * armLength, center.z);
        vertices[6] = new Vector3(center.x + armLength, center.y - 2 * armLength, center.z);
        vertices[7] = new Vector3(center.x + armLength, center.y - armLength, center.z);
        vertices[8] = new Vector3(center.x + 2 * armLength, center.y - armLength, center.z);
        vertices[9] = new Vector3(center.x + 2 * armLength, center.y, center.z);
        vertices[10] = new Vector3(center.x + armLength, center.y, center.z);
        vertices[11] = new Vector3(center.x + armLength, center.y + armLength, center.z);
        vertices[12] = vertices[0]; // Close the loop

        return vertices;
    }
    public static Vector3[] AssignPoints_Elipse(float semiMajorAxis_, float semiMinorAxis_, Vector3 center)
    {
        int numberOfPoints = 360;
        Vector3[] vertices = new Vector3[numberOfPoints + 1];

        for (int i = 0; i < numberOfPoints; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfPoints;
            Vector3 vertex = new Vector3(center.x + Mathf.Cos(angle) * semiMajorAxis_, center.y + Mathf.Sin(angle) * semiMinorAxis_, center.z);
        }

        vertices[numberOfPoints] = vertices[0];

        return vertices;
    }


    public static Vector3[] AssignPoints_Circle(float radius, Vector3 center)
    {
        int numberOfPoints = 360;
        Vector3[] vertices = new Vector3[numberOfPoints + 1];

        for (int i = 0; i < numberOfPoints; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfPoints;
            vertices[i] = new Vector3(center.x + Mathf.Cos(angle) * radius, center.y + Mathf.Sin(angle) * radius, center.z);
        }
        vertices[numberOfPoints] = vertices[0];

        return vertices;
    }

    public static Vector3[] AssignPoints_SemiCircle(float radius, Vector3 center)
    {
        int numberOfPoints = 180;
        Vector3[] vertices = new Vector3[numberOfPoints + 1];

        for (int i = 0; i <= numberOfPoints; i++)
        {
            float angle = i * Mathf.PI / numberOfPoints;
            vertices[i] = new Vector3(center.x + Mathf.Cos(angle) * radius, center.y + Mathf.Sin(angle) * radius, center.z);
        }
        return vertices;
    }
    public static Vector3[] AssignPoints_Trapezoid(float base1_, float base2_, float height, Vector3 center)
    {
        Vector3[] vertices = new Vector3[5];

        vertices[0] = new Vector3(center.x - base1_ / 2, center.y - height / 2, center.z);
        vertices[1] = new Vector3(center.x + base1_ / 2, center.y - height / 2, center.z);

        float smallerBaseOffset = (base1_ - base2_) / 2;  // Determine the offset of the smaller base relative to the larger base
        vertices[2] = new Vector3(center.x + base2_ / 2 - smallerBaseOffset, center.y + height / 2, center.z);
        vertices[3] = new Vector3(center.x - base2_ / 2 + smallerBaseOffset, center.y + height / 2, center.z);

        vertices[4] = vertices[0]; // Close the loop

        return vertices;
    }

    public static Vector3[] AssignPoints_Square(float sideLength_, Vector3 center)
    {
        Vector3[] vertices = new Vector3[5];

        vertices[0] = new Vector3(center.x - sideLength_ / 2, center.y - sideLength_ / 2, center.z);
        vertices[1] = new Vector3(center.x + sideLength_ / 2, center.y - sideLength_ / 2, center.z);
        vertices[2] = new Vector3(center.x + sideLength_ / 2, center.y + sideLength_ / 2, center.z);
        vertices[3] = new Vector3(center.x - sideLength_ / 2, center.y + sideLength_ / 2, center.z);
        vertices[4] = vertices[0]; // Close the loop

        return vertices;
    }

    public static Vector3[] AssignPoints_Rectangle(float width, float height, Vector3 center)
    {
        Vector3[] vertices = new Vector3[5];
        vertices[0] = new Vector3(center.x - width / 2, center.y - height / 2, center.z); // Bottom left
        vertices[1] = new Vector3(center.x + width / 2, center.y - height / 2, center.z); // Bottom right
        vertices[2] = new Vector3(center.x + width / 2, center.y + height / 2, center.z); // Top right
        vertices[3] = new Vector3(center.x - width / 2, center.y + height / 2, center.z); // Top left
        vertices[4] = vertices[0]; // Close the loop

        return vertices;
    }

    public static Vector3[] AssignPoints_Diamond(float width, float height, Vector3 center)
    {
        Vector3[] vertices = new Vector3[5];

        vertices[0] = new Vector3(center.x, center.y + height / 2, center.z);
        vertices[1] = new Vector3(center.x + width / 2, center.y, center.z);
        vertices[2] = new Vector3(center.x, center.y - height / 2, center.z);
        vertices[3] = new Vector3(center.x - width / 2, center.y, center.z);
        vertices[4] = vertices[0];

        return vertices;
    }

    public static Vector3[] AssignPoints_Moon(int numberOfPoints, float innerRadius, float outerRadius, Vector3 center)
    {
        Vector3[] vertices = new Vector3[numberOfPoints * 2 + 2];

        for (int i = 0; i <= numberOfPoints; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfPoints;

            // Outer circle
            if (i < numberOfPoints / 2) // Only create half of the outer circle
            {
                vertices[i] = new Vector3(center.x + Mathf.Cos(angle) * outerRadius, center.y + Mathf.Sin(angle) * outerRadius, center.z);
            }

            // Inner circle
            if (i >= numberOfPoints / 2 && i <= numberOfPoints) // Only create half of the inner circle
            {
                vertices[i + numberOfPoints + 1] = new Vector3(center.x + Mathf.Cos(angle) * innerRadius, center.y + Mathf.Sin(angle) * innerRadius, center.z);
            }
        }

        return vertices;
    }

    public static Vector3[] AssignPoints_Pill(float length, float radius, Vector3 center)
    {
        // We'll define semi-circle by 180 points
        int numberOfPointsInSemiCircle = 180;
        // The pill will be composed by two semi-circles and a rectangle.
        // Since we're sharing points between semi-circle and rectangle, we'll subtract 2.
        Vector3[] vertices = new Vector3[numberOfPointsInSemiCircle * 2 + 2];

        for (int i = 0; i < numberOfPointsInSemiCircle; i++)
        {
            float angle = i * Mathf.PI / numberOfPointsInSemiCircle;
            vertices[i] = new Vector3(center.x - length / 2 + Mathf.Cos(angle) * radius, center.y + Mathf.Sin(angle) * radius, center.z);
        }

        for (int i = numberOfPointsInSemiCircle; i < numberOfPointsInSemiCircle * 2; i++)
        {
            float angle = i * Mathf.PI / numberOfPointsInSemiCircle;
            vertices[i] = new Vector3(center.x + length / 2 + Mathf.Cos(angle) * radius, center.y + Mathf.Sin(angle) * radius, center.z);
        }

        vertices[vertices.Length - 2] = new Vector3(center.x - length / 2, center.y - radius, center.z);
        vertices[vertices.Length - 1] = vertices[0];

        return vertices;
    }



    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 center, float rotation)
    {
        // Get the direction from the pivot to the point
        Vector3 dir = point - center;

        // Rotate the direction vector      
        dir = Quaternion.Euler(0, 0, rotation) * dir;

        // Compute the rotated point
        Vector3 rotatedPoint = dir + center;

        return rotatedPoint;
    }

    public static void AdjustChildDistance(Transform parent, int childIndex, float factor = 2)
    {
        if (childIndex < 0 || childIndex >= parent.childCount)
        {
            Debug.LogError("Child index out of range.");
            return;
        }

        Transform child = parent.GetChild(childIndex);
        child.localPosition *= factor;
    }

    public static void AdjustChildDistance_All(Transform parent, float factor = 2)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            AdjustChildDistance(parent, i, factor);
        }
    }
    public static void DrawDebugLines(Vector3[] vertices, Color color, float duration)
    {
        for (int i = 0; i < vertices.Length - 1; i++)
        {
            Debug.DrawLine(vertices[i], vertices[i + 1], color, duration);
        }
    }
}









