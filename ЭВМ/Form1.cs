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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pisatelButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Есть ли у вас действующий конракт с нашим центром?", "Для писателей", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (res == DialogResult.Yes)
            {
                WriterForm writerForm = new WriterForm();
                writerForm.Show();
            }

            if (res == DialogResult.No)
            {
                NewWriterForm newWriterForm = new NewWriterForm();
                newWriterForm.Show();
            }

            if (res == DialogResult.Cancel)
            {
                return;
            }
        }

        private void kniga_Click(object sender, EventArgs e)
        {
            DobavKniga dobavKniga = new DobavKniga();
            dobavKniga.Show();
        }

        private void zakazchiklButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы зарегистрированы в нашем центре?", "Для заказчиков", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (res == DialogResult.Yes)
            {
                ZakazForm zakazchikForm = new ZakazForm();
                zakazchikForm.Show();
            }

            if (res == DialogResult.No)
            {
                NewZakazchikForm newZakazchikForm = new NewZakazchikForm();
                newZakazchikForm.Show();
            }

            if (res == DialogResult.Cancel)
            {
                return;
            }
        }

        private void administrator_Click(object sender, EventArgs e)
        {
            AdministrationForm administrationForm = new AdministrationForm();
            administrationForm.Show();
        }
    }
}
