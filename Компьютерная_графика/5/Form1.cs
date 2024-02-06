namespace KG_LR5
{
    public partial class Form1 : Form
    {
        private Bitmap image;

        //List<List<double>> tochki = new List<List<double>>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            image = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);
            pictureBox.Image = image;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        public Points Conversion(Points vector)//метод, который реализует перемещение, вращение и масштаб
        {

            double x = vector.X, y = vector.Y, z = vector.Z;
            double deg = Math.PI / 180;

            //перемещение
            x = x + peremeshenieXtrackBar.Value - 5;
            y = y + peremeshenieYtrackBar.Value - 5;
            z = z + peremeshenieZtrackBar.Value - 5;

            double x0, y0 = y, z0 = z;
            //поворот вокруг X
            y = y0 * Math.Cos((povorotXtrackBar.Value - 180) * deg) - z0 * Math.Sin((povorotXtrackBar.Value - 180) * deg);
            z = y0 * Math.Sin((povorotXtrackBar.Value - 180) * deg) + z0 * Math.Cos((povorotXtrackBar.Value - 180) * deg);

            x0 = x;
            z0 = z;
            //поворот вокруг Y
            x = x0 * Math.Cos((povorotYtrackBar.Value - 180) * deg) + z0 * Math.Sin((povorotYtrackBar.Value - 180) * deg);
            z = -x0 * Math.Sin((povorotYtrackBar.Value - 180) * deg) + z0 * Math.Cos((povorotYtrackBar.Value - 180) * deg);

            x0 = x;
            y0 = y;
            //поворот вокруг Z
            x = x0 * Math.Cos((povorotZtrackBar.Value - 180) * deg) - y0 * Math.Sin((povorotZtrackBar.Value - 180) * deg);
            y = x0 * Math.Sin((povorotZtrackBar.Value - 180) * deg) + y0 * Math.Cos((povorotZtrackBar.Value - 180) * deg);

            x0 = x;
            y0 = y;
            z0 = z;

            //аксонометрическое проецирование
            double alpha = -45 * deg;
            double betta = 45 * deg;
            x = x0 * Math.Cos(alpha) + y0 * Math.Sin(alpha);
            y = -x0 * Math.Sin(alpha) * Math.Cos(betta) + y0 * Math.Cos(alpha) * Math.Cos(betta) + z0 * Math.Sin(betta);
            z = x0 * Math.Sin(alpha) * Math.Sin(betta) - y0 * Math.Cos(alpha) * Math.Sin(betta) + z0 * Math.Cos(betta);

            //масштабирование
            x = 2 * x * (mashtabirovanieTrackBar.Value - 10);
            y = 2 * y * (mashtabirovanieTrackBar.Value - 10);
            z = 2 * z * (mashtabirovanieTrackBar.Value - 10);

            //сдвиг
            x = x + pictureBox.ClientSize.Width / 2;
            y = y + pictureBox.ClientSize.Height / 2;


            return new Points(x, y, z);
        }

        //каркас
        private void Draw_()
        {
            Points[,] vertices = new Points[41, 41];
            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Black);

            for (int i = 0; i <= 40; i++)
            {
                for (int j = 0; j <= 40; j++)
                {
                    double x = (double)(i - 20) / 10;
                    double y = (double)(j - 20) / 10;

                    double z;
                    double t = y + y * x;
                    if (t < 0)
                    {
                        z = Math.Pow(Math.Abs(t), 1.0 / 3) * (-1);
                    }
                    else
                    {
                        z = Math.Pow(t, 1.0 / 3);
                    }
                    vertices[i, j] = Conversion(new Points(x, y, z));
                }
            }
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    Point[] polygonPoints = new Point[]
                    {
                        new Point((int) vertices[i, j].X, (int) vertices[i, j].Y),
                        new Point((int) vertices[i, j + 1].X, (int) vertices[i, j + 1].Y),
                        new Point((int) vertices[i + 1, j + 1].X, (int) vertices[i + 1, j + 1].Y),
                        new Point((int) vertices[i + 1, j].X, (int) vertices[i + 1, j].Y)
                    };
                    g.DrawPolygon(pen, polygonPoints);

                }
            }
            pictureBox.Refresh();
        }


        //вывод полигонов с закраской √уро
        private void Draw()
        {
            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);

            Points[,] vertices = new Points[41, 41];

            for (int i = 0; i <= 40; i++)
            {
                for (int j = 0; j <= 40; j++)
                {
                    double x = (double)(i - 20) / 10;
                    double y = (double)(j - 20) / 10;

                    double z;
                    double t = y + y * x;
                    if (t < 0)
                    {
                        z = Math.Pow(Math.Abs(t), 1.0 / 3) * (-1);
                    }
                    else
                    {
                        z = Math.Pow(t, 1.0 / 3);
                    }
                    vertices[i, j] = Conversion(new Points(x, y, z));
                }
            }


            Color color1 = Color.White;
            Color color2 = Color.DarkGray;

            double viewDirectionX = 0; // Ќаправление взгл€да вдоль оси X
            double viewDirectionY = 0; // Ќаправление взгл€да вдоль оси Y
            double viewDirectionZ = -1; // Ќаправление взгл€да вдоль оси Z(взл€д вдоль отрицательной оси z)

            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40; j++)
                {

                    // нормали к каждой грани
                    double vector1X = vertices[i, j + 1].X - vertices[i, j].X;
                    double vector1Y = vertices[i, j + 1].Y - vertices[i, j].Y;
                    double vector1Z = vertices[i, j + 1].Z - vertices[i, j].Z;

                    double vector2X = vertices[i + 1, j].X - vertices[i, j].X;
                    double vector2Y = vertices[i + 1, j].Y - vertices[i, j].Y;
                    double vector2Z = vertices[i + 1, j].Z - vertices[i, j].Z;

                    // нахождение нормали к точке
                    double nx = (vector1Y) * (vector2Z) - (vector1Z) * (vector2Y);
                    double ny = (vector1Z) * (vector2X) - (vector1X) * (vector2Z);
                    double nz = (vector1X) * (vector2Y) - (vector1Y) * (vector2X);



                    Point[] polygonPoints = new Point[]
                        {
                            new Point((int) vertices[i, j].X, (int) vertices[i, j].Y),
                            new Point((int) vertices[i, j + 1].X, (int) vertices[i, j + 1].Y),
                            new Point((int) vertices[i + 1, j + 1].X, (int) vertices[i + 1, j + 1].Y),
                            new Point((int) vertices[i + 1, j].X, (int) vertices[i + 1, j].Y)
                        };


                    // интенсивность освещени€
                    double intensivnost = (nx * viewDirectionX + ny * viewDirectionY + nz * viewDirectionZ) / 300;

                    // ограничение интенсивности от 0 до 1
                    double intensity = Math.Max(0, intensivnost);

                    Brush brush = new SolidBrush(InterpolateColor(color1, color2, intensity));

                    g.FillPolygon(brush, polygonPoints);
                }
            }
            pictureBox.Refresh();
        }


        /*//вывод точек интерполированным цветом
        private void Draw()
        {
            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);
            int width = image.Width;
            int height = image.Height;

            double[][] tochki = new double[40 * 40][];
            int index = 0;

            for (double x = -2; x <= 2; x += 0.1)
            {
                for (double y = -2; y <= 2; y += 0.1)
                {
                    double z;
                    double t = y + y * x;
                    if (t < 0)
                    {
                        z = Math.Pow(Math.Abs(t), 1.0 / 3) * (-1);
                    }
                    else
                    {
                        z = Math.Pow(t, 1.0 / 3);
                    }
                    Points point = Conversion(new Points(x, y, z));
                    int pixelX = (int)point.X;
                    int pixelY = (int)point.Y;

                    tochki[index] = new double[] { x, y, z };
                    index++;
                }
            }

            Array.Sort(tochki, (a, b) => b[2].CompareTo(a[2]));

            Color color1 = Color.Red;
            Color color2 = Color.Blue;

            // ќтрисовка точек поверхности
            foreach (var tochka in tochki)
            {
                var t = (double)Array.IndexOf(tochki, tochka) / tochki.Length;
                var interpolatedColor = InterpolateColor(color1, color2, t);

                Pen pen = new Pen(interpolatedColor);

                Points point = Conversion(new Points(tochka[0], tochka[1], tochka[2]));
                int pixelX = (int)point.X;
                int pixelY = (int)point.Y;

                g.DrawRectangle(pen, pixelX, pixelY, 1, 1);
            }

            pictureBox.Refresh();
        }*/




        /*//вывод полигонов с закраской
        private void Draw()
        {
            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);
            
            Points[,] vertices = new Points[41, 41];

            for (int i = 0; i <= 40; i++)
            {
                for (int j = 0; j <= 40; j++)
                {
                    double x = (double)(i - 20) / 10;
                    double y = (double)(j - 20) / 10;

                    double z;
                    double t = y + y * x;
                    if (t < 0)
                    {
                        z = Math.Pow(Math.Abs(t), 1.0 / 3) * (-1);
                    }
                    else
                    {
                        z = Math.Pow(t, 1.0 / 3);
                    }
                    vertices[i, j] = Conversion(new Points(x, y, z));
                }
            }

            Pen pen = new Pen(Color.Black);
            *//*Color color1 = Color.Red;
            Color color2 = Color.Blue;*//*
            Color color1 = Color.White;
            Color color2 = Color.Gray;

            double viewDirectionX = 0; // Ќаправление взгл€да вдоль оси X
            double viewDirectionY = 0; // Ќаправление взгл€да вдоль оси Y
            double viewDirectionZ = -1; // Ќаправление взгл€да вдоль оси Z

            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40; j++)
                {

                    // нормали к каждой грани
                    double vector1X = vertices[i, j + 1].X - vertices[i, j].X;
                    double vector1Y = vertices[i, j + 1].Y - vertices[i, j].Y;
                    double vector1Z = vertices[i, j + 1].Z - vertices[i, j].Z;

                    double vector2X = vertices[i + 1, j].X - vertices[i, j].X;
                    double vector2Y = vertices[i + 1, j].Y - vertices[i, j].Y;
                    double vector2Z = vertices[i + 1, j].Z - vertices[i, j].Z;

                    // нахождение нормали к плоскости
                    double nx = (vector1Y) * (vector2Z) - (vector1Z) * (vector2Y);
                    double ny = (vector1Z) * (vector2X) - (vector1X) * (vector2Z);
                    double nz = (vector1X) * (vector2Y) - (vector1Y) * (vector2X);

                    // нормализаци€ нормали
                    double length = Math.Sqrt(nx * nx + ny * ny + nz * nz);
                    nx /= length;
                    ny /= length;
                    nz /= length;

                    // угол между нормалью и направлением взгл€да
                    double dotProduct = nx * viewDirectionX + ny * viewDirectionY + nz * viewDirectionZ; 
                    if (dotProduct > 0) // т.е. грань видна
                    {
                        Point[] polygonPoints = new Point[]
                        {
                            new Point((int) vertices[i, j].X, (int) vertices[i, j].Y),
                            new Point((int) vertices[i, j + 1].X, (int) vertices[i, j + 1].Y),
                            new Point((int) vertices[i + 1, j + 1].X, (int) vertices[i + 1, j + 1].Y),
                            new Point((int) vertices[i + 1, j].X, (int) vertices[i + 1, j].Y)
                        };

                        // рассто€ние от наблюдател€ до грани
                        double distanceToFace = Math.Sqrt(Math.Pow(viewDirectionX - vertices[i, j].X, 2) + Math.Pow(viewDirectionY - vertices[i, j].Y, 2) + Math.Pow(viewDirectionZ - vertices[i, j].Z, 2));
                        double t = 100000.0 / (Math.Pow(distanceToFace, 2));

                        Brush brush = new SolidBrush(InterpolateColor(color1, color2, t));

                        g.FillPolygon(brush, polygonPoints);
                        //g.DrawPolygon(pen, polygonPoints);
                    }
                }
            }
            pictureBox.Refresh();
        }
*/



        private void DrawI()
        {
            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Black);

            Points[,] vertices = new Points[41, 41];

            for (int i = 0; i <= 40; i++)
            {
                for (int j = 0; j <= 40; j++)
                {
                    double x = (double)(i - 20) / 10;
                    double y = (double)(j - 20) / 10;

                    double z;
                    double t = y + y * x;
                    if (t < 0)
                    {
                        z = Math.Pow(Math.Abs(t), 1.0 / 3) * (-1);
                    }
                    else
                    {
                        z = Math.Pow(t, 1.0 / 3);
                    }
                    vertices[i, j] = Conversion(new Points(x, y, z));
                }
            }

            double viewDirectionX = 0;
            double viewDirectionY = 0;
            double viewDirectionZ = -1;
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    double nx = (vertices[i, j + 1].Y - vertices[i, j].Y) * (vertices[i + 1, j].Z - vertices[i, j].Z) - (vertices[i, j + 1].Z - vertices[i, j].Z) * (vertices[i + 1, j].Y - vertices[i, j].Y);
                    double ny = (vertices[i, j + 1].Z - vertices[i, j].Z) * (vertices[i + 1, j].X - vertices[i, j].X) - (vertices[i, j + 1].X - vertices[i, j].X) * (vertices[i + 1, j].Z - vertices[i, j].Z);
                    double nz = (vertices[i, j + 1].X - vertices[i, j].X) * (vertices[i + 1, j].Y - vertices[i, j].Y) - (vertices[i, j + 1].Y - vertices[i, j].Y) * (vertices[i + 1, j].X - vertices[i, j].X);

                    // Ќормализаци€ нормалей
                    double length = Math.Sqrt(nx * nx + ny * ny + nz * nz);
                    nx /= length;
                    ny /= length;
                    nz /= length;

                    // ”гол между нормалью и направлением взгл€да
                    double dotProduct = nx * viewDirectionX + ny * viewDirectionY + nz * viewDirectionZ;

                    if (dotProduct > 0) // √рань видна
                    {
                        // »нтерполаци€ интенсивности освещени€ в вершинах
                        double l1 = 0.5 + 0.5 * dotProduct; // »нтенсивность в вершине (i, j)

                        Point[] polygonPoints = new Point[]
                        {
                            new Point((int)vertices[i, j].X, (int)vertices[i, j].Y),
                            new Point((int)vertices[i, j + 1].X, (int)vertices[i, j + 1].Y),
                            new Point((int)vertices[i + 1, j + 1].X, (int)vertices[i + 1, j + 1].Y),
                            new Point((int)vertices[i + 1, j].X, (int)vertices[i + 1, j].Y)
                        };

                        // »нтерполаци€ цвета
                        int red = (int)(l1 * 255);
                        int green = (int)(l1 * 255);
                        int blue = (int)(l1 * 255);

                        Color color = Color.FromArgb(red, green, blue);
                        Brush brush = new SolidBrush(color);
                        g.FillPolygon(brush, polygonPoints);
                    }
                }
            }

            pictureBox.Refresh();
        }



        public Color InterpolateColor(Color color1, Color color2, double t)
        {
            if (t < 0)
                t = 0;
            else if (t > 1)
                t = 1;

            int red = (int)(color1.R + (color2.R - color1.R) * t);
            int green = (int)(color1.G + (color2.G - color1.G) * t);
            int blue = (int)(color1.B + (color2.B - color1.B) * t);

            return Color.FromArgb(red, green, blue);
        }
    }
}





