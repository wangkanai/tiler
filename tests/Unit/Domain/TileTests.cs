namespace Wangkanai.Tiler.Domain;

public class TileTests
{
    [Fact]
    public void QuadKey_WhenCalledWithValidCoordinates_ReturnsCorrectQuadKey()
    {
        // Arrange
        int x = 3;
        int y = 5;
        int levelOfDetail = 3;
        string expectedQuadKey = "213";

        // Act
        string result = Tile.QuadKey(x, y, levelOfDetail);

        // Assert
        Assert.Equal(expectedQuadKey, result);
    }

    [Fact]
    public void QuadKey_WhenCalledWithZeroCoordinates_ReturnsQuadKeyWithZeros()
    {
        // Arrange
        int x = 0;
        int y = 0;
        int levelOfDetail = 3;
        string expectedQuadKey = "000";

        // Act
        string result = Tile.QuadKey(x, y, levelOfDetail);

        // Assert
        Assert.Equal(expectedQuadKey, result);
    }

    [Fact]
    public void QuadKey_WhenCalledWithMaxCoordinates_ReturnsQuadKeyWithThrees()
    {
        // Arrange
        int x = (1 << 3) - 1; // 7
        int y = (1 << 3) - 1; // 7
        int levelOfDetail = 3;
        string expectedQuadKey = "333";

        // Act
        string result = Tile.QuadKey(x, y, levelOfDetail);

        // Assert
        Assert.Equal(expectedQuadKey, result);
    }

    [Fact]
    public void QuadKey_WhenCalledWithMinimumLevelOfDetail_ReturnsCorrectLength()
    {
        // Arrange
        int x = 0;
        int y = 0;
        int levelOfDetail = 1;

        // Act
        string result = Tile.QuadKey(x, y, levelOfDetail);

        // Assert
        Assert.Equal(1, result.Length);
        Assert.Equal("0", result);
    }

    [Fact]
    public void QuadKey_WhenCalledWithHighLevelOfDetail_ReturnsCorrectLength()
    {
        // Arrange
        int x = 8192;
        int y = 8192;
        int levelOfDetail = 15;

        // Act
        string result = Tile.QuadKey(x, y, levelOfDetail);

        // Assert
        Assert.Equal(15, result.Length);
    }

    [Fact]
    public void QuadKey_WhenCalledWithDifferentXY_GeneratesDifferentQuadKeys()
    {
        // Arrange
        int levelOfDetail = 4;

        // Act
        string result1 = Tile.QuadKey(5, 10, levelOfDetail);
        string result2 = Tile.QuadKey(10, 5, levelOfDetail);

        // Assert
        Assert.NotEqual(result1, result2);
    }

    [Theory]
    [InlineData(2, 3, 2, "31")]
    [InlineData(5, 2, 3, "021")]
    [InlineData(7, 3, 3, "231")]
    [InlineData(0, 0, 4, "0000")]
    [InlineData(15, 15, 4, "3333")]
    public void QuadKey_WithVariousInputs_ReturnsExpectedResults(int x, int y, int levelOfDetail, string expected)
    {
        // Act
        string result = Tile.QuadKey(x, y, levelOfDetail);

        // Assert
        Assert.Equal(expected, result);
    }
}
