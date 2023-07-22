using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenImage : MonoBehaviour
{
    void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        rectTransform.anchoredPosition = CONSTANTS.DEFAULT_START_POINT;
    }
}
