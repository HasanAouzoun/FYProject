using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ConsoleApp.Helpers;
using ConsoleApp.Models;

namespace ConsoleApp.Pages
{
    class FilterPage
    {
        public static void Display()
        {
            // Console set up
            Console.Clear();

            // Info
            Console.WriteLine("### Filter Information ###");
            Console.WriteLine("To filter you will need to input a few details about the filter.");
            Console.WriteLine("Such as:" +
                "\n\tFilter Pattern (regular expression), Title (that will be used to create a directory)" +
                "\n\tDescription of this filter, and finally the type of the filter");
            Console.WriteLine("There are two types of filters: Normal and Reverse" +
                "\n\tNormal: it will return the filtered list." +
                "\n\tReverse: it will return the removed list. i.e. the list that did not match the filter pattern.");
            Console.WriteLine();

            // Request Inputs
            var inputs = RequestInputs();

            // Process Filter
            // create Folder/ Directory (title)
            // create the Description.txt
            // process the filter
            
        
        }

        private static FilterInputs RequestInputs()
        {
            // Request Inputs
            Console.CursorVisible = true;
            Console.WriteLine("### Filter Inputs ###");
            var regex = RequestPattern();
            var title = RequestTitle();
            var description = RequestDescription();
            var filterType = RequestFilterType();
            Console.WriteLine();

            // Confirm Inputs
            // if confirmation failed then reset the Filter Request
            Console.WriteLine("### Input Confirmation ###");
            Console.WriteLine($"\tPattern: {regex.ToString()}" +
                $"\n\tTitle: {title}" +
                $"\n\tDescription: {description}" +
                $"\n\tReverseType: {filterType}");

            if (ConsoleHelper.InputConfirmation() == false)
            {
                return RequestInputs();
            }

            return new FilterInputs
            {
                Pattern = regex,
                Title = $"{title} - {DateTime.Now.ToString("dd/MM/yyyy H-mm tt")}",
                Description = description,
                ReverseFilter = filterType
            };
        }

        private static Regex RequestPattern()
        {
            // Request Pattern
            Console.Write("Filter Pattern: ");
            var pattern = Console.ReadLine();

            if (string.IsNullOrEmpty(pattern))
            {
                Console.WriteLine("Pattern can not be empty.");
                return RequestPattern();
            }

            // Confirm pattern
            if(ConsoleHelper.InputConfirmation() == false)
            {
                return RequestPattern();
            }

            // Create/Check pattern
            try
            {
                Console.WriteLine("Pattern is valid.");
                return new Regex(pattern);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message.ToString()}");
                return RequestPattern();
            }
        }

        private static string RequestTitle()
        {
            // request Title
            Console.Write("Title: ");
            var title = Console.ReadLine();

            if (string.IsNullOrEmpty(title))
            {
                Console.WriteLine("Title can not be empty.");
                return RequestTitle();
            }

            return title;
        }

        private static string RequestDescription()
        {
            // request Description
            Console.Write("Description: ");
            var description = Console.ReadLine();

            return description;
        }

        private static bool RequestFilterType()
        {
            // request type
            Console.Write("Type -- please type (Normal (n) or Reverse (r)): ");
            var type = Console.ReadLine();
            
            if( type.ToLower().Equals("normal") || type.ToLower().Equals("n") )
            {
                // return false for (ReverseFilter)
                return false;
            }
            else if (type.ToLower().Equals("reverse") || type.ToLower().Equals("r"))
            {
                // return true for (ReverseFilter)
                return true;
            }
            else
            {
                Console.WriteLine("Wrong type");
                return RequestFilterType();
            }
        }
        }

        public static List<string> Filter(List<string> list, string regex, string title, string description, bool reverseFilter)
        {
            var filteredList = new List<string>();
            var removedList = new List<string>();

            // regex
            var _regex = new Regex(regex);

            foreach (var str in list)
            {
                if (_regex.IsMatch(str))
                {
                    filteredList.Add(str);
                }
                else
                {
                    removedList.Add(str);
                }
            }

            return filteredList;
        }
    }
}
