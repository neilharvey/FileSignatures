using FileSignatures;
using System;
using System.IO;
using System.Linq;

namespace InspectFormat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine();

            if(args.Length != 1 || args[0] == "--help")
            {
                Console.WriteLine("Usage: dotnet run <filePath>");
                return;
            }

            var fileInfo = new FileInfo(args[0]);
            if(!fileInfo.Exists)
            {
                Console.WriteLine(args[0] + " does not exist.");
                return;
            }

            var inspector = new FileFormatInspector();
            using(var stream = fileInfo.OpenRead())
            {
                var format = inspector.DetermineFileFormat(stream);

                if(format == null)
                {
                    Console.WriteLine("File format was not recognised.");
                }
                else
                {
                    Console.WriteLine("Media Type : " + format.MediaType);
                    Console.WriteLine("Signature  : " + BitConverter.ToString(format.Signature.ToArray()));
                    Console.WriteLine("Extension  : " + format.Extension);
                }
            }
        }
    }
}
