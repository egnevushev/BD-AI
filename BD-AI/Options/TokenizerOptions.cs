using CommandLine;

namespace BDAI.Options;

[Verb("tokens", HelpText = "Count tokens.")]
public class TokenizerOptions
{
    [Option('f', "file", Required = true, HelpText = "Input file to be processed.")]
    public string File { get; init; } = default!;
    
    [Option('m', "model", Required = false, HelpText = "Model to use. Default is 'gpt-4o'.")]
    public string? Model { get; init; }
}