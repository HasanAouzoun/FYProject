using System.Text.RegularExpressions;

namespace ConsoleApp.Models
{
    public class FilterInputs
    {
        public Regex Pattern { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool ReverseFilter { get; set; }
    }
}
