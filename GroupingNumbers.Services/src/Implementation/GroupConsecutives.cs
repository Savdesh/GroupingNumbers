using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroupingNumbers.Services.src.Interfaces;

namespace GroupingNumbers.Services.src.Implementation
{
    /// <summary>
    /// This class is responsible to group numbers consecutively
    /// </summary>
    public class GroupConsecutives : IGroupConsecutives
    {
        public string Group(IEnumerable<int> numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("numbers");
            }

            var groupSummary = new StringBuilder();

            // Remove duplicates
            List<int> numbersList = numbers.Distinct().ToList();

            // Sort the numbers
            numbersList.Sort();

            var listOfConsecutiveNos = new List<int>();
            for (int i = 0; i < numbersList.Count; i++)
            {
                if (i == 0)
                {
                    // Add the first element to the list
                    listOfConsecutiveNos.Add(numbersList[i]);
                    continue;
                }
                
                if (numbersList[i] == numbersList[i - 1] + 1)
                {
                    // Add if the current number is consecutive
                    listOfConsecutiveNos.Add(numbersList[i]);
                }
                else
                {
                    // Current number not consecutive so summarise the collected numbers
                    groupSummary.Append(SummarizeGroup(listOfConsecutiveNos));

                    // Clear and initialize for next set
                    listOfConsecutiveNos.Clear();
                    listOfConsecutiveNos.Add(numbersList[i]);
                }
            }

            // Add the last grouping to the summary
            if (listOfConsecutiveNos.Count > 0)
            {
                groupSummary.Append(SummarizeGroup(listOfConsecutiveNos));
            }

            return groupSummary.ToString();
        }

        private string SummarizeGroup(List<int> group)
        {
            return (group.Count > 1) ? group[0] + "-" + group[group.Count - 1] + ";" : group[0] + ";";
        }
    }
}
