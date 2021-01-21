using System;
using System.Collections.Generic;
using System.Linq;

namespace ReimplementingLinq
{
    /// <summary>
    /// The <see cref="Program"/> class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The program main method.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Lets create some nasty linqs!");

            // Example how iterator actually works.
            var names = new List<string> { "x", "y" };
            var age = new List<int> { 2, 1 };
            PrintNamesAndAges(names, age);
        }

        static void PrintNamesAndAges(IEnumerable<string> names, IEnumerable<int> ages)
        {
            using IEnumerator<int> ageIterator = ages.GetEnumerator();
            {
                foreach (string name in names)
                {
                    if (!ageIterator.MoveNext())
                    {
                        throw new ArgumentException("Not enough ages");
                    }
                    Console.WriteLine("{0} is {1} years old", name, ageIterator.Current);
                }
                if (ageIterator.MoveNext())
                {
                    throw new ArgumentException("Not enough names");
                }

            }
        }
    }
}
