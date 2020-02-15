using System.Collections.Generic;
using ConsoleApp.Enums;

namespace ConsoleApp.Helpers
{
    class SortListHelper
    {
        public static List<string> Sort(List<string> list, SortType sortType)
        {
            var newList = list;

            if (sortType == SortType.Ascending)
                newList.Sort();
            else if (sortType == SortType.Descending)
                newList.Sort((a, b) => b.CompareTo(a));

            return newList;
        }
    }
}
