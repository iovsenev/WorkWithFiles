namespace SecondTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\ovsen\OneDrive\Рабочий стол\TemporyFolder";
            var volume = CalculatorVolume.Run(path);
            var def = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Папка {0} занимает: {1} байт", path, volume);
            Console.ForegroundColor = def;
        }
    }
}
