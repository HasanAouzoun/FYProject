using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

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

            // Inputs
            Console.CursorVisible = true;
            Console.WriteLine("### Filter Inputs ###");
            RequestValidateRegex();
        }

        public static Regex RequestValidateRegex()
        {
            Console.Write("Filter Pattern: ");
            var pattern = Console.ReadLine();

            if()

            Console.WriteLine(pattern);

            return new Regex("");
        }

        public static void ValidateRegexString(string pattern)
        {
            var testString = "someone@example.com";

            var validator = new RegexStringValidator(pattern);
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
