// Copyright (c) 2014-2024 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

namespace Wangkanai.Tiler.Domain.Providers;

public class BingProvider
{
	public static string GetTileUrl(int x, int y, int z)
	{
		var q = TileXyToQuadKey(x, y, z);
		return $"http://ecn.t3.tiles.virtualearth.net/tiles/a{q}.jpeg?g=1";
	}

	/// <summary>
	/// Converts tile XYZ coordinates into a QuadKey at a specified level of detail.
	/// </summary>
	/// <param name="tileX">Tile X coordinate</param>
	/// <param name="tileY">Tile Y coordinate</param>
	/// <param name="levelOfDetail">Level of detail, from 1 (lowest detail) to 23 (highest detail)</param>
	/// <returns>A string containing the QuadKey</returns>
	private static string TileXyToQuadKey(int tileX, int tileY, int levelOfDetail)
	{
		var quadKey = new char[levelOfDetail];

		for (int i = levelOfDetail - 1; i >= 0; i--)
		{
			char digit = '0';
			int mask = 1 << i;

			if ((tileX & mask) != 0)
			{
				digit++;
			}

			if ((tileY & mask) != 0)
			{
				digit++;
				digit++;
			}

			quadKey[levelOfDetail - 1 - i] = digit;
		}

		return new string(quadKey);
	}
}
