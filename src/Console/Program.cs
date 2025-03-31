// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using System.CommandLine;

internal static class Program
{
	private static async Task<int> Main(string[] args)
	{
		var rootCommand = new RootCommand("Wangkanai Map Tiler CLI");
		rootCommand.Name = "tiler";

		return await rootCommand.InvokeAsync(args);
	}
}
