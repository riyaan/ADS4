using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Insertion_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            // generate a list of integers
            const int NUMBER = 100000;
            Random r = new Random((int)DateTime.Now.Ticks);

            List<int> list = new List<int>(NUMBER);
            for (int i = 0; i < NUMBER; i++)
            {
                list.Add(r.Next(NUMBER));
            }

            int[] a = list.ToArray();
            Console.WriteLine("Unsorted list");
            //PrintArray(a);
            //int[] a = { 5, 14, 9, 2, 34, 8, 41, 1, 22, 3, 88, 7, 55, 6 };

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            //sw.Start();
            //BubbleSort(a);
            //sw.Stop();
            //Console.WriteLine("Bubble Sort: " + sw.ElapsedMilliseconds + "ms");

            sw.Start();
            InsertSort(a);
            sw.Stop();
            Console.WriteLine("Insertion Sort: " + sw.ElapsedMilliseconds + "ms");

            sw.Start();
            SelectionSort(a);
            sw.Stop();
            Console.WriteLine("My Selection Sort: " + sw.ElapsedMilliseconds + "ms");

            sw.Start();
            TemsSelectionSort(a);
            sw.Stop();
            Console.WriteLine("Tems Selection Sort: " + sw.ElapsedMilliseconds + "ms");
        }

        static void PrintArray(int[] a)
        {
            //System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));

            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("|"+a[i]);
            }
            Console.WriteLine();
        }

        public static void BubbleSort(int[] a)
        {
            // 7, 5, 8, 2, 4, 9
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = 0; j < a.Length - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
            }

            //PrintArray(a);
        }

        private static void InsertSort(int[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                int j=i;
                while (j > 0)
                {
                    if (a[j] < a[j - 1])
                    {
                        int temp = a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = temp;
                    }
                    j--;                    
                }
            }

            //PrintArray(a);
        }

        private static void TemsSelectionSort(int[] a)
        {
           for (int i = 0; i < a.Length-1; i++) 
           {
               int smallest = a[i];
               int pos = i;
               for (int j = i+1; j < a.Length; j++)
               {
                   if (a[j] < smallest) 
                   {
                       smallest = a[j];
                       pos = j;
                   }
                   int temp = a[pos];
                   a[pos] = a[i];
                   a[i] = temp;
                }
           }
        }

        private static void SelectionSort(int[] a)
        {
            // find the largest item
            int largest = 0;
            int totalSize = a.Length;

            for (int i = 0; i < totalSize; i++)
            {
                // 5, 9, 2, 8, 4, 1, 3, 7, 6
                for (int j = 0; j < totalSize; j++)
                {
                    if (a[j] > a[largest])
                    {
                        largest = j;
                    }
                }

                // swap the largest with the last item
                int temp = a[totalSize - 1]; // store the last item
                a[totalSize - 1] = a[largest]; // move the biggest item to the end
                // store the end item in the biggest place
                a[largest] = temp;

                largest = 0;
                totalSize--;
                i = 0;
            }

            //PrintArray(a);
        }
    }
}