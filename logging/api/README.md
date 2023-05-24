# .NET Cloud Logging Samples

A collection of samples that demonstrate how to invoke [Google Cloud Logging](https://cloud.google.com/logging/docs/) from C#.

The samples require [.NET 6](
     https://dotnet.microsoft.com/en-us/download/dotnet/6.0) or later.  That means using
[Visual Studio 2022](
    https://www.visualstudio.com/), or the command line.

## Build and Run

1.  **Follow the set-up instructions in [the documentation](https://cloud.google.com/dotnet/docs/setup).**

2.  Edit [`Program.cs`](LoggingSample/Program.cs), and replace YOUR-PROJECT-ID with id
    of the project you created in step 1.

5.  From a Powershell command line, run the Logging sample to see a list of
    subcommands:

    ```ps1
    PS C:\...\dotnet-docs-samples\logging\api\LoggingSample> dotnet run
    Usage:
      dotnet run create-log-entry log-id new-log-entry-text
      dotnet run list-log-entries log-id
      dotnet run create-sink sink-id log-id
      dotnet run list-sinks
      dotnet run update-sink sink-id log-id
      dotnet run delete-log log-id
      dotnet run delete-sink sink-id
    ```

## Contributing changes

* See [CONTRIBUTING.md](../../CONTRIBUTING.md)

## Licensing

* See [LICENSE](../../LICENSE)
