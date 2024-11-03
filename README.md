## Tools for DB-AI

Tools for AI experiments which can count tokens (the same as [openai Tokenizer](https://platform.openai.com/tokenizer)) and convert files from XML to YAML [WIP].

### Install
0. Install [.Net 8+ SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
1. Go to the root folder in a terminal. Run: `cd <BD-AI root>`
1. Install the tool. Run: `dotnet tool install --global --add-source .\BD-AI\nupkg\ BD-AI`
1. Run the tool in a terminal: `bd-ai --help`

### How to use

#### Count tokens

Run `bd-ai tokens -f <filepath>` to get amount of tokens as a console output. 

You can also specify model (default is `gpt-4o`). See full help running: `bd-ai tokens --help`.

#### Convert files [WIP]

Run `bd-ai convert -f <xml_filepath>` to convert an `XML` file to `YAML`. 

You can also specify an `output path` and `extension`. See full help running: `bd-ai tokens --help`.

### Contribution

How to build new version.

1. Make code changes.
1. Change version in the `BD-AI.csproj` file in the `<version></version>` section, e.g. `<version>2.1.7</version>`
1. `cd <BD-AI root>`
1. `dotnet pack`
1. `dotnet tool update --global --add-source .\BD-AI\nupkg\ BD-AI`

### How to unintsall the tool
1. `dotnet tool uninstall --global BD-AI `
