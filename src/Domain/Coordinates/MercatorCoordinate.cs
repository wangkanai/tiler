namespace Wangkanai.Tiler.Domain;

public class MercatorCoordinate
{
	/// <summary>
	/// Gets or sets the size of the Mercator coordinate.
	/// </summary>
	public int Size { get; set; }

	/// <summary>
	/// Gets or sets the resolution (meters / pixel) of the Mercator coordinate.
	/// </summary>
	public double Resolution { get; set; }
}
