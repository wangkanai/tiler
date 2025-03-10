namespace Wangkanai.Tiler.Domain;

public class TileTests
{
    [Fact]
    public void QuadKey_WhenCalledWithValidCoordinates_ReturnsCorrectQuadKey()
    {
        // Arrange
        int x = 3;
        int y = 5;
        int zoom = 3;
        string expectedQuadKey = "213";

        // Act
        string result = Tile.QuadKey(x, y, zoom);

        // Assert
        Assert.Equal(expectedQuadKey, result);
    }

    [Fact]
    public void QuadKey_WhenCalledWithZeroCoordinates_ReturnsQuadKeyWithZeros()
    {
        // Arrange
        int x = 0;
        int y = 0;
        int zoom = 3;
        string expectedQuadKey = "000";

        // Act
        string result = Tile.QuadKey(x, y, zoom);

        // Assert
        Assert.Equal(expectedQuadKey, result);
    }

    [Fact]
    public void QuadKey_WhenCalledWithMaxCoordinates_ReturnsQuadKeyWithThrees()
    {
        // Arrange
        int zoom = 3;
        int x = (1 << zoom) - 1; // 7 for zoom=3
        int y = (1 << zoom) - 1; // 7 for zoom=3
        string expectedQuadKey = "333";

        // Act
        string result = Tile.QuadKey(x, y, zoom);

        // Assert
        Assert.Equal(expectedQuadKey, result);
    }

    [Fact]
    public void QuadKey_WhenCalledWithZoom1_ReturnsSingleDigit()
    {
        // Arrange
        int x = 0;
        int y = 0;
        int zoom = 1;

        // Act
        string result = Tile.QuadKey(x, y, zoom);

        // Assert
        Assert.Equal("0", result);
        Assert.Equal(zoom, result.Length);
    }

    [Fact]
    public void QuadKey_WhenCalledWithZoom2_ReturnsTwoDigits()
    {
        // Arrange
        int x = 2;
        int y = 1;
        int zoom = 2;

        // Act
        string result = Tile.QuadKey(x, y, zoom);

        // Assert
        Assert.Equal("12", result);
        Assert.Equal(zoom, result.Length);
    }

    [Theory]
    [InlineData(0, 0, 4, "0000")]
    [InlineData(15, 15, 4, "3333")]
    [InlineData(2, 3, 3, "032")]
    [InlineData(5, 2, 4, "1021")]
    [InlineData(7, 3, 4, "1321")]
    [InlineData(8, 9, 5, "02101")]
    [InlineData(16, 16, 5, "10303")]
    public void QuadKey_WithVariousInputs_ReturnsExpectedResults(int x, int y, int zoom, string expected)
    {
        // Act
        string result = Tile.QuadKey(x, y, zoom);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void QuadKey_DifferentCoordinatesAtSameZoom_ProduceDifferentQuadKeys()
    {
        // Arrange
        int zoom = 4;
        var coordinates = new[]
        {
            (x: 0, y: 0),
            (x: 1, y: 0),
            (x: 0, y: 1),
            (x: 1, y: 1),
            (x: 8, y: 8),
            (x: 15, y: 15)
        };

        // Act
        var results = coordinates.Select(c => Tile.QuadKey(c.x, c.y, zoom)).ToList();

        // Assert
        Assert.Equal(coordinates.Length, results.Distinct().Count());
    }

    [Fact]
    public void QuadKey_BitPatternTest_EnsuresCorrectQuadKeyGeneration()
    {
        // This test verifies the bit pattern handling for each quadrant at zoom level 1
        
        // Quadrant 0: x=0, y=0
        Assert.Equal("0", Tile.QuadKey(0, 0, 1));
        
        // Quadrant 1: x=1, y=0
        Assert.Equal("1", Tile.QuadKey(1, 0, 1));
        
        // Quadrant 2: x=0, y=1
        Assert.Equal("2", Tile.QuadKey(0, 1, 1));
        
        // Quadrant 3: x=1, y=1
        Assert.Equal("3", Tile.QuadKey(1, 1, 1));
    }

    [Fact]
    public void QuadKey_ZoomLevel23_GeneratesCorrectLength()
    {
        // Arrange
        int zoom = 23; // Maximum zoom level typically used
        int x = 1234567;
        int y = 7654321;

        // Act
        string result = Tile.QuadKey(x, y, zoom);

        // Assert
        Assert.Equal(zoom, result.Length);
    }
    
    [Fact]
    public void QuadKey_LengthEqualsZoomLevel_ForAllZoomLevels()
    {
        // Test that the quadkey length always equals the zoom level
        for (int zoom = 1; zoom <= 10; zoom++)
        {
            int x = zoom * 2;
            int y = zoom * 3;
            
            string result = Tile.QuadKey(x, y, zoom);
            
            Assert.Equal(zoom, result.Length);
        }
    }
    
    [Fact]
    public void QuadKey_FirstDigitEncodesMostSignificantBit()
    {
        // This test verifies that the first digit of the quadkey 
        // encodes the most significant bit position
        
        // For zoom=3, the first digit should encode bit position 2
        Assert.Equal('0', Tile.QuadKey(0, 0, 3)[0]);
        Assert.Equal('1', Tile.QuadKey(4, 0, 3)[0]);
        Assert.Equal('2', Tile.QuadKey(0, 4, 3)[0]);
        Assert.Equal('3', Tile.QuadKey(4, 4, 3)[0]);
    }
}
