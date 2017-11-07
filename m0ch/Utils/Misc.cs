using System;
namespace m0ch.Utils
{
    public class Misc
    {

        /// <summary>
        /// Possible types of operating system
        /// </summary>
        public enum OS { UNIX, WINDOWS, DEFAULT };

        /// <summary>
        /// Compression algorithms currently implemented
        /// </summary>
        public enum COMPRESSION_AlG { GZIP, DEFLATE, L4Z };


        /// <summary>
        /// Detectes the operating system that is running on the current machine
        /// </summary>
        /// <returns>The running operating system.</returns>
        public static OS GetRunningOperatingSystem()
        {
            OS version = OS.DEFAULT;

            int p = (int)System.Environment.OSVersion.Platform;

            if (p == 4 || p == 6 || p == 128)
                version = OS.UNIX;
            else
                version = OS.WINDOWS;

            return version;
        }

        /// <summary>
        /// Makes use of the operating system version to retrieve config file location
        /// </summary>
        /// <returns>The config file URL.</returns>
        public static string GetConfigFileURL()
        {

            if (Misc.GetRunningOperatingSystem() == Misc.OS.UNIX)
                return @"/Users/" + Environment.UserName + "/.m0ch/config.ini";
            else
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                                  + "/.m0ch/config.ini";

        }
    }
}
