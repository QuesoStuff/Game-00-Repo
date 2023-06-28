using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The I_UI interface defines the expected behaviors for UI elements.
/// It includes methods to control blinking, update text and color, and resize text.
/// </summary>
public interface I_UI
{
    /// <summary>
    /// Sets the blinking state of the UI element.
    /// </summary>
    void SetIsBlinking(bool state);

    /// <summary>
    /// Gets the current blinking state of the UI element.
    /// </summary>
    bool GetIsBlinking();

    /// <summary>
    /// Gets the duration of the blink effect.
    /// </summary>
    float GetDuration();

    /// <summary>
    /// Sets the duration of the blink effect.
    /// </summary>
    void SetDuration(float duration);

    /// <summary>
    /// Gets the speed of the blink effect.
    /// </summary>
    float GetSpeed();

    /// <summary>
    /// Sets the speed of the blink effect.
    /// </summary>
    void SetSpeed(float speed);

    /// <summary>
    /// Updates the UI text with the given string.
    /// </summary>
    void Update_UI_Text(string input);

    /// <summary>
    /// Updates the UI text with the given float.
    /// </summary>
    void Update_UI_Text(float input);

    /// <summary>
    /// Updates the UI color with the given color.
    /// </summary>
    void Update_UI_Color(Color newColor);

    /// <summary>
    /// Updates the UI color with the stored new color.
    /// </summary>
    void Update_UI_Color();

    /// <summary>
    /// Starts a blink effect on the UI text.
    /// </summary>
    void BlinkText();

    /// <summary>
    /// Starts a blink effect on the UI text indefinitely.
    /// </summary>
    void BlinkTextIndefinitely();

    /// <summary>
    /// Sets the size of the UI text.
    /// </summary>
    void SetTextSize(int newSize);

    /// <summary>
    /// Sets the size of the UI text with animation, using a starting size and duration.
    /// </summary>
    void SetTextSize(Vector3 startSize, float newSize, float duration);

    /// <summary>
    /// Sets the size of the UI text with animation, using a new size and duration.
    /// </summary>
    void SetTextSize(float newSize, float duration);

    /// <summary>
    /// Stops the blink effect on the UI text.
    /// </summary>
    void StopBlinking();

    /// <summary>
    /// Starts a blink effect on the UI text with a specific color and an action to perform when completed.
    /// </summary>
    void BlinkText(Color color, Action onComplete = null);

    /// <summary>
    /// Starts a blink effect on the UI text indefinitely with a specific color.
    /// </summary>
    void BlinkTextIndefinitely(Color color);

    /// <summary>
    /// An update method for the UI. Specific implementation to be provided by the class.
    /// </summary>
    void Update_UI();
}
