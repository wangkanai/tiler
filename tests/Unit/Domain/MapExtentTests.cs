// Copyright (c) 2014-2024 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

namespace Wangkanai.Tiler.Domain;

public class MapExtentTests
{
	[Fact]
	public void MapExtent_WhenCreatedWithDefaultConstructor_HasZeroValues()
	{
		var mapExtent = new MapExtent();
		Assert.Equal(0, mapExtent.Width);
		Assert.Equal(0, mapExtent.Height);
	}
}
