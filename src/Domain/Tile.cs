namespace Wangkanai.Tiler.Domain;

public static class Tile
{
	/// <summary>
	/// Converts tile XYZ coordinates into a QuadKey at a specified level of detail.
	/// </summary>
	/// <param name="x">Tile X coordinate</param>
	/// <param name="y">Tile Y coordinate</param>
	/// <param name="levelOfDetail">Level of detail, from 1 (lowest detail) to 23 (highest detail)</param>
	/// <returns>A string containing the QuadKey</returns>
	public static string QuadKey(int x, int y, int levelOfDetail)
	{
		var quadKey = new char[levelOfDetail];

		for (int i = levelOfDetail - 1; i >= 0; i--)
		{
			var digit = '0';
			var mask  = 1 << i;

			if ((x & mask) != 0)
				digit++;

			if ((y & mask) != 0)
			{
				digit++;
				digit++;
			}

			quadKey[levelOfDetail - 1 - i] = digit;
		}

		return new string(quadKey);
	}
}
