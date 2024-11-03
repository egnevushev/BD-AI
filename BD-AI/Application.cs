using BDAI.Options;
using CommandLine;
using LunarLabs.Parser;
using Tiktoken;

namespace BDAI;

public class Application
{
    public async Task RunAsync(string[] args)
    {
        await Parser.Default.ParseArguments<TokenizerOptions, ConvertOptions>(args)
            .MapResult(
                async (TokenizerOptions opts) =>
                {
                    var model = opts.Model ?? "gpt-4o";
                    var encoder = ModelToEncoder.For(model);
                    var content = await File.ReadAllTextAsync(opts.File);
                    Console.WriteLine(encoder.CountTokens(content));
                    return 0;
                }, 
                (ConvertOptions opts) =>
                {
                    var extension = opts.Extension.ToString().ToLower();
                    var output = opts.Output ?? $"{opts.File}.{extension}";
                    var root = DataFormats.LoadFromFile(opts.File);
                    DataFormats.SaveToFile(output, root);
                    return Task.FromResult(0);
                },
                errs =>
                {
                    Console.WriteLine("Error parsing arguments: " + string.Join(", ", errs));
                    return Task.FromResult(1);
                });
    }
}