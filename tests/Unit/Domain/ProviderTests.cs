// Copyright (c) 2014-2024 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Wangkanai.Tiler.Domain.Providers;

namespace Wangkanai.Tiler.Domain;

public class ProviderTests
{
    [Fact]
    public void GoogleProvider_GetTileUrl_ReturnsCorrectUrl()
    {
        // Arrange
        int x = 1;
        int y = 2;
        int z = 3;
        string expected = "https://mt1.google.com/vt/lyrs=s&x=1&y=2&z=3";
        
        // Act
        string actual = GoogleProvider.GetTileUrl(x, y, z);
        
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void BingProvider_GetTileUrl_ReturnsCorrectUrl()
    {
        // Arrange
        int x = 1;
        int y = 2;
        int z = 3;
        string expected = "http://ecn.t3.tiles.virtualearth.net/tiles/a021.jpeg?g=1";
        
        // Act
        string actual = BingProvider.GetTileUrl(x, y, z);
        
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData(0, 0, 1, "0")]
    [InlineData(1, 1, 2, "03")]
    [InlineData(3, 5, 4, "0321")]
    [InlineData(15, 10, 5, "02313")]
    public void BingProvider_GetTileUrl_GeneratesCorrectQuadKey(int x, int y, int z, string expectedQuadKey)
    {
        // Act
        string url = BingProvider.GetTileUrl(x, y, z);
        
        // Assert
        Assert.Contains($"{expectedQuadKey}", url);
    }
}
