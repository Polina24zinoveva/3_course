using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KG_LR4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static Bitmap image; //Bitmap для открываемого изображения
        Bitmap bmp;

        //public Bitmap image { get; set; }

        private void originalPictureButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    image = new Bitmap(open_dialog.FileName);
                    originalPicture.Image = image;
                    originalPicture.Invalidate();
                    bmp = new Bitmap(originalPicture.Image, originalPicture.Width, originalPicture.Height);
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void grayOttenkiButton_Click(object sender, EventArgs e)
        {
            //Bitmap bmp = new Bitmap(image, image.Width, image.Height);
            bmp = new Bitmap(originalPicture.Image, originalPicture.Width, originalPicture.Height);

            Color color;
            int rgbColor;
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    color = bmp.GetPixel(x, y);
                    rgbColor = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    bmp.SetPixel(x, y, Color.FromArgb(rgbColor, rgbColor, rgbColor));
                }
            }
            grayOttenki.Image = bmp;
        }

        private void Preparirovanie_SelectedIndexChanged(object sender, EventArgs e)
        {
            int max = Convert.ToInt32(maxPrepar.Text);
            int min = Convert.ToInt32(minPrepar.Text);

            Bitmap bmp1 = new Bitmap(grayOttenki.Image, grayOttenki.Width, grayOttenki.Height);
            Color color;
            int rgbColor;
            

            if (Preparirovanie.SelectedIndex == 0)
            {
                for (int y = 0; y < bmp1.Height; y++)
                {
                    for (int x = 0; x < bmp1.Width; x++)
                    {
                        color = bmp1.GetPixel(x, y);
                        rgbColor = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                        if (rgbColor > max)
                        {
                            bmp1.SetPixel(x, y, Color.White);
                        }
                        else if (rgbColor < min)
                        {
                            bmp1.SetPixel(x, y, Color.Black);
                        }
                        else
                        {
                            int greyY = (int)(((rgbColor - min) * 255) / (max - min));
                            bmp1.SetPixel(x, y, Color.FromArgb(greyY, greyY, greyY));
                        }
                    }
                }
            }
            else if (Preparirovanie.SelectedIndex == 1)
            {
                for (int y = 0; y < bmp1.Height; y++)
                {
                    for (int x = 0; x < bmp1.Width; x++)
                    {
                        color = bmp1.GetPixel(x, y);
                        rgbColor = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                        if ((rgbColor > max) || (rgbColor < min))
                        {
                            bmp1.SetPixel(x, y, Color.Black);
                        }
                        else
                        {
                            int greyY = (int)(((rgbColor - min) * 255) / (max - min));
                            bmp1.SetPixel(x, y, Color.FromArgb(greyY, greyY, greyY));
                        }
                    }
                }
            }
            else if (Preparirovanie.SelectedIndex == 2)
            {
                for (int y = 0; y < bmp1.Height; y++)
                {
                    for (int x = 0; x < bmp1.Width; x++)
                    {
                        color = bmp1.GetPixel(x, y);
                        rgbColor = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                        if ((rgbColor > max) || (rgbColor < min))
                        {
                            bmp1.SetPixel(x, y, Color.White);
                        }
                        else
                        {
                            int greyY = (int)(((rgbColor - min) * 255) / (max - min));
                            bmp1.SetPixel(x, y, Color.FromArgb(greyY, greyY, greyY));

                        }
                    }
                }
            }
            else if (Preparirovanie.SelectedIndex == 3)
            {
                for (int y = 0; y < bmp1.Height; y++)
                {
                    for (int x = 0; x < bmp1.Width; x++)
                    {
                        color = bmp1.GetPixel(x, y);
                        rgbColor = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                        if ((rgbColor > max) || (rgbColor < min))
                        {
                            bmp1.SetPixel(x, y, Color.Gray);
                        }
                        else
                        {
                            int greyY = (int)(((rgbColor - min) * 255) / (max - min));
                            bmp1.SetPixel(x, y, Color.FromArgb(greyY, greyY, greyY));

                        }
                    }
                }
            }
            preparirovaniePicture.Image = bmp1;

        }

        private void MaskFilterButton_Click_(object sender, EventArgs e)
        {
            Bitmap bmp11 = new Bitmap(grayOttenki.Image, grayOttenki.Width, grayOttenki.Height);

            Bitmap bmp1 = new Bitmap(grayOttenki.Width + 2, grayOttenki.Height + 2);
            Bitmap result = new Bitmap(grayOttenki.Width + 2, grayOttenki.Height + 2);

            Bitmap result1 = new Bitmap(grayOttenki.Width, grayOttenki.Height);

            for (int i = 0; i < bmp1.Width; i++)
            {
                bmp1.SetPixel(i, 0, Color.White);
            }
            for (int i = 0; i < bmp1.Height; i++)
            {
                bmp1.SetPixel(0, i, Color.White);
            }
            for (int i = 0; i < bmp1.Width; i++)
            {
                bmp1.SetPixel(i, bmp1.Height - 1, Color.White);
            }
            for (int i = 0; i < bmp1.Height; i++)
            {
                bmp1.SetPixel(bmp1.Width - 1, i, Color.White);
            }
            for (int y = 0; y < bmp1.Height - 1; y++)
            {
                for (int x = 0; x < bmp1.Width - 1; x++)
                {
                    if (x + 1 < bmp11.Width && y + 1 < bmp11.Height)
                    {
                        bmp1.SetPixel(x, y, bmp11.GetPixel(x + 1, y + 1));

                    }
                }
            }

            int[,] mask = { { -1, 0, 0 }, { 0, 0, 0 }, { 0, 0, 1 } };

            double a = 0.5 * FindMaxYarkost(bmp1);
            double b = 0.5;

            double yarkost;

            for (int y = 1; y < bmp1.Height - 1; y++)
            {
                for (int x = 1; x < bmp1.Width - 1; x++)
                {
                    yarkost = a + b * (
                        bmp1.GetPixel(x - 1, y - 1).R * mask[0, 0] +
                        /*bmp1.GetPixel(x - 1, y).R * mask[0, 0] +
                        bmp1.GetPixel(x - 1, y + 1).R * mask[0, 0] +
                        bmp1.GetPixel(x, y - 1).R * mask[0, 0] +
                        bmp1.GetPixel(x, y).R * mask[0, 0] +
                        bmp1.GetPixel(x, y + 1).R * mask[0, 0] +
                        bmp1.GetPixel(x + 1, y - 1).R * mask[0, 0] +
                        bmp1.GetPixel(x + 1, y).R * mask[0, 0] +*/
                        bmp1.GetPixel(x + 1, y + 1).R * mask[2, 2]);
                    if (yarkost > 255)
                        yarkost = 255;
                    else if (yarkost < 0)
                        yarkost = 0;

                    result.SetPixel(x, y, Color.FromArgb((int)yarkost, (int)yarkost, (int)yarkost));
                }
            }

            for (int y = 1; y < result.Height - 1; y++)
            {
                for (int x = 1; x < result.Width - 1; x++)
                {
                    result1.SetPixel(x - 1, y - 1, result.GetPixel(x, y));
                }
            }
            maskFilter.Image = result1;

        }

        private void MaskFilterButton_Click(object sender, EventArgs e)
        {
            //Bitmap bmp = new Bitmap(image, image.Width, image.Height);
            //Bitmap result = new Bitmap(image.Width, image.Height);
            Bitmap bmp1 = new Bitmap(grayOttenki.Image, grayOttenki.Width, grayOttenki.Height);
            Bitmap result = new Bitmap(grayOttenki.Width, grayOttenki.Height);


            int[,] mask = { { -1, 0, 0 }, { 0, 0, 0 }, { 0, 0, 1 } };

            double a = 0.5 * FindMaxYarkost(bmp);
            double b = 0.5;

            double yarkost;

            for (int y = 1; y < bmp1.Height - 1; y++)
            {
                for (int x = 1; x < bmp1.Width - 1; x++)
                {
                    yarkost = a + b * (
                        bmp1.GetPixel(x - 1, y - 1).R * mask[0, 0] +
                        /*bmp.GetPixel(x - 1, y).R * mask[0, 0] +
                        bmp.GetPixel(x - 1, y + 1).R * mask[0, 0] +
                        bmp.GetPixel(x, y - 1).R * mask[0, 0] +
                        bmp.GetPixel(x, y).R * mask[0, 0] +
                        bmp.GetPixel(x, y + 1).R * mask[0, 0] +
                        bmp.GetPixel(x + 1, y - 1).R * mask[0, 0] +
                        bmp.GetPixel(x + 1, y).R * mask[0, 0] +*/
                        bmp1.GetPixel(x + 1, y + 1).R * mask[2, 2] );
                    if (yarkost > 255)
                        yarkost = 255;
                    else if (yarkost < 0)
                        yarkost = 0;

                    result.SetPixel(x, y, Color.FromArgb((int)yarkost, (int)yarkost, (int)yarkost));
                }
            }
            maskFilter.Image = result;
        }

        private int FindMaxYarkost(Bitmap bmp)
        {
            Color color;
            int rgbColor;
            int maxx = 0;
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    color = bmp.GetPixel(x, y);
                    rgbColor = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    if (rgbColor > maxx) { maxx = rgbColor; }
                }
            }
            return maxx;
        }

        private void zadanie4Button_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
            
        }

    }
}
