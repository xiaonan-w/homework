using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个数字:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("它的素数因子为:");
            if (a == 1)
            {
                Console.WriteLine("此数字没有素数因子");
                return;
            }
            for (int i = 2; i <= a; i++)
            {
                if (a % i == 0 && isPrime(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        static bool isPrime(int n)
        {
            if (n <= 1) return false;
            for (int j = 2; j < n; j++)
            {
                if (n % j == 0) return false;
                return true;
            }
            return true;
        }
    }
}
