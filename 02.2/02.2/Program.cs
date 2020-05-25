using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] a = new int[10];
            int sum = 0;
            int average = 0;
            for (int i = 0; i <= 9; i++)
            {
                Console.WriteLine("请输入一个数字:");
                a[i] = int.Parse(Console.ReadLine());
            }
            int min = a[0];
            for (int i = 1; i <= 9; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                }
            }
            int max = a[0];
            for (int i = 0; i <= 9; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
            }
            for (int i = 0; i <= 9; i++)
            {
                sum += a[i];
            }
            average = sum / 10;
            Console.WriteLine("这组数字的最大值为:" + max);
            Console.WriteLine("这组数字的最小值为:" + min);
            Console.WriteLine("这组数字的和为:" + sum);
            Console.WriteLine("这组数字的平均值为:" + average);

        }
    }
}