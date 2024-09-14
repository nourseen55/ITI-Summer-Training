namespace _2DArrayass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[3, 4];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine($"Student {i+1}");
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine($"Mark Of Subject {j + 1} Of Student {i + 1}");
                    
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());

                }

            }
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine($"Student {i + 1}");
                double avg, sum = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    sum += arr[i, j];

                }
                Console.WriteLine($"Sum Of Marks {sum} , Avg of Marks {sum / arr.GetLength(1)} Of Student {i+1}");
            }
        }
    }
}
