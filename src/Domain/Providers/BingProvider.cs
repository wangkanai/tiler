// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

namespace Wangkanai.Tiler.Domain.Providers;

public class BingProvider
{
	public static string GetTileUrl(int x, int y, int z)
	{
		var q = Tile.QuadKey(x, y, z);
		return $"http://ecn.t3.tiles.virtualearth.net/tiles/a{q}.jpeg?g=1";
	}
}
