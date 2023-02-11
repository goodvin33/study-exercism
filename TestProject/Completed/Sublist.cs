using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public enum SublistType
    {
        Equal,
        Unequal,
        Superlist,
        Sublist
    }

    public static class Sublist
    {
        public static SublistType Classify<T>(List<T> list1, List<T> list2)
            where T : IComparable
        {
            if (list1.SequenceEqual(list2))
            {
                return SublistType.Equal;
            }
            else if (CheckSublist(list1, list2))
            {
                return SublistType.Sublist;
            }
            else if (CheckSuperList(list1, list2))
            { return SublistType.Superlist; }
            else
            { return SublistType.Unequal; }
        }

        private static bool CheckSublist<T>(List<T> list1, List<T> list2)
            where T : IComparable
        {
            List<T> listForCompare;
            if (list1.Count == 0)
            {
                return true;
            }
            else if (list1.Count > list2.Count)
            {
                return false;
            }
            else
            {
                for (int startedIndex = 0; startedIndex <= (list2.Count) - (list1.Count); startedIndex++)
                {
                    listForCompare = list2.GetRange(startedIndex, list1.Count);
                    if (listForCompare.SequenceEqual(list1))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        private static bool CheckSuperList<T>(List<T> list1, List<T> list2)
           where T : IComparable => CheckSublist(list2, list1);
        
    }
}
