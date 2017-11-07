using System;
using m0ch.Network;
using m0ch.Utils;

namespace m0ch
{
    class MainClass
    {
        public static void Main(string[] args)
        {


            Networking net = new Networking();


            Console.ReadLine();
        }


        /// <summary>
        /// Makes use of the operating system version to retrieve config file location
        /// </summary>
        /// <returns>The config file URL.</returns>
        public string getConfigFileURL()
        {

            if (Misc.GetRunningOperatingSystem() == Misc.OS.UNIX)
                return "~/.m0ch/config.ini";
            else
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                                  + "/.m0ch/config.ini";

        }
    }
}
