using System.Collections.Generic;

namespace GroupingNumbers.Services.src.Interfaces
{
    /// <summary>
    /// Interface to group consecutive numbers
    /// </summary>
    public interface IGroupConsecutives
    {
        /// <summary>
        /// Groups numbers consecutively
        /// </summary>
        /// <param name="numbers">List of numbers</param>
        /// <returns>Summarised string for e.g.</returns>
        string Group(IEnumerable<int> numbers);
    }
}
