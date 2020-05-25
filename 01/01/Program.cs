using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01
{
    public class Ope
    {
        public static double GetResult(double nA, double nB, string choice)
        {
            double result = 0d;
            switch (choice)
            {
                case "+":
                    result = nA + nB;
                    break;
                case "-":
                    result = nA - nB;
                    break;
                case "*":
                    result = nA * nB;
                    break;
                case "/":
                    result = nA / nB;
                    break;
            }

            return result;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("请输入数字A：");
                string strA = Console.ReadLine();
                Console.Write("请输入数字B：");
                string strB = Console.ReadLine();
                Console.Write("请输入运算符号（+，-，*,/）：");
                string choice = Console.ReadLine();
                string strResult = "";
                strResult = Convert.ToString(Ope.GetResult(Convert.ToDouble(strA), Convert.ToDouble(strB), Convert.ToString(choice)));
                Console.WriteLine("结果是：" + strResult);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("您的输入有错：" + ex.Message);

            }
        }
    }
}
