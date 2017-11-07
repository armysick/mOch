using System;
using m0ch.Network;
using m0ch.Utils;

namespace m0ch
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Read, parse, store the config file
            string configFileURL = Misc.GetConfigFileURL();
            Config configFile = new Config(configFileURL);
            configFile.InitParse();

            Console.ReadLine();
        }

    }
}
