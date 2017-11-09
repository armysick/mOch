using System;
using System.IO;
using System.IO.Compression;
using LZ4;
using System.Text;

namespace m0ch.Utils
{
    /// <summary>
    /// Abstract class that defines data and functions needed to be implemented by child classes.
    /// </summary>
    public abstract class Compression
    {

        /// <summary>
        /// InitialData represents the data to be compressed
        /// </summary>
        protected string InitialData;
        
        /// <summary>
        /// FinalData represents the data after be compressed
        /// </summary>
        protected byte[] FinalData;
        
        /// <summary>
        /// GainPercentage represents the gain in percentage of doing the compression.
        /// It is calculated by dividing initialData's length by finaldata's length
        /// </summary>
        private double _gainPercentage;

        /// <summary>
        /// Retuns the gain percentage of doing this algorithm after actual doing the compression
        /// </summary>
        /// <returns>-1 in case of finalData is not yet defined or gain percentage otherwise</returns>
        public double GetGainPercentage()
        {
            if (FinalData == null)
                return -1;
            else {
                _gainPercentage = 100 * FinalData.Length / InitialData.Length ;
            }

            return _gainPercentage;
        }

        /// <summary>
        /// Function that is implemented by child classes in order to compress the member "initial data"
        /// </summary>
        /// <returns>A sequence of bytes </returns>
        public abstract byte[] CompressData();
        
        /// <summary>
        /// Function responsible for converting a sequence of bytes that represents a compressed data into uncomprompressed data
        /// </summary>
        /// <param name="toDecode"></param>
        /// <returns></returns>
        public abstract string DecompressData(byte[] toDecode);
        
        /// <summary>
        /// Override function to print compressed data into a readable string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Data: " + Convert.ToBase64String(this.FinalData);
        }


        public string GetStatistics()
        {
            return "Converted \"" + this.InitialData + "\" to \"" + Convert.ToBase64String(this.FinalData) + "\" with a gain of " + GetGainPercentage() + "%.";
        }

    }

    /// <summary>
    /// Class responsible for compression and decompressing text using GZIP
    /// </summary>
    public class GZIP : Compression
    {
        /// <summary>
        /// Constructor that initializes only the data to compress
        /// </summary>
        /// <param name="data">String representing the data to compress</param>
        public GZIP(string data)
        {
            InitialData = data;
        }

        /// <summary>
        /// Function that converts the data passed in the constructor's argument
        /// </summary>
        /// <returns>A sequence of bytes representing the compressed data</returns>
        public override byte[] CompressData()
        {
            MemoryStream memOut = new MemoryStream();
            GZipStream compressionStream = new GZipStream(memOut, CompressionMode.Compress);
            StreamWriter writingStream = new StreamWriter(compressionStream, System.Text.Encoding.UTF8);

            writingStream.Write(InitialData);

            writingStream.Close();
            compressionStream.Close();

            FinalData = memOut.ToArray();

            return FinalData;
        }

        /// <summary>
        /// Function responsible for decompress data passed as argument
        /// </summary>
        /// <param name="toDecode">A sequence of bytes</param>
        /// <returns>Data umcompressed</returns>
        public override string DecompressData(byte[] toDecode)
        {

            MemoryStream compressedData = new MemoryStream(toDecode);
            GZipStream defStream = new GZipStream(compressedData, CompressionMode.Decompress);
            StreamReader readingStream = new StreamReader(defStream, System.Text.Encoding.UTF8);

            InitialData = readingStream.ReadToEnd();

            readingStream.Dispose();
            defStream.Dispose();
            compressedData.Dispose();

            return InitialData;
        }
    }

    /// <summary>
    /// Class responsible for compression and decompressing text using Deflate
    /// </summary>
    public class Deflate : Compression
    {
        /// <summary>
        /// Constructor that initializes only the data to compress
        /// </summary>
        /// <param name="data">String representing the data to compress</param>
        public Deflate(string data)
        {
            InitialData = data;
        }

        /// <summary>
        /// Function that converts the data passed in the constructor's argument
        /// </summary>
        /// <returns>A sequence of bytes representing the compressed data</returns>
        public override byte[] CompressData()
        {

            MemoryStream memOut = new MemoryStream();
            DeflateStream compressionStream = new DeflateStream(memOut, CompressionMode.Compress);
            StreamWriter writingStream = new StreamWriter(compressionStream, System.Text.Encoding.UTF8);

            writingStream.Write(InitialData);

            writingStream.Close();
            compressionStream.Close();

            FinalData = memOut.ToArray();

            return FinalData;

        }

        /// <summary>
        /// Function responsible for decompress data passed as argument
        /// </summary>
        /// <param name="toDecode"></param>
        /// <returns>Data umcompressed</returns>
        public override string DecompressData(byte[] toDecode)
        {
            MemoryStream compressedData = new MemoryStream(toDecode);
            DeflateStream defStream = new DeflateStream(compressedData, 
                                                        CompressionMode.Decompress);
            StreamReader readingStream = new StreamReader(defStream, 
                                                          Encoding.UTF8);

            InitialData = readingStream.ReadToEnd();

            readingStream.Dispose();
            defStream.Dispose();
            compressedData.Dispose();

            return InitialData;
        }
    }

    /// <summary>
    /// Class responsible for compression and decompressing text using Lz4
    /// </summary>
    public class Lz4 : Compression 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:m0ch.Utils.Lz4"/> class.
        /// </summary>
        /// <param name="data">Text to be compressed</param>
        public Lz4(string data)
        {
            this.InitialData = data;
        }

        /// <summary>
        /// Function that converts the data passed in the constructor's argument
        /// </summary>
        /// <returns>A sequence of bytes representing the compressed data</returns>
        public override byte[] CompressData()
        {

            MemoryStream memOut = new MemoryStream();
            LZ4Stream lz4Strm = new LZ4Stream(memOut, LZ4StreamMode.Compress);
            StreamWriter inputData = new StreamWriter(lz4Strm, Encoding.UTF8);

            inputData.Write(InitialData);

            inputData.Dispose();
            lz4Strm.Dispose();

            FinalData = memOut.ToArray();
            memOut.Dispose();
            return FinalData;

        }

        /// <summary>
        /// Function responsible for decompress data passed as argument
        /// </summary>
        /// <returns>The data compressed</returns>
        /// <param name="toDecode">Data decompressed</param>
        public override string DecompressData(byte[] toDecode)
        {

            MemoryStream memIn = new MemoryStream(toDecode);
            LZ4Stream lz4Strm = new LZ4Stream(memIn, LZ4StreamMode.Decompress);
            StreamReader outData = new StreamReader(lz4Strm);

            InitialData = outData.ReadToEnd();

            outData.Dispose();
            lz4Strm.Dispose();
            memIn.Dispose();

            return InitialData;
        }


    }
}
