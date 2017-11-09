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
        /// <returns>The config file URL.</returns>
        public static string GetConfigFileUrl()
        {

            if (Misc.GetRunningOperatingSystem() == Misc.OperatingSystem.Unix)
                return @"/Users/" + Environment.UserName + "/.m0ch/config.ini";
            else
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                                  + "/.m0ch/config.ini";

        }
    }
}
