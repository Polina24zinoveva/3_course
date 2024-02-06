using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class WriterForm : Form
    {
        public WriterForm()
        {
            InitializeComponent();
        }

        private void numberPassportTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            numberPassportTextBox.Text = null;
            numberPassportTextBox.ForeColor = Color.Black;
        }

        private void checkbuttonpas_Click(object sender, EventArgs e)
        {
            int pasport = Convert.ToInt32(numberPassportTextBox.Text);
            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            db.OpenDB();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM whriter WHERE Number_passport = @pas", db.GetConnection());
            cmd.Parameters.Add("@pas", MySqlDbType.Int32).Value = pasport;
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            MySqlDataReader reader = cmd.ExecuteReader();

            int numberCont = 0;
            if (dt.Rows.Count == 0) 
            {
                MessageBox.Show("Писатель не найден");
            }
            else
            {
                while (reader.Read()) 
                { 
                    surnameTextbox.Text = reader[1].ToString();
                    nameTextBox.Text = reader[2].ToString();
                    lastNameTextBox.Text = reader[3].ToString();
                    telephoneTextBox.Text = reader[5].ToString();
                    contractTextBox.Text = reader[6].ToString();
                    numberCont = Convert.ToInt32(reader[6]);
                }
            }
            reader.Close();
            DataTable dt2 = new DataTable();
            MySqlDataAdapter adapter2 = new MySqlDataAdapter();
            cmd = new MySqlCommand("SELECT * FROM contract WHERE Number_contract = @con", db.GetConnection());
            cmd.Parameters.Add("@con", MySqlDbType.Int32).Value = numberCont;
            adapter2.SelectCommand = cmd;
            adapter2.Fill(dt2);
            reader = cmd.ExecuteReader();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Контракт не найден");
            }
            else
            {
                while (reader.Read())
                {
                    dateZaklucheniaTextBox.Text = DateTime.Parse(reader[1].ToString()).ToShortDateString();
                    string a = reader[2].ToString();
                    if (Int32.Parse(a) <= 4)
                    {
                        termContractTextBox.Text = a + " года";
                    }
                    else
                    {
                        termContractTextBox.Text = a + " лет";
                    }
                    if (Convert.ToBoolean(reader[3]) == false)
                    {
                        dateRastorgeniaTextBox.Visible = true;
                        dateRastorgeniaTextBox.Text = DateTime.Parse(reader[4].ToString()).ToShortDateString();
                        dateRastorgeniaTextBox.BackColor = Color.IndianRed;
                        prodlenieButton.Visible = true;
                        label8.Visible = true;     
                    }
                    else
                    {
                        dateRastorgeniaTextBox.Text = "Контракт активен";
                        dateRastorgeniaTextBox.BackColor = Color.White;
                        prodlenieButton.Visible = false;
                        label8.Visible = false;
                        dateRastorgeniaTextBox.Visible = false;
                    }
                }
            }
            reader.Close();
            db.CloseDB();
        }

        private void prodlenieButton_Click(object sender, EventArgs e)
        {
            prodlenieButton.Visible = false;
            label9.Visible = true;
            timeProdlenieTextBox.Visible = true;
            prodlenieUpdateButton.Visible = true;
            dateRastorgeniaTextBox.BackColor= Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int prodlen = Int32.Parse(timeProdlenieTextBox.Text);
            int contract = Convert.ToInt32(contractTextBox.Text);
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            DB db = new DB();


            db.OpenDB();

            MySqlCommand cmd1 = new MySqlCommand("UPDATE contract SET Date_zakluchenia = @data, Term_contract = @prod, Status = true, Date_rastorgenia = null WHERE Number_contract = @con", db.GetConnection());
            cmd1.Parameters.Add("@con", MySqlDbType.Int32).Value = contract;
            cmd1.Parameters.Add("@data", MySqlDbType.String).Value = today;
            cmd1.Parameters.Add("@prod", MySqlDbType.Int32).Value = prodlen;
            int a = cmd1.ExecuteNonQuery();


            MessageBox.Show("Успешно! Ваш контракт продлён!");
            label9.Visible = false;
            prodlenieButton.Visible = false;
            prodlenieUpdateButton.Visible= false;
            timeProdlenieTextBox.Visible = false;

            checkbuttonpas_Click(sender, e);

            db.CloseDB();
            Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
