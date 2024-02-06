namespace WindowsFormsApp1
{
    partial class ZakazForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.IDzakazchikaTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dostupnueBooksComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.countExemplarsTextBox = new System.Windows.Forms.TextBox();
            this.zakazButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11F);
            this.label1.Location = new System.Drawing.Point(115, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID заказчика";
            // 
            // IDzakazchikaTextBox
            // 
            this.IDzakazchikaTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.IDzakazchikaTextBox.Location = new System.Drawing.Point(120, 231);
            this.IDzakazchikaTextBox.Name = "IDzakazchikaTextBox";
            this.IDzakazchikaTextBox.Size = new System.Drawing.Size(350, 34);
            this.IDzakazchikaTextBox.TabIndex = 1;
            this.IDzakazchikaTextBox.TextChanged += new System.EventHandler(this.IDzakazchikaTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11F);
            this.label2.Location = new System.Drawing.Point(115, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Доступные для заказа книги:";
            // 
            // dostupnueBooksComboBox
            // 
            this.dostupnueBooksComboBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.dostupnueBooksComboBox.FormattingEnabled = true;
            this.dostupnueBooksComboBox.Location = new System.Drawing.Point(120, 312);
            this.dostupnueBooksComboBox.Name = "dostupnueBooksComboBox";
            this.dostupnueBooksComboBox.Size = new System.Drawing.Size(350, 35);
            this.dostupnueBooksComboBox.TabIndex = 3;
            this.dostupnueBooksComboBox.SelectedIndexChanged += new System.EventHandler(this.DostupnueBooks_SelectedIndexChanged);
            this.dostupnueBooksComboBox.Click += new System.EventHandler(this.DostupnueBooks_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11F);
            this.label3.Location = new System.Drawing.Point(115, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(352, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "Количество экземпляров для заказа";
            // 
            // countExemplarsTextBox
            // 
            this.countExemplarsTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.countExemplarsTextBox.Location = new System.Drawing.Point(120, 395);
            this.countExemplarsTextBox.Name = "countExemplarsTextBox";
            this.countExemplarsTextBox.Size = new System.Drawing.Size(350, 34);
            this.countExemplarsTextBox.TabIndex = 5;
            // 
            // zakazButton
            // 
            this.zakazButton.BackColor = System.Drawing.Color.DarkCyan;
            this.zakazButton.Font = new System.Drawing.Font("Calibri", 12F);
            this.zakazButton.ForeColor = System.Drawing.Color.White;
            this.zakazButton.Location = new System.Drawing.Point(120, 517);
            this.zakazButton.Name = "zakazButton";
            this.zakazButton.Size = new System.Drawing.Size(350, 70);
            this.zakazButton.TabIndex = 6;
            this.zakazButton.Text = "Заказать";
            this.zakazButton.UseVisualStyleBackColor = false;
            this.zakazButton.Click += new System.EventHandler(this.zakazButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(167, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(262, 35);
            this.label5.TabIndex = 19;
            this.label5.Text = "Оформление заказа:";
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.IndianRed;
            this.exitButton.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitButton.Location = new System.Drawing.Point(493, 659);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(83, 33);
            this.exitButton.TabIndex = 31;
            this.exitButton.Text = "Выйти";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // ZakazForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(578, 694);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.zakazButton);
            this.Controls.Add(this.countExemplarsTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dostupnueBooksComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IDzakazchikaTextBox);
            this.Controls.Add(this.label1);
            this.Name = "ZakazForm";
            this.Text = "ZakazchikForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IDzakazchikaTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox dostupnueBooksComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox countExemplarsTextBox;
        private System.Windows.Forms.Button zakazButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button exitButton;
    }
}