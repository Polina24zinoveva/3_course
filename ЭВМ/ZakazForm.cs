using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ZakazForm : Form
    {
        public ZakazForm()
        {
            InitializeComponent();
        }

        int ID_zakazchika;
        string nameBook;
        int ID_Book;


        private void DostupnueBooks_Click(object sender, EventArgs e)
        {
            dostupnueBooksComboBox.Items.Clear();
            DB db = new DB();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            db.OpenDB();

            if (IDzakazchikaTextBox.Text != "")
            {
                ID_zakazchika = Convert.ToInt32(IDzakazchikaTextBox.Text);
                MySqlCommand cmd0 = new MySqlCommand("SELECT COUNT(*) FROM zakazchik WHERE ID_zakazchika = @ID_zakazchika", db.GetConnection());
                cmd0.Parameters.Add("@ID_zakazchika", MySqlDbType.Int32).Value = ID_zakazchika;
                int check_ID_zakazchika = Convert.ToInt32(cmd0.ExecuteScalar());
                if (check_ID_zakazchika != 1)
                {
                    MessageBox.Show("Неправильный ID. Попробуйте еще раз");
                    IDzakazchikaTextBox.Text = "";
                    return;
                }
            }
            else
            {
                MessageBox.Show("Сначала введите ID заказчика");
                return;
            }

            MySqlCommand cmd = new MySqlCommand("SELECT book.Name_book, book.Tiragh - SUM(zakaz.Count_exemplyars) FROM book JOIN zakaz ON book.ID_book = zakaz.Book_ID_book GROUP BY zakaz.Book_ID_book, book.Tiragh HAVING book.Tiragh - SUM(zakaz.Count_exemplyars) != 0; ", db.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            MySqlDataReader reader = cmd.ExecuteReader();

            int numberCont = 0;
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Доступных для заказа книг нет");
            }
            else
            {
                while (reader.Read())
                {
                    dostupnueBooksComboBox.Items.Add(reader[0] + " (" + reader[1] + " экземпляров)");
                }
            }
            reader.Close();
            db.CloseDB();
        }

        void DostupnueBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            nameBook = dostupnueBooksComboBox.SelectedItem.ToString();
            nameBook = nameBook.Split('(')[0];
            nameBook = nameBook.Remove(nameBook.Length - 1);

            DB db = new DB();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            db.OpenDB();

            MySqlCommand cmd = new MySqlCommand("SELECT ID_book FROM book WHERE Name_book = @nameBookZ; ", db.GetConnection());
            cmd.Parameters.Add("@nameBookZ", MySqlDbType.String).Value = nameBook;
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            ID_Book = Convert.ToInt32(cmd.ExecuteScalar());
            db.CloseDB();
        }

        private void zakazButton_Click(object sender, EventArgs e)
        {
            int countExemplars = 0;
            if (countExemplarsTextBox.Text != "")
            {
                countExemplars = Convert.ToInt32(countExemplarsTextBox.Text);
            }
            else
            {
                MessageBox.Show("Введите количество экземпляров");
                return;
            }

            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            db.OpenDB();

            MySqlCommand cmd = new MySqlCommand("SELECT book.Tiragh - SUM(zakaz.Count_exemplyars) FROM book JOIN zakaz ON book.ID_book = zakaz.Book_ID_book GROUP BY zakaz.Book_ID_book, book.Tiragh, book.Name_book HAVING book.Tiragh - SUM(zakaz.Count_exemplyars) != 0 AND book.Name_book = @nameBookZ; ", db.GetConnection());
            cmd.Parameters.Add("@nameBookZ", MySqlDbType.String).Value = nameBook;
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            int dostupnoeKolochestvoExemplars = Convert.ToInt32(cmd.ExecuteScalar());

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Доступных для заказа книг нет");
            }
            else
            {
                if (dostupnoeKolochestvoExemplars - countExemplars >= 0)
                {

                    string today = DateTime.Now.ToString("yyyy-MM-dd");
                    string date_vipolnenia = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
                    int ID_zakaz = ID_Zakaz();
                    db.OpenDB();

                    cmd = new MySqlCommand("INSERT INTO zakaz VALUES(@ID_Zakaz, @Date_postuplenia, @Date_vipolnenia, @Count_exemplyars, @Book_ID_book, @Zakazchik_ID_zakazchika);", db.GetConnection());
                    cmd.Parameters.Add("@ID_Zakaz", MySqlDbType.Int32).Value = ID_zakaz;
                    cmd.Parameters.Add("@Date_postuplenia", MySqlDbType.String).Value = today;
                    cmd.Parameters.Add("@Date_vipolnenia", MySqlDbType.String).Value = date_vipolnenia;
                    cmd.Parameters.Add("@Count_exemplyars", MySqlDbType.Int32).Value = countExemplars;
                    cmd.Parameters.Add("@Book_ID_book", MySqlDbType.Int32).Value = ID_Book;
                    cmd.Parameters.Add("@Zakazchik_ID_zakazchika", MySqlDbType.Int32).Value = ID_zakazchika;

                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);


                    //SELECT Cost - Sebestoimost FROM book WHERE ID_book = 1001;

                    int gonorarZa1Book = 0;
                    int gonorarDoZakaza = 0;

                    cmd = new MySqlCommand("SELECT Cost - Sebestoimost, gonorar FROM book WHERE ID_book = @Book_ID_book;", db.GetConnection());
                    cmd.Parameters.Add("@Book_ID_book", MySqlDbType.Int32).Value = ID_Book;

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        gonorarZa1Book = Convert.ToInt32(reader[0]);
                        gonorarDoZakaza = Convert.ToInt32(reader[1]);
                    }
                    reader.Close();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);



                    //UPDATE book SET SET Gonorar = @Gonorar WHERE ID_book = @Book_ID_book;;

                    cmd = new MySqlCommand("UPDATE book SET Gonorar = @Gonorar WHERE ID_book = @Book_ID_book;", db.GetConnection());
                    cmd.Parameters.Add("@Gonorar", MySqlDbType.Int32).Value = gonorarDoZakaza + (gonorarZa1Book * countExemplars);
                    cmd.Parameters.Add("@Book_ID_book", MySqlDbType.Int32).Value = ID_Book;

                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);

                    MessageBox.Show("Успешно! Ваш заказ оформлен!");


                    db.CloseDB();
                    IDzakazchikaTextBox.Text = "";
                    countExemplarsTextBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Нельзя заказать столько экземпляров. Попробуйте еще раз");
                    countExemplarsTextBox.Text = "";
                }
            }
            db.CloseDB();
            dostupnueBooksComboBox.Text = "";
            dostupnueBooksComboBox.Items.Clear();
        }

        int ID_Zakaz()
        {
            DB db = new DB();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            db.OpenDB();

            MySqlCommand cmd = new MySqlCommand("SELECT MAX(ID_Zakaz) FROM zakaz;", db.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            int lastIDzakaz = Convert.ToInt32(cmd.ExecuteScalar());
            int ID_zakaz = lastIDzakaz + 1;
            db.CloseDB();
            return ID_zakaz;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void IDzakazchikaTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
