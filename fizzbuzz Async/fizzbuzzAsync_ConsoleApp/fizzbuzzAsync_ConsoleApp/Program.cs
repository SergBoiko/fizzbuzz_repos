using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fizbuuzAsync_ClassLibrary;

namespace fizzbuzzAsync_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();


            int[] a = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};
            
            var b = FizzBuzz.Sync(a.ToList());
            var c = FizzBuzz.Async(a.ToList());            

            foreach (string fizzbuzz in b)
            {
                Console.Write(fizzbuzz + " ");
            }
            Console.WriteLine();

            foreach(string fizzbuzz in c)
            {
                Console.Write(fizzbuzz + " ");
            }
            Console.WriteLine();

            watch.Stop();
            Console.WriteLine(watch.Elapsed.ToString(format: "g"));

            Console.ReadKey();
        }
    }
}
