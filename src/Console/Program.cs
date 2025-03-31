using System.CommandLine;

class Program
{
	static async Task<int> Main(string[] args)
	{
		var rootCommand = new RootCommand("Wangkanai Map Tiler CLI");

		return await rootCommand.InvokeAsync(args);
	}
}
