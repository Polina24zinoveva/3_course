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
    public partial class NewWriterForm : Form
    {
        public NewWriterForm()
        {
            InitializeComponent();
        }



        private void surnameTextBox_Click(object sender, EventArgs e)
        {
            surnameTextBox.Text = null;
            surnameTextBox.ForeColor = Color.Black;
        }

        private void nameTextBox_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = null;
            nameTextBox.ForeColor = Color.Black;
        }

        private void lastNameTextBox_Click(object sender, EventArgs e)
        {
            lastNameTextBox.Text = null;
            lastNameTextBox.ForeColor = Color.Black;
        }

        private void numberPassportTextBox_Click(object sender, EventArgs e)
        {
            numberPassportTextBox.Text = null;
            numberPassportTextBox.ForeColor = Color.Black;
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

        private void termContractTextBox_Click(object sender, EventArgs e)
        {
            termContractTextBox.Text = null;
            termContractTextBox.ForeColor = Color.Black;
        }

        private void zakluchitContractButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string surname = Convert.ToString(surnameTextBox.Text);
            string name = Convert.ToString(nameTextBox.Text);
            string lastname = Convert.ToString(nameTextBox.Text);
            int pasport = Convert.ToInt32(numberPassportTextBox.Text);
            string mectozhtelcstva = Convert.ToString(addressTextBox.Text);
            string telephone = Convert.ToString(telephoneTextBox.Text);
            int term = Convert.ToInt32(termContractTextBox.Text);
            string today = DateTime.Now.ToString("yyyy-MM-dd");

            db.OpenDB();
            int primaryKeyValueToCheck = 101;
            while (true)
            {
                MySqlCommand checkCmd = new MySqlCommand("SELECT COUNT(*) FROM contract WHERE Number_contract = @primaryKeyValue", db.GetConnection());
                checkCmd.Parameters.Add("@primaryKeyValue", MySqlDbType.Int32).Value = primaryKeyValueToCheck;
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count > 0)
                {
                    primaryKeyValueToCheck += 1;
                }
                else
                { 
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO contract VALUES(@key, @data, @term, true, null)", db.GetConnection());
                    cmd1.Parameters.Add("@data", MySqlDbType.String).Value = today;
                    cmd1.Parameters.Add("@term", MySqlDbType.Int32).Value = term;
                    cmd1.Parameters.Add("@key", MySqlDbType.Int32).Value = primaryKeyValueToCheck;
                    int b = cmd1.ExecuteNonQuery();


                    MySqlCommand cmd = new MySqlCommand("INSERT INTO whriter VALUES(@pas, @surn, @name, @lastn, @address, @telep, @key)", db.GetConnection());
                    cmd.Parameters.Add("@pas", MySqlDbType.Int32).Value = pasport;
                    cmd.Parameters.Add("@surn", MySqlDbType.String).Value = surname;
                    cmd.Parameters.Add("@name", MySqlDbType.String).Value = name;
                    cmd.Parameters.Add("@lastn", MySqlDbType.String).Value = lastname;
                    cmd.Parameters.Add("@address", MySqlDbType.String).Value = mectozhtelcstva;
                    cmd.Parameters.Add("telep", MySqlDbType.String).Value = telephone;
                    cmd.Parameters.Add("@key", MySqlDbType.Int32).Value = primaryKeyValueToCheck;
                    int a = cmd.ExecuteNonQuery();

                    MessageBox.Show("Успешно! Вы теперь являетесь писателем!");

                    db.CloseDB();
                    break;
                }
            }
            Close();
        }
    }
}
