using System;
using System.Collections.Generic;

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
            foreach (string x in GetDemoEnumerable())
            {
                Console.WriteLine(x);
            }
        }

        private static IEnumerable<string> GetDemoEnumerable()
        {
            yield return "start";

            for (int i = 0; i < 5; i++)
            {
                yield return i.ToString();
            }

            yield return "end";
        }
    }
}
