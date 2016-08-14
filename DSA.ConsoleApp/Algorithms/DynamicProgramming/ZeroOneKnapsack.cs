using System.Collections.Generic;
using DSA.ConsoleApp.SupportingClasses;

namespace DSA.ConsoleApp.Algorithms.DynamicProgramming
{
    public class ZeroOneKnapsack
    {
        public static List<KnapsackItem> PickItems(List<KnapsackItem> items, int maxCapacity, out int solutionValue)
        {
            // Adding one to the sizes below, so we can consider scenarios when no item is picked 
            // and when the maxCapacity is 0. The 0th row and column of the maxValues array will be 0's 
            var maxValues  = new int  [items.Count + 1, maxCapacity + 1];
            var doInclude  = new bool [items.Count + 1, maxCapacity + 1];

            // At this point the maxValues multi-dim array is filled with all 0's & the doInclude matrix contains all false values

            for (int i = 0; i < items.Count; i++)
            {
                var currentItem = items[i];
                var row         = i + 1;

                for (int column = 1; column <= maxCapacity; column++)
                {
                    // Best we have so far from the cell above
                    var valueExcluded = maxValues[row - 1, column];

                    var valueIncluded = 0;
                    if (currentItem.Weight <= column)
                        valueIncluded = currentItem.Value + maxValues[row - 1, column - currentItem.Weight];

                    if (valueIncluded > valueExcluded)
                    {
                        maxValues[row, column] = valueIncluded;
                        doInclude[row, column] = true;
                    }
                    else
                    {
                        maxValues[row, column] = valueExcluded;
                    }
                }
            }

            // All items and weights are processed. The solution is in the lowest right most corner
            solutionValue = maxValues[items.Count, maxCapacity];

            // Now to determine which items were selected, we look at the do include array
            var chosenItem = new List<KnapsackItem>();

            // we traverse bottom up 
            for (var row = items.Count; row > 0; row--)
            {
                if(!doInclude[row, maxCapacity])
                    continue;

                // Items is still a zero based List, with no additional padding for the 0th row
                var item = items[row - 1];
                chosenItem.Add(item);

                maxCapacity -= item.Weight;
            }
            
            return chosenItem;
        } 
    }
}