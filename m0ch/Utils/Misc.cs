using System;
namespace m0ch.Utils
{
    public class Misc
    {

        /// <summary>
        /// Possible types of operating system
        /// </summary>
        public enum OperatingSystem { Unix, Windows, Default };

        /// <summary>
        /// Detectes the operating system that is running on the current machine
        /// </summary>
        /// <returns>The running operating system.</returns>
        private static OperatingSystem GetRunningOperatingSystem()
        {
            OperatingSystem version = OperatingSystem.Default;

            int p = (int)System.Environment.OSVersion.Platform;

            if (p == 4 || p == 6 || p == 128)
                version = OperatingSystem.Unix;
            else
                version = OperatingSystem.Windows;

            return version;
        }

        /// <summary>
        /// Makes use of the operating system version to retrieve config file location
        /// </summary>
        /// <returns>The config files URL.</returns>
        public static string GetConfigFilesUrl()
        {

            if (Misc.GetRunningOperatingSystem() == Misc.OperatingSystem.Unix)
                return @"/Users/" + Environment.UserName + "/.m0ch/config/";
            else
                return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                                  + "/m0ch/config/".Replace('/', System.IO.Path.DirectorySeparatorChar);

        }
    }
}
