using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fizbuuzAsync_ClassLibrary
{
    public static class FizzBuzz
    {
        private static string Transform(int x)
        {
            int number3 = x % 3;
            int number5 = x % 5;
            string result = "";

            if (number3 == 0)
            {
                result += "Fizz";
            }
            if (number5 == 0)
            {
                result += "Buzz";
            }
            if (number3 != 0 && number5 != 0)
            {
                result = x.ToString();
            }

            return result;
        }

        public static List<string> Sync(List<int> list)
        {
            List<string> stringList = new List<string>();
            foreach(int number in list)
            {
                stringList.Add(Transform(number));
            }
            return stringList;
        }

        public static List<string> Async(List<int> list)
        {
            int threadsCount = list.Count % 10 == 0 ? list.Count / 10 : list.Count / 10 + 1;
            var fizzbuzzLists = new List<string>[threadsCount];

            Parallel.For(0, threadsCount, (int threadNumber) => {
                fizzbuzzLists[threadNumber] = Sync(list.Skip(threadNumber * 10).Take(10).ToList());
            });
            var resultList = new List<string>();
            foreach(var anyNumber in fizzbuzzLists)
            {
                resultList.AddRange(anyNumber);
            }
            return resultList;
        }      
    }
}
