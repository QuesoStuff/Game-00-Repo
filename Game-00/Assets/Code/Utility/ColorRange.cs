using UnityEngine;
using System.Collections.Generic;

public class ColorRange : I_ColorRange
{
    [SerializeField] private Color startColor_; //Starting color of the range
    [SerializeField] private Color endColor_; //Ending color of the range
    [SerializeField] private uint numberOfSteps_; //Number of colors in the range

    private List<Color> inBetweenColors_; //List of colors between start and end colors

    // Default constructor
    public ColorRange() : this(Color.white, Color.black, 5) { }

    // Parametrized constructor
    public ColorRange(Color startColor, Color endColor, uint numberOfSteps)
    {
        startColor_ = startColor;
        endColor_ = endColor;
        numberOfSteps_ = numberOfSteps;
        inBetweenColors_ = GenerateInBetweenColors(); //Generate colors in the range
    }

    // Returns the start color
    public Color GetstartColor_()
    {
        return startColor_;
    }

    // Sets the start color and regenerate the colors
    public void SetstartColor(Color startColor)
    {
        startColor_ = startColor;
        inBetweenColors_ = GenerateInBetweenColors();
    }

    // Returns the end color
    public Color GetEndColor()
    {
        return endColor_;
    }

    // Sets the end color and regenerate the colors
    public void SetEndColor(Color endColor)
    {
        endColor_ = endColor;
        inBetweenColors_ = GenerateInBetweenColors();
    }

    // Returns the number of steps
    public uint GetNumberOfSteps()
    {
        return numberOfSteps_;
    }

    // Sets the number of steps and regenerate the colors
    public void SetNumberOfSteps(uint numberOfSteps)
    {
        numberOfSteps_ = numberOfSteps;
        inBetweenColors_ = GenerateInBetweenColors();
    }

    // Generates the colors in the range
    private List<Color> GenerateInBetweenColors()
    {
        List<Color> colors = new List<Color>();

        for (uint i = 0; i <= numberOfSteps_; i++)
        {
            float t = (float)i / (float)numberOfSteps_;
            colors.Add(Color.Lerp(startColor_, endColor_, t));
        }

        return colors;
    }

    // Returns the color at a specified index
    public Color GetColor(uint index)
    {
        if (index >= 0 && index < inBetweenColors_.Count)
            return inBetweenColors_[(int)index];
        else
            throw new System.IndexOutOfRangeException("Index is out of range.");
    }

    // Returns a random color from the range
    public Color GetRandomColor()
    {
        int randomIndex = Random.Range(0, inBetweenColors_.Count);
        return inBetweenColors_[randomIndex];
    }
}
