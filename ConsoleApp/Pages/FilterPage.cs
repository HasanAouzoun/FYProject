using System;
using System.Text.RegularExpressions;
using System.IO;
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

            // Confirm to proceed with the filtering
            Console.WriteLine("Would you like to proceed (y) or go back (n)");
            if (!ConsoleHelper.InputConfirmation())
            {
                Console.WriteLine("Filter aborted");
                ConsoleHelper.RequestAnyInputToProceed();
                return;
            }

            // Request Inputs
            var filterInputs = RequestInputs();

            // Process the filter
            ProcessRequest(filterInputs);
        }

        private static FilterInputs RequestInputs()
        {
            // Request Inputs
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
                Title = $"{title} - {DateTime.Now.ToString("dd-MM-yyyy HH-mm tt")}",
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

            if (!InputOutputHelper.IsValidFileName(title))
            {
                Console.WriteLine("Title contains ilegal character. The tilte is needed to create a new directory. Therefore, it is needed to have a valid file name.");
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

        private static void ProcessRequest(FilterInputs filterInputs)
        {
            Console.WriteLine("\n### Processing the filter ###");

            Console.WriteLine($"Output Directory: " +
                $"\n\t{GetOutputDirectory(filterInputs.Title)}");

            OutputDescriptionToFile(filterInputs);

            // Filter the Pipe
            var filterOutputs = FilterHelper.FilterList(Program._Pipe, filterInputs.Pattern);

            OutputListsToFile(filterOutputs, filterInputs);

            // update the Pipe
            if (filterInputs.ReverseFilter)
            {
                Program._Pipe = filterOutputs.RemovedList;
            }
            else
            {
                Program._Pipe = filterOutputs.FilteredList;
            }

            ConsoleHelper.RequestAnyInputToProceed();
        }

        private static string GetOutputDirectory(string title)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), @$"Outputs\Filters\{title}\");
        }

        private static void OutputDescriptionToFile(FilterInputs inputs)
        {
            var path = Path.Combine(GetOutputDirectory(inputs.Title), "Description.txt");

            InputOutputHelper.WriteTextToFile(path, inputs.Description);

            Console.WriteLine("Writing Description to Description.txt - Done");
        }

        private static void OutputListsToFile(FilterOutputs lists, FilterInputs inputs)
        {
            string filteredListFileName;
            string removedListFileName;

            if (inputs.ReverseFilter)
            {
                filteredListFileName = "FilteredList.txt";
                removedListFileName = "RemovedList_MainOutput.txt";
            }
            else
            {
                filteredListFileName = "FilteredList_MainOutput.txt";
                removedListFileName = "RemovedList.txt";
            }

            var filteredListPath = Path.Combine(GetOutputDirectory(inputs.Title), filteredListFileName);
            var removedListPath = Path.Combine(GetOutputDirectory(inputs.Title), removedListFileName);

            // write Filtered List To file
            Console.WriteLine("Filtered List - ");
            InputOutputHelper.WriteListToFile(filteredListPath, lists.FilteredList);

            // write Removed List to file 
            Console.WriteLine("Removed List - ");
            InputOutputHelper.WriteListToFile(removedListPath, lists.RemovedList);

            Console.WriteLine("Processing Done.");
        }
    }
}
