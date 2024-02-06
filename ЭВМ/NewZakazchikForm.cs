using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class NewZakazchikForm : Form
    {
        public NewZakazchikForm()
        {
            InitializeComponent();
        }

        private void NewZakazchikForm_Load(object sender, EventArgs e)
        {

        }


        private void nameTextBox_Click(object sender, EventArgs e)
        {
            nameZakazchikaTextBox.Text = null;
            nameZakazchikaTextBox.ForeColor = Color.Black;
        }

        private void addressTextBox_Click(object sender, EventArgs e)
        {
            addressTextBox.Text = null;
            addressTextBox.ForeColor = Color.Black;
        }

        private void telephoneTextBox_Click(object sender, EventArgs e)
        {
            telephoneTextBox.Text = null;
            telephoneTextBox.ForeColor = Color.Black;
        }


        private void FIOPredstavitelaTextBox_Click(object sender, EventArgs e)
        {
            FIOPredstavitelaTextBox.Text = null;
            FIOPredstavitelaTextBox.ForeColor = Color.Black;
            FIOPredstavitelaTextBox.TextAlign = HorizontalAlignment.Left;
        }

        private void addZakazchikButton_Click(object sender, EventArgs e)
        {
            int ID_zakazchika = ID_Zakaz();
            string nameZakazchika = nameZakazchikaTextBox.Text;
            string address = addressTextBox.Text;
            string telephone = telephoneTextBox.Text;
            string FIOPredstavitela = FIOPredstavitelaTextBox.Text;

            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            db.OpenDB();


            MySqlCommand cmd = new MySqlCommand("INSERT INTO zakazchik VALUES(@ID_zakazchika, @Name_zakazchik, @Address, @Telephone, @FIO_predstavitel);", db.GetConnection());
            cmd.Parameters.Add("@ID_zakazchika", MySqlDbType.Int32).Value = ID_zakazchika;
            cmd.Parameters.Add("@Name_zakazchik", MySqlDbType.String).Value = nameZakazchika;
            cmd.Parameters.Add("@Address", MySqlDbType.String).Value = address;
            cmd.Parameters.Add("@Telephone", MySqlDbType.String).Value = telephone;
            cmd.Parameters.Add("@FIO_predstavitel", MySqlDbType.String).Value = FIOPredstavitela;

            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            MessageBox.Show("Вы успешно зарегистрированны! Ваш ID: " + ID_zakazchika);

            Close();
        }

        int ID_Zakaz()
        {
            DB db = new DB();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            db.OpenDB();

            MySqlCommand cmd = new MySqlCommand("SELECT MAX(ID_zakazchika) FROM zakazchik;", db.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            int lastIDzakazchika = Convert.ToInt32(cmd.ExecuteScalar());
            int ID_zakazchika = lastIDzakazchika + 1;
            db.CloseDB();
            return ID_zakazchika;
        }
    }
}
