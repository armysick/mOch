using System;
using System.Net;
using IniParser;
using IniParser.Model;
using System.IO;
using System.Collections.Generic;
using System.Linq;


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
        private readonly string configFileURL;

        /// <summary>
        /// Name to be used as AID's name
        /// </summary>
        private string machineName;

        /// <summary>
        /// Stores the IP address of the Agent Platform
        /// </summary>
        private string platformIP;

        /// <summary>
        /// Stores the port to be used in this agent
        /// </summary>
        private int port;

        /// <summary>
        /// Stores the compression algorithms understood by the platform
        /// </summary>
        private List<string> supportedAlgorithms;


        /// <summary>
        /// Stores the prefered algorithm of the platform
        /// </summary>
        private string preferedAlgorithm;


        /// <summary>
        /// Initializes a new instance of the <see cref="T:m0ch.Utils.Config"/> class.
        /// </summary>
        /// <param name="fileLocation">Location of the config file.</param>
        public Config(string fileLocation)
        {
            configFileURL = fileLocation;
            supportedAlgorithms = new List<string>();
        }


        /// <summary>
        /// Parses the file passed in the constructor of this class and populates the members.
        /// </summary>
        /// <returns><c>true</c>, if parse was successfully finished, <c>false</c> otherwise.</returns>
        public bool InitParse()
        {

            var parser = new FileIniDataParser();

            if (File.Exists(this.configFileURL))
            {
                try {
                    IniData configuration = parser.ReadFile(configFileURL);

                    // Agent Platform related
                    platformIP = configuration["AgentPlatform"]["IP"];
                    port = Int32.Parse(configuration["AgentPlatform"]["Port"]);

                    // Compression Algorithms Available
                    supportedAlgorithms = configuration["CompressionAlgorithms"]["Compression"]
                        .Split(',').ToList();

                    // User preferences related
                    preferedAlgorithm = configuration["Preferences"]["CompressionAlgorithm"];
                    machineName = configuration["Preferences"]["MachineName"];

                } catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return true;
        }
    }
}
