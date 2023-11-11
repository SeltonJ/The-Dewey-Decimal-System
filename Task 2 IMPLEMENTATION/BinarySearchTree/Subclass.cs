using System.Collections.Generic;

namespace Task_2_IMPLEMENTATION.BinarySearchTree
{
    /// <summary>
    /// The Subclass class represents a specific category within the Dewey Decimal Classification system.
    /// </summary>
    public class Subclass
    {
        // Code is a unique identifier for the subclass, typically a numeric or alphanumeric code.
        public string Code { get; set; }

        // Title is the name or description of the subclass, describing the category it represents.
        public string Title { get; set; }

        // Entries is a list of Entry objects that belong to this subclass, representing individual books or resources.
        public List<Entry> Entries { get; set; }
    }

}
