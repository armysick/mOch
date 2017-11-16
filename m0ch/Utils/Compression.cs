
using System.IO;
using System.IO.Compression;
using System.Text;
using LZ4;

namespace m0ch.Utils
{


    public class Compression
    {

        /// <summary>
        /// Function responsible for compressing a string passed as argument into an array of bytes.
        /// </summary>
        /// <param name="data">Data that needs to be compressed.</param>
        /// <param name="compressionAlgorithm">The desired algorithm to compress the data.</param>
        /// <returns>An array of bytes resulting from the compression.</returns>
        public static byte[] DataCompression(string data, Misc.CompressionAlgorithm compressionAlgorithm)
        {
            switch (compressionAlgorithm)
            {
                case Misc.CompressionAlgorithm.L4Z:
                    return L4ZCompression(data);
                case Misc.CompressionAlgorithm.Deflate:
                    return DeflateCompression(data);
                case Misc.CompressionAlgorithm.Gzip:
                default:
                    return GzipCompression(data);
            }
        }


        /// <summary>
        /// Function responsible for compressing a string passed as argument into an array of bytes using L4Z algorithm.
        /// </summary>
        /// <param name="data">The string to be compressed.</param>
        /// <returns>An array resulting from the compression.</returns>
        private static byte[] L4ZCompression(string data)
        {
            MemoryStream memOut = new MemoryStream();
            LZ4Stream lz4Strm = new LZ4Stream(memOut, LZ4StreamMode.Compress);
            StreamWriter inputData = new StreamWriter(lz4Strm, Encoding.UTF8);

            inputData.Write(data);

            inputData.Dispose();
            lz4Strm.Dispose();

            byte[] compressedData = memOut.ToArray();
            memOut.Dispose();

            return compressedData;
        }

        /// <summary>
        /// Function responsible for compressing a string passed as argument into an array of bytes using Deflate algorithm.
        /// </summary>
        /// <param name="data">The string to be compressed.</param>
        /// <returns>An array resulting from the compression.</returns>
        private static byte[] DeflateCompression(string data)
        {
            MemoryStream memOut = new MemoryStream();
            DeflateStream compressionStream = new DeflateStream(memOut, CompressionMode.Compress);
            StreamWriter writingStream = new StreamWriter(compressionStream, System.Text.Encoding.UTF8);

            writingStream.Write(data);

            writingStream.Close();
            compressionStream.Close();

            byte[] compressedData = memOut.ToArray();

            return compressedData;
        }

        /// <summary>
        /// Function responsible for compressing a string passed as argument into an array of bytes using Gzip algorithm.
        /// </summary>
        /// <param name="data">The string to be compressed.</param>
        /// <returns>An array resulting from the compression.</returns>
        private static byte[] GzipCompression(string data)
        {
            MemoryStream memOut = new MemoryStream();
            GZipStream compressionStream = new GZipStream(memOut, CompressionMode.Compress);
            StreamWriter writingStream = new StreamWriter(compressionStream, System.Text.Encoding.UTF8);

            writingStream.Write(data);

            writingStream.Close();
            compressionStream.Close();

            byte[] compressedData = memOut.ToArray();

            return compressedData;
        }


        /// <summary>
        /// Function responsible for decompressing an array of bytes passed as argument into a string.
        /// </summary>
        /// <param name="data">Data that needs to be decompressed.</param>
        /// <param name="decompressionAlgorithm">The desired algorithm to decompress the data.</param>
        /// <returns>A string resulting from the decompressing.</returns>
        public static string DecompressData(byte[] data, Misc.CompressionAlgorithm decompressionAlgorithm)
        {
            switch (decompressionAlgorithm)
            {
                case Misc.CompressionAlgorithm.L4Z:
                    return L4ZDecompression(data);
                case Misc.CompressionAlgorithm.Deflate:
                    return DeflateDecompression(data);
                case Misc.CompressionAlgorithm.Gzip:
                default:
                    return GzipDecompression(data);
            }
        }

        /// <summary>
        /// Function responsible for decompressing an array of bytes passed as argument into a string using L4Z algorithm.
        /// </summary>
        /// <param name="data">The byte array to be decompressed.</param>
        /// <returns>A string resulting from the compression.</returns>
        private static string L4ZDecompression(byte[] data)
        {
            MemoryStream memIn = new MemoryStream(data);
            LZ4Stream lz4Strm = new LZ4Stream(memIn, LZ4StreamMode.Decompress);
            StreamReader outData = new StreamReader(lz4Strm);

            string decompressedData = outData.ReadToEnd();

            outData.Dispose();
            lz4Strm.Dispose();
            memIn.Dispose();

            return decompressedData;
        }

        /// <summary>
        /// Function responsible for decompressing an array of bytes passed as argument into a string using L4Z algorithm.
        /// </summary>
        /// <param name="data">The byte array to be decompressed.</param>
        /// <returns>A string resulting from the compression.</returns>
        private static string DeflateDecompression(byte[] data)
        {
            MemoryStream compressedData = new MemoryStream(data);
            DeflateStream defStream = new DeflateStream(compressedData, CompressionMode.Decompress);
            StreamReader readingStream = new StreamReader(defStream, Encoding.UTF8);

            string decompressedData = readingStream.ReadToEnd();

            readingStream.Dispose();
            defStream.Dispose();
            compressedData.Dispose();

            return decompressedData;
        }

        /// <summary>
        /// Function responsible for decompressing an array of bytes passed as argument into a string using L4Z algorithm.
        /// </summary>
        /// <param name="data">The byte array to be decompressed.</param>
        /// <returns>A string resulting from the compression.</returns>
        private static string GzipDecompression(byte[] data)
        {
            MemoryStream compressedData = new MemoryStream(data);
            GZipStream defStream = new GZipStream(compressedData, CompressionMode.Decompress);
            StreamReader readingStream = new StreamReader(defStream, System.Text.Encoding.UTF8);

            string decompressedData = readingStream.ReadToEnd();

            readingStream.Dispose();
            defStream.Dispose();
            compressedData.Dispose();

            return decompressedData;
        }

    }
}
