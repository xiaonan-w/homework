using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        double th1;
        double th2;
        double per1;
        double per2;
        int n;
        double length;
        string pen;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null)
            {
                graphics = this.panel1.CreateGraphics();
            }
            drawCayleyTree(200, 300, -Math.PI / 2);
        }

        void drawCayleyTree(double x0, double y0, double th)
        {
            if (n == 0) return;

            double x1 = x0 + length * Math.Cos(th);
            double y1 = y0 + length * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree1(n - 1, x1, y1, per1 * length, th + th1);
            drawCayleyTree1(n - 1, x1, y1, per2 * length, th - th2);

        }

        void drawCayleyTree1(int n, double x0, double y0, double length, double th)
        {
            if (n == 0) return;

            double x1 = x0 + length * Math.Cos(th);
            double y1 = y0 + length * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree1(n - 1, x1, y1, per1 * length, th + th1);
            drawCayleyTree1(n - 1, x1, y1, per2 * length, th - th2);
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            switch (pen)
            {
                case "红色":
                    graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "蓝色":
                    graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "黑色":
                    graphics.DrawLine(Pens.Black, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                n = int.Parse(textBox6.Text);
            }
            catch (Exception m)
            {
                Console.Write("请输入数字");
                textBox6.Text = "";
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                length = double.Parse(textBox1.Text);
            }
            catch (Exception m)
            {
                Console.Write("请输入数字");
                textBox1.Text = "";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                per2 = double.Parse(textBox4.Text);
            }
            catch (Exception m)
            {
                Console.Write("请输入数字");
                textBox4.Text = "";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                per1 = double.Parse(textBox5.Text);
            }
            catch (Exception m)
            {
                Console.Write("请输入数字");
                textBox5.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                th2 = double.Parse(textBox2.Text) * Math.PI / 180;
            }
            catch (Exception m)
            {
                Console.Write("请输入数字");
                textBox2.Text = "";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                th1 = double.Parse(textBox3.Text) * Math.PI / 180;
            }
            catch (Exception m)
            {
                Console.Write("请输入数字");
                textBox3.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                pen = comboBox1.Text;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

    }
}
