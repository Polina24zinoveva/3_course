namespace WindowsFormsApp1
{
    partial class AdministrationForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bookButton = new System.Windows.Forms.Button();
            this.whriterButton = new System.Windows.Forms.Button();
            this.contractButton = new System.Windows.Forms.Button();
            this.bookHasWhriterButton = new System.Windows.Forms.Button();
            this.zakazchikiButton = new System.Windows.Forms.Button();
            this.zakazButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.otchetButton = new System.Windows.Forms.Button();
            this.otchetlabel1 = new System.Windows.Forms.Label();
            this.otchetComboBox = new System.Windows.Forms.ComboBox();
            this.otchetlabel2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(234, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1013, 512);
            this.dataGridView1.TabIndex = 0;
            // 
            // bookButton
            // 
            this.bookButton.BackColor = System.Drawing.Color.DarkCyan;
            this.bookButton.Font = new System.Drawing.Font("Calibri", 10F);
            this.bookButton.ForeColor = System.Drawing.Color.White;
            this.bookButton.Location = new System.Drawing.Point(31, 91);
            this.bookButton.Name = "bookButton";
            this.bookButton.Size = new System.Drawing.Size(171, 64);
            this.bookButton.TabIndex = 1;
            this.bookButton.Text = "Книги";
            this.bookButton.UseVisualStyleBackColor = false;
            this.bookButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // whriterButton
            // 
            this.whriterButton.BackColor = System.Drawing.Color.DarkCyan;
            this.whriterButton.Font = new System.Drawing.Font("Calibri", 10F);
            this.whriterButton.ForeColor = System.Drawing.Color.White;
            this.whriterButton.Location = new System.Drawing.Point(31, 160);
            this.whriterButton.Name = "whriterButton";
            this.whriterButton.Size = new System.Drawing.Size(171, 64);
            this.whriterButton.TabIndex = 2;
            this.whriterButton.Text = "Писатели";
            this.whriterButton.UseVisualStyleBackColor = false;
            this.whriterButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // contractButton
            // 
            this.contractButton.BackColor = System.Drawing.Color.DarkCyan;
            this.contractButton.Font = new System.Drawing.Font("Calibri", 10F);
            this.contractButton.ForeColor = System.Drawing.Color.White;
            this.contractButton.Location = new System.Drawing.Point(31, 229);
            this.contractButton.Name = "contractButton";
            this.contractButton.Size = new System.Drawing.Size(171, 64);
            this.contractButton.TabIndex = 3;
            this.contractButton.Text = "Контракты";
            this.contractButton.UseVisualStyleBackColor = false;
            this.contractButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // bookHasWhriterButton
            // 
            this.bookHasWhriterButton.BackColor = System.Drawing.Color.DarkCyan;
            this.bookHasWhriterButton.Font = new System.Drawing.Font("Calibri", 10F);
            this.bookHasWhriterButton.ForeColor = System.Drawing.Color.White;
            this.bookHasWhriterButton.Location = new System.Drawing.Point(31, 298);
            this.bookHasWhriterButton.Name = "bookHasWhriterButton";
            this.bookHasWhriterButton.Size = new System.Drawing.Size(171, 64);
            this.bookHasWhriterButton.TabIndex = 4;
            this.bookHasWhriterButton.Text = "Книга - писатель";
            this.bookHasWhriterButton.UseVisualStyleBackColor = false;
            this.bookHasWhriterButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // zakazchikiButton
            // 
            this.zakazchikiButton.BackColor = System.Drawing.Color.DarkCyan;
            this.zakazchikiButton.Font = new System.Drawing.Font("Calibri", 10F);
            this.zakazchikiButton.ForeColor = System.Drawing.Color.White;
            this.zakazchikiButton.Location = new System.Drawing.Point(31, 367);
            this.zakazchikiButton.Name = "zakazchikiButton";
            this.zakazchikiButton.Size = new System.Drawing.Size(171, 64);
            this.zakazchikiButton.TabIndex = 5;
            this.zakazchikiButton.Text = "Заказчики";
            this.zakazchikiButton.UseVisualStyleBackColor = false;
            this.zakazchikiButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // zakazButton
            // 
            this.zakazButton.BackColor = System.Drawing.Color.DarkCyan;
            this.zakazButton.Font = new System.Drawing.Font("Calibri", 10F);
            this.zakazButton.ForeColor = System.Drawing.Color.White;
            this.zakazButton.Location = new System.Drawing.Point(31, 436);
            this.zakazButton.Name = "zakazButton";
            this.zakazButton.Size = new System.Drawing.Size(171, 64);
            this.zakazButton.TabIndex = 6;
            this.zakazButton.Text = "Заказы";
            this.zakazButton.UseVisualStyleBackColor = false;
            this.zakazButton.Click += new System.EventHandler(this.button6_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.IndianRed;
            this.exitButton.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitButton.Location = new System.Drawing.Point(1193, 658);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(83, 33);
            this.exitButton.TabIndex = 32;
            this.exitButton.Text = "Выйти";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // otchetButton
            // 
            this.otchetButton.BackColor = System.Drawing.Color.DarkCyan;
            this.otchetButton.Font = new System.Drawing.Font("Calibri", 10F);
            this.otchetButton.ForeColor = System.Drawing.Color.White;
            this.otchetButton.Location = new System.Drawing.Point(31, 539);
            this.otchetButton.Name = "otchetButton";
            this.otchetButton.Size = new System.Drawing.Size(171, 64);
            this.otchetButton.TabIndex = 33;
            this.otchetButton.Text = "Отчет";
            this.otchetButton.UseVisualStyleBackColor = false;
            this.otchetButton.Click += new System.EventHandler(this.otchetButton_Click);
            // 
            // otchetlabel1
            // 
            this.otchetlabel1.AutoSize = true;
            this.otchetlabel1.Location = new System.Drawing.Point(268, 46);
            this.otchetlabel1.Name = "otchetlabel1";
            this.otchetlabel1.Size = new System.Drawing.Size(579, 20);
            this.otchetlabel1.TabIndex = 34;
            this.otchetlabel1.Text = "Прибыль от продаж книг издательского центра \"Апрельская страница\" за";
            this.otchetlabel1.Visible = false;
            // 
            // otchetComboBox
            // 
            this.otchetComboBox.FormattingEnabled = true;
            this.otchetComboBox.Items.AddRange(new object[] {
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023"});
            this.otchetComboBox.Location = new System.Drawing.Point(862, 43);
            this.otchetComboBox.Name = "otchetComboBox";
            this.otchetComboBox.Size = new System.Drawing.Size(121, 28);
            this.otchetComboBox.TabIndex = 35;
            this.otchetComboBox.Visible = false;
            this.otchetComboBox.SelectedIndexChanged += new System.EventHandler(this.otchetComboBox_SelectedIndexChanged);
            // 
            // otchetlabel2
            // 
            this.otchetlabel2.AutoSize = true;
            this.otchetlabel2.Location = new System.Drawing.Point(998, 46);
            this.otchetlabel2.Name = "otchetlabel2";
            this.otchetlabel2.Size = new System.Drawing.Size(36, 20);
            this.otchetlabel2.TabIndex = 36;
            this.otchetlabel2.Text = "год";
            this.otchetlabel2.Visible = false;
            // 
            // AdministrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1278, 694);
            this.Controls.Add(this.otchetlabel2);
            this.Controls.Add(this.otchetComboBox);
            this.Controls.Add(this.otchetlabel1);
            this.Controls.Add(this.otchetButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.zakazButton);
            this.Controls.Add(this.zakazchikiButton);
            this.Controls.Add(this.bookHasWhriterButton);
            this.Controls.Add(this.contractButton);
            this.Controls.Add(this.whriterButton);
            this.Controls.Add(this.bookButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AdministrationForm";
            this.Text = "AdministrationForm";
            this.Load += new System.EventHandler(this.AdministrationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bookButton;
        private System.Windows.Forms.Button whriterButton;
        private System.Windows.Forms.Button contractButton;
        private System.Windows.Forms.Button bookHasWhriterButton;
        private System.Windows.Forms.Button zakazchikiButton;
        private System.Windows.Forms.Button zakazButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button otchetButton;
        private System.Windows.Forms.Label otchetlabel1;
        private System.Windows.Forms.ComboBox otchetComboBox;
        private System.Windows.Forms.Label otchetlabel2;
    }
}