#region

using System.IO;
using System.Reflection;

#endregion

namespace App.Utility
{
    public static class AppRuntimeVariables
    {
        /***
         * 實際 dll 位置 (於開發時期，則為啟動專案之 src path)
         */
        public static string AppRootPath => Directory.GetCurrentDirectory();


        /***
         * 實際 dll 位置
         */
        // public static string AssemblyRootPath => Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
        public static string AssemblyRootPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly()?.Location);
    }
}
