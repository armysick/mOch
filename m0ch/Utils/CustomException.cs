using System;
namespace m0ch.Utils
{
    public class DirectoryFacilitatorException : Exception
    {
        public DirectoryFacilitatorException(string text) : base(text)
        { 
        }
    }

    public class MiscException : Exception
    {
        public MiscException(string text) :base(text)
        {            
        }
    }
}
