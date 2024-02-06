using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class AdministrationForm : Form
    {
        public AdministrationForm()
        {
            InitializeComponent();
        }

        private void AdministrationForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            otchetlabel1.Visible = false;
            otchetlabel2.Visible = false;
            otchetComboBox.Visible = false;

            DB db = new DB();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            db.OpenDB();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM book;", db.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            db.CloseDB();

            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            otchetlabel1.Visible = false;
            otchetlabel2.Visible = false;
            otchetComboBox.Visible = false;

            DB db = new DB();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            db.OpenDB();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM whriter;", db.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            db.CloseDB();

            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            otchetlabel1.Visible = false;
            otchetlabel2.Visible = false;
            otchetComboBox.Visible = false;

            DB db = new DB();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            db.OpenDB();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM contract;", db.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            db.CloseDB();

            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            otchetlabel1.Visible = false;
            otchetlabel2.Visible = false;
            otchetComboBox.Visible = false;

            DB db = new DB();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            db.OpenDB();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM book_has_whriter;", db.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            db.CloseDB();

            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            otchetlabel1.Visible = false;
            otchetlabel2.Visible = false;
            otchetComboBox.Visible = false;

            DB db = new DB();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            db.OpenDB();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM zakazchik;", db.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            db.CloseDB();

            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            otchetlabel1.Visible = false;
            otchetlabel2.Visible = false;
            otchetComboBox.Visible = false;

            DB db = new DB();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            db.OpenDB();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM zakaz;", db.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            db.CloseDB();

            dataGridView1.DataSource = dt;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void otchetButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            otchetlabel1.Visible = true;
            otchetlabel2.Visible = true;
            otchetComboBox.Visible = true;

        }
       
        private void otchetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String year = otchetComboBox.SelectedItem.ToString();
            DB db = new DB();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            db.OpenDB();

            dt1.Columns.Add(new DataColumn("Заказчик", typeof(string)));
            dt1.Columns.Add(new DataColumn("Название книги", typeof(string)));
            dt1.Columns.Add(new DataColumn("Себестоимость, руб.", typeof(int)));
            dt1.Columns.Add(new DataColumn("Цена продажи, руб.", typeof(int)));
            dt1.Columns.Add(new DataColumn("Количество экземпляров", typeof(int)));
            dt1.Columns.Add(new DataColumn("Прибыль от продажи книги, руб.", typeof(int)));


            int sum = 0;
            int id_prev_zakazchik = 0;

            MySqlCommand cmd = new MySqlCommand("SELECT zakazchik.ID_zakazchika, zakazchik.Name_zakazchik AS 'Заказчик', book.Name_book AS 'Название книги', book.Sebestoimost AS 'Себестоимость, руб.', book.Cost AS 'Цена продажи, руб.', SUM(zakaz.Count_exemplyars) AS 'Количество экземпляров', (book.Cost - book.Sebestoimost) * SUM(zakaz.Count_exemplyars) AS 'Прибыль от продажи книги, руб.' FROM book JOIN zakaz ON book.ID_book = zakaz.Book_ID_book JOIN zakazchik ON zakazchik.ID_zakazchika = zakaz.Zakazchik_ID_zakazchika WHERE zakaz.Date_vipolnenia LIKE '" + year + "%' GROUP BY zakazchik.ID_zakazchika, zakazchik.Name_zakazchik, zakaz.Book_ID_book, book.Tiragh order by zakazchik.Name_zakazchik", db.GetConnection());

            //MySqlCommand cmd = new MySqlCommand("SELECT book.Name_book AS 'Название книги', book.Sebestoimost AS 'Себестоимость, руб.', book.Cost AS 'Цена продажи, руб.', SUM(zakaz.Count_exemplyars) AS 'Количество экземпляров', (book.Cost - book.Sebestoimost) * SUM(zakaz.Count_exemplyars) AS 'Прибыль от продажи книги, руб.' FROM book JOIN zakaz ON book.ID_book = zakaz.Book_ID_book WHERE zakaz.Date_vipolnenia LIKE '" + year + "%' GROUP BY zakaz.Book_ID_book, book.Tiragh UNION SELECT 'Итого' AS 'Название книги', null AS 'Себестоимость, руб.', null AS 'Цена продажи, руб.', null AS 'Количество экземпляров', ( SELECT SUM((b.Cost - b.Sebestoimost) * z.Count_exemplyars) FROM book b JOIN zakaz z ON b.ID_book = z.Book_ID_book WHERE z.Date_vipolnenia LIKE '" + year + "%' ) AS 'Прибыль от продажи книги, руб.';", db.GetConnection());
            //MySqlCommand cmd = new MySqlCommand("select * from BookSalesSummary union SELECT 'Итого' AS 'Заказчик', null AS 'Название книги', null AS 'Себестоимость, руб.', null AS 'Цена продажи, руб.', null AS 'Количество экземпляров', SUM(`Прибыль от продажи книги, руб.`) AS 'Прибыль от продажи книг, руб.' FROM BookSalesSummary;", db.GetConnection());
            //SELECT zakazchik.ID_zakazchika, zakazchik.Name_zakazchik AS 'Заказчик', book.Name_book AS 'Название книги', book.Sebestoimost AS 'Себестоимость, руб.', book.Cost AS 'Цена продажи, руб.', SUM(zakaz.Count_exemplyars) AS 'Количество экземпляров', (book.Cost - book.Sebestoimost) * SUM(zakaz.Count_exemplyars) AS 'Прибыль от продажи книги, руб.' FROM book JOIN zakaz ON book.ID_book = zakaz.Book_ID_book JOIN zakazchik ON zakazchik.ID_zakazchika = zakaz.Zakazchik_ID_zakazchika WHERE zakaz.Date_vipolnenia LIKE '2023%' GROUP BY zakazchik.ID_zakazchika, zakazchik.Name_zakazchik, zakaz.Book_ID_book, book.Tiragh order by zakazchik.Name_zakazchik
            //SELECT zakazchik.Name_zakazchik AS 'Заказчик', book.Name_book AS 'Название книги', book.Sebestoimost AS 'Себестоимость, руб.', book.Cost AS 'Цена продажи, руб.', SUM(zakaz.Count_exemplyars) AS 'Количество экземпляров', (book.Cost - book.Sebestoimost) * SUM(zakaz.Count_exemplyars) AS 'Прибыль от продажи книги, руб.' FROM book JOIN zakaz ON book.ID_book = zakaz.Book_ID_book JOIN zakazchik ON zakazchik.ID_zakazchika = zakaz.Zakazchik_ID_zakazchika WHERE zakaz.Date_vipolnenia LIKE '2023%' GROUP BY zakazchik.Name_zakazchik, zakaz.Book_ID_book, book.Tiragh UNION SELECT 'Итого' AS 'Заказчик', null AS 'Название книги', null AS 'Себестоимость, руб.', null AS 'Цена продажи, руб.', null AS 'Количество экземпляров', (SELECT SUM((b.Cost - b.Sebestoimost) * z.Count_exemplyars) FROM book b JOIN zakaz z ON b.ID_book = z.Book_ID_book WHERE z.Date_vipolnenia LIKE '2023%') AS 'Прибыль от продажи книги, руб.';

            //MySqlCommand cmd = new MySqlCommand("SELECT book.Name_book AS 'Название книги', book.Sebestoimost AS 'Себестоимость, руб.', book.Cost AS 'Цена продажи, руб.', SUM(zakaz.Count_exemplyars) AS 'Количество экземпляров',  (book.Cost - book.Sebestoimost) * SUM(zakaz.Count_exemplyars) AS 'Прибыль от продажи книги, руб.' from book JOIN zakaz ON book.ID_book = zakaz.Book_ID_book WHERE zakaz.Date_vipolnenia LIKE '" + year + "%' GROUP BY zakaz.Book_ID_book, book.Tiragh;", db.GetConnection());

            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            int sum_z = 0;
            int count = 0;

            MySqlDataReader reader = cmd.ExecuteReader();

            if (dt.Rows.Count == 0)
            {
            }
            else
            {
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader[0]) != id_prev_zakazchik)
                    {
                        sum_z = 0;
                        sum_z += Convert.ToInt32(reader[6]);
                        sum += Convert.ToInt32(reader[6]);
                        dt1.Rows.Add(reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]);
                        id_prev_zakazchik = Convert.ToInt32(reader[0]);
                        dt1.Rows.Add("Подытог", null, null, null, null, sum_z);
                        count++;
                    }
                    else
                    {
                        DataRow a = dt1.Rows[count + 1];
                        dt1.Rows.Remove(a);
                        sum_z += Convert.ToInt32(reader[6]);
                        sum += Convert.ToInt32(reader[6]);
                        dt1.Rows.Add(null, reader[2], reader[3], reader[4], reader[5], reader[6]);
                        dt1.Rows.Add("Подытог", null, null, null, null, sum_z);
                    }

                }
            }
            dt1.Rows.Add("Итого", null, null, null, null, sum);

            reader.Close();
            db.CloseDB();


            dataGridView1.DataSource = dt1;

            using (Document doc = new Document())
            {
                PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\polin\Desktop\Универ\5 семестр\ЭВМ\3 лаба_отчет\otchet.pdf", FileMode.Create));
                doc.Open();
                BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

                PdfPTable table = new PdfPTable(dt1.Columns.Count);

                PdfPCell cell = new PdfPCell(new Phrase("Отчёт за " + year + " год", font));
                cell.Colspan = dt1.Columns.Count;
                cell.HorizontalAlignment = 1;
                cell.Border = 0;
                table.AddCell(cell);

                for (int j = 0; j < dt1.Columns.Count; j++)
                {
                    cell = new PdfPCell(new Phrase(new Phrase(dt1.Columns[j].ColumnName, font)));
                    cell.BackgroundColor = BaseColor.GRAY;
                    table.AddCell(cell);
                }
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    for (int k = 0; k < dt1.Columns.Count; k++)
                    {
                        table.AddCell(new Phrase(dt1.Rows[j][k].ToString(), font));
                    }
                }
                doc.Add(table);
                doc.Close();
            }
            MessageBox.Show("Pdf-документ создан");
        }
    }
}