using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp.Helpers
{
    public class InputOutputHelper
    {
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

            // feedback done -- display cursor
            Console.CursorVisible = true;

            return passwords;
        }

        public static void WriteListToFile(string path, List<string> list)
        {
            // set up for feedback (progress)
            var lenght = list.Count;
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
                Console.WriteLine($"Writing to File ... ({string.Format("{0:0.00}", progress)}%)");
            }

            // feedback done -- display cursor
            Console.CursorVisible = true;

            sw.Close();
        }

        public static void WriteTextToFile(string path, string text)
        {
            // creates Directory if does not exists
            var file = new FileInfo(path);
            file.Directory.Create();

            File.WriteAllText(file.FullName, text);
        }

        public static bool IsValidFileName(string filename)
        {
            var isValid = !string.IsNullOrEmpty(filename) &&
                          filename.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;

            return isValid;
        }

        public static void WriteGroupsToFiles(List<IGrouping<string, string>> groups)
        {
            // Disable cursor
            Console.CursorVisible = false;

            // Number of groups
            var length = groups.Count;

            // Path directory 
            var floderName = $"Split - {DateTime.Now.ToString("dd-MM-yyyy HH-mm tt")}";
            var dirPath = Path.Combine(Directory.GetCurrentDirectory(), @$"Outputs\Lists\{floderName}\");

            // Writing each group to file
            for (int i = 0; i < length; i++)
            {
                var currentGroupNumber = i + 1;
                Console.WriteLine($"Writing to file each group: {currentGroupNumber}/{length}");

                // current group list
                var group = groups[i];
                var groupKey = group.Key;
                var list = group.ToList();

                var filePath = Path.Combine(dirPath, @$"List - {groupKey}.txt");

                // writing to file
                InputOutputHelper.WriteListToFile(filePath, list);
            }

            // enable cursor
            Console.CursorVisible = true;
        }
    }
}
