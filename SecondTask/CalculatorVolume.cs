using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTask
{
    public static class CalculatorVolume
    {
        public static void Run(string path)
        {
            if (!Directory.Exists(path))
                Console.WriteLine($"[{path}] Не верно указан путь!");
            else
            {
                CountingVolume(path);
                Console.WriteLine("Папка очищена!");
            }
        }

        static void CountingVolume(string path)
        {
            var dir = new DirectoryInfo(path);

        }
    }
}
