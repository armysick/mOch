using System;
using m0ch.Network;
using m0ch.Utils;

namespace m0ch
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            //Networking ntwk = new Networking();

            GZIP t = new GZIP("Ola");
            t.CompressData();

            Console.WriteLine(t);

            Console.ReadLine();
        }
    }
}
