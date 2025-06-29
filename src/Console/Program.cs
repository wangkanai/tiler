﻿// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using System.CommandLine;
using System.Text;

namespace Wangkanai.Tiler;

public static class Program
{
	private static async Task<int> Main(string[] args)
	{
		if (System.Console.IsInputRedirected)
			System.Console.OutputEncoding = Encoding.UTF8;

		var rootCommand = new RootCommand("Wangkanai Map Tiler");

		return await rootCommand.InvokeAsync(args);
	}
}
