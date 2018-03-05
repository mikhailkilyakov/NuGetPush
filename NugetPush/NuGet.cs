namespace NuGetPush
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;

    public static class NuGet
    {
        public const string NuGetPath = "External\\nuget.exe";

        public static void TryPush(string url, string key, string path)
        {
            string basePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) ?? "";
            string nuGetPath = Path.Combine(basePath, NuGetPath);

            List<string> arguments = new List<string>();

            arguments.Add("push");
            arguments.Add(path);

            if (!string.IsNullOrWhiteSpace(url))
                arguments.Add($"-Source {url}");

            if (!string.IsNullOrWhiteSpace(key))
                arguments.Add($"-ApiKey {key}");

            arguments.Add("-ForceEnglishOutput");

            using (var process = new Process
            {
                StartInfo = new ProcessStartInfo(nuGetPath)
                {
                    Arguments = string.Join(" ", arguments),
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                }
            })
            {
                process.Start();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    var output = process.StandardOutput.ReadToEnd();
                    var error = process.StandardError.ReadToEnd();
                    var filename = $"NugetPush-{DateTime.Now:yyyyMMddHHmmss}-log.txt";
                    bool logCreated;

                    try
                    {
                        File.WriteAllText(filename, output);
                        File.AppendAllText(filename, error);
                        logCreated = true;
                    }
                    catch
                    {
                        logCreated = false;
                    }

                    string logMessage = logCreated ? $"{Environment.NewLine}Check output in {filename}" : "";
                    
                    throw new InvalidOperationException($"nuget.exe exited with status code {process.ExitCode}.{logMessage}");
                }
            }
        }
    }
}