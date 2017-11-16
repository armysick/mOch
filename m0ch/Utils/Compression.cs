
using System.IO;
using System.IO.Compression;
using System.Text;
using LZ4;

namespace m0ch.Utils
{


    public class Compression
    {

        /// <summary>
        /// Function responsible for converting a string passed as argument into an array of bytes.
        /// </summary>
        /// <param name="data">Data that needs to be compressed.</param>
        /// <param name="compressionAlgorithm">The desired algorithm to compress the data.</param>
        /// <returns>An array of bytes resulting from the compression.</returns>
        public byte[] DataCompression(string data, Misc.CompressionAlgorithm compressionAlgorithm)
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
    }
    
    
    
    
    
    
    
    
    
    
    /*
    
    
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
            this.CompressionMd = CompressionMode.Compress;
            this.DecompressedData = data;
        }

        public GZIP(byte[] data)
        {

            this.CompressionMd = CompressionMode.Decompress;
            this.CompressedData = data;
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

            writingStream.Write(DecompressedData);

            writingStream.Close();
            compressionStream.Close();

            CompressedData = memOut.ToArray();

            return CompressedData;
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

            DecompressedData = readingStream.ReadToEnd();

            readingStream.Dispose();
            defStream.Dispose();
            compressedData.Dispose();

            return DecompressedData;
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
            DecompressedData = data;
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

            writingStream.Write(DecompressedData);

            writingStream.Close();
            compressionStream.Close();

            CompressedData = memOut.ToArray();

            return CompressedData;

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

            DecompressedData = readingStream.ReadToEnd();

            readingStream.Dispose();
            defStream.Dispose();
            compressedData.Dispose();

            return DecompressedData;
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
            this.DecompressedData = data;
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

            inputData.Write(DecompressedData);

            inputData.Dispose();
            lz4Strm.Dispose();

            CompressedData = memOut.ToArray();
            memOut.Dispose();
            return CompressedData;

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

            DecompressedData = outData.ReadToEnd();

            outData.Dispose();
            lz4Strm.Dispose();
            memIn.Dispose();

            return DecompressedData;
        }


    }
    */
}
