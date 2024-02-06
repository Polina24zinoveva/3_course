using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KG_LR3
{
    public partial class Form1 : Form
    {
        Drawing_algoritms graphics;
        public Form1()
        {
            InitializeComponent();
            graphics = new Drawing_algoritms(Field.Width, Field.Height);
            Field.BackColor = Color.White;
            Field.Image = graphics.field;
        }
        int countClick = 0;
        int x0 = 0;
        int y0 = 0;
        int x = 0;
        int y = 0;
        List<Tuple<int, int>> orientiru = new List<Tuple<int, int>>();
        List<Tuple<int, int, int, int>> otrezki = new List<Tuple<int, int, int, int>>();


        byte[][] pattern1 =
        {
            new byte[] {1, 0, 0, 1}, new byte[] {0, 0, 0, 0}, new byte[] {1, 0, 0, 1}, new byte[] {0, 0, 0, 0}
        };

        byte[][] pattern2 =
        {
            new byte[] {1, 0, 0, 0, 0, 0, 0, 1}, new byte[] {0, 1, 0, 0, 0, 0, 1, 0}, new byte[] {0, 0, 1, 0, 0, 1, 0, 0}, new byte[] {0, 0, 0, 1, 1, 0, 0, 0}, new byte[] {0, 0, 0, 1, 1, 0, 0, 0}, new byte[] {0, 0, 1, 0, 0, 1, 0, 0}, new byte[] {0, 1, 0, 0, 0, 0, 1, 0}, new byte[] {1, 0, 0, 0, 0, 0, 0, 1},
        };

        byte[][] pattern =
        {
            new byte[] {1, 0, 0, 0, 0, 0, 0, 1}, new byte[] {0, 0, 0, 0, 0, 0, 0, 0}, new byte[] {0, 0, 1, 0, 0, 1, 0, 0}, new byte[] {0, 0, 0, 0, 0, 0, 0, 0}, new byte[] {0, 0, 0, 0, 0, 0, 0, 0}, new byte[] {0, 0, 1, 0, 0, 1, 0, 0}, new byte[] {0, 0, 0, 0, 0, 0, 0, 0}, new byte[] {1, 0, 0, 0, 0, 0, 0, 1},
        };


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Visible = false;
            button2.Enabled = false;
            if (comboBox1.SelectedIndex == 0)
            {
                Podskazka.Text = "Выберите(кликом) точку начала и конца линии:";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                Podskazka.Text = "Первым кликом выберите центр окружности, а вторым радиус:";
            }
            if (comboBox1.SelectedIndex == 2)
            {
                button2.Visible = true;
                button2.Enabled = true;
                Podskazka.Text = "Поставьте точки ориентиры и нажмите 'Построить':";
            }
            if (comboBox1.SelectedIndex == 3)
            {
                /*button2.Visible = true;
                button2.Enabled = true;*/
                Podskazka.Text = "Начертите контур замкнутой фигуры и выберете область закрашивания:";
            }
            if (comboBox1.SelectedIndex == 4)
            {
                /*button2.Visible = true;
                button2.Enabled = true;*/
                Podskazka.Text = "Начертите контур замкнутой фигуры и выберете область закрашивания:";
            }
            if (comboBox1.SelectedIndex == 5)
            {
                /*button2.Visible = true;
                button2.Enabled = true;*/
                Podskazka.Text = "Первым кликом выберите центр окружности, а вторым радиус:";
            }
        }

        private void onFieldClick(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    countClick++;
                    if (countClick == 1)
                    {
                        x0 = me.X;
                        y0 = me.Y;
                    }
                    if (countClick == 2)
                    {
                        countClick = 0;
                        x = me.X;
                        y = me.Y;
                        otrezki.Add(Tuple.Create(x0, y0, x, y));
                        Field.Image = graphics.field;
                        graphics.BresenhamLine(x0, y0, x, y, Color.Black);
                    }
                    break;
                case 1:
                    countClick++;
                    if (countClick == 1)
                    {
                        x0 = me.X;
                        y0 = me.Y;
                        DrawPoint(x0, y0, Color.Black);
                    }
                    if (countClick == 2)
                    {
                        countClick = 0;
                        x = me.X;
                        int r = Math.Abs(x0 - x);
                        Field.Image = graphics.field;
                        graphics.NaturalCircle(x0, y0, r, Color.Black);

                    }
                    break;
                case 2:
                    /*if (countClick == 0)
                    {
                        orientiru.Clear();
                    }*/
                    x = me.X;
                    y = me.Y;
                    orientiru.Add(Tuple.Create(x, y));
                    DrawPoint(x, y, Color.Black);
                    break;
                case 3:
                    Field.Image = graphics.field;
                    DrawPoint(x0, y0, Color.White);
                    graphics.ZapolneniePoligonov(otrezki, Color.Green);
                    break;
                case 4:
                    x = me.X;
                    y = me.Y;
                    Field.Image = graphics.field;
                    graphics.KoroedAlgoritm(x, y, Field.BackColor, Color.Yellow, Color.Red, pattern);
                    break;
                case 5:
                    countClick++;
                    if (countClick == 1)
                    {
                        x0 = me.X;
                        y0 = me.Y;
                        DrawPoint(x0, y0, Color.Black);
                    }
                    if (countClick == 2)
                    {
                        countClick = 0;
                        x = me.X;
                        int r = Math.Abs(x0 - x);
                        Field.Image = graphics.field;
                        graphics.NaturalCircleForZakraska(x0, y0, r, Color.Black);

                    }
                    break;
                default:
                    countClick = 0;
                    break;
            }
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            graphics.field = new Bitmap(Field.Width, Field.Height);
            Field.Image = graphics.field;
            countClick = 0;
            orientiru.Clear();
            otrezki.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Field.Image = graphics.field;
            graphics.Bezie(orientiru, Color.Black);
            orientiru.Clear();
        }

        private void DrawPoint(int x, int y, Color color)
        {
            if (x > 0 & x < graphics.field.Width & y > 0 & y < graphics.field.Height)
            {
                Field.Image = graphics.field;
                graphics.field.SetPixel(x, y, color);
            }
        }
    }
}
