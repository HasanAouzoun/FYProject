using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;
using FluentAssertions;
using ConsoleApp.Helpers;
using ConsoleApp.Models;

namespace UnitTest.Helpers
{
    public class FilterHelperTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void Filter(string filterPattern, FilterOutputs expectedOutput, string errorMessage)
        {
            // Arrange
            var unfilteredList = GetUnfilteredList();
            var regex = new Regex(filterPattern);

            // Act
            var result = FilterHelper.FilterList(unfilteredList, regex);

            // Assert
            result.Should().BeEquivalentTo(expectedOutput, errorMessage);
        }

        public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { "^[0-9]*$", 
                            new FilterOutputs { FilteredList= new List<string>{ "1234", "01234"},
                                                RemovedList = new List<string>{ "zebra", "Global", "gl0ry", "g@llery", "@pple" } },
                            "Filtered list should contain only numbered strings" },
            new object[] { "[0-9]",
                            new FilterOutputs { FilteredList= new List<string>{ "1234", "01234", "gl0ry"},
                                                RemovedList = new List<string>{ "zebra", "Global", "g@llery", "@pple" } },
                            "Filtered list should contain strings with at least a digit" },
            new object[] { "^[a-zA-Z]",
                            new FilterOutputs { FilteredList= new List<string>{ "zebra", "Global", "gl0ry", "g@llery" },
                                                RemovedList = new List<string>{ "1234", "01234", "@pple" } },
                            "Filtered list should contain strings that starts with an alphabet character" },
        };

        private static List<string> GetUnfilteredList()
        {
            return new List<string>
            {
                "zebra",
                "1234",
                "01234",
                "Global",
                "gl0ry",
                "g@llery",
                "@pple"
            };
        }
    }
}
