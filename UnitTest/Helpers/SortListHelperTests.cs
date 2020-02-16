using System.Collections.Generic;
using Xunit;
using ConsoleApp.Helpers;
using ConsoleApp.Enums;


namespace UnitTest.Helpers
{
    public class SortListHelperTests
    {
        [Fact]
        public void SortListInAscendingOrder()
        {
            // Arrange
            var unorderedList = GetUnorderedList();

            // Act
            SortListHelper.Sort(unorderedList, SortType.Ascending);

            // Assert
            Assert.Equal(unorderedList, GetAscendingOrderedList());
        }

        [Fact]
        public void SortListInDescendingOrder()
        {
            // Arrange
            var unorderedList = GetUnorderedList();

            // Act
            SortListHelper.Sort(unorderedList, SortType.Descending);

            // Assert
            Assert.Equal(unorderedList, GetDescendingOrderedList());
        }

        private List<string> GetUnorderedList()
        {
            return new List<string>
            {
                "zebra",
                "1234",
                "01234",
                "Global",
                "gallery",
                "@pple"
            };
        }

        private List<string> GetAscendingOrderedList()
        {
            return new List<string>
            {
                "@pple",
                "01234",
                "1234",
                "gallery",
                "Global",
                "zebra"
            };
        }

        private List<string> GetDescendingOrderedList()
        {
            return new List<string>
            {
                "zebra",
                "Global",
                "gallery",
                "1234",
                "01234",
                "@pple"
            };
        }
    }
}
