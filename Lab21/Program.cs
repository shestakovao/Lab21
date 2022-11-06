using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab21
{
    internal class Program
    {
        const int n = 5;
        const int m = 5;
        static int[,] path = new int[n, m] { {30, 70, 30, 40, 50 },
        { 15, 25, 35, 45, 55 },
        { 20, 30, 40, 50, 60 },
        { 25, 35, 45, 55, 65 },
        { 30, 40, 50, 60, 70 } };
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Gardner1);
            Thread thread = new Thread(threadStart);   
            thread.Start();

            Gardner2();


            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{path[i, j]} ");
                }            
            }

            Console.ReadKey();
        }



        static void Gardner1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (path[i, j] >= 0)
                    {
                        int delay = path[i, j];
                        path[i, j] = -1;
                        Thread.Sleep(delay);
                    }
                }
            }
        }
        static void Gardner2()
        {
            for (int j = m-1; j >= 0; j--)
            {
                for (int i = n-1; i >= 0; i--)
                {
                    if (path[i, j] >= 0)
                    {
                        int delay = path[i, j];
                        path[i, j] = -2;
                        Thread.Sleep(delay);
                    }
                }
            }
        }


    }
}
