﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    public static class CleanerFolder
    {
        static ConsoleColor _defCol = Console.ForegroundColor;
        public static void Run(string path)
        {
            if (!Directory.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{path}] Не верно указан путь!");
                Console.ForegroundColor = _defCol;
            }
            else
            {
                Clean(path);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Папка очищена!");
                Console.ForegroundColor = _defCol;
            }
        }

        static void Clean(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            var files = dir.GetFiles();
            var directories = dir.GetDirectories();
            if (files.Length > 0)
                CleanFiles(files);
            if (directories.Length > 0)
            {
                foreach (var directory in directories)
                {
                    DirectoryClean(directory);
                }
            }
        }

        static void DirectoryClean(DirectoryInfo directory)
        {
            try
            {
                var timeAcces = directory.LastAccessTime;
                var timeNow = DateTime.Now;
                var min = timeNow - timeAcces;
                if (min.TotalMinutes > 30)
                    directory.Delete(true);
                else
                {
                    var nextPath = directory.FullName;
                    Clean(nextPath);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                Console.ForegroundColor = _defCol;
            }
        }

        static void CleanFiles(FileInfo[] files)
        {
            try
            {
                foreach (var item in files)
                {
                    var nowTime = DateTime.Now;
                    var fileAcess = item.LastAccessTime;
                    var minutes = nowTime - fileAcess;
                    if (minutes.TotalMinutes > 30)
                    {
                        item.Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ex");
                Console.ForegroundColor = _defCol;
            }

        }


    }
}
