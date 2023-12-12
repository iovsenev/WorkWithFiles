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
        public static void Run(string path)
        {
            var defCol = Console.ForegroundColor;
            if (!Directory.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{path}] Не верно указан путь!");
                Console.ForegroundColor = defCol;
            }
            else
            {
                _volume = 0;
                CountingVolume(path);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Текущий объем файлов: {0} байт.", _volume);
                Console.ForegroundColor = defCol;
            }
        }

        static void CountingVolume(string path)
        {
            var dir = new DirectoryInfo(path);
            var files = dir.GetFiles();
            var directories = dir.GetDirectories();
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
    }
}
