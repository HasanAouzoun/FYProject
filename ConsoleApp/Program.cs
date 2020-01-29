using System;
using System.Collections.Generic;
using System.IO;
using ConsoleApp.Pages;
using ConsoleApp.Helpers;
using ConsoleApp.Pipes;

namespace ConsoleApp
{
    class Program
    {
        private static List<string> _Pipe;

        static void Main()
        {
            // Initial set up
            _Pipe = new List<string>();

            MainPage.Display();
        }
        

        static void Convert()
        {
            var inputPath = Path.Combine(Directory.GetCurrentDirectory(), @"Files\test.txt");
            var outputPath = Path.Combine(Directory.GetCurrentDirectory(), @"Outputs\testOutput.txt");

            var x = InputOutputHelper.ConvertTextToJson(inputPath, outputPath);
        }

        static void GetFile()
        {
            List<string> list;
            try
            {
                list = InputOutputHelper.ReadFile("x");
            } 
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine($"File not found: {e.FileName}");
            }
        }

        static void Filter()
        {
            Console.WriteLine("Filter the list");
        }
    }
}
