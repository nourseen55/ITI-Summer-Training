namespace day5itiass
{
    interface test<T>
    {
        T GetByIndex(int index);

    }
    public class MyStack<T>:test<T>
    {
        public int top;
        private T[] arr;
        public T this[int idx]
        {
            get { return arr[idx]; }
        }
        public static MyStack<T> operator +(MyStack<T> s1,MyStack<T> s2)
        {
            MyStack<T> news= new MyStack<T>(s1.top + s2.top);
            for (int i = 0; i < s1.top; i++)
            {
                news.Push(s1[i]);
            }
            for (int i = 0; i < s2.top; i++)
            {
                news.Push(s2[i]);
            }
            return news;
        }
        public static explicit operator MyStack<T>(T[] arr)
        {
            MyStack<T> myStack = new MyStack<T>(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                myStack.Push(arr[i]);
            }
            return myStack;
        }
        public static explicit operator T[] (MyStack<T> s)
        {
            T[] newarr= new T[s.top];
            for (int i = 0;i < s.top; i++)
            {
                newarr[i]= s[i];
            }
            return newarr;
        }


        public int Size { get; private set; }

        public MyStack()
        {
            top = 0;
            
            Size = 10;
            arr = new T[Size];
        }

        public MyStack(int n)
        {
            top = 0;
            Size = n;
            arr = new T[Size];
        }

        public T Peek()
        {
            if (top == 0)
            {
                Console.WriteLine("Stack is empty");
            }
            return arr[top-1];
        }

        public void Push(T e)
        {
            if (top < Size)
            {
                arr[top] = e;
                top++;
            }
            else
            {
                Console.WriteLine("Stack is full");
            }
        }

        public T Pop()
        {
            if (top >= -1)
            {
                top--;
                return arr[top];

            }
            else
            {
                Console.WriteLine("Stack Is Empty");
                return default(T);
            }
           
        }

        public T GetByIndex(int index)
        {
            return arr[index];
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> s1 = new MyStack<int>();
            MyStack<int> s2 = new MyStack<int>();

            int[] array =(int[])s1;
            
            
            MyStack<int> stackFromArray = (MyStack<int>)array;
            
            s1.Push(1);
            s1.Push(2);
            s1.Push(3);
            s2.Push(4);
            s2.Push(5);

            MyStack<int> s3 = s1 + s2;
            for (int i = 0; i < s3.top; i++)
            {
                Console.WriteLine(s3[i]);
            }
            Console.WriteLine(s3.GetByIndex(1));



        }
    }
}
