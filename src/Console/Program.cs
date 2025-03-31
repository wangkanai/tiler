using System.CommandLine;

class Program
{
	static async Task<int> Main(string[] args)
	{
		var rootCommand = new RootCommand("Wangkanai Map Tiler CLI");
		rootCommand.Name = "tiler";

		return await rootCommand.InvokeAsync(args);
	}
}
