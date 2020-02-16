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
                            "\n\t2) Descending order" +
                            "\n\t3) Go back");

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
            Console.Write("Please select a type: ");
            var request = Console.ReadKey();
            Console.WriteLine();

            // Process the Request
            switch (request.KeyChar)
            {
                case '1':
                    return SortType.Ascending;
                case '2':
                    return SortType.Descending;
                case '3':
                    return SortType.Null;
                default:
                    // if wrong option selected -- ask for input again
                    Console.WriteLine($"You have selected a wrong option, please select 1, 2 or 3");
                    return RequestSortTypeInput();
            }
        }

        private static void ProcessRequest(SortType sortType)
        {
            if (sortType == SortType.Null)
            {
                Console.WriteLine($"Going back to Project page");
            }
            else 
            {
                var sortedList = SortListHelper.Sort(Program._Pipe, sortType);
                Program._Pipe = sortedList;
                Console.WriteLine($"The list has been sorted in {sortType.ToString()} order.");
            }
        }
    }
}
