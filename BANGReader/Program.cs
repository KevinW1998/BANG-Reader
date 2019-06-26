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

            BangFiles.ReadFromFile("Tiny_FFA_v2.5.age3Yscn");
        }
    }
}
