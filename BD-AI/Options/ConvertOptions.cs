using CommandLine;

namespace BDAI.Options;

[Verb("convert", HelpText = "Convert a file to a different format.")]
public class ConvertOptions
{
    [Option('f', "file", Required = true, HelpText = "Input file to be processed.")]
    public string File { get; init; } = default!;

    [Option('e', "extension", Required = false, HelpText = "Output extension. Default is 'yaml'.")]
    public Extension Extension { get; init; } = Extension.Yaml;
    
    [Option('o', "output", Required = false, HelpText = "Output file. Default is the input file with the new extension.")]
    public string? Output { get; init; }
}

public enum Extension
{
    Yaml
}