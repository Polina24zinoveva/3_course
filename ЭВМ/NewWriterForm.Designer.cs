namespace WindowsFormsApp1
{
    partial class NewWriterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.contractTermTextBox = new System.Windows.Forms.TextBox();
            this.zakluchitContractButton = new System.Windows.Forms.Button();
            this.telephoneTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.numberPassportTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.termContractTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // contractTermTextBox
            // 
            this.contractTermTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.contractTermTextBox.Location = new System.Drawing.Point(1477, 216);
            this.contractTermTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.contractTermTextBox.Name = "contractTermTextBox";
            this.contractTermTextBox.Size = new System.Drawing.Size(147, 35);
            this.contractTermTextBox.TabIndex = 6;
            // 
            // zakluchitContractButton
            // 
            this.zakluchitContractButton.BackColor = System.Drawing.Color.DarkCyan;
            this.zakluchitContractButton.Font = new System.Drawing.Font("Calibri", 12F);
            this.zakluchitContractButton.ForeColor = System.Drawing.Color.White;
            this.zakluchitContractButton.Location = new System.Drawing.Point(125, 561);
            this.zakluchitContractButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.zakluchitContractButton.Name = "zakluchitContractButton";
            this.zakluchitContractButton.Size = new System.Drawing.Size(350, 70);
            this.zakluchitContractButton.TabIndex = 16;
            this.zakluchitContractButton.Text = "Заключить контракт";
            this.zakluchitContractButton.UseVisualStyleBackColor = false;
            this.zakluchitContractButton.Click += new System.EventHandler(this.zakluchitContractButton_Click);
            // 
            // telephoneTextBox
            // 
            this.telephoneTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.telephoneTextBox.ForeColor = System.Drawing.Color.Gray;
            this.telephoneTextBox.Location = new System.Drawing.Point(125, 419);
            this.telephoneTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.telephoneTextBox.Name = "telephoneTextBox";
            this.telephoneTextBox.Size = new System.Drawing.Size(350, 34);
            this.telephoneTextBox.TabIndex = 14;
            this.telephoneTextBox.Text = "Телефон";
            this.telephoneTextBox.Click += new System.EventHandler(this.telephoneTextBox_Click);
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.lastNameTextBox.ForeColor = System.Drawing.Color.Gray;
            this.lastNameTextBox.Location = new System.Drawing.Point(125, 262);
            this.lastNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(350, 34);
            this.lastNameTextBox.TabIndex = 13;
            this.lastNameTextBox.Text = "Отчество";
            this.lastNameTextBox.Click += new System.EventHandler(this.lastNameTextBox_Click);
            // 
            // numberPassportTextBox
            // 
            this.numberPassportTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.numberPassportTextBox.ForeColor = System.Drawing.Color.Gray;
            this.numberPassportTextBox.Location = new System.Drawing.Point(125, 314);
            this.numberPassportTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numberPassportTextBox.Name = "numberPassportTextBox";
            this.numberPassportTextBox.Size = new System.Drawing.Size(350, 34);
            this.numberPassportTextBox.TabIndex = 12;
            this.numberPassportTextBox.Text = "Номер паспорта";
            this.numberPassportTextBox.Click += new System.EventHandler(this.numberPassportTextBox_Click);
            // 
            // addressTextBox
            // 
            this.addressTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.addressTextBox.ForeColor = System.Drawing.Color.Gray;
            this.addressTextBox.Location = new System.Drawing.Point(125, 366);
            this.addressTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(350, 34);
            this.addressTextBox.TabIndex = 11;
            this.addressTextBox.Text = "Домашний адрес";
            this.addressTextBox.Click += new System.EventHandler(this.addressTextBox_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.nameTextBox.ForeColor = System.Drawing.Color.Gray;
            this.nameTextBox.Location = new System.Drawing.Point(125, 209);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(350, 34);
            this.nameTextBox.TabIndex = 10;
            this.nameTextBox.Text = "Имя";
            this.nameTextBox.Click += new System.EventHandler(this.nameTextBox_Click);
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.surnameTextBox.ForeColor = System.Drawing.Color.Gray;
            this.surnameTextBox.Location = new System.Drawing.Point(125, 157);
            this.surnameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(350, 34);
            this.surnameTextBox.TabIndex = 9;
            this.surnameTextBox.Text = "Фамилия";
            this.surnameTextBox.Click += new System.EventHandler(this.surnameTextBox_Click);
            // 
            // termContractTextBox
            // 
            this.termContractTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.termContractTextBox.ForeColor = System.Drawing.Color.Gray;
            this.termContractTextBox.Location = new System.Drawing.Point(125, 470);
            this.termContractTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.termContractTextBox.Name = "termContractTextBox";
            this.termContractTextBox.Size = new System.Drawing.Size(350, 34);
            this.termContractTextBox.TabIndex = 17;
            this.termContractTextBox.Text = "Срок контракта";
            this.termContractTextBox.Click += new System.EventHandler(this.termContractTextBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(155, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 35);
            this.label1.TabIndex = 18;
            this.label1.Text = "Заключение контракта:";
            // 
            // NewWriterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(578, 694);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.termContractTextBox);
            this.Controls.Add(this.zakluchitContractButton);
            this.Controls.Add(this.telephoneTextBox);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.numberPassportTextBox);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.surnameTextBox);
            this.Controls.Add(this.contractTermTextBox);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NewWriterForm";
            this.Text = "NewWriterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox contractTermTextBox;
        private System.Windows.Forms.Button zakluchitContractButton;
        private System.Windows.Forms.TextBox telephoneTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox numberPassportTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.TextBox termContractTextBox;
        private System.Windows.Forms.Label label1;
    }
}