using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03
{
    interface MyShape
    {
        double getArea();
        double getCircum();
        bool Islegal();
    }
    class MyRectangle : MyShape
    {
        private double height;
        private double width;
        public MyRectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }
        public double getArea()
        {
            return height * width;
        }
        public double getCircum()
        {
            return 2 * (height + width);
        }
        public bool Islegal()
        {
            return height != width && height > 0 && width > 0;
        }
    }

    class Square : MyShape
    {
        private double side;
        public Square(double side)
        {
            this.side = side;
        }
        public double getArea()
        {
            return side * side;
        }
        public double getCircum()
        {
            return 4 * side;
        }
        public bool Islegal()
        {
            return side > 0;
        }
    }

    class MyTriangle : MyShape
    {
        private double a;
        private double b;
        private double c;

        public MyTriangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public double getArea()
        {
            return Math.Sqrt((a + b + c) * (a + b - c) * (a + c - b) * (b + c - a)) / 4;
        }
        public double getCircum()
        {
            return a + b + c;
        }
        public bool Islegal()
        {
            return (a > 0 && b > 0 && c > 0 && a < b + c && b < a + c && c < a + b);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int flag;
                Console.WriteLine("1.构造矩形  ");
                Console.WriteLine("2.构造正方形  ");
                Console.WriteLine("3.构造三角形\n");
                Console.WriteLine("请选择操作：");
                flag = Convert.ToInt32(Console.ReadLine());

                switch (flag)
                {
                    case 1:
                        double height, width;
                        Console.WriteLine("输入矩形的长：");
                        height = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("输入矩形的宽：");
                        width = Convert.ToDouble(Console.ReadLine());
                        MyRectangle r = new MyRectangle(height, width);
                        if (!r.Islegal())
                        {
                            Console.WriteLine("该长和宽构不成矩形！");
                        }
                        else Console.WriteLine($"矩形的面积是：{r.getArea()}\n");
                        break;
                    case 2:
                        double side;
                        Console.WriteLine("输入正方形的边长：");
                        side = Convert.ToDouble(Console.ReadLine());
                        Square s = new Square(side);
                        if (!s.Islegal())
                        {
                            Console.WriteLine("该边长构不成正方形！");
                        }
                        else Console.WriteLine($"正方形的面积是：{s.getArea()}\n");
                        break;
                    case 3:
                        double a, b, c;
                        Console.WriteLine("依次输入三角形三边长：");
                        a = Convert.ToDouble(Console.ReadLine());
                        b = Convert.ToDouble(Console.ReadLine());
                        c = Convert.ToDouble(Console.ReadLine());
                        MyTriangle t = new MyTriangle(a, b, c);
                        if (!t.Islegal())
                        {
                            Console.WriteLine("该三边构不成三角形！");
                        }
                        else Console.WriteLine($"三角形的面积是：{t.getArea()}\n");
                        break;

                    default:
                        Console.WriteLine("输入错误！");
                        break;
                }
            }
        }
    }
}