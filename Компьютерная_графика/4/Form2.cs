using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*(У зеленого наибольший коэффициент, это связано с воприятием глаза)
Вопросы по теории:
 1.Линейное контрастирование малоконтрастного изображения.
Это поэлементное преобразование. Контрастность - разность между самым ярким и самым темный пикселами изображения. Чем больше разность, тем контрастнее изображение. 
Линейное контрастирование происходит с помощью линейной формулы g =af+b, f - яркость пиксела до преобразования, g - яркость пиксела после преобразования ( формула яркости: r = g = b = 0,299r + 0,587g + 0,114b). С помощью системы уравнений для gmin и gmax находим коэффициенты а, b
          (Пороговая обработка: выделяется значение порога, и все пикселы яркость которых больше порога, то они становятся белыми, которых меньше порога, становятся черными.По сути перевод из цветного изображения(или изображения в оттенках серого) в черно белое)

   2.  Препарирование изображений.
Приведение изображения к виду, возможно далекому от естественного, но удобному для дальнейшего машинного анализа. Напоминает преобразование пороговой обработки. Выбирается рабочий диапазон и происходят изменения в соответствии с заданной функцией(например для г: пикселы яркость которых меньше рабочего диапазон становятся черными, больше становятся белыми. Яркости пикселей растягиваются по рабочему диапазону)

 3.Градиентный метод выделения контуров на изображении.
Контур изображения - совокупность его пикселов, в окрестности которых наблюдается скачкообразное изменение функции яркости.
Состоит из 2 этапов: 1 - подчеркивание контуров, 2 - пороговая обработка.Для каждого пикселя ищется его градиент
 
Далее применяется пороговая обработка

  4. Утончение линий и выделение связных контуров при помощи алгоритма Зонга-Суена.
Состоит из 2 подытераций: 
 
 
Алгоритм является параллельным, т.е. все пикселы изображения должны обрабатываться одновременно. Для этого надо взять 2 области памяти( в первой хранится старое изображение, во второй будем записывать преобразованные значения яркости). Итерации происходят пока хотя бы 1 пиксел с изображения удалился.

 5. Утончение линий и выделение связных контуров при помощи эвристического алгоритма.
Высчитывается 2 локальные плотности : d - плотность изображения для пиксела с помощью его соседей и D плотность локальных плотностей. Пиксел останется на изображении, если d>F1 и D>F2, где F1, F2 - некоторые константы, которые подбираются экспериментально для каждого изображения

 6. Линейная масочная фильтрация.
Маски=матрицы. Яркость каждого пиксела вычисляется по формуле
 
В - нормирующий коэффициент, он необходим, чтобы яркость не увеличилась очень сильно и не получилось в итоге засвеченное изображение.
https://www.youtube.com/watch?v=qinfTWzbehM (https://www.youtube.com/watch?v=qinfTWzbehM)

 7.Нелинейная масочная фильтрация.Медианный фильтр.
Позволяет удалять точечные шумы. Берется пиксел, и рассматриваются его соседи. Эти 9 элементов заносятся в массив, он сортируется и находится медиана(элемент по середине) этого массива.И вместо предыдущей яркости ставится новое медианное значение.Если в массиве будет четное количество элементов(на краях изображения), то медиана находится как среднее арифметическое между 2 центральными элементами массива.
Фильтр немного размывает изображение, за счет усреднения.

 8. Векторизация растровых изображений. Преобразование Хафа.
На вход получаем изобрадение- растр точек, на выход хотим получить уравнение линий, которые находятся на этом изображении.
При помощи обычной формулы для прямых y=kx+b не описываются вертикальные прямые(х=3), поэтому удобнее пользоваться заданием прямой в полярной системе координат: 
 
1 отрезок в декартовой системе координат задает 1 точку(ро, тетта) в пространстве Хафа.
Через 1 точку в декартовой системе координат можно провести бесконечное количество прямых, каждая из которых имеет свое значение ро и тетта, поэтому 1 точке в декартовой системе координат соответствует набор точек в пространстве Хафа(образуют синусоиду)
Алгоритм:
Имеем отрезок, состоящий из точек изображения в д.с.к которая является синусоидой в пространстве Хафа. Точка пересечения синусоид- соответствует параметру прямой.
    Более подробный алгоритм:
1 этап: задание пространства Хафа.Пространство Хафа-двумерный массив. Идеи по всем точкам изображения. Если точка- черная, то она может принадлежать пространству Хафа. Все точки в которых лежит синусоида отмечаются += 1.
2 этап: выделение точек пересечения синусоид(нахождение локальных максимумов в пространстве Хафа)*/
namespace KG_LR4
{
    public partial class Form2 : Form
    {
        int[] p = new int[8];

        public Form2()
        {
            InitializeComponent();
        }

        //form1.ShowDialog();

        Bitmap image;
        Bitmap bmp;
        Bitmap field;


        //Bitmap bmp = Form1.bmp;

        int[,] matricaYarkostey;
        int[,] matricaB_W;

        int[,] originalZS;
        int[,] resultZS;

        int[,] evristic;

        int[,] waveOriginal;

        int width;
        int height;

        int countClickToFirstButton = 0;

        private void originalPictureButton_Click(object sender, EventArgs e)
        {
            countClickToFirstButton++;
            if (countClickToFirstButton == 1)
            {

                OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
                open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
                if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
                {
                    try
                    {
                        image = new Bitmap(open_dialog.FileName);
                        firstPicture.Image = image;
                        firstPicture.Invalidate();
                        bmp = new Bitmap(image, image.Width, image.Height);
                        width = bmp.Width;
                        height = bmp.Height;
                    }
                    catch
                    {
                        DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                firstPictureButton.Text = "Алгоритм Зонга-Суена";

                FromPictureToMatrix();
                ConvertToBlackAndWhite();
            }
            if (countClickToFirstButton == 2)
            {
                countClickToFirstButton = 0;
                firstPictureButton.Text = "Загрузить изображение";
                ZongSyenButton_Click();
            }


        }


        private void FromPictureToMatrix()
        {
            matricaYarkostey = new int[height, width];
            Color color;
            int rgbColor;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    color = bmp.GetPixel(x, y);
                    rgbColor = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    matricaYarkostey[y, x] = rgbColor;
                }
            }
        }

        private void ConvertToBlackAndWhite()      
        {
            matricaB_W = new int[height, width];
            if (matricaYarkostey != null)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (matricaYarkostey[y, x] < 128)
                            matricaB_W[y, x] = 1;
                        else matricaB_W[y, x] = 0;
                    }   
                } 
            }
        }

        private void ZongSyenButton_Click()
        {
            originalZS = new int[height, width];
            for (int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    originalZS[y, x] = matricaB_W[y, x];
                }
            }

            bool deleted = true;
            int a;
            int b;
            resultZS = new int[height, width];

            while (deleted)
            {
                deleted = false;

                //подытерация 1
                for (int y = 1; y < height - 1; y++)
                {
                    for (int x = 1; x < width - 1; x++)
                    {
                        a = 0;
                        b = 0;

                        p[0] = originalZS[y - 1, x];
                        p[1] = originalZS[y - 1, x + 1];
                        p[2] = originalZS[y, x + 1];
                        p[3] = originalZS[y + 1, x + 1];
                        p[4] = originalZS[y + 1, x];
                        p[5] = originalZS[y + 1, x - 1];
                        p[6] = originalZS[y, x - 1];
                        p[7] = originalZS[y - 1, x - 1];

                        for (int i = 0; i < p.Length - 1; i++)
                        {
                            if ((p[i] == 0) && (p[i + 1] == 1))
                            {
                                a++;
                            }
                        }
                        if (p[7] == 0 && p[0] == 1) { a++; }
                        b = p.Sum();
                        int p1 = p[0] * p[2] * p[4];
                        int p2 = p[2] * p[4] * p[6];
                        if ((2 <= b) && (b <= 6) && (a == 1) && (p1 == 0) && (p2 == 0))
                        {
                            resultZS[y, x] = 1;
                            if (originalZS[y, x] != 0)
                            {
                                //originalZS[y, x] = 0;
                                deleted = true;
                            }
                        }
                        else
                        {
                            resultZS[y, x] = 0;
                        }
                    }
                }
                RefreshThinLineMatr();

                //подытерация 2
                for (int y = 1; y < height - 1; y++)
                {
                    for (int x = 1; x < width - 1; x++)
                    {
                        a = 0;
                        b = 0;
                        p[0] = originalZS[y - 1, x];
                        p[1] = originalZS[y - 1, x + 1];
                        p[2] = originalZS[y, x + 1];
                        p[3] = originalZS[y + 1, x + 1];
                        p[4] = originalZS[y + 1, x];
                        p[5] = originalZS[y + 1, x - 1];
                        p[6] = originalZS[y, x - 1];
                        p[7] = originalZS[y - 1, x - 1];

                        for (int i = 0; i < p.Length - 1; i++)
                        {
                            if ((p[i] == 0) && (p[i + 1] == 1))
                            {
                                a++;
                            }
                        }
                        if (p[7] == 0 && p[0] == 1) { a++; }
                        b = p.Sum();
                        int p1 = p[0] * p[2] * p[6];
                        int p2 = p[0] * p[4] * p[6];
                        if (((2 <= b) && (b <= 6)) && (a == 1) && (p1 == 0) && (p2 == 0))
                        {
                            resultZS[y, x] = 1;
                            if (originalZS[y, x] != 0)
                            {
                                //originalZS[y, x] = 0;
                                deleted = true;
                            }
                        }
                        else
                        {
                            resultZS[y, x] = 0;
                        }
                    }
                }
                RefreshThinLineMatr();
            }
            FromMatrixToPicture(originalZS);
            firstPicture.Image = bmp;

        }

        private void RefreshThinLineMatr()     //удаление помеченных пикселей в алгоритме З-С
        {
            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                    if (resultZS[y, x] == 1)
                        originalZS[y, x] = 0;
        }
        

        private void FromMatrixToPicture(int[,] matrix)                 
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (matrix[y, x] == 0)
                    {
                        bmp.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        bmp.SetPixel(x, y, Color.Black);
                    }
                }
            }
        }

        private void Evristicheskiy_algoritmButton_Click(object sender, EventArgs e)
        {
            evristic = new int[height, width];
            int[,] d = new int[height, width];
            int[,] D = new int[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    evristic[y, x] = matricaB_W[y, x];
                }
            }
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    d[y, x] = (
                        (evristic[y - 1, x - 1] - evristic[y, x]) +
                        (evristic[y - 1, x] - evristic[y, x]) +
                        (evristic[y - 1, x + 1] - evristic[y, x]) +
                        (evristic[y, x - 1] - evristic[y, x]) +
                        (evristic[y, x] - evristic[y, x]) +
                        (evristic[y, x + 1] - evristic[y, x]) +
                        (evristic[y + 1, x - 1] - evristic[y, x]) +
                        (evristic[y + 1, x] - evristic[y, x]) +
                        (evristic[y + 1, x + 1] - evristic[y, x]));
                }
            }
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    D[y, x] = (
                        (d[y - 1, x - 1] - d[y, x]) +
                        (d[y - 1, x] - d[y, x]) +
                        (d[y - 1, x + 1] - d[y, x]) +
                        (d[y, x - 1] - d[y, x]) +
                        (d[y, x] - d[y, x]) +
                        (d[y, x + 1] - d[y, x]) +
                        (d[y + 1, x - 1] - d[y, x]) +
                        (d[y + 1, x] - d[y, x]) +
                        (d[y + 1, x + 1] - d[y, x]));
                }
            }
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (d[y, x] < 1 && D[y, x] < 10)
                    {
                        evristic[y, x] = 0;
                    }
                }
            }
            FromMatrixToPicture(evristic);
            evristicPicture.Image = bmp;

        }

        private void WaveButton_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = new Bitmap(width, height);
            field = new Bitmap(width, height);


            int color;
            int x0 = 0;
            int y0 = 0;
            int x = 0;
            int y = 0;

            waveOriginal = new int[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    waveOriginal[i, j] = matricaB_W[i, j];
                }
            }

            int[,] waveResult = new int[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    waveResult[i, j] = matricaB_W[i, j];
                }
            }

            List<List<int>> queue = new List<List<int>>();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (waveOriginal[j, i] != 0)
                    {
                        queue.Add(new List<int> { i, j });
                        goto Reducted;
                    }
                }
            }

        //создание волн
        Reducted:


            x0 = queue[0][0];
            y0 = queue[0][1];

            List<List<int>> queueLeft = new List<List<int>>();


            waveResult[y0, x0] = 2;

            while (queue.Count > 0)
            {
                x = queue[0][0];
                y = queue[0][1];
                color = waveResult[y, x];
                color++;
                if (color == 4)
                {
                    color = 2;
                }
                for (int i = 1; i >= -1; i--)
                {
                    for (int j = 1; j >= -1; j--)
                    {
                        if (y + i >= 0 && x + j >= 0 && y + i < waveResult.GetLength(0) - 1 && x + j < waveResult.GetLength(1) - 1 && waveResult[y + i, x + j] == 1)
                        {
                            waveResult[y + i, x + j] = color;
                            queue.Add(new List<int> { x + j, y + i });
                        }
                    }
                }
                queue.RemoveAt(0);
            }
            x = 0;
            y = 0;
            queue.Clear();

            //вывод волн

            for (int y7 = 0; y7 < height; y7++)
            {
                for (int x7 = 0; x7 < width; x7++)
                {
                    if (waveResult[y7, x7] == 2)
                    {
                        bmp.SetPixel(x7, y7, Color.White);
                    }
                    else if (waveResult[y7, x7] == 3)
                    {
                        bmp.SetPixel(x7, y7, Color.Black);
                    }
                    else
                    {
                        bmp.SetPixel(x7, y7, Color.White);
                    }
                }
            }
            hafPicture.Image = bmp;

            //создание скелета
            List<List<int>> wave = new List<List<int>>();
            List<List<int>> skeletPoints = new List<List<int>>();
            List<List<int>> proverenu = new List<List<int>>();

            queue.Add(new List<int> { x0, y0 });
            bool waveNotFinished;
            while (queue.Count > 0 || queueLeft.Count > 0)
            {
                if (queue.Count > 0)
                {
                    waveNotFinished = true;
                    wave.Add(new List<int> { queue[0][0], queue[0][1] });
                    color = waveResult[wave[wave.Count - 1][1], wave[wave.Count - 1][0]];
                    if (MyContains(queue[0][0], queue[0][1], proverenu) == false)
                    {
                        proverenu.Add(new List<int> { queue[0][0], queue[0][1] });
                        while (waveNotFinished)
                        {
                            waveNotFinished = false;
                            if (color != 0)
                            {
                                x = wave[wave.Count - 1][0];
                                y = wave[wave.Count - 1][1];
                                waveResult[y, x] = 0;
                                waveNotFinished = false;

                                if (x < width - 1 && waveResult[y, x + 1] == color)
                                {
                                    wave.Add(new List<int> { x + 1, y });
                                    waveResult[y, x + 1] = 0;
                                    waveNotFinished = true;
                                }
                                else if (y < height - 1 && waveResult[y + 1, x] == color)
                                {
                                    wave.Add(new List<int> { x, y + 1 });
                                    waveResult[y + 1, x] = 0;
                                    waveNotFinished = true;
                                }
                                else if (x > 0 && waveResult[y, x - 1] == color)
                                {
                                    wave.Add(new List<int> { x - 1, y });
                                    waveResult[y, x - 1] = 0;
                                    waveNotFinished = true;
                                }
                                else if (y > 0 && waveResult[y - 1, x] == color)
                                {
                                    wave.Add(new List<int> { x, y - 1 });
                                    waveResult[y - 1, x] = 0;
                                    waveNotFinished = true;
                                }
                            }

                        }
                        x = wave[0][0];
                        y = wave[0][1];
                        if (x < width - 1 && waveResult[y, x + 1] != color && waveResult[y, x + 1] != 0 && waveResult[y, x + 1] != 1)
                        {
                            queue.Add(new List<int> { x + 1, y });
                        }
                        else if (y < height - 1 && waveResult[y + 1, x] != color && waveResult[y + 1, x] != 0 && waveResult[y + 1, x] != 1)
                        {
                            queue.Add(new List<int> { x, y + 1 });
                        }
                        else if (x > 0 && waveResult[y, x - 1] != color && waveResult[y, x - 1] != 0 && waveResult[y, x - 1] != 1)
                        {
                            queue.Add(new List<int> { x - 1, y });
                        }
                        else if (y > 0 && waveResult[y - 1, x] != color && waveResult[y - 1, x] != 0 && waveResult[y - 1, x] != 1)
                        {
                            queue.Add(new List<int> { x, y - 1 });
                        }
                        

                        else if (x < width - 1 && y < height - 1 && waveResult[y + 1, x + 1] != 0 && waveResult[y + 1, x + 1] != 1)
                        {
                            queue.Add(new List<int> { x + 1, y + 1 });
                        }
                        else if (x > 0 && y < height - 1 && waveResult[y + 1, x - 1] != 0 && waveResult[y + 1, x - 1] != 1)
                        {
                            queue.Add(new List<int> { x - 1, y + 1 });
                        }
                        else if (x > 0 && y > 0 && waveResult[y - 1, x - 1] != 0 && waveResult[y - 1, x - 1] != 1)
                        {
                            queue.Add(new List<int> { x - 1, y - 1 });
                        }
                        else if (x < width - 1 && y > 0 && waveResult[y - 1, x + 1] != 0 && waveResult[y - 1, x + 1] != 1)
                        {
                            queue.Add(new List<int> { x + 1, y - 1 });
                        }




                        if (color == 0)
                        {
                            wave.RemoveAt(0);
                        }

                        if (wave.Count > 0 && MyContains(wave[wave.Count - 1][0], wave[wave.Count - 1][1], queueLeft) == false)
                        {
                            queueLeft.Add(new List<int> { wave[wave.Count - 1][0], wave[wave.Count - 1][1] });
                        }


                        if (wave.Count > 0)
                        {
                            if (wave.Count == 1)
                            {
                                skeletPoints.Add(new List<int> { wave[0][0], wave[0][1] });
                            }
                            else
                            {
                                skeletPoints.Add(new List<int> { wave[wave.Count / 2][0], wave[wave.Count / 2][1] });
                            }
                        }
                    }

                    queue.RemoveAt(0);
                    wave.Clear();
                }
                else if (queueLeft.Count > 0)
                {
                    waveNotFinished = true;
                    wave.Add(new List<int> { queueLeft[0][0], queueLeft[0][1] });
                    color = waveResult[wave[wave.Count - 1][1], wave[wave.Count - 1][0]];
                    if (MyContains(queueLeft[0][0], queueLeft[0][1], proverenu) == false)
                    {
                        proverenu.Add(new List<int> { queueLeft[0][0], queueLeft[0][1] });
                        while (waveNotFinished)
                        {
                            waveNotFinished = false;
                            if (color != 0)
                            {
                                x = wave[wave.Count - 1][0];
                                y = wave[wave.Count - 1][1];
                                waveResult[y, x] = 0;
                                waveNotFinished = false;
                                if (x > 0 && waveResult[y, x - 1] == color)
                                {
                                    wave.Add(new List<int> { x - 1, y });
                                    waveResult[y, x - 1] = 0;
                                    waveNotFinished = true;
                                }
                                else if (y > 0 && waveResult[y - 1, x] == color)
                                {
                                    wave.Add(new List<int> { x, y - 1 });
                                    waveResult[y - 1, x] = 0;
                                    waveNotFinished = true;
                                }
                                else if (x < width - 1 && waveResult[y, x + 1] == color)
                                {
                                    wave.Add(new List<int> { x + 1, y });
                                    waveResult[y, x + 1] = 0;
                                    waveNotFinished = true;
                                }
                                else if (y < height - 1 && waveResult[y + 1, x] == color)
                                {
                                    wave.Add(new List<int> { x, y + 1 });
                                    waveResult[y + 1, x] = 0;
                                    waveNotFinished = true;
                                }
                            }

                        }
                        x = wave[0][0];
                        y = wave[0][1];
                        if (x > 0 && waveResult[y, x - 1] != color && waveResult[y, x - 1] != 0 && waveResult[y, x - 1] != 1)
                        {
                            queueLeft.Add(new List<int> { x - 1, y });
                        }
                        else if (y > 0 && waveResult[y - 1, x] != color && waveResult[y - 1, x] != 0 && waveResult[y - 1, x] != 1)
                        {
                            queueLeft.Add(new List<int> { x, y - 1 });
                        }
                        else if (x < width - 1 && waveResult[y, x + 1] != color && waveResult[y, x + 1] != 0 && waveResult[y, x + 1] != 1)
                        {
                            queueLeft.Add(new List<int> { x + 1, y });
                        }
                        else if (y < height - 1 && waveResult[y + 1, x] != color && waveResult[y + 1, x] != 0 && waveResult[y + 1, x] != 1)
                        {
                            queueLeft.Add(new List<int> { x, y + 1 });
                        }


                        else if (x > 0 && y > 0 && waveResult[y - 1, x - 1] != 0 && waveResult[y - 1, x - 1] != 1)
                        {
                            queueLeft.Add(new List<int> { x - 1, y - 1 });
                        }
                        else if (x < width - 1 && y > 0 && waveResult[y - 1, x + 1] != 0 && waveResult[y - 1, x + 1] != 1)
                        {
                            queueLeft.Add(new List<int> { x + 1, y - 1 });
                        }
                        else if (x < width - 1 && y < height - 1 && waveResult[y + 1, x + 1] != 0 && waveResult[y + 1, x + 1] != 1)
                        {
                            queueLeft.Add(new List<int> { x + 1, y + 1 });
                        }
                        else if (x > 0 && y < height - 1 && waveResult[y + 1, x - 1] != 0 && waveResult[y + 1, x - 1] != 1)
                        {
                            queueLeft.Add(new List<int> { x - 1, y + 1 });
                        }
                        


                        if (color == 0)
                        {
                            wave.RemoveAt(0);
                        }

                        if (wave.Count > 0 && MyContains(wave[wave.Count - 1][0], wave[wave.Count - 1][1], queue) == false)
                        {
                            queue.Add(new List<int> { wave[wave.Count - 1][0], wave[wave.Count - 1][1] });
                        }


                        if (wave.Count > 0)
                        {
                            if (wave.Count == 1)
                            {
                                skeletPoints.Add(new List<int> { wave[0][0], wave[0][1] });
                            }
                            else if (wave.Count % 2 == 0)
                            {
                                skeletPoints.Add(new List<int> { wave[wave.Count / 2][0], wave[wave.Count / 2][1] });
                            }
                            else
                            {
                                skeletPoints.Add(new List<int> { wave[wave.Count / 2][0], wave[wave.Count / 2][1] });
                            }
                        }
                    }

                    queueLeft.RemoveAt(0);
                    wave.Clear();
                }
            }

            /*// вывод точек скелета
            foreach (List<int> point in skeletPoints)
            {
                bmp1.SetPixel(point[0], point[1], Color.Black);
            }
            wavePicture.Image = bmp1;*/

            

            int k = 0;
            int x1;
            int y1;
            int x2;
            int y2;
            List<List<int>> orientiru = new List<List<int>>();
            Graphics gr = Graphics.FromImage(bmp1);
            Pen p = new Pen(Color.Black, 1);// цвет линии и ширина
            // для 'Г'
            /*
            while (k < skeletPoints.Count - 1)
            {
                x1 = skeletPoints[k][0];
                y1 = skeletPoints[k][1];
                int dx = 0;
                int dy = 0;
                while (dx < 2 && dy < 2 && k < skeletPoints.Count - 1)
                {
                    dx = Math.Abs(skeletPoints[k][0] - skeletPoints[k + 1][0]);
                    dy = Math.Abs(skeletPoints[k][1] - skeletPoints[k + 1][1]);
                    k++;
                }
                x2 = skeletPoints[k - 1][0];
                y2 = skeletPoints[k - 1][1];
                if (k != skeletPoints.Count - 1)
                {
                    if ((Math.Abs(x1 - x2) < 1 && dy > 15) || (Math.Abs(y1 - y2) < 1 && dx > 15) == false)
                    {
                        orientiru.Add(new List<int> { (int)Math.Abs(x1 - x2) / 2, (int)Math.Abs(y1 - y2) / 2 });
                    }
                    else
                    {
                        //orientiru.Add(new List<int> { x1, y1 });
                        orientiru.Add(new List<int> { x2, y2 });
                    }
                }
                
                else
                {
                    //orientiru.Add(new List<int> { x1, y1});
                    orientiru.Add(new List<int> { x2, y2});
                }


                *//*//вывод точек скелета
                foreach (List<int> point in skeletPoints)
                {
                    bmp1.SetPixel(point[0], point[1], Color.Black);
                }
                wavePicture.Image = bmp1;*/

            /*//вывод волн

            for (int y1 = 0; y1 < height; y1++)
            {
                for (int x1 = 0; x1 < width; x1++)
                {
                    if (waveResult[y1, x1] == 2)
                    {
                        bmp.SetPixel(x1, y1, Color.White);
                    }
                    else if (waveResult[y1, x1] == 3)
                    {
                        bmp.SetPixel(x1, y1, Color.Black);
                    }
                }
            }
            wavePicture.Image = bmp;*//*

        }
        orientiru.Sort((a, b) => b[0].CompareTo(a[0]));

        for (int i = 0; i < orientiru.Count - 1; i++)
        {
            if (Math.Abs(orientiru[i][0] - orientiru[i + 1][0]) < 2 || Math.Abs(orientiru[i][1] - orientiru[i + 1][1]) < 2)
            {
                Point p1 = new Point(orientiru[i][0], orientiru[i][1]);// первая точка
                Point p2 = new Point(orientiru[i + 1][0], orientiru[i + 1][1]);// вторая точка
                gr.DrawLine(p, p1, p2);// рисуем линию
            }
        }
        wavePicture.Image = bmp1;*/


            //вывод волн


            /*for (int i = 1; i < skeletPoints.Count - 1; i++)
            {
                for (int j = i + 1; j < skeletPoints.Count - 1; j++)
                {
                    if (skeletPoints[i][0] == skeletPoints[j][0] && Math.Abs(skeletPoints[i][1] - skeletPoints[j][1]) < 30 && Math.Abs(skeletPoints[i][1] - skeletPoints[j][1]) > 5 && Math.Abs(skeletPoints[j - 1][0] - skeletPoints[j][0]) > 1 && Math.Abs(skeletPoints[j + 1][0] - skeletPoints[j][0]) > 1)
                    {
                        skeletPoints[i][1] = (skeletPoints[i][1] + skeletPoints[j][1]) / 2;
                        skeletPoints.RemoveAt(j);
                    }
                    else if (skeletPoints[i][1] == skeletPoints[j][1] && Math.Abs(skeletPoints[i][0] - skeletPoints[j][0]) < 30 && Math.Abs(skeletPoints[i][0] - skeletPoints[j][0]) > 5 && Math.Abs(skeletPoints[j - 1][1] - skeletPoints[j][1]) > 1 && Math.Abs(skeletPoints[j + 1][1] - skeletPoints[j][1]) > 1)
                    {
                        skeletPoints[i][0] = (skeletPoints[i][0] + skeletPoints[j][0]) / 2;
                        skeletPoints.RemoveAt(j);
                    }
                }
            }*/
            /*//вывод точек скелета
            foreach (List<int> point in skeletPoints)
            {
                bmp1.SetPixel(point[0], point[1], Color.Black);
            }
            wavePicture.Image = bmp1;
*/
            // для 'S'
            orientiru.Add(new List<int> { skeletPoints[0][0], skeletPoints[0][1] });
            while (k < skeletPoints.Count - 1)
            {
                int dx = 0;
                int dy = 0;
                while (dx < 10 && dy < 10 && k < skeletPoints.Count - 1)
                {
                    dx = Math.Abs(skeletPoints[k][0] - skeletPoints[k + 1][0]);
                    dy = Math.Abs(skeletPoints[k][1] - skeletPoints[k + 1][1]);
                    wave.Add(new List<int> { skeletPoints[k][0], skeletPoints[k][1] });
                    k++;
                }
                if (wave.Count > 6 && (wave[0][0] == wave[wave.Count - 1][0] || wave[0][1] == wave[wave.Count - 1][1]))
                {
                    orientiru.Add(new List<int> { wave[0][0], wave[0][1] });
                    orientiru.Add(new List<int> { wave[wave.Count - 1][0], wave[wave.Count - 1][1] });
                }
                else if (wave.Count > 5 )
                {
                    orientiru.Add(new List<int> { wave[wave.Count - 1][0], wave[wave.Count - 1][1] });
                }
                if (dx > 20 && dy > 20 && orientiru.Count > 0 )
                {
                    orientiru.RemoveAt(orientiru.Count - 1);
                }
                wave.Clear();
            }

            /*for (int i = 0; i < orientiru.Count - 1; i++)
            {
                Point p1 = new Point(orientiru[i][0], orientiru[i][1]);// первая точка
                Point p2 = new Point(orientiru[i + 1][0], orientiru[i + 1][1]);// вторая точка
                gr.DrawLine(p, p1, p2);// рисуем линию
            }*/
            //wavePicture.Image = bmp1;

            Point[] points = new Point[orientiru.Count];

            for (int i = 0; i < orientiru.Count; i++)
            {
                points[i].X = orientiru[i][0];
                points[i].Y = orientiru[i][1];
            }
            Pen pen = new Pen(Color.Black);
            gr.DrawCurve(pen, points, 0.0f);
            wavePicture.Image = bmp1;

        }

        private bool EstPohoshaya(int k, List<List<int>> wave,  List<List<int>> orientiru)
        {
            for (int i = 0; i < orientiru.Count; i++)
            {
                if (Math.Abs(wave[k][0] - orientiru[i][0]) < 5 && Math.Abs(wave[k][1] - orientiru[i][1]) < 5)
                {
                    return true;
                }
            }
            return false;
        }

        public void DeletePoint(int x, int y, List<List<int>> queue)
        {
            for (int i = 0; i < queue.Count; i++)
            {
                if (queue[i][0] == x && queue[i][1] == y)
                {
                    queue.RemoveAt(i);
                }
            }
        }

        private bool MyContains(int x, int y, List<List<int>> queue)
        {
            if (queue.Count > 0)
            {
                for (int i = 0; i < queue.Count; i++)
                {
                    if (queue[i][0] == x && queue[i][1] == y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private double K_(int x1, int y1, int x2, int y2)
        {
            return Math.Atan(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1,  2) / (y2 - y1)));
        }


        private void HafButton_Click(object sender, EventArgs e)
        {

        }

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
                    else { e += m; }
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
                    else { e += m; }
                    DrawPoint(x, y, color);
                    if (y0 < y1) { y += 1; }
                    else { y -= 1; }
                    i++;
                }
            }

        }
        private void DrawPoint(int x, int y, Color color)
        {
            if (x > 0 & x < field.Width & y > 0 & y < field.Height)
                field.SetPixel(x, y, color);

        }





        private void zadanie1_3Button_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
        }

    }
}
