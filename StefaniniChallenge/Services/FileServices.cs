using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniChallenge.Services
{
    public static class FileServices
    {
        public static string[] ReadLines(string path)
        {
            return System.IO.File.ReadAllLines(path);
        }

        public static void CreateJSON(string json)
        {

        }
    }
}
