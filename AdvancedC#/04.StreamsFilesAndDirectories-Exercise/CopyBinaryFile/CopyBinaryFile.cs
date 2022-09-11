namespace CopyBinaryFile
{
    using System;
    using System.Linq;
    using System.IO;
    public class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\copyMe.png";
            string outputPath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputPath, outputPath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using FileStream streamReader = new FileStream(inputFilePath, FileMode.Open);
            using FileStream streamWriter = new FileStream(outputFilePath, FileMode.Create);


            byte[] buffer = new byte[256];

            while (true)
            {
                int currentBytes = streamReader.Read(buffer, 0, buffer.Length);

                if (currentBytes == 0)
                {
                    break;
                }

                streamWriter.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
