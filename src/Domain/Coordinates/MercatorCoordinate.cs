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

	/// <summary>
	/// Represents a Mercator coordinate system, commonly used in mapping applications,
	/// that is based on the Spherical Mercator projection (EPSG:3857).
	/// Provides properties to calculate properties like resolution and size.
	/// </summary>
	public MercatorCoordinate()
	{
		Size       = 512;
		Resolution = 2 * Math.PI * MapExtent.MaxExtent / Size;
	}
}
