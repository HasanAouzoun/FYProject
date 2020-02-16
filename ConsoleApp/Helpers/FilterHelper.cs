using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ConsoleApp.Models;

namespace ConsoleApp.Helpers
{
    public class FilterHelper
    {
        public static FilterOutputs FilterList(List<string> list, Regex regex)
        {
            // set up for feedback (progress)
            var lenght = list.Count;
            Console.CursorVisible = false;
            var rowNumber = Console.CursorTop;

            var filteredList = new List<string>();
            var removedList = new List<string>();

            for (int i = 0; i < lenght; i++)
            {
                string str = list[i];
                // reset the cursor possition to the beginning of the current line
                Console.SetCursorPosition(0, rowNumber);

                if (regex.IsMatch(str))
                {
                    filteredList.Add(str);
                }
                else
                {
                    removedList.Add(str);
                }

                // display progress
                var progress = (double)(i + 1) / lenght * 100;
                Console.WriteLine($"Filtering List ... ({string.Format("{0:0.00}", progress)}%)");
            }

            // display cursor when done
            Console.CursorVisible = true;

            return new FilterOutputs { FilteredList = filteredList, RemovedList = removedList };
        }
    }
}
