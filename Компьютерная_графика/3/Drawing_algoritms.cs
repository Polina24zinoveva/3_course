using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace KG_LR3
{
    internal class Drawing_algoritms
    {
        public Bitmap field { get; set; }

        public Drawing_algoritms(int width, int height)
        {
            field = new Bitmap(width, height);
        }

        //линия
        public void BresenhamLine(int x0, int y0, int x1, int y1, Color color)
        {
            // Если линия растёт не слева направо, то меняем начало и конец отрезка местами
            if (x0 > x1)
            {
                var vedro = x0;
                x0 = x1;
                x1 = vedro;

                vedro = y0;
                y0 = y1;
                y1 = vedro;
            }
            int x = x0;
            int y = y0;
            int dx = x1 - x0;
            int dy = Math.Abs(y1 - y0);
            if (dx == 0 & dy == 0)
            {
                DrawPoint(x, y, color);
                return;
            }
            int i = 0;
            DrawPoint(x, y, color);
            if (dx > dy)
            {
                double m = (double)dy / (double)dx;
                double e = m - 0.5;
                while (i < dx)
                {
                    if (e >= 0)
                    {
                        if (y0 < y1) { y += 1; }
                        else { y -= 1; }
                        e += m - 1;
                    }
                    else {e += m;}
                    x++;
                    DrawPoint(x, y, color);
                    i++;
                }
            }
            else
            {
                double m = (double)dx / (double)dy;
                double e = m - 0.5;
                while (i < dy)
                {
                    if (e >= 0)
                    {
                        if (x0 < x1) { x += 1; }
                        else { x -= 1; }
                        e += m - 1;
                    }
                    else {e += m;}
                    DrawPoint(x, y, color);
                    if (y0 < y1) { y += 1; }
                    else { y -= 1; }
                    i++;
                }
            }
            
        }

        //круг
        public void NaturalCircle(int x0, int y0, int r, Color color)
        {
            for (int x = x0 - r; x < x0 + r + 1; x++)
            {
                DrawPoint(x, y0 + Convert.ToInt32(Math.Sqrt(Math.Pow(r, 2) - Math.Pow(Math.Abs(x - x0), 2))), color);
                DrawPoint(x, y0 - Convert.ToInt32(Math.Sqrt(Math.Pow(r, 2) - Math.Pow(Math.Abs(x - x0), 2))), color);
            }
        }

        //круг для закраски
        public void NaturalCircleForZakraska(int x0, int y0, int r, Color color)
        {
            for (int x = x0 - r; x < x0 + r + 1; x++)
            {
                DrawPoint(x, y0 + Convert.ToInt32(Math.Sqrt(Math.Pow(r, 2) - Math.Pow(Math.Abs(x - x0), 2))), color);
                DrawPoint(x, y0 - Convert.ToInt32(Math.Sqrt(Math.Pow(r, 2) - Math.Pow(Math.Abs(x - x0), 2))), color);
            }
            for (int y = y0 - r; y < y0 + r + 1; y++)
            {
                DrawPoint(x0 + Convert.ToInt32(Math.Sqrt(Math.Pow(r, 2) - Math.Pow(Math.Abs(y - y0), 2))), y, color);
                DrawPoint(x0 - Convert.ToInt32(Math.Sqrt(Math.Pow(r, 2) - Math.Pow(Math.Abs(y - y0), 2))), y, color);
            }
        }

        //кривая
        public void Bezie(List<Tuple<int, int>> orientiru, Color color)
        {
            orientiru = GetBeziePoints(orientiru, 0.01);
            for (int i = 0; i < orientiru.Count - 1; i++)
            {
                BresenhamLine(orientiru[i].Item1, orientiru[i].Item2, orientiru[i + 1].Item1, orientiru[i + 1].Item2, color);
            }
        }

        private List<Tuple<int, int>> GetBeziePoints(List<Tuple<int, int>> orientiru , double step)
        {
            List<Tuple<int, int>> results = new List<Tuple<int, int>>();
            int m = orientiru.Count - 1;
            for (double t = 0; t < 1; t += step)
            {
                double x = 0;
                double y = 0;
                for (int i = 0; i <= m; i++)
                {
                    x += (Sochetania(m, i) * Math.Pow(t, i) * Math.Pow(1 - t, m - i) * orientiru[i].Item1);
                    y += (Sochetania(m, i) * Math.Pow(t, i) * Math.Pow(1 - t, m - i) * orientiru[i].Item2);
                }
                results.Add(Tuple.Create((int)x, (int)y));
            }
            return results;
        }
        private int Sochetania(int m, int i)
        {
            return Convert.ToInt32(Factorial(m) / (Factorial(i) * Factorial(m - i)));
        }

        private int Factorial(int n)
        {
            if (n == 1 || n == 0) return 1;
            return n * Factorial(n - 1);
        }

        //закраска
        public void ZapolneniePoligonov(List<Tuple<int, int, int, int>> otrezki1, Color color)
        {
            if (otrezki1.Count == 0){return;}
            List<int> xj = new List<int>();
            List<Tuple<int, int, int, int>> otrezki = new List<Tuple<int, int, int, int>>();
            int x = 0;
            int ymax = otrezki1[0].Item2;
            int ymin = otrezki1[0].Item2;

            for (int i = 0; i < otrezki1.Count; i++)
            {
                if (Math.Max(otrezki1[i].Item2, otrezki1[i].Item4) > ymax) { ymax = Math.Max(otrezki1[i].Item2, otrezki1[i].Item4); }
                if (Math.Min(otrezki1[i].Item2, otrezki1[i].Item4) < ymin) { ymin = Math.Min(otrezki1[i].Item2, otrezki1[i].Item4); }
            }

            for (int i = 0; i < otrezki1.Count; i++)
            {
                if (otrezki1[i].Item2 > otrezki1[i].Item4)
                {
                    otrezki.Add(Tuple.Create(otrezki1[i].Item3, otrezki1[i].Item4, otrezki1[i].Item1, otrezki1[i].Item2));
                }
                else
                {
                    otrezki.Add(Tuple.Create(otrezki1[i].Item1, otrezki1[i].Item2, otrezki1[i].Item3, otrezki1[i].Item4));
                }
            }

            for (int y = ymin; y < ymax; y++)
            {
                foreach (Tuple<int, int, int, int> otrezok in otrezki) {
                    if ((otrezok.Item2 <= y && otrezok.Item4 >= y) || (otrezok.Item2 >= y && otrezok.Item4 <= y))
                    {
                        if (otrezok.Item2 - otrezok.Item4 != 0)
                        {
                            x = otrezok.Item1 + (otrezok.Item2 - y) * (otrezok.Item3 - otrezok.Item1) / (otrezok.Item2 - otrezok.Item4);
                            xj.Add(x);
                        }
                        else
                        {
                            xj.Add(otrezok.Item1);
                            xj.Add(otrezok.Item2);
                        }
                    }
                }
                xj.Sort();
                for (int i = 0; i < xj.Count - 1; i += 2)
                {
                    if (Math.Abs(xj[i] - xj[i + 1]) < 2) 
                    { 
                        {
                            xj.RemoveAt(i + 1);
                        }
                    }
                }
                for (int i = 0; i < xj.Count - 1; i+=2)
                {
                    BresenhamLine(xj[i], y, xj[i + 1], y, color);
                }
                xj.Clear();
            }
            otrezki1.Clear();
            otrezki.Clear();
        }

        /*public void ZapolneniePoligonov(List<Tuple<int, int>> orientiru, Color color)
        {
            if (orientiru.Count == 0) { return; }
            int x0, x1;
            List<int> xj = new List<int>();
            int ymax = orientiru[0].Item2;
            int ymin = orientiru[0].Item2;
            int xmax = orientiru[0].Item1;
            int xmin = orientiru[0].Item1;
            for (int i = 0; i < orientiru.Count; i++)
            {
                if (orientiru[i].Item2 > ymax) { ymax = orientiru[i].Item2; }
                if (orientiru[i].Item2 < ymin) { ymin = orientiru[i].Item2; }
                if (orientiru[i].Item1 > xmax) { xmax = orientiru[i].Item1; }
                if (orientiru[i].Item1 < xmin) { xmin = orientiru[i].Item1; }
            }
            if (ymin < 0) { ymin = 0; }
            if (ymax > field.Height) { ymax = field.Height; }
            if (xmin < 0) { xmin = 0; }
            if (xmax > field.Width) { xmax = field.Width; }
            for (int y = ymin; y < ymax; y++)
            {
                for (int x = xmin; x <= xmax; x++)
                {
                    if (field.GetPixel(x, y).ToArgb() == Color.Black.ToArgb())
                    {
                        x0 = x;
                        while (field.GetPixel(x, y).ToArgb() == Color.Black.ToArgb())
                        {
                            x++;
                        }
                        x1 = x;
                        xj.Add((x0 + x1) / 2);
                    }
                }
                if (xj.Count == 1) { DrawPoint(xj[0], y, color); }
                else if (xj.Count == 2) { BresenhamLine(xj[0], y, xj[1], y, color); }
                else if (xj.Count % 3 == 0)
                {
                    for (int i = 0; i < xj.Count; i += 3)
                    {
                        if ((field.GetPixel((xj[i] + xj[i + 1]) / 2, y - 1).ToArgb() == color.ToArgb()) & (field.GetPixel((xj[i + 1] + xj[i + 2]) / 2, y - 1).ToArgb() == color.ToArgb()))
                        {
                            BresenhamLine(xj[i], y, xj[i + 2], y, color);
                        }
                        else if (field.GetPixel((xj[i] + xj[i + 1]) / 2, y - 1).ToArgb() == color.ToArgb())
                        {
                            BresenhamLine(xj[i], y, xj[i + 1], y, color);
                            DrawPoint(xj[i + 2], y, color);
                        }
                        else if (field.GetPixel((xj[i + 1] + xj[i + 2]) / 2, y - 1).ToArgb() == color.ToArgb())
                        {
                            DrawPoint(xj[i], y, color);
                            BresenhamLine(xj[i + 1], y, xj[i + 2], y, color);
                        }
                    }
                }
                else if (xj.Count % 4 == 0)
                {
                    for (int i = 0; i < xj.Count; i += 4)
                    {
                        BresenhamLine(xj[i], y, xj[i + 1], y, color);
                        BresenhamLine(xj[i + 2], y, xj[i + 3], y, color);
                    }
                }
                xj.Clear();
                orientiru.Clear();
            }
        }*/

        //Алгоритм короеда
        public void KoroedAlgoritm(int x, int y, Color backColor, Color fill_color, Color pattern_color, byte[][] pattern)
        {

            List<List<int>> stek = new List<List<int>>();
            stek.Add(new List<int> { x, y });
            while (stek.Count > 0)
            {
                List<int> pixel = stek[stek.Count - 1];
                Color c = field.GetPixel(pixel[0], pixel[1]);
                c.ToArgb();
                if ( (field.GetPixel(pixel[0], pixel[1]).ToArgb() != Color.Black.ToArgb()) && (field.GetPixel(pixel[0], pixel[1]).ToArgb() != fill_color.ToArgb()) && (field.GetPixel(pixel[0], pixel[1]).ToArgb() != pattern_color.ToArgb()) )
                {
                    DrawPointYzor(pixel[0], pixel[1], fill_color, pattern_color, pattern);

                    if (!stek.Any(o => o.SequenceEqual(new[] { pixel[0] + 1, pixel[1] }) && field.GetPixel(pixel[0] + 1, pixel[1]).ToArgb() != Color.Black.ToArgb()) && (field.GetPixel(pixel[0] + 1, pixel[1]).ToArgb() != fill_color.ToArgb()) && (field.GetPixel(pixel[0] + 1, pixel[1]).ToArgb() != pattern_color.ToArgb()))
                    { 
                        stek.Add(new List<int> { pixel[0] + 1, pixel[1] }); 
                    }
                    if (!stek.Any(o => o.SequenceEqual(new[] { pixel[0], pixel[1] + 1 }) && field.GetPixel(pixel[0], pixel[1] + 1).ToArgb() != Color.Black.ToArgb()) && (field.GetPixel(pixel[0], pixel[1] + 1).ToArgb() != fill_color.ToArgb()) && (field.GetPixel(pixel[0], pixel[1] + 1).ToArgb() != pattern_color.ToArgb()))
                    { 
                        stek.Add(new List<int> { pixel[0], pixel[1] + 1 }); 
                    }
                    if (!stek.Any(o => o.SequenceEqual(new[] { pixel[0] - 1, pixel[1] }) && field.GetPixel(pixel[0] - 1, pixel[1]).ToArgb() != Color.Black.ToArgb()) && (field.GetPixel(pixel[0] - 1, pixel[1]).ToArgb() != fill_color.ToArgb()) && (field.GetPixel(pixel[0] - 1, pixel[1]).ToArgb() != pattern_color.ToArgb()))
                    { 
                        stek.Add(new List<int> { pixel[0] - 1, pixel[1] }); 
                    }
                    if (!stek.Any(o => o.SequenceEqual(new[] { pixel[0], pixel[1] - 1 }) && field.GetPixel(pixel[0], pixel[1] - 1).ToArgb() != Color.Black.ToArgb()) && (field.GetPixel(pixel[0], pixel[1] - 1).ToArgb() != fill_color.ToArgb()) && (field.GetPixel(pixel[0], pixel[1] - 1).ToArgb() != pattern_color.ToArgb()))
                    { 
                        stek.Add(new List<int> { pixel[0], pixel[1] - 1 }); 
                    }
                }
                stek.Remove(pixel);
            }

        }


        private void DrawPointYzor(int x, int y, Color fill_color, Color pattern_color, byte[][] pattern)
        {
            if (x > 0 & x < field.Width & y > 0 & y < field.Height)
                field.SetPixel(x, y, fill_color);
            field.SetPixel(x, y, SetColor(x, y, fill_color, pattern_color, pattern));
        }

        private Color SetColor(int x, int y, Color fill_color, Color pattern_color, byte[][] pattern)
        {
            Color[] colors = { fill_color, pattern_color };
            byte m = pattern[x % pattern[0].Length][y % pattern.Length];
            return colors[m];
        }

        private void DrawPoint(int x, int y, Color color)
        {
            if (x > 0 & x < field.Width & y > 0 & y < field.Height)
                field.SetPixel(x, y, color);

        }
    }
}
