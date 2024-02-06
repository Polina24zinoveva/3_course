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
    public partial class DobavKniga : Form
    {
        public DobavKniga()
        {
            InitializeComponent();
        }

        private void dobavButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            db.OpenDB();
            int primaryKeyValueToCheck = 1001;  
            while (true)
            {
                MySqlCommand checkCmd = new MySqlCommand("SELECT COUNT(*) FROM book WHERE ID_book = @primaryKeyValue", db.GetConnection());
                checkCmd.Parameters.Add("@primaryKeyValue", MySqlDbType.Int32).Value = primaryKeyValueToCheck;
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count > 0)
                {
                    primaryKeyValueToCheck += 1;
                }
                else
                {
                    string pasport = Convert.ToString(numberPassportTextBox.Text);
                    string nameKniga = Convert.ToString(nameKnigaTextBox.Text);
                    int costKniga = Convert.ToInt32(costKnigaTextBox.Text);
                    int costINMAGAZIN = Convert.ToInt32(costknigaINMAGAZINTextBox.Text);
                    string today = DateTime.Now.ToString("yyyy-MM-dd");

                    string[] numberStrings = pasport.Split(',');
                    int[] numbers = numberStrings.Select(str => int.Parse(str.Trim())).ToArray();

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        //проверка, что есть писатель с указанным паспортом
                        MySqlCommand cmd0 = new MySqlCommand("SELECT COUNT(*) FROM whriter WHERE Number_passport = @number_p", db.GetConnection());
                        cmd0.Parameters.Add("@number_p", MySqlDbType.Int32).Value = numbers[i];
                        int check_pasport = Convert.ToInt32(cmd0.ExecuteScalar());
                        if (check_pasport != 1)
                        {
                            MessageBox.Show("Не существует писателя в нашем издательском центре с таким номером паспорта. Попробуйте еще раз");
                            numberPassportTextBox.Text = null;
                            nameKnigaTextBox.Text = null;
                            costKnigaTextBox.Text = null;
                            costknigaINMAGAZINTextBox.Text = null;

                            return;
                        }
                        else //проверка на то, что контракт еще действителен
                        {
                            MySqlCommand cmd00 = new MySqlCommand("SELECT contract.Status FROM contract JOIN whriter ON whriter.Number_contract = contract.Number_contract WHERE whriter.Number_passport = @number_p", db.GetConnection());
                            cmd00.Parameters.Add("@number_p", MySqlDbType.Int32).Value = numbers[i];
                            int status = Convert.ToInt32(cmd00.ExecuteScalar());
                            if (status == 0) //т.е. контракт не активен
                            {
                                MessageBox.Show("Контракт с писателем с номером паспорта " + numbers[i].ToString() + " расторгнут. Попробуйте еще раз");
                                numberPassportTextBox.Text = null;
                                nameKnigaTextBox.Text = null;
                                costKnigaTextBox.Text = null;
                                costknigaINMAGAZINTextBox.Text = null;
                                return;
                            }

                        }
                    }



                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO book VALUES(@key, @namekn, 0, @data, @costpr, @costmagazin, 0)", db.GetConnection());
                    cmd1.Parameters.Add("@namekn", MySqlDbType.String).Value = nameKniga;
                    cmd1.Parameters.Add("@data", MySqlDbType.String).Value = today;
                    cmd1.Parameters.Add("@costpr", MySqlDbType.Int32).Value = costKniga;
                    cmd1.Parameters.Add("@costmagazin", MySqlDbType.String).Value = costINMAGAZIN;
                    cmd1.Parameters.Add("@key", MySqlDbType.Int32).Value = primaryKeyValueToCheck;
                    int b = cmd1.ExecuteNonQuery();

                    int primaryKeyValueToCheck2 = 2001;
                    while (true)
                    {
                        MySqlCommand checkCmd2 = new MySqlCommand("SELECT COUNT(*) FROM book_has_whriter WHERE ID_BHW = @primaryKeyValue", db.GetConnection());
                        checkCmd2.Parameters.Add("@primaryKeyValue", MySqlDbType.Int32).Value = primaryKeyValueToCheck2;
                        int count2 = Convert.ToInt32(checkCmd2.ExecuteScalar());
                        if (count2 > 0)
                        {
                            primaryKeyValueToCheck2 += 1;
                        }
                        else
                        {
                            int a = primaryKeyValueToCheck2;
                            for (int i = 0; i < numberStrings.Length; i++)
                            {
                                MySqlCommand cmd2 = new MySqlCommand("INSERT INTO book_has_whriter VALUES(@ind, @key, @pas)", db.GetConnection());
                                cmd2.Parameters.Add("@pas", MySqlDbType.Int32).Value = numbers[i];
                                cmd2.Parameters.Add("@ind", MySqlDbType.Int32).Value = a;
                                cmd2.Parameters.Add("@key", MySqlDbType.Int32).Value = primaryKeyValueToCheck;
                                int n = cmd2.ExecuteNonQuery();
                                a++;
                            }
                            break;
                        }
                    }
                    break;
                }
            }
            MessageBox.Show("Успешно!Ваша книга была добавлена!");
            Close();
        }

       

    } 
}
