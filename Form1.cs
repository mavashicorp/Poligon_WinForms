using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp24
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int n;//количество сторон
        int R;//расстояние от центра до стороны
        Point Centr; // центр
        Point[] p;//массив точек будущего многоугольника

        private void lineAngle(double angle)
        {
            double z = 0; int i = 0;
            while (i < n + 1)
            {
                p[i].X = Centr.X + (int)(Math.Round(Math.Cos(z / 180 * Math.PI) * R));
                p[i].Y = Centr.Y - (int)(Math.Round(Math.Sin(z / 180 * Math.PI) * R));
                z = z + angle;
                i++;
            }
        }




        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //label10.text = "";
            //получаем входные данные и проверяем их на корректность
            n = Convert.ToInt32(textBox1.Text);
            R = Convert.ToInt32(textBox2.Text);
            Centr.X = Convert.ToInt32(textBox3.Text);
            Centr.Y = Convert.ToInt32(textBox4.Text);

            if (n < 0 || R < 0)
            {
                MessageBox.Show("Неверные входные данные !");
            }
            else // входные данные корректны, рисуем многоуголььник
            {
                p = new Point[n + 1];
                lineAngle((double)(360.0 / (double)n));
                int i = n;
                Graphics g = pictureBox1.CreateGraphics();
                while (i > 0)
                {
                    g.DrawLine(new Pen(Color.Black, 2), p[i], p[i - 1]);
                    i = i - 1;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
    }
}
