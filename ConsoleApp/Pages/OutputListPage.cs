using ConsoleApp.Helpers;
using System;
using System.IO;

namespace ConsoleApp.Pages
{
    class OutputListPage
    {
        private static bool _abortProcess;

        public static void Display()
        {
            // Console set up
            Console.Clear();
            _abortProcess = false;

            // Info
            Console.WriteLine("### Output Current List ###");
            Console.WriteLine("Please provide the name of the file or type (back) without the brackets to abort this action.");
            Console.WriteLine();

            // Request Inputs
            var fileName = RequestFileName();

            // Process the filter
            if (!_abortProcess)
            {
                var filePath = GetFullFilePath(fileName);
                Console.WriteLine($"Outputing the list to : {filePath}");
                ProcessRequest(filePath);
            }

            // ask for any input to proceed
            ConsoleHelper.RequestAnyInputToProceed();
        }

        private static string RequestFileName()
        {
            Console.Write("File name: ");
            var filename = Console.ReadLine();

            if (string.IsNullOrEmpty(filename))
            {
                Console.WriteLine("File name should not be empty. Please input again.");
                return RequestFileName();
            }

            if (!InputOutputHelper.IsValidFileName(filename))
            {
                Console.WriteLine("File name contains ilegal characters. Please input again.");
                return RequestFileName();
            }

            if (filename.Contains("Back", StringComparison.InvariantCultureIgnoreCase))
            {
                _abortProcess = true;
                filename = "";
            }

            return filename;
        }

        private static void ProcessRequest(string filePath)
        {
            try
            {
                InputOutputHelper.WriteListToFile(filePath, Program._Pipe);
            }
            catch (Exception e)
            {
                Console.WriteLine($"### Error ###" +
                    $"\n{e}" +
                    $"\n#############" +
                    $"\nProcess aborted");
            }
        }

        private static string GetFullFilePath(string filename)
        {
            if(!filename.Contains(".txt", StringComparison.InvariantCultureIgnoreCase))
            {
                filename += ".txt";
            }

            filename = $"{DateTime.Now.ToString("dd-MM-yyyy HH-mm tt")} - {filename}";

            return Path.Combine(Directory.GetCurrentDirectory(), @$"Outputs\Lists\{filename}");
        }
    }
}
