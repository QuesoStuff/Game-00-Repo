using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameObject : UI
{
    [SerializeField] private Vector3 offset_ = new Vector3(0, 2, 0);
    [SerializeField] private float fadeDuration_ = CONSTANTS.DEFAULT_DURATION;
    [SerializeField] private float scaleDuration_ = CONSTANTS.DEFAULT_DURATION;
    [SerializeField] private float scaleSize_ = CONSTANTS.DEFAULT_DURATION;
    [SerializeField] private float moveSpeed_ = CONSTANTS.DEFAULT_SPEED;
    private RectTransform rectTransform_;
    private Transform target_;
    private Quaternion initialRotation_;
    private RectTransform canvasTransform_;

    Coroutine currentShowNotificationCoroutine_ = null;  // add a reference for notification coroutine

    private Vector3 initialPosition_;
    private Vector3 initialScale_;
    private Color initialColor_;

    private Vector3 temporaryOffset_ = CONSTANTS.DEFAULT_START_POINT;  // Create a variable to hold the temporary offset
    private float temporaryRotationAngle_ = 0f;  // Create a variable to hold the temporary rotation angle
    CollectionRange<float, Color> colorRange_Damage_;
    CollectionRange<float, Color> colorRange_Health_;
    public override void Init()
    {
        List<float> thresholds = new List<float> { 3, 7 };
        List<Color> colorsDamage = new List<Color> { Color.red, Color.yellow, Color.white };
        List<Color> colorsHealth = new List<Color> { Color.blue, Color.green, Color.white };
        colorRange_Damage_ = new CollectionRange<float, Color>(thresholds, colorsDamage);
        colorRange_Health_ = new CollectionRange<float, Color>(thresholds, colorsHealth);
    }

    private void Awake()
    {
        rectTransform_ = this.GetComponent<RectTransform>();

        // This is assuming the UI_GameObject is a direct child of the canvas
        canvasTransform_ = transform.parent.GetComponent<RectTransform>();
        initialRotation_ = rectTransform_.rotation; // Store the initial rotation of the UI

        // This is assuming the Canvas is a direct child of the player
        target_ = canvasTransform_.parent;

        initialPosition_ = transform.position;
        initialScale_ = transform.localScale;
        initialColor_ = textBox_.color;
        Init();

    }

    private void LateUpdate()
    {
        // Update the position of the UI text to follow the player
        rectTransform_.position = target_.position + offset_ + temporaryOffset_;  // Add the temporary offset to the position

        // Maintain the initial rotation of the UI text
        rectTransform_.rotation = Quaternion.Euler(Camera.main.transform.eulerAngles.x,
                                                     Camera.main.transform.eulerAngles.y,
                                                     Camera.main.transform.eulerAngles.z + temporaryRotationAngle_);
    }

    // Rest of your code...

    public IEnumerator ShowNotification(string message)
    {
        // Create a random position offset each time ShowNotification is called
        temporaryOffset_ = new Vector3(Random.Range(-0.75f, 0.75f), Random.Range(-0.75f, 0.75f), 0);

        // If FlipCoin returns true, add a random rotation offset
        if (GENERIC.CoinToss())
        {
            temporaryRotationAngle_ = Random.Range(-5, 5); // set a random rotation angle
        }

        Update_UI_Text(message);

        // Perform the animations
        yield return StartCoroutine(ScaleOverTime(this.gameObject, initialScale_, initialScale_.x * scaleSize_, scaleDuration_));
        yield return StartCoroutine(MoveUpOverTime(this.gameObject, 500 * moveSpeed_, scaleDuration_));
        yield return StartCoroutine(FadeOverTime(fadeDuration_));

        // Always reset UI at the end of coroutine.
        ResetUI();
    }


    public IEnumerator ShowHPChange(float hpChange = 1, bool isHeal = false)
    {
        // If the gameObject is not already ActiveItems, activate it
        if (!this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(true);
        }

        // If there is a current coroutine running, stop it
        if (currentShowNotificationCoroutine_ != null)
        {
            StopCoroutine(currentShowNotificationCoroutine_);
        }

        string message;
        if (isHeal)
        {
            message = $"Health Up: +{Mathf.Abs(hpChange)}";
            collectionColorRange_ = colorRange_Health_;
        }
        else
        {
            message = $"Damage: -{Mathf.Abs(hpChange)}";
            collectionColorRange_ = colorRange_Damage_;
        }

        // Color the text
        ColorText(hpChange);

        // Wait for some time
        yield return new WaitForSeconds(0.5f);
        yield return null;

        // Start the ShowNotification Coroutine and store its reference
        currentShowNotificationCoroutine_ = StartCoroutine(ShowNotification(message));
    }

    public void ColorText(float hpChange = 1)
    {
        if (collectionColorRange_ != null)
        {
            textBox_.color = collectionColorRange_.GetResultBasedOnThreshold(hpChange);
        }
        else
        {
            Debug.LogError("Color range is not set");
        }
    }

    private void ResetUI()
    {
        // Reset everything back to original
        transform.localScale = initialScale_;
        transform.position = initialPosition_;
        textBox_.color = initialColor_;
        textBox_.text = "";
        transform.rotation = initialRotation_; // reset the rotation

        // Reset the temporary offset
        temporaryOffset_ = Vector3.zero;
        temporaryRotationAngle_ = 0f;

        // Disable the UI
        this.gameObject.SetActive(false);
    }


}
