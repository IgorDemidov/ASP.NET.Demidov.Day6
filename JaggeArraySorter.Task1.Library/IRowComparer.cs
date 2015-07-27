using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArraySorter.Task1.Library
{
    public interface IRowComparer
    {
        int Compare(int[] first, int[] second);
    }
}
