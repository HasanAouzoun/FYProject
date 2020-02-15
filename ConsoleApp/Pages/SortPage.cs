using System;
using ConsoleApp.Enums;
using ConsoleApp.Helpers;

namespace ConsoleApp.Pages
{
    class SortPage
    {
        public static void Display()
        {
            // Console set up
            Console.Clear();

            // Display options
            Console.WriteLine("### Sort List Page ###");
            Console.WriteLine("How would you like to sort the list?");
            Console.WriteLine("\t1) Ascending order" +
                            "\n\t2) Descending order");

            // Request sort type input
            var sortType = RequestSortTypeInput();

            // Process 
            ProcessRequest(sortType);

            // Request input to continue
            ConsoleHelper.RequestAnyInputToProceed();
        }

        private static SortType RequestSortTypeInput()
        {
            // Wait for input
            Console.CursorVisible = true;
            Console.Write("Please select a type: ");
            var request = Console.ReadKey();
            Console.WriteLine();
            Console.CursorVisible = false;

            // Process the Request
            switch (request.KeyChar)
            {
                case '1':
                    return SortType.Ascending;
                case '2':
                    return SortType.Descending;
                default:
                    // if wrong option selected -- ask for input again
                    Console.WriteLine($"You have selected a wrong option, please select 1 or 2");
                    return RequestSortTypeInput();
            }
        }

        private static void ProcessRequest(SortType sortType)
        {
            var sortedList = SortListHelper.Sort(Program._Pipe, sortType);
            Program._Pipe = sortedList;
            Console.WriteLine($"The list has been sorted in {sortType.ToString()} order.");
        }
    }
}
