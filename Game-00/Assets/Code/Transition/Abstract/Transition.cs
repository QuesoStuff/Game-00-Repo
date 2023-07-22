using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Transition : MonoBehaviour, I_SetComponents
{
    [SerializeField]
    protected Image screenCover_;

    [SerializeField]
    protected float transitionTime_ = 5;

    public abstract IEnumerator TransitionCoroutine();
    public void BeginTransition()
    {
        StartCoroutine(TransitionCoroutine());
    }

    protected void Awake()
    {
        SetComponents();
    }
    public void Visible(bool visible)
    {
        screenCover_.enabled = visible;  // Disable the screen cover

    }

    public void SetComponents()
    {
        if (screenCover_ == null)
        {
            // Creating new GameObject for Canvas
            GameObject canvasObject = new GameObject("Canvas");
            Canvas canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.sortingOrder = 1; // Set high sorting order to ensure canvas is rendered on top
            CanvasScaler cs = canvasObject.AddComponent<CanvasScaler>();
            cs.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            cs.referenceResolution = new Vector2(Screen.width, Screen.height); // Adapt to the screen resolution

            // Creating new GameObject for Image and setting it as a child of Canvas
            GameObject imageObject = new GameObject("Image");
            imageObject.transform.SetParent(canvasObject.transform);
            screenCover_ = imageObject.AddComponent<Image>();
            RectTransform rect = imageObject.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0, 0);
            rect.anchorMax = new Vector2(1, 1);
            rect.anchoredPosition = new Vector2(0, 0);
            rect.sizeDelta = new Vector2(0, 0); // to make sure it stretches to full canvas size

            // Disable image by default
            screenCover_.enabled = false;

            // Preventing canvasObject from being destroyed when a new scene is loaded
        }
        else
        {
            Visible(false);
            //Debug.LogWarning("Screen cover already exists! Did not create a new one.");
        }
    }


}
