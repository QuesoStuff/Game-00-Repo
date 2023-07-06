[System.Serializable]
public struct BorderParameters
{
    public float sideLength; // for Square, Hexagon
    public float width, height; // for Rectangle
    public float radius; // for Circle, SemiCircle, Crescent
    public float semiMajorAxis, semiMinorAxis; // for Ellipse
    public float base1, base2; // for Trapezoid
    public float armLength; // for Cross
    public float outerRadius, innerRadius; // for Star
    public float pillLength, pillDiameter; // for Pill shape
    public float length; // for Pill shape
}
