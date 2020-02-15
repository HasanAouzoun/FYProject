using System;
using System.IO;
using ConsoleApp.Helpers;

namespace ConsoleApp.Pages
{
    class GetListPage
    {
        public static void Display()
        {
            // Console UI
            Console.Clear();
            Console.WriteLine("To start a new project you need a list of strings to perform the filters on it.");
            Console.WriteLine("Please provide the name of the file that contains this list. This should be inside the directory of this software.");
            Console.WriteLine(@"Example: list.txt or subDirectory\list.txt");

            // Get File Name
            var filePath = RequestFile();

            // Read List from File
            var list = InputOutputHelper.ReadListFromFile(filePath);

            // Update the pipe
            Program._Pipe = list;

            // request key to proceed
            ConsoleHelper.RequestAnyInputToProceed();
            Console.Clear();
        }

        private static string RequestFile()
        {
            // set up
            string file;

            // request file name
            Console.Write("Input file name: ");
            Console.CursorVisible = true;
            string fileName = Console.ReadLine();
            Console.CursorVisible = false;

            // Get full path of the file name
            string fileFullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            // Check if file exists
            if (!File.Exists(fileFullPath))
            {
                Console.WriteLine("File not found. Please check that it exists.");
                Console.WriteLine(fileFullPath);
                Console.WriteLine();
                file = RequestFile();
            }
            else
            {
                file = fileFullPath;
            }

            return file;
        }
    }
}
