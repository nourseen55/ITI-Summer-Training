namespace Day3itiass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Num Of Class Room");
            int numofroom = Convert.ToInt32(Console.ReadLine());
            int[][] classroom = new int[numofroom][];

            for (int i = 0; i < numofroom; i++)
            {

                Console.WriteLine($"Class {i + 1}");
                Console.WriteLine($"Enter Num Of Students in Class Room {i + 1}");

                int numofstudent = Convert.ToInt32(Console.ReadLine());
                classroom[i] = new int[numofstudent];
                for (int j = 0; j < numofstudent; j++)
                {
                    Console.WriteLine($"Enter Mark Of Student {j + 1}");
                    int mark = Convert.ToInt32(Console.ReadLine());
                    classroom[i][j] = mark;
                }

            }
            for (int i = 0; i < numofroom; i++)
            {
                int sumofmarks = 0;
                for (int j = 0; j < classroom[i].Length; j++)
                {
                    sumofmarks += classroom[i][j];
                }
                Console.WriteLine($"Averge Mark of  Class {i + 1}");

                Console.WriteLine(sumofmarks / classroom[i].Length);
            }


        }
    
}
}
