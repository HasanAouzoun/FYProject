using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;


namespace ConsoleApp.Helpers
{
    class Notes
    {
        public static void processingProgress()
        {
            Console.WriteLine("Hello World!");

            var lenght = 50;
            var rowNumber = Console.CursorTop;
            for (int i = 0; i <= lenght; i++)
            {
                Console.SetCursorPosition(0, rowNumber);

                Console.WriteLine($"processing ... ({i}/{lenght})");

                Thread.Sleep(100);
            }

            Console.WriteLine("Hello World!");
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
    }
}
