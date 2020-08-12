using System;
using System.IO;
using System.Linq;

namespace ECommerce.CommandRunner
{
    public static class ScenarioFileReader
    {
        private static string CurrentDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
        public static string[] ScenarioFiles = Directory.GetFiles(CurrentDirectory).Where(x => x.EndsWith(".txt") && x.ToLower().Contains("scenario1")).ToArray();
        public static string[] Lines(string path)
        {
            try
            {
                return File.ReadAllLines(path).Select(s => s.Trim()).ToArray();
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }

    }
}