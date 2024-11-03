using BDAI.Options;
using CommandLine;
using LunarLabs.Parser;
using LunarLabs.Parser.XML;
using Tiktoken;

namespace BDAI;

public class Application
{
    public async Task RunAsync(string[] args) => await Parser.Default
        .ParseArguments<TokenizerOptions, ConvertOptions>(args)
        .MapResult<TokenizerOptions, ConvertOptions, Task>(
            async (TokenizerOptions opts) =>
            {
                var model = opts.Model ?? "gpt-4o";
                var encoder = ModelToEncoder.For(model);
                var content = await File.ReadAllTextAsync(opts.File);
                Console.WriteLine(encoder.CountTokens(content));
            },
            async (ConvertOptions opts) =>
            {
                var extension = opts.Extension.ToString().ToLower();
                var output = opts.Output ?? $"{opts.File}.{extension}";
                var content = await File.ReadAllTextAsync(opts.File);
                var root = XMLReader.ReadFromString(content);
                DataFormats.SaveToFile(output, root);
                Console.WriteLine($"{opts.Extension} OK: {output}");
            }, errs =>
            {
                Console.WriteLine("Error parsing arguments: " + string.Join(", ", errs));
                return Task.CompletedTask;
            }
        );
}