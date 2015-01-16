using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsConsole
{
    public class Quicksort
    {
        public List<int> Sort(List<int> array)
        {
            var pivot = Partition(array, 0, array.Count - 1);
            Sort(array, 0, pivot - 1);
            Sort(array, pivot, array.Count);
        }

        private int Partition(List<int> array, int lower, int higher)
        {
            
        }
    }
}
