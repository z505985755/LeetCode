using System;

namespace ImplementRand10UsingRand7
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] vs = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 1000; i++)
            {
                vs[s.Rand10() - 1]++;
            }
            Console.WriteLine("Hello World!");
        }
    }
    public class Solution
    {
        public int Rand10()
        {
            int r = 0;
            for (int i = 0; i < 10; i++)
            {
                r += Rand7();
            }
            return (r % 10) + 1;
        }
        public int Rand7()
        {
            return new Random(Guid.NewGuid().GetHashCode()).Next(7)+1;
        }
    }
}
