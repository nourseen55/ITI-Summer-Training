namespace Arrayass
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter Num of Numbers");
            int num = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[num];
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Enter Num");
                arr[i] = Convert.ToInt32(Console.ReadLine());


            }
            Console.WriteLine($"Min Is {arr.Min()}");
            Console.WriteLine($"Max Is {arr.Max()}");
            Console.WriteLine($"Avg Is {arr.Average()}");

            //calc

            //string exp=Console.ReadLine();
            //var arrexp = exp.Split(' ');
            //int number1=int.Parse(arrexp[0]);
            //int number2=int.Parse(arrexp[2]);
            //char op = Convert.ToChar(arrexp[1]);
            //switch (op)
            //{
            //    case '+':
            //        Console.WriteLine($"Sum Is {number1 + number2}");
            //        break;
            //    case '-':
            //        Console.WriteLine($"Substraction Is {number1 - number2}");
            //        break;
            //    case '*':
            //        Console.WriteLine($"Multiplication Is {number1 * number2}");
            //        break;
            //    case '/':
            //        Console.WriteLine($"Division Is {number1 / number2}");
            //        break;
            //}

        }
        }
}
