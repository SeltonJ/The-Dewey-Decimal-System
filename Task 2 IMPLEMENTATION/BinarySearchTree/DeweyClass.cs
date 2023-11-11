using System.Collections.Generic;

namespace Task_2_IMPLEMENTATION.BinarySearchTree
{
    /// <summary>
    /// Represents a Dewey Decimal class which includes a title, list of subclasses, and entries.
    /// </summary>
    public class DeweyClass
    {
        public string Class { get; set; }
        public string Title { get; set; }
        public List<Subclass> Subclasses { get; set; }
        public List<Entry> Entries { get; set; }
    }
}
