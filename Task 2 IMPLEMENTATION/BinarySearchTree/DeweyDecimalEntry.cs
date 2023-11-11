using System;

namespace Task_2_IMPLEMENTATION.BinarySearchTree
{
    /// <summary>
    /// Represents an entry in the Dewey Decimal system with a class, subclass, description, and call number.
    /// </summary>
    public class DeweyDecimalEntry : IComparable<DeweyDecimalEntry>
    {
        public string Class { get; set; }
        public string Subclass { get; set; }
        public string Description { get; set; }
        public string CallNumber { get; set; }

        /// <summary>
        /// Compares the current DeweyDecimalEntry with another based on the call number.
        /// </summary>
        /// <param name="other">The DeweyDecimalEntry to compare with this instance.</param>
        /// <returns>A value indicating the relative order of the objects being compared.</returns>
        public int CompareTo(DeweyDecimalEntry other)
        {
            // Assuming CallNumber is a unique identifier and used for comparison
            return String.Compare(CallNumber, other.CallNumber, StringComparison.Ordinal);
        }
    }
}
