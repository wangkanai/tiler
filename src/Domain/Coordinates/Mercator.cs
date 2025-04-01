// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

namespace Wangkanai.Tiler.Domain;

public class Mercator
{
	/// <summary>Gets or sets the size of the Mercator coordinate.</summary>
	public int Size { get; set; }

	/// <summary>Gets or sets the resolution (meters / pixel) of the Mercator coordinate. </summary>
	public double Resolution { get; set; }

	/// <summary>Gets or sets the maximum extent of the Mercator coordinate.</summary>
	public double OriginShift { get; set; }

	/// <summary>
	/// Represents a Mercator coordinate system, commonly used in mapping applications,
	/// that is based on the Spherical Mercator projection (EPSG:3857).
	/// Provides properties to calculate properties like resolution and size.
	/// </summary>
	public Mercator(int size = 512)
	{
		Size        = size;
		Resolution  = 2 * Math.PI * MapExtent.Max / Size;
		OriginShift = 2 * Math.PI * MapExtent.Max / 2.0;
	}
}
