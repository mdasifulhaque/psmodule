using System;

namespace RoboCMDL.Exceptions
{
    [Serializable]
    public class InvalidPathException : Exception
    {
        public string FilePath { get; }
        public InvalidPathException() { }


        public InvalidPathException(string message, Exception innerException) : base(message, innerException) { }

        public InvalidPathException(string message, string filePath) : this(message) => FilePath = filePath;

        public InvalidPathException(string filePath) : base($"Invalid Path {filePath} ") { }


    }
}
