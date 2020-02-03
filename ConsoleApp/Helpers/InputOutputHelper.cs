using System;
using System.Collections.Generic;
using System.IO;
using ConsoleApp.Pipes;
using Newtonsoft.Json;

namespace ConsoleApp.Helpers
{
    class InputOutputHelper
    {
        /// <summary>
        /// THIS WILL BE REMOVED - NO need to covert to Json format
        /// </summary>
        /// <param name="inputPath"></param>
        /// <param name="outputPath"></param>
        /// <returns></returns>
        public static Pipe ConvertTextToJson(string inputPath, string outputPath)
        {
            Console.WriteLine("Convert started" +
                $"\n input: {inputPath}" +
                $"\n output: {outputPath}");

            // Read the file
            Console.WriteLine("Reading the file");
            var passwordList = ReadListFromFile(inputPath);
            Console.WriteLine("Done!");

            // Creating the pipe
            var pipe = new Pipe { Passwords = passwordList };

            // Write to JSON
            Console.WriteLine("Writing to TXT");
            WriteText(outputPath, pipe);
            Console.WriteLine("Done!");

            return null;
        }

        public static List<string> ReadListFromFile(string path)
        {
            // set up for feedback (progress)
            Console.CursorVisible = false;
            var rowNumber = Console.CursorTop;

            // set up empty list
            var passwords = new List<string>();

            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                // Get the lenght of the file - used for calculating the progress
                var lenght = sr.BaseStream.Length;

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // reset the cursor possition to the beginning of the current line
                    Console.SetCursorPosition(0, rowNumber);

                    // add password to list
                    passwords.Add(line);

                    // display progress
                    var progress = (double)sr.BaseStream.Position / lenght * 100;
                    Console.WriteLine($"Reading File ... ({string.Format("{0:0.00}", progress)}%)");
                }
                sr.Close();
            }

            return passwords;
        }

        public static void WriteToJson(string path, Pipe pipe)
        {
            var file = new FileInfo(path);

            // create if dose not exist
            file.Directory.Create();

            // Serialize and Write to file
            using StreamWriter sw = File.CreateText(file.FullName);
            var serialazer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };
            serialazer.Serialize(sw, pipe, typeof(Pipe));
            sw.Close();
        }

        public static void WriteText(string path, Pipe pipe)
        {
            var list = pipe.Passwords;
            var lenght = list.Count;

            // set up for feedback (progress)
            Console.CursorVisible = false;
            var rowNumber = Console.CursorTop;

            // create directory if dose not exist
            var file = new FileInfo(path);
            file.Directory.Create();

            // write to file
            using StreamWriter sw = File.CreateText(file.FullName);
            for (int i = 0; i < lenght; i++)
            {
                // reset the cursor possition to the beginning of the current line
                Console.SetCursorPosition(0, rowNumber);

                // writing to file
                sw.WriteLine(list[i]);

                // display progress
                var progress = (double) (i+1) / lenght * 100;
                Console.WriteLine($"Reading File ... ({string.Format("{0:0.00}", progress)}%)");
            }

            sw.Close();
        }

        public static void WriteTextToFile(string path, string text)
        {
            // creates Directory if does not exists
            var file = new FileInfo(path);
            file.Directory.Create();

            File.WriteAllText(file.FullName, text);
        }
    }
}
