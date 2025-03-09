// Copyright (c) 2014-2024 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Wangkanai.Tiler.Domain;

namespace Wangkanai.Tiler.UnitTests.Domain;

public class CoordinatePairTests
{
	[Fact]
	public void CoordinatePair_WhenCreatedWithDefaultConstructor_HasZeroValues()
	{
		var coordinatePair = new CoordinatePair();
		Assert.Equal(0, coordinatePair.X);
		Assert.Equal(0, coordinatePair.Y);
	}

	[Fact]
	public void CoordinatePair_WhenCreatedWithValues_HasCorrectValues()
	{
		var coordinatePair = new CoordinatePair(1, 2);
		Assert.Equal(1, coordinatePair.X);
		Assert.Equal(2, coordinatePair.Y);
	}
}
