#region

using System.IO;

#endregion

namespace App.Utility
{
    public static class ResourceProvider
    {
        public static string ReadFile(string path)
        {
            // for full path
            if (Path.IsPathFullyQualified(path))
            {
                return File.ReadAllText(path);
            }

            var appLocation = AppRuntimeVariables.AssemblyRootPath;

            return File.ReadAllText(
                Path.Combine(
                    appLocation,
                    "Resources",
                    path
                )
            );
        }
    }
}
