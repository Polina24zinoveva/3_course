namespace WindowsFormsApp1
{
    partial class WriterForm
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
            this.numberPassportTextBox = new System.Windows.Forms.TextBox();
            this.checkbuttonpas = new System.Windows.Forms.Button();
            this.surnameTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.telephoneTextBox = new System.Windows.Forms.TextBox();
            this.contractTextBox = new System.Windows.Forms.TextBox();
            this.dateZaklucheniaTextBox = new System.Windows.Forms.TextBox();
            this.termContractTextBox = new System.Windows.Forms.TextBox();
            this.dateRastorgeniaTextBox = new System.Windows.Forms.TextBox();
            this.prodlenieButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Имя = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timeProdlenieTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.prodlenieUpdateButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // numberPassportTextBox
            // 
            this.numberPassportTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.numberPassportTextBox.ForeColor = System.Drawing.Color.Gray;
            this.numberPassportTextBox.Location = new System.Drawing.Point(47, 189);
            this.numberPassportTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numberPassportTextBox.Name = "numberPassportTextBox";
            this.numberPassportTextBox.Size = new System.Drawing.Size(213, 34);
            this.numberPassportTextBox.TabIndex = 5;
            this.numberPassportTextBox.Text = "Номер паспорта";
            this.numberPassportTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numberPassportTextBox_MouseClick);
            // 
            // checkbuttonpas
            // 
            this.checkbuttonpas.Font = new System.Drawing.Font("Calibri", 11F);
            this.checkbuttonpas.Location = new System.Drawing.Point(287, 189);
            this.checkbuttonpas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkbuttonpas.Name = "checkbuttonpas";
            this.checkbuttonpas.Size = new System.Drawing.Size(120, 45);
            this.checkbuttonpas.TabIndex = 6;
            this.checkbuttonpas.Text = "Ввод";
            this.checkbuttonpas.UseVisualStyleBackColor = true;
            this.checkbuttonpas.Click += new System.EventHandler(this.checkbuttonpas_Click);
            // 
            // surnameTextbox
            // 
            this.surnameTextbox.Enabled = false;
            this.surnameTextbox.Font = new System.Drawing.Font("Calibri", 11F);
            this.surnameTextbox.Location = new System.Drawing.Point(163, 366);
            this.surnameTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.surnameTextbox.Name = "surnameTextbox";
            this.surnameTextbox.Size = new System.Drawing.Size(244, 34);
            this.surnameTextbox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F);
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(84, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "Информация о писателе:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Enabled = false;
            this.nameTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.nameTextBox.ForeColor = System.Drawing.Color.Black;
            this.nameTextBox.Location = new System.Drawing.Point(163, 431);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(244, 34);
            this.nameTextBox.TabIndex = 9;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Enabled = false;
            this.lastNameTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.lastNameTextBox.ForeColor = System.Drawing.Color.Black;
            this.lastNameTextBox.Location = new System.Drawing.Point(163, 495);
            this.lastNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(244, 34);
            this.lastNameTextBox.TabIndex = 10;
            // 
            // telephoneTextBox
            // 
            this.telephoneTextBox.Enabled = false;
            this.telephoneTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.telephoneTextBox.ForeColor = System.Drawing.Color.Black;
            this.telephoneTextBox.Location = new System.Drawing.Point(220, 561);
            this.telephoneTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.telephoneTextBox.Name = "telephoneTextBox";
            this.telephoneTextBox.Size = new System.Drawing.Size(187, 34);
            this.telephoneTextBox.TabIndex = 11;
            // 
            // contractTextBox
            // 
            this.contractTextBox.Enabled = false;
            this.contractTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.contractTextBox.ForeColor = System.Drawing.Color.Black;
            this.contractTextBox.Location = new System.Drawing.Point(789, 114);
            this.contractTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.contractTextBox.Name = "contractTextBox";
            this.contractTextBox.Size = new System.Drawing.Size(217, 34);
            this.contractTextBox.TabIndex = 12;
            // 
            // dateZaklucheniaTextBox
            // 
            this.dateZaklucheniaTextBox.Enabled = false;
            this.dateZaklucheniaTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.dateZaklucheniaTextBox.ForeColor = System.Drawing.Color.Black;
            this.dateZaklucheniaTextBox.Location = new System.Drawing.Point(789, 176);
            this.dateZaklucheniaTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateZaklucheniaTextBox.Name = "dateZaklucheniaTextBox";
            this.dateZaklucheniaTextBox.Size = new System.Drawing.Size(217, 34);
            this.dateZaklucheniaTextBox.TabIndex = 13;
            // 
            // termContractTextBox
            // 
            this.termContractTextBox.Enabled = false;
            this.termContractTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.termContractTextBox.ForeColor = System.Drawing.Color.Black;
            this.termContractTextBox.Location = new System.Drawing.Point(789, 237);
            this.termContractTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.termContractTextBox.Name = "termContractTextBox";
            this.termContractTextBox.Size = new System.Drawing.Size(217, 34);
            this.termContractTextBox.TabIndex = 15;
            // 
            // dateRastorgeniaTextBox
            // 
            this.dateRastorgeniaTextBox.Enabled = false;
            this.dateRastorgeniaTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.dateRastorgeniaTextBox.ForeColor = System.Drawing.Color.Black;
            this.dateRastorgeniaTextBox.Location = new System.Drawing.Point(823, 297);
            this.dateRastorgeniaTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateRastorgeniaTextBox.Name = "dateRastorgeniaTextBox";
            this.dateRastorgeniaTextBox.Size = new System.Drawing.Size(183, 34);
            this.dateRastorgeniaTextBox.TabIndex = 16;
            this.dateRastorgeniaTextBox.Visible = false;
            // 
            // prodlenieButton
            // 
            this.prodlenieButton.BackColor = System.Drawing.Color.DarkCyan;
            this.prodlenieButton.Font = new System.Drawing.Font("Calibri", 11F);
            this.prodlenieButton.ForeColor = System.Drawing.Color.White;
            this.prodlenieButton.Location = new System.Drawing.Point(611, 395);
            this.prodlenieButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prodlenieButton.Name = "prodlenieButton";
            this.prodlenieButton.Size = new System.Drawing.Size(395, 70);
            this.prodlenieButton.TabIndex = 17;
            this.prodlenieButton.Text = "Продлить";
            this.prodlenieButton.UseVisualStyleBackColor = false;
            this.prodlenieButton.Visible = false;
            this.prodlenieButton.Click += new System.EventHandler(this.prodlenieButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11F);
            this.label2.Location = new System.Drawing.Point(42, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 27);
            this.label2.TabIndex = 18;
            this.label2.Text = "Фамилия";
            // 
            // Имя
            // 
            this.Имя.AutoSize = true;
            this.Имя.Font = new System.Drawing.Font("Calibri", 11F);
            this.Имя.Location = new System.Drawing.Point(42, 431);
            this.Имя.Name = "Имя";
            this.Имя.Size = new System.Drawing.Size(51, 27);
            this.Имя.TabIndex = 19;
            this.Имя.Text = "Имя";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11F);
            this.label4.Location = new System.Drawing.Point(42, 495);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 27);
            this.label4.TabIndex = 20;
            this.label4.Text = "Отчество";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11F);
            this.label5.Location = new System.Drawing.Point(42, 564);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 27);
            this.label5.TabIndex = 21;
            this.label5.Text = "Номер телефона";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Calibri", 11F);
            this.label3.Location = new System.Drawing.Point(606, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 27);
            this.label3.TabIndex = 22;
            this.label3.Text = "Дата заключения";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Font = new System.Drawing.Font("Calibri", 11F);
            this.label6.Location = new System.Drawing.Point(606, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 27);
            this.label6.TabIndex = 23;
            this.label6.Text = "Срок контракта";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Font = new System.Drawing.Font("Calibri", 11F);
            this.label7.Location = new System.Drawing.Point(606, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 27);
            this.label7.TabIndex = 24;
            this.label7.Text = "Номер контракта";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Font = new System.Drawing.Font("Calibri", 11F);
            this.label8.Location = new System.Drawing.Point(606, 303);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 27);
            this.label8.TabIndex = 25;
            this.label8.Text = "Дата расторжения";
            this.label8.Visible = false;
            // 
            // timeProdlenieTextBox
            // 
            this.timeProdlenieTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.timeProdlenieTextBox.Location = new System.Drawing.Point(894, 514);
            this.timeProdlenieTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.timeProdlenieTextBox.Name = "timeProdlenieTextBox";
            this.timeProdlenieTextBox.Size = new System.Drawing.Size(112, 34);
            this.timeProdlenieTextBox.TabIndex = 26;
            this.timeProdlenieTextBox.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 11F);
            this.label9.Location = new System.Drawing.Point(606, 517);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(272, 27);
            this.label9.TabIndex = 27;
            this.label9.Text = "Срок продления контракта:";
            this.label9.Visible = false;
            // 
            // prodlenieUpdateButton
            // 
            this.prodlenieUpdateButton.BackColor = System.Drawing.Color.DarkCyan;
            this.prodlenieUpdateButton.Font = new System.Drawing.Font("Calibri", 11F);
            this.prodlenieUpdateButton.ForeColor = System.Drawing.Color.White;
            this.prodlenieUpdateButton.Location = new System.Drawing.Point(611, 582);
            this.prodlenieUpdateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prodlenieUpdateButton.Name = "prodlenieUpdateButton";
            this.prodlenieUpdateButton.Size = new System.Drawing.Size(395, 60);
            this.prodlenieUpdateButton.TabIndex = 28;
            this.prodlenieUpdateButton.Text = "Продлить";
            this.prodlenieUpdateButton.UseCompatibleTextRendering = true;
            this.prodlenieUpdateButton.UseVisualStyleBackColor = false;
            this.prodlenieUpdateButton.Visible = false;
            this.prodlenieUpdateButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F);
            this.label10.ForeColor = System.Drawing.Color.DarkCyan;
            this.label10.Location = new System.Drawing.Point(693, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(279, 29);
            this.label10.TabIndex = 29;
            this.label10.Text = "Информация о контракте:";
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.IndianRed;
            this.exitButton.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitButton.Location = new System.Drawing.Point(1095, 660);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(83, 33);
            this.exitButton.TabIndex = 30;
            this.exitButton.Text = "Выйти";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // WriterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1178, 694);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.prodlenieUpdateButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.timeProdlenieTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Имя);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.prodlenieButton);
            this.Controls.Add(this.dateRastorgeniaTextBox);
            this.Controls.Add(this.termContractTextBox);
            this.Controls.Add(this.dateZaklucheniaTextBox);
            this.Controls.Add(this.contractTextBox);
            this.Controls.Add(this.telephoneTextBox);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.surnameTextbox);
            this.Controls.Add(this.checkbuttonpas);
            this.Controls.Add(this.numberPassportTextBox);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WriterForm";
            this.Text = "WriterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox numberPassportTextBox;
        private System.Windows.Forms.Button checkbuttonpas;
        private System.Windows.Forms.TextBox surnameTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox telephoneTextBox;
        private System.Windows.Forms.TextBox contractTextBox;
        private System.Windows.Forms.TextBox dateZaklucheniaTextBox;
        private System.Windows.Forms.TextBox termContractTextBox;
        private System.Windows.Forms.TextBox dateRastorgeniaTextBox;
        private System.Windows.Forms.Button prodlenieButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Имя;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox timeProdlenieTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button prodlenieUpdateButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button exitButton;
    }
}