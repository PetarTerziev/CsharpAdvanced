using System;
using System.IO.Compression;

namespace ZipAndExtract
{
    class ZipAndExtract
    {
        static void Main(string[] args)
        {
            // Please create ../../../ZipFileDirectory with copyMe.png file in it.

            string startPath = @"../../../ZipFileDirectory";
            string zipPath = @"../../../../newZipFile.zip";
            string extractPath = @"../../../UnZipFileDirectory";

            ZipFile.CreateFromDirectory(startPath, zipPath);
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
