// Copyright (c) 2014-2024 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

namespace Wangkanai.Tiler.Domain.Providers;

public class GoogleProvider
{
	public static string GetTileUrl(int x, int y, int z)
		=> $"https://mt1.google.com/vt/lyrs=s&x={x}&y={y}&z={z}";
}
