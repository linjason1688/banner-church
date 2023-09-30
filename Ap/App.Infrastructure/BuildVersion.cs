using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace App.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public static class BuildVersion
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime StartupAt = DateTime.Now;

        /// <summary>
        /// git commit hash to indicate current running version
        /// </summary>
        public static string Version { get; } = "$.hash";

#if DEBUG
        /// <summary>
        /// 開發時自動代入，uat/prod 時由 build 時候 update commit
        /// </summary>
        static BuildVersion()
        {
            if (!Version.Contains("$"))
            {
                return;
            }

            var regex = new Regex("[^a-z0-9]", RegexOptions.IgnoreCase);

            try
            {
                var cmd = new ProcessStartInfo("git", "rev-parse --short HEAD");

                cmd.RedirectStandardOutput = true;
                cmd.UseShellExecute = false;
                cmd.CreateNoWindow = true;

                var process = new Process();
                process.StartInfo = cmd;
                process.Start();

                var commit = process.StandardOutput.ReadToEnd().ToLower();

                if (string.IsNullOrEmpty(commit))
                {
                    return;
                }

                Version = regex.Replace(commit, "");
            }
            catch (Exception)
            {
                // we dont care the error
            }
        }
#endif
    }
}
