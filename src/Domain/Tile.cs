namespace Wangkanai.Tiler.Domain;

public static class Tile
{
	/// <summary>
	/// Converts tile XYZ coordinates into a QuadKey at a specified level of detail.
	/// </summary>
	/// <param name="x">Tile X coordinate</param>
	/// <param name="y">Tile Y coordinate</param>
	/// <param name="zoom">Level of detail, from 1 (lowest detail) to 23 (highest detail)</param>
	/// <returns>A string containing the QuadKey</returns>
	public static string QuadKey(int x, int y, int zoom)
	{
		var quadKey = new char[zoom];

		for (int i = zoom - 1; i >= 0; i--)
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

			quadKey[zoom - 1 - i] = digit;
		}

		return new string(quadKey);
	}
}
