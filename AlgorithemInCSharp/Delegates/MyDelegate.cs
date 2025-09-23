namespace AlgorithemInCSharp.Delegates
{
    public  delegate int MyDelegate(int x, int y);
    public  class Delegatess
    {
        static int Add(int x, int y) => x + y;
        static int Mul(int x, int y) => x * y;

        public static void Run()
        {
            MyDelegate d1 = Add;
            MyDelegate d2 = Mul;

            Console.WriteLine(d1(3, 4)); // Output: 7
            Console.WriteLine(d2(3, 4)); // Output: 12


            MyDelegate d3 = delegate (int x, int y) { return x + y; };
            MyDelegate d4 = (x, y) => x * y;

            Action notify = () => Console.WriteLine("Notified!");
            notify += () => Console.WriteLine("Notified Again!");
            notify += () => Console.WriteLine("Notified Third Time!");
            notify();
        }
    }
}