using System;
using System.Text;
using System.IO;
using System.IO.Compression;
namespace m0ch.Utils
{
    public abstract class Compression
    {
        protected string initialData;
        protected byte[] finalData;

        double winPercentage;

        public double getWinPercentage()
        {
            if (finalData == null)
                return -1;
            else
                return finalData.Length / initialData.Length;
        }

        public abstract byte[] CompressData();
        public abstract string DecompressData(byte[] toDecode);

        public override string ToString()
        {
            return System.Text.Encoding.UTF8.GetString(finalData);
        }
    }


    public class GZIP : Compression
    {


        public GZIP(string data)
        {
            initialData = data;
        }

        public override byte[] CompressData()
        {
            byte[] dataAsBytes = new ASCIIEncoding().GetBytes(initialData);
            MemoryStream dataToCompress = new MemoryStream();

            GZipStream gstream = new GZipStream(dataToCompress,
                                                CompressionMode.Compress, true);
            
            gstream.Write(dataAsBytes, 0, dataAsBytes.Length);
            gstream.Flush();

            finalData = dataToCompress.ToArray();

            return finalData;
        }

        public override string DecompressData(byte[] toDecode)
        {

            return "";
        }
    }

    public class Deflate : Compression
    {

        public Deflate(string data)
        {
            initialData = data;
        }

        public override byte[] CompressData()
        {

            return new byte[2];
        }

        public override string DecompressData(byte[] toDecode)
        {

            return "";
        }
    }
}
