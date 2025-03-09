namespace Wangkanai.Tiler.Domain;

/// <summary>
/// Represents a coordinate pair with X and Y values.
/// Can be used for geographical coordinates, pixel positions, or any 2D coordinate system.
/// </summary>
public class CoordinatePair
{
    /// <summary>
    /// X coordinate (horizontal position)
    /// </summary>
    public double X { get; set; }

    /// <summary>
    /// Y coordinate (vertical position)
    /// </summary>
    public double Y { get; set; }

    /// <summary>
    /// Represents a coordinate pair with X and Y values.
    /// Can be used for geographical coordinates, pixel positions, or any 2D coordinate system.
    /// </summary>
    public CoordinatePair() { }

    /// <summary>
    /// Represents a coordinate pair with X and Y values.
    /// Can be used for geographical coordinates, pixel positions, or any 2D coordinate system.
    /// </summary>
    public CoordinatePair(double x, double y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Returns a string representation of the coordinate pair
    /// </summary>
    public override string ToString() => $"({X}, {Y})";
}