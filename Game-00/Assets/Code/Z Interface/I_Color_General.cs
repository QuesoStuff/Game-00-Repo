using System;
using System.Collections;
using UnityEngine;

public interface I_Color_General
{
    /// <summary>
    /// Sets the color from a color range based on the given index.
    /// </summary>
    /// <param name="index">Index of the color in the color range.</param>
    void SetColorFromRange(uint index);

    /// <summary>
    /// Sets the color to a random color from a predefined color range.
    /// </summary>
    void SetRandomColorFromRange();

    /// <summary>
    /// Sets the color to a specific Color.
    /// </summary>
    /// <param name="color">Color to set.</param>
    void SetColor(Color color);

    /// <summary>
    /// Sets the color to the current predefined color.
    /// </summary>
    void SetColor();

    /// <summary>
    /// Sets the color to clear (transparent).
    /// </summary>
    void SetColorBlank();

    /// <summary>
    /// Sets the current color to a specific Color.
    /// </summary>
    /// <param name="color">Color to set as the current color.</param>
    void SetCurrentColor(Color color);

    /// <summary>
    /// Gets the current color.
    /// </summary>
    /// <returns>The current color.</returns>
    Color GetCurrentColor();

    /// <summary>
    /// Sets the "other" color to a specific Color.
    /// </summary>
    /// <param name="color">Color to set as the "other" color.</param>
    void SetOtherColor(Color color);

    /// <summary>
    /// Gets the "other" color.
    /// </summary>
    /// <returns>The "other" color.</returns>
    Color GetOtherColor();

    /// <summary>
    /// Sets the default color to a specific Color.
    /// </summary>
    /// <param name="color">Color to set as the default color.</param>
    void SetDefaultColor(Color color);

    /// <summary>
    /// Gets the default color.
    /// </summary>
    /// <returns>The default color.</returns>
    Color GetDefaultColor();

    /// <summary>
    /// Sets the duration of the color change.
    /// </summary>
    /// <param name="duration">Duration to set for the color change.</param>
    void SetDuration(float duration);

    /// <summary>
    /// Gets the duration of the color change.
    /// </summary>
    /// <returns>The duration of the color change.</returns>
    float GetDuration();

    /// <summary>
    /// Sets the speed of the color change.
    /// </summary>
    /// <param name="speed">Speed to set for the color change.</param>
    void SetSpeed(float speed);

    /// <summary>
    /// Gets the speed of the color change.
    /// </summary>
    /// <returns>The speed of the color change.</returns>
    float GetSpeed();

    /// <summary>
    /// Starts blinking the color between current color and clear (transparent).
    /// </summary>
    void BlinkColor();

    /// <summary>
    /// Holds the color to white for a certain duration.
    /// </summary>
    void HoldColor();

    /// <summary>
    /// Starts blinking the color between current color and clear (transparent) indefinitely.
    /// </summary>
    void BlinkColorIndefinitely();

    /// <summary>
    /// Starts blinking the color between current color and a specific color for a certain duration and speed.
    /// </summary>
    /// <param name="blinkColor">Color to blink to.</param>
    /// <param name="duration">Duration of the blinking.</param>
    /// <param name="speed">Speed of the blinking.</param>
    void BlinkColor(Color blinkColor, float duration, float speed);

    /// <summary>
    /// Holds the color to a specific color for a certain duration.
    /// </summary>
    /// <param name="holdColor">Color to hold.</param>
    /// <param name="holdDuration">Duration to hold the color.</param>
    void HoldColor(Color holdColor, float holdDuration);

    /// <summary>
    /// Starts blinking the color between current color and a specific color indefinitely at a certain speed.
    /// </summary>
    /// <param name="blinkColor">Color to blink to.</param>
    /// <param name="speed">Speed of the blinking.</param>
    void BlinkColorIndefinitely(Color blinkColor, float speed);

    /// <summary>
    /// Stops the blinking of the color.
    /// </summary>
    void StopBlinking();

    /// <summary>
    /// Gets the color range.
    /// </summary>
    /// <returns>The color range.</returns>
    ColorRange GetColorRange();

    /// <summary>
    /// Sets the color range to a specific color range.
    /// </summary>
    /// <param name="colorRange">Color range to set.</param>
    void SetColorRange(ColorRange colorRange);

    /// <summary>
    /// Gets a color from the color range based on the given index.
    /// </summary>
    /// <param name="index">Index of the color in the color range.</param>
    /// <returns>The color at the given index in the color range.</returns>
    Color GetColorFromRange(uint index);

    /// <summary>
    /// Sets the current color from a color range based on the given index.
    /// </summary>
    /// <param name="index">Index of the color in the color range.</param>
    void SetCurrentColorFromRange(uint index);
}
