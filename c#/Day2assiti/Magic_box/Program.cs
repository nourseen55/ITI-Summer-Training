using System;

namespace Magic_box
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Magic_box-----------------------------------------------------
            int n;
            while (true)
            {
                Console.Write("Enter the magic box size (odd number): ");
                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    continue;
                }

                if (n <= 0)
                {
                    Console.WriteLine("Please enter a positive integer.");
                    continue;
                }

                if (n % 2 == 0)
                {
                    Console.WriteLine("Please enter an odd number.");
                    continue;
                }

                break;
            }

            int row, col, i;
            row = 1;
            col = 2;
            i = 1;

            int winShift = Console.WindowWidth / (n + 1);
            int winHeight = Console.WindowHeight / (n + 1);

            for (i = 1; i <= n * n; i++)
            {
                Console.SetCursorPosition(col * winShift, row * winHeight);
                Console.WriteLine(i);

                if (i % n == 0)
                {
                    row++;
                    if (row > n)
                    {
                        row = 1;
                    }
                }
                else
                {
                    row--;
                    col--;
                    if (row <= 0)
                    {
                        row = n;
                    }
                    if (col <= 0)
                    {
                        col = n;
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
