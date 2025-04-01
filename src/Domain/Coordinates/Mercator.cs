// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

namespace Wangkanai.Tiler.Domain;

public class Mercator
{
	/// <summary>
	///     Represents a Mercator coordinate system, commonly used in mapping applications,
	///     that is based on the Spherical Mercator projection (EPSG:3857).
	///     Provides properties to calculate properties like resolution and size.
	/// </summary>
	public Mercator()
	{
		Size       = 512;
		Resolution = 2 * Math.PI * MapExtent.MaxExtent / Size;
	}

	/// <summary>
	///     Gets or sets the size of the Mercator coordinate.
	/// </summary>
	public int Size { get; set; }

	/// <summary>
	///     Gets or sets the resolution (meters / pixel) of the Mercator coordinate.
	/// </summary>
	public double Resolution { get; set; }
}
