﻿using System;
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


    }
}
