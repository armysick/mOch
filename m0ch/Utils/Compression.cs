using System;
using System.Text;
using System.IO;
using System.IO.Compression;
namespace m0ch.Utils
{
    /// <summary>
    /// Abstract class that defines data and functions needed to be implemented by child classes.
    /// </summary>
    public abstract class Compression
    {
        // InitialData represents the data to be compressed
        protected string initialData;
        // FinalData represents the data after be compressed
        protected byte[] finalData;
        // GainPercentage represents the gain in percentage of doing the compression. It is calculated by dividing initialData's length by finaldata's length
        double gainPercentage;

        /// <summary>
        /// Retuns the gain percentage of doing this algorithm after actual doing the compression
        /// </summary>
        /// <returns>-1 in case of finalData is not yet defined or gain percentage otherwise</returns>
        public double getGainPercentage()
        {
            if (finalData == null)
                return -1;
            else
                return finalData.Length / initialData.Length;
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
            return "Data: " + Convert.ToBase64String(this.finalData);
        }


        public string getStatistics()
        {
            return "Converted \"" + this.initialData + "\" to \"" + Convert.ToBase64String(this.finalData) + "\" with a gain of " + getGainPercentage() + "%.";
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
            initialData = data;
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

            writingStream.Write(initialData);

            writingStream.Close();
            compressionStream.Close();

            finalData = memOut.ToArray();

            return finalData;
        }

        /// <summary>
        /// Function responsible for decompress data passed by argument
        /// </summary>
        /// <param name="toDecode">A sequence of bytes</param>
        /// <returns>Data umcompressed</returns>
        public override string DecompressData(byte[] toDecode)
        {

            MemoryStream compressedData = new MemoryStream(toDecode);
            GZipStream defStream = new GZipStream(compressedData, CompressionMode.Decompress);
            StreamReader readingStream = new StreamReader(defStream, System.Text.Encoding.UTF8);

            initialData = readingStream.ReadToEnd();

            readingStream.Dispose();
            defStream.Dispose();
            compressedData.Dispose();

            return initialData;
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
            initialData = data;
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

            writingStream.Write(initialData);

            writingStream.Close();
            compressionStream.Close();

            finalData = memOut.ToArray();

            return finalData;

        }

        /// <summary>
        /// Function responsible for decompress data passed by argument
        /// </summary>
        /// <param name="toDecode"></param>
        /// <returns>Data umcompressed</returns>
        public override string DecompressData(byte[] toDecode)
        {
            MemoryStream compressedData = new MemoryStream(toDecode);
            DeflateStream defStream = new DeflateStream(compressedData, CompressionMode.Decompress);
            StreamReader readingStream = new StreamReader(defStream, System.Text.Encoding.UTF8);

            initialData = readingStream.ReadToEnd();

            readingStream.Dispose();
            defStream.Dispose();
            compressedData.Dispose();

            return initialData;
        }
    }
}
