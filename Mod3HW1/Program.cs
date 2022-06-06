using System.Collections.Generic;
using System.Collections;

namespace Mod3HW1
{
    class Program
    {
        public static void Main()
        {
            var MyList = new MyList<int>(8);
            var array = new int[] { 4, 3, 2, 1 , 0};
            MyList.AddRange(array);
            MyList.Add(5);
            MyList.RemoveAt(0);
            MyList.Remove(4);
            MyList.Sort(new IntComparer());

            foreach(var i in MyList)
            {
                Console.WriteLine(i);
            }
        }
    }
}