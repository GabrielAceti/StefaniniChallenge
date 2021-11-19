using System.IO;

namespace StefaniniChallenge.Services
{
    public static class FileServices
    {
        public static string[] ReadLines(string path)
        {
            return System.IO.File.ReadAllLines(path);
        }

        public static void CreateFile(string content, string path, string fileName)
        {
            File.WriteAllText(path + @"\" + fileName, content);
        }
    }
}
