using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            TextManipulator testRun = new TextManipulator(@"\data\data.txt");
            Console.WriteLine(testRun.Trimmed(".!?"));
        }
    }
}
