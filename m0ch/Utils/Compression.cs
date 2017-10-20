using System;
using System.IO.Compression;
namespace m0ch.Utils
{
    public abstract class Compression
    {
        protected string initialData;
        protected byte[] finalData;

        double winPercentage;

        public double getWinPercentage(){
            if (finalData == null)
                return -1;
            else
                return finalData.Length / initialData.Length;
        }

        public abstract byte[] CompressData();
        public abstract string DecompressData(byte[] toDecode);

    }


    public class GZIP: Compression {


        public GZIP(string data)
        {
            initialData = data;
        }

        public override byte[] CompressData(){

            return new byte[2];
        }

        public override string DecompressData(byte[] toDecode){

            return "";
        }
    }

    public class Deflate: Compression {

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
