using System;

namespace LinqConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new LinqSamples();

            Console.WriteLine("Task 1:");
            foreach (var emp in LinqSamples.Task1())
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine("\nTask 2:");
            foreach (var emp in LinqSamples.Task2())
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine("\nTask 3:");
            Console.WriteLine(LinqSamples.Task3());

            Console.WriteLine("\nTask 4:");
            foreach (var emp in LinqSamples.Task4())
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine("\nTask 5:");
            foreach (var emp in LinqSamples.Task5())
            {
                Console.WriteLine(emp);
            }
            
            Console.WriteLine("\nTask 6:");
            foreach (var emp in LinqSamples.Task6())
            {
                Console.WriteLine(emp);
            }
            
            Console.WriteLine("\nTask 7:");
            foreach (var job in LinqSamples.Task7())
            {
                Console.WriteLine(job);
            }
            
            Console.WriteLine("\nTask 8:");
            Console.Write("Is there \"Backend programmer\" in the collection?   ");
            Console.WriteLine(LinqSamples.Task8() ? "Yes" : "No");
            
            Console.WriteLine("\nTask 9:");
            Console.WriteLine(LinqSamples.Task9());
            
            Console.WriteLine("\nTask 10:");
            foreach (var emp in LinqSamples.Task10())
            {
                Console.WriteLine(emp);
            }
            
            Console.WriteLine("\nTask 11:");
            Console.WriteLine(LinqSamples.Task11());
            
            Console.WriteLine("\nTask 12:");
            foreach (var emp in LinqSamples.Task12())
            {
                Console.WriteLine(emp);
            }
        }
    }
}
