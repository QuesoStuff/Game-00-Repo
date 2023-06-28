using UnityEngine;
using System.Collections.Generic;
public interface I_ColorRange
{
    /// <summary>
    /// Returns the starting color of the range.
    /// </summary>
    /// <returns>The starting color of the range.</returns>
    Color GetstartColor_();

    /// <summary>
    /// Sets the starting color of the range and regenerates the in-between colors.
    /// </summary>
    /// <param name="startColor">The starting color to set.</param>
    void SetstartColor(Color startColor);

    /// <summary>
    /// Returns the ending color of the range.
    /// </summary>
    /// <returns>The ending color of the range.</returns>
    Color GetEndColor();

    /// <summary>
    /// Sets the ending color of the range and regenerates the in-between colors.
    /// </summary>
    /// <param name="endColor">The ending color to set.</param>
    void SetEndColor(Color endColor);

    /// <summary>
    /// Returns the number of steps (colors) in the range.
    /// </summary>
    /// <returns>The number of steps (colors) in the range.</returns>
    uint GetNumberOfSteps();

    /// <summary>
    /// Sets the number of steps (colors) in the range and regenerates the in-between colors.
    /// </summary>
    /// <param name="numberOfSteps">The number of steps (colors) to set.</param>
    void SetNumberOfSteps(uint numberOfSteps);

    /// <summary>
    /// Returns the color at a specified index in the range.
    /// </summary>
    /// <param name="index">The index of the color to return.</param>
    /// <returns>The color at the specified index in the range.</returns>
    /// <exception cref="System.IndexOutOfRangeException">Thrown when the index is out of the range of in-between colors.</exception>
    Color GetColor(uint index);

    /// <summary>
    /// Returns a random color from the range.
    /// </summary>
    /// <returns>A random color from the range.</returns>
    Color GetRandomColor();
}
