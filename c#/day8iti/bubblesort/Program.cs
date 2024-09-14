namespace bubblesort
{
    internal class Program
    {
        public delegate bool delcompare<T>(T a, T b);
        public static void swap<T>(List<T> list, int idx1, int idx2)
        {
            T temp = list[idx1];
            list[idx1] = list[idx2];
            list[idx2] = temp;
        }
        public static void bubblesort<T>(List<T> list, delcompare<T> compare)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - 1 - i; j++)
                {
                    if (compare(list[j], list[j + 1]))
                    {
                        swap(list, i, j);

                    }
                }

            }
        }
        static void Main(string[] args)
        {
            List<int> nums = [4, 2, 9, 5, 3];
            bubblesort(nums, (x, y) => x > y);
            Console.WriteLine("Asc sort");
            for (int i = 0; i < nums.Count; i++)
            {
                Console.WriteLine(nums[i]);

            }
            bubblesort(nums, (x, y) => x < y);
            Console.WriteLine("desc sort");
            for (int i = 0; i < nums.Count; i++)
            {
                Console.WriteLine(nums[i]);

            }

        }
    }
}