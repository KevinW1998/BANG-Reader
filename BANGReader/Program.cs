using BANGReader.Core;
using System;
using System.IO;

namespace BANGReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(Directory.GetCurrentDirectory());

            BangFiles.ReadFromFile("Athens_13_Mileto_Land.age4scn");
        }
    }
}
