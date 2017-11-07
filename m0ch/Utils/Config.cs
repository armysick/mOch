﻿using System;
using System.Net;
using IniParser;
using IniParser.Model;
using System.IO;


namespace m0ch.Utils
{
    /// <summary>
    /// Class responsible for parsing and storing all the information present on the config file
    /// </summary>
    public class Config
    {

        /// <summary>
        /// Location of the config file in the disk
        /// </summary>
        private string configFileURL;

        /// <summary>
        /// Stores the IP address of the Agent Platform
        /// </summary>
        private IPAddress platformIP;

        /// <summary>
        /// Stores the compression algorithms understood by the platform
        /// </summary>
        private Misc.COMPRESSION_AlG[] supportedAlgorithms;


        /// <summary>
        /// Stores the prefered algorithm of the platform
        /// </summary>
        private Misc.COMPRESSION_AlG preferedAlgorithm;


        /// <summary>
        /// Initializes a new instance of the <see cref="T:m0ch.Utils.Config"/> class.
        /// </summary>
        /// <param name="fileLocation">Location of the config file.</param>
        public Config(string fileLocation)
        {
            configFileURL = fileLocation;
        }



        public bool initParse()
        {

            var parser = new FileIniDataParser();

            if (File.Exists(this.configFileURL))
            {
                try {
                    IniData configuration = parser.ReadFile(configFileURL);


                    Console.WriteLine(configuration);
                } catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return true;
        }
    }
}
