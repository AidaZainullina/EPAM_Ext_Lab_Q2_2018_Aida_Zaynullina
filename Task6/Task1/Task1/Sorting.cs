namespace Task1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Sorting
    {
        public static void Sort(string[] strings, Program.Сomparison del, int first, int last)
        {
            int firstElement = first, lastElement = last;
            var mid = strings[(firstElement + lastElement) / 2];
            do
            {
                while (del(strings[firstElement], mid))
                {
                    firstElement++;
                }

                while (del(mid, strings[lastElement]))
                {
                    lastElement--;
                }

                if (firstElement <= lastElement)
                {
                    var count = strings[firstElement];
                    strings[firstElement] = strings[lastElement];
                    strings[lastElement] = count;
                    firstElement++;
                    lastElement--;
                }
            }
            while (firstElement < lastElement);
            if (first < lastElement)
            {
                Sort(strings, del, first, lastElement);
            }

            if (firstElement < last)
            {
                Sort(strings, del, firstElement, last);
            }
        }

        public static bool СomparisonMethod(string string1, string string2)
        {
            if (string1.Length < string2.Length)
            {
                return true;
            }
            else
            {
                if (string.Compare(string1, string2) < 0)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
