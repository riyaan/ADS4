using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Summing
    {
        List<int> customList = new List<int>();

        public int Total { get; set; }

        // int[] a = {1, 2, 3, 4, 5}
        public int Sum(int x)
        {
            if (x <= 0)
                return x;
            else
                return x + Sum(x - 1);
        }

        // int[] a = {1, 2, 3, 4, 5}
        public int SumArray(int start, int[] a)
        {
            if (start <= 0)
                return start;

            int smallerProblem = start - 1;
            int smallerSolution = SumArray(smallerProblem, a);

            int bigSolution = smallerSolution + start;
            return bigSolution;
        }

        // int[] a = {1, 2, 3, 4, 5}
        public int SumCustomArray(int start, int[] a)
        {
            if (start >= a.Length)
                return start; // we have a harder problem to solve

            int smallerProblem = start + 1; // make the problem simpler
            int smallerSolution = SumCustomArray(smallerProblem, a);

            int bigSolution = smallerSolution + start;
            return bigSolution;
        }

        public int Factorial(int n)
        {
            if (n <= 1)
                return n;

            int smallerProblemArgument = n - 1;
            int smallerSolution = Factorial(smallerProblemArgument);

            int bigSolution = smallerSolution * n;
            return bigSolution;

            //return Factorial(n - 1) * n;
        }

        public int Fibonacci(int n)
        {
            // 5
            // 0, 1, 1, 2, 3

            if (n < 2)
                return n;

            int sum1 = Fibonacci(n - 1);
            int sum2 = Fibonacci(n-2);

            return sum1 + sum2;
        }

        public void EmptyV(int n)
        {
            if (n <= 0)
            {
                Console.WriteLine("Empty"); // trivial solution
                return;
            }   

            int smallerProblem = n - 1;
            Console.WriteLine(String.Format("{0} left.", smallerProblem));
            EmptyV(smallerProblem); // smaller solution

            // the calculation
            //return bigSolution;
            return;
        }

        // Only does one iteration of the Array
        //1, 8, 3, 6, 9, 4, 12, 15, 7, 33, 77, 2, 0
        //1, 3, 6, 8, 4, 9, 12, 7, 15, 33, 2, 0, 77
        public void BSort(int n, int[] a)
        {
            // if solution is trivial
            if (n >= a.Length-1)
                return;                        

            // calculate
            if (a[n] > a[n + 1])
            {
                int temp = a[n];
                a[n] = a[n + 1];
                a[n + 1] = temp;
            }

            int smallerProblem = n + 1;

            BSort(smallerProblem, a);
            return;
        }

        public void FindFile(string directory, string fileName, bool found)
        {
            Total += 1;
            foreach (var v in Directory.EnumerateFiles(directory))
            {
                if (v.Contains(fileName))
                {
                    Console.WriteLine(String.Format("File '{0}' found in directory '{1}'", fileName, directory));                    
                }
            }

            foreach (var d in Directory.EnumerateDirectories(directory))
            {
                Total += 1;
                try
                {
                    FindFile(d, fileName, found);
                }
                catch (Exception)
                {                    
                }
            }
            
            return;
        }

        //XXX
        //XXX
        //XOX
        // Initial row=0, column=0
        public void SearchGrid(string[,] grid, int currentRow, int currentColumn, 
            int rowLength, int columnLength, bool done)
        {
            // base case
            if(done)  return;
            else
            {
                Console.WriteLine(String.Format("Searching [{0},{1}]: ", currentRow, currentColumn));
                if (grid[currentRow, currentColumn].Equals("O")) { Console.WriteLine("Found 'O'"); }

                // smallerProblem
                currentColumn++;

                if (currentColumn >= columnLength)
                {
                    if (currentRow >= rowLength-1)
                    {
                        done = true; return;
                    }
                    else
                    {
                        currentRow++; currentColumn = 0;
                    }
                }              
 
                SearchGrid(grid, currentRow, currentColumn, rowLength, columnLength, done);

                return;
            }
        }

    }
}