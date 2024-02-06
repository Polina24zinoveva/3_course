namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pisatelButton = new System.Windows.Forms.Button();
            this.zakazchikButton = new System.Windows.Forms.Button();
            this.kniga = new System.Windows.Forms.Button();
            this.administrator = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Goldenrod;
            this.label1.Location = new System.Drawing.Point(342, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(580, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "\"Апрельская страница\"";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Goldenrod;
            this.label2.Location = new System.Drawing.Point(477, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 44);
            this.label2.TabIndex = 1;
            this.label2.Text = "Издательский центр";
            // 
            // pisatelButton
            // 
            this.pisatelButton.BackColor = System.Drawing.Color.PowderBlue;
            this.pisatelButton.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pisatelButton.ForeColor = System.Drawing.Color.Black;
            this.pisatelButton.Location = new System.Drawing.Point(96, 565);
            this.pisatelButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pisatelButton.Name = "pisatelButton";
            this.pisatelButton.Size = new System.Drawing.Size(230, 80);
            this.pisatelButton.TabIndex = 2;
            this.pisatelButton.Text = "Для писателей";
            this.pisatelButton.UseVisualStyleBackColor = false;
            this.pisatelButton.Click += new System.EventHandler(this.pisatelButton_Click);
            // 
            // zakazchikButton
            // 
            this.zakazchikButton.BackColor = System.Drawing.Color.PowderBlue;
            this.zakazchikButton.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zakazchikButton.ForeColor = System.Drawing.Color.Black;
            this.zakazchikButton.Location = new System.Drawing.Point(692, 565);
            this.zakazchikButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.zakazchikButton.Name = "zakazchikButton";
            this.zakazchikButton.Size = new System.Drawing.Size(230, 80);
            this.zakazchikButton.TabIndex = 3;
            this.zakazchikButton.Text = "Для заказчиков";
            this.zakazchikButton.UseVisualStyleBackColor = false;
            this.zakazchikButton.Click += new System.EventHandler(this.zakazchiklButton_Click);
            // 
            // kniga
            // 
            this.kniga.BackColor = System.Drawing.Color.PowderBlue;
            this.kniga.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kniga.ForeColor = System.Drawing.Color.Black;
            this.kniga.Location = new System.Drawing.Point(402, 565);
            this.kniga.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kniga.Name = "kniga";
            this.kniga.Size = new System.Drawing.Size(230, 80);
            this.kniga.TabIndex = 4;
            this.kniga.Text = "Выпустить книгу";
            this.kniga.UseVisualStyleBackColor = false;
            this.kniga.Click += new System.EventHandler(this.kniga_Click);
            // 
            // administrator
            // 
            this.administrator.AutoSize = true;
            this.administrator.Location = new System.Drawing.Point(1093, 9);
            this.administrator.Name = "administrator";
            this.administrator.Size = new System.Drawing.Size(0, 20);
            this.administrator.TabIndex = 5;
            this.administrator.Click += new System.EventHandler(this.administrator_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PowderBlue;
            this.button1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(975, 565);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 80);
            this.button1.TabIndex = 6;
            this.button1.Text = "Для администратора";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.administrator_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1278, 694);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.administrator);
            this.Controls.Add(this.kniga);
            this.Controls.Add(this.zakazchikButton);
            this.Controls.Add(this.pisatelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button pisatelButton;
        private System.Windows.Forms.Button zakazchikButton;
        private System.Windows.Forms.Button kniga;
        private System.Windows.Forms.Label administrator;
        private System.Windows.Forms.Button button1;
    }
}

