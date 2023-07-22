using UnityEngine;
using System.Collections.Generic;

public class ColorRange
{
    [SerializeField] private Color startColor_; //Starting color of the range
    [SerializeField] private Color endColor_; //Ending color of the range
    [SerializeField] private int numberOfSteps_; //Number of colors in the range
    private int currIndex_ = 0;
    private List<Color> inBetweenColors_; //List of colors between start and end colors

    // Default constructor
    public ColorRange() : this(Color.white, Color.black, 5) { }

    // Parametrized constructor
    public ColorRange(Color startColor, Color endColor, int numberOfSteps)
    {
        startColor_ = startColor;
        endColor_ = endColor;
        numberOfSteps_ = numberOfSteps;
        inBetweenColors_ = GenerateInBetweenColors(); //Generate colors in the range
    }
    public int GetCurrIndex()
    {
        return currIndex_;
    }
    public void SetCurrIndex(int index = 0)
    {
        currIndex_ = index;
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
    public int GetNumberOfSteps()
    {
        return numberOfSteps_;
    }

    // Sets the number of steps and regenerate the colors
    public void SetNumberOfSteps(int numberOfSteps)
    {
        numberOfSteps_ = numberOfSteps;
        inBetweenColors_ = GenerateInBetweenColors();
        currIndex_ = 0;
    }

    // Generates the colors in the range
    private List<Color> GenerateInBetweenColors()
    {
        List<Color> colors = new List<Color>();
        Color currColor;
        for (int i = 0; i <= numberOfSteps_; i++)
        {
            float t = (float)i / (float)numberOfSteps_;
            currColor = Color.Lerp(startColor_, endColor_, t);
            //currColor.a = 1;
            colors.Add(currColor);
        }

        return colors;
    }

    // Returns the color at a specified index
    public Color GetColor(int index)
    {
        if (index >= 0 && index < inBetweenColors_.Count)
            return inBetweenColors_[(int)index];
        else
            throw new System.IndexOutOfRangeException("Index is out of range.");
    }

    public List<Color> GetColors()
    {
        return inBetweenColors_;

    }

    public Color GetNextColor()
    {
        Color color = inBetweenColors_[currIndex_];
        currIndex_ = (currIndex_ + 1) % inBetweenColors_.Count;
        return color;
    }

    // Returns a random color from the range
    public Color GetRandomColor()
    {
        int randomIndex = Random.Range(0, inBetweenColors_.Count);
        return inBetweenColors_[randomIndex];
    }
}
