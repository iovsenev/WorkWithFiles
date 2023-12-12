

namespace ThirdTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\ovsen\OneDrive\Рабочий стол\TemporyFolder";
            CleanFolder(path);

        }

        static void CleanFolder(string path)
        {
            ConsoleColor def = Console.ForegroundColor;
            if (!Directory.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[{0}] Не корректный путь!", path);
                Console.ForegroundColor = def;
                return;
            }
            var startVolume = CalculatorVolume.Run(path);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("В папке до очистки {0} байт.", startVolume);
            CleanerFolder.Run(path);
            var lastVolume = CalculatorVolume.Run(path);
            var deletedVolume = startVolume - lastVolume;
            Console.WriteLine("Очищенно {0} байт", deletedVolume);
            Console.WriteLine("В папке после очистки {0} байт", lastVolume);
            Console.ForegroundColor = def;
        }
    }
}
