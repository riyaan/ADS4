using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        const int FACT = 200;

        static void Main(string[] args)
        {
            int[] a = { 1, 8, 3, 6, 9, 4, 12, 15, 7, 33, 77, 2, 0 };

            Summing summing = new Summing();

            //Console.WriteLine("Sum: {0}", summing.Sum(5));
            //Console.WriteLine("Sum Array: {0}", summing.SumArray(a.Length, a));
            //Console.WriteLine("Sum Custom Array: {0}", summing.SumCustomArray(0, a));
            //Console.WriteLine("Factorial: {0}", summing.Factorial(25));
            //Console.WriteLine("Fibonacci 5: {0}", summing.Fibonacci(5));
            //summing.EmptyV(5);
            //summing.BSort(0, a);
            //foreach (int i in a)
            //{
            //    Console.WriteLine(i);
            //}

            int row = 10;
            int column = 10; 

            string[,] arr = new string[row,column];
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if(i > 0 && j%i != 0)
                        arr[i, j] = "O";
                    else
                        arr[i, j] = "X";

                    sb.Append(arr[i, j]);
                }
                Console.WriteLine(String.Format("{0}", sb.ToString()));
                sb.Clear();
            }

            summing.SearchGrid(arr, 0, 0, row, column, false);

            //summing.FindFile(@"C:\", "Riyaan", false);
            //Console.WriteLine(String.Format("Searched {0} directories.", summing.Total));

            //RunFactorial();
        }

        static void RunFactorial()
        {
            long answer = 1;
            // 5! = 1*2*3*4*5 = 120

            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            Console.WriteLine(String.Format("{0}! = {1}", FACT, FactorialNonRecursive()));
            watch.Stop();
            Console.WriteLine("Non-recursive elapsed time: {0}ms", watch.ElapsedMilliseconds);

            answer = 1;
            watch.Start();
            FactorialRecursive(0, ref answer);
            Console.WriteLine(String.Format("{0}! = {1}", FACT, answer));
            watch.Stop();
            Console.WriteLine("Recursive elapsed time: {0}ms", watch.ElapsedMilliseconds);

            //Console.ReadLine();
        }

        static long FactorialNonRecursive()
        {
            long answer = 1;
            for (int i = 1; i <= FACT; i++)
            {
                answer = answer * i;
            }

            return answer;
        }
        
        static void FactorialRecursive(int position, ref long answer)
        {
            if (position >= FACT)
            {
                return;
            }               // BASE CASE

            position++;             // WORK TOWARDS
            answer *= position;     // BASE CASE

            FactorialRecursive(position, ref answer);   // THE RECURSIVE CALL
        }
    }
}
