using System;
using System.Net;
using IniParser;
using IniParser.Model;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using NLog;


namespace m0ch.Utils
{
    /// <summary>
    /// Class responsible for parsing and storing all the information present on the config file
    /// </summary>
    public abstract class Config
    {
        /// <summary>
        /// Variable responsible for logging.
        /// </summary>
        protected static readonly Logger LoggerObj = LogManager.GetCurrentClassLogger();
        
        /// <summary>
        /// Location of the config file in the disk
        /// </summary>
        protected string ConfigFileUrl;
        
        /// <summary>
        /// Parses the file passed in the constructor of this class and populates the members.
        /// </summary>
        /// <returns><c>true</c>, if parse was successfully finished, <c>false</c> otherwise.</returns>
        public abstract bool InitParse();
        
    }

    /// <summary>
    /// Class responsible for parsing and storing the information about config variables related to the Agent Platform
    /// </summary>
    public class AgentPlatformConfig : Config
    {
        private static readonly string FILENAME = "platoform.ini";

        /// <summary>
        /// Represents the host domain of the platform.
        /// </summary>
        private string _platformName;

        /// <summary>
        /// The support for dynamic registration of the AP.
        /// </summary>
        private bool _dynamic;

        /// <summary>
        /// The support for mobility of the AP.
        /// </summary>
        private bool _mobility;

        /// <summary>
        /// Holds the port where it is supposed to listen for incoming messages
        /// </summary>
        private int _serverPort;

        /// <summary>
        /// Initializes a new AgentPlataformConfig object in order to store all the configs presented in the config file.
        /// </summary>
        /// <param name="configFileUrl">Url where config file is presented.</param>
        public AgentPlatformConfig(string configFileUrl)
        {
            this.ConfigFileUrl = configFileUrl + AgentPlatformConfig.FILENAME;
        }

        public override bool InitParse()
        {
            FileIniDataParser parser = new FileIniDataParser();

            if (File.Exists(this.ConfigFileUrl))
            {
                try
                {
                    LoggerObj.Trace("Parsing data present in " + FILENAME);
                    IniData configuration = parser.ReadFile(ConfigFileUrl);

                    // Agent Platform Description
                    this._platformName = configuration["AgentPlatformDescription"]["PlataformName"];
                    this._dynamic = bool.Parse(configuration["AgentPlatformDescription"]["AllowDynamic"]);
                    this._mobility = bool.Parse(configuration["AgentPlatformDescription"]["AllowMobility"]);

                    // Server
                    this._serverPort = Int32.Parse(configuration["Server"]["Port"]);
                }
                catch (Exception ex)
                {
                    LoggerObj.Error("On parsing data present in " + FILENAME);
                    return false;
                }
            }
            else
            {
                LoggerObj.Fatal("Config file " + FILENAME + " not found.");
            }

            return true;
        }

        /// <summary>
        /// Returns Platform Name.
        /// </summary>
        /// <returns>String read in config files.</returns>
        public string getPlatformName()
        {
            return this._platformName;
        }

        /// <summary>
        /// Returns the port where it is supposed to listen incoming messages.
        /// </summary>
        /// <returns>Integer read in config file.</returns>
        public int getServerPort()
        {
            return this._serverPort;
        }

        /// <summary>
        /// Gets the dynamic variable
        /// </summary>
        /// <returns>Variable read in config file</returns>
        public bool GetDynamic()
        {
            return this._dynamic;
        }

        /// <summary>
        /// Gets the Mobility variable
        /// </summary>
        /// <returns>Variable read in config file</returns>
        public bool GetMobility()
        {
            return this._mobility;
        }
    }

    /// <summary>
    /// Class responsible for parsing and storing the information about config variables related to Agents
    /// </summary>
    public class AgentConfig : Config
    {
        /// <summary>
        /// Variable that holds the filename where the configurations are made.
        /// </summary>
        private static readonly string FILENAME = "agent.ini";

        /// <summary>
        /// Name to be used as AID's name.
        /// </summary>
        private string _machineName;

        /// <summary>
        /// Stores the IP address of the Agent Platform.
        /// </summary>
        private string _platformIp;

        /// <summary>
        /// Stores the port to be used in this agent.
        /// </summary>
        private int _platformPort;

        /// <summary>
        /// Stores the compression algorithms understood by the platform.
        /// </summary>
        private List<string> _supportedAlgorithms;
        
        /// <summary>
        /// Stores the prefered algorithm of the platform.
        /// </summary>
        private string _preferedAlgorithm;

        /// <summary>
        /// Initializes a new AgentPlataformConfig object in order to store all the configs presented in the config file.
        /// </summary>
        /// <param name="configFileUrl">Url where config file is presented.</param>
        public AgentConfig(string configFileUrl)
        {
            this.ConfigFileUrl = configFileUrl + AgentConfig.FILENAME;
        }


        public override bool InitParse()
        {
            FileIniDataParser parser = new FileIniDataParser();

            if (File.Exists(this.ConfigFileUrl))
            {
                try
                {
                    LoggerObj.Trace("Parsing data present in " + FILENAME);
                    IniData configuration = parser.ReadFile(ConfigFileUrl);

                    // Agent Platform related
                    _platformIp = configuration["AgentPlatform"]["IP"];
                    _platformPort = Int32.Parse(configuration["AgentPlatform"]["Port"]);

                    // Compression Algorithms Available
                    _supportedAlgorithms = configuration["CompressionAlgorithms"]["Compression"]
                        .Split(',').ToList();

                    // User preferences related
                    _preferedAlgorithm = configuration["Preferences"]["CompressionAlgorithm"];
                    _machineName = configuration["Preferences"]["MachineName"];

                }
                catch (Exception ex)
                {
                    LoggerObj.Error("On parsing data present in " + FILENAME);
                    return false;
                }
            }
            else
            {
                LoggerObj.Fatal("Config file " + FILENAME + " not found.");
            }

            return true;
        }

        /// <summary>
        /// Gets the config URL.
        /// </summary>
        /// <returns>The config URL passed in the constructor.</returns>
        public string GetConfigUrl()
        {
            return this.ConfigFileUrl;
        }

        /// <summary>
        /// Gets the agent platform IP.
        /// </summary>
        /// <returns>The agent platform IP present in the configuration file.</returns>
        public string GetAgentPlatformIP()
        {
            return this._platformIp;
        }

        /// <summary>
        /// Gets the agent platform port.
        /// </summary>
        /// <returns>The agent platform port present in the configuration file.</returns>
        public int GetAgentPlatformPort()
        {
            return this._platformPort;
        }

        /// <summary>
        /// Gets the name of the machine.
        /// </summary>
        /// <returns>The machine name present in the configuration file.</returns>
        public string GetMachineName()
        {
            return this._machineName;
        }

        /// <summary>
        /// Gets the available compression algorithms.
        /// </summary>
        /// <returns>The available compression algorithms present in the configuration file.</returns>
        public List<String> GetAvailableCompressionAlgorithms()
        {
            return this._supportedAlgorithms;
        }

        /// <summary>
        /// Gets the prefered compression algorithm.
        /// </summary>
        /// <returns>The prefered compression algorithm as it is specified in the configuration file.</returns>
        public String GetPreferedCompressionAlgorithm()
        {
            return this._preferedAlgorithm;
        }
    }
}
