using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTask
{
    public static class CalculatorVolume
    {
        static decimal _volume;
        static ConsoleColor _defCol = Console.ForegroundColor;
        public static decimal Run(string path)
        {
            if (!Directory.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{path}] Не верно указан путь!");
                Console.ForegroundColor = _defCol;
            }
            else
            {
                _volume = 0;
                CountingVolume(path);
            }
            return _volume;
        }

        static void CountingVolume(string path)
        {
            var dir = new DirectoryInfo(path);
            var files = dir.GetFiles();
            var directories = dir.GetDirectories();
            try
            {
                if (files.Length > 0)
                {
                    foreach (var file in files)
                    {
                        _volume += file.Length;
                    }
                }
                if (directories.Length > 0)
                {
                    foreach (var directory in directories)
                    {
                        var nextPath = directory.FullName;
                        CountingVolume(nextPath);
                    }
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e);
                Console.ForegroundColor = _defCol;
            }
        }
    }
}
