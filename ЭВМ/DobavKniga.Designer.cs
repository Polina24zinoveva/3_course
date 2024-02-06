namespace WindowsFormsApp1
{
    partial class DobavKniga
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
            this.dobavButton = new System.Windows.Forms.Button();
            this.numberPassportTextBox = new System.Windows.Forms.TextBox();
            this.nameKnigaTextBox = new System.Windows.Forms.TextBox();
            this.costKnigaTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.costknigaINMAGAZINTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dobavButton
            // 
            this.dobavButton.BackColor = System.Drawing.Color.DarkCyan;
            this.dobavButton.Font = new System.Drawing.Font("Calibri", 11F);
            this.dobavButton.ForeColor = System.Drawing.Color.White;
            this.dobavButton.Location = new System.Drawing.Point(120, 546);
            this.dobavButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dobavButton.Name = "dobavButton";
            this.dobavButton.Size = new System.Drawing.Size(350, 70);
            this.dobavButton.TabIndex = 0;
            this.dobavButton.Text = "Добавить книгу";
            this.dobavButton.UseVisualStyleBackColor = false;
            this.dobavButton.Click += new System.EventHandler(this.dobavButton_Click);
            // 
            // numberPassportTextBox
            // 
            this.numberPassportTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.numberPassportTextBox.Location = new System.Drawing.Point(120, 211);
            this.numberPassportTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numberPassportTextBox.Name = "numberPassportTextBox";
            this.numberPassportTextBox.Size = new System.Drawing.Size(350, 34);
            this.numberPassportTextBox.TabIndex = 1;
            // 
            // nameKnigaTextBox
            // 
            this.nameKnigaTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.nameKnigaTextBox.Location = new System.Drawing.Point(120, 294);
            this.nameKnigaTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nameKnigaTextBox.Name = "nameKnigaTextBox";
            this.nameKnigaTextBox.Size = new System.Drawing.Size(350, 34);
            this.nameKnigaTextBox.TabIndex = 2;
            // 
            // costKnigaTextBox
            // 
            this.costKnigaTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.costKnigaTextBox.Location = new System.Drawing.Point(120, 373);
            this.costKnigaTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.costKnigaTextBox.Name = "costKnigaTextBox";
            this.costKnigaTextBox.Size = new System.Drawing.Size(350, 34);
            this.costKnigaTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11F);
            this.label1.Location = new System.Drawing.Point(115, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "Номера паспортов авторов книги";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11F);
            this.label2.Location = new System.Drawing.Point(115, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "Название книги";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11F);
            this.label3.Location = new System.Drawing.Point(115, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 27);
            this.label3.TabIndex = 6;
            this.label3.Text = "Себестоимость книги";
            // 
            // costknigaINMAGAZINTextBox
            // 
            this.costknigaINMAGAZINTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.costknigaINMAGAZINTextBox.Location = new System.Drawing.Point(120, 451);
            this.costknigaINMAGAZINTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.costknigaINMAGAZINTextBox.Name = "costknigaINMAGAZINTextBox";
            this.costknigaINMAGAZINTextBox.Size = new System.Drawing.Size(350, 34);
            this.costknigaINMAGAZINTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11F);
            this.label4.Location = new System.Drawing.Point(115, 420);
            this.label4.MaximumSize = new System.Drawing.Size(500, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 27);
            this.label4.TabIndex = 8;
            this.label4.Text = "Цена книги";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(166, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(249, 35);
            this.label5.TabIndex = 9;
            this.label5.Text = " Добавление книги:";
            // 
            // DobavKniga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(578, 694);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.costknigaINMAGAZINTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.costKnigaTextBox);
            this.Controls.Add(this.nameKnigaTextBox);
            this.Controls.Add(this.numberPassportTextBox);
            this.Controls.Add(this.dobavButton);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DobavKniga";
            this.Text = "DobavKniga";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dobavButton;
        private System.Windows.Forms.TextBox numberPassportTextBox;
        private System.Windows.Forms.TextBox nameKnigaTextBox;
        private System.Windows.Forms.TextBox costKnigaTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox costknigaINMAGAZINTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}