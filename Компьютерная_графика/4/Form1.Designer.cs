namespace KG_LR4
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
            this.originalPictureButton = new System.Windows.Forms.Button();
            this.originalPicture = new System.Windows.Forms.PictureBox();
            this.grayOttenkiButton = new System.Windows.Forms.Button();
            this.grayOttenki = new System.Windows.Forms.PictureBox();
            this.preparirovaniePicture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Preparirovanie = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.minPrepar = new System.Windows.Forms.TextBox();
            this.maxPrepar = new System.Windows.Forms.TextBox();
            this.maskFilter = new System.Windows.Forms.PictureBox();
            this.maskFilterButton = new System.Windows.Forms.Button();
            this.zadanie4Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.originalPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grayOttenki)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparirovaniePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // originalPictureButton
            // 
            this.originalPictureButton.Location = new System.Drawing.Point(50, 443);
            this.originalPictureButton.Name = "originalPictureButton";
            this.originalPictureButton.Size = new System.Drawing.Size(176, 66);
            this.originalPictureButton.TabIndex = 0;
            this.originalPictureButton.Text = "Загрузить изображение";
            this.originalPictureButton.UseVisualStyleBackColor = true;
            this.originalPictureButton.Click += new System.EventHandler(this.originalPictureButton_Click);
            // 
            // originalPicture
            // 
            this.originalPicture.Location = new System.Drawing.Point(12, 48);
            this.originalPicture.Name = "originalPicture";
            this.originalPicture.Size = new System.Drawing.Size(270, 370);
            this.originalPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.originalPicture.TabIndex = 1;
            this.originalPicture.TabStop = false;
            // 
            // grayOttenkiButton
            // 
            this.grayOttenkiButton.Location = new System.Drawing.Point(378, 443);
            this.grayOttenkiButton.Name = "grayOttenkiButton";
            this.grayOttenkiButton.Size = new System.Drawing.Size(176, 66);
            this.grayOttenkiButton.TabIndex = 2;
            this.grayOttenkiButton.Text = "Оттенки серого";
            this.grayOttenkiButton.UseVisualStyleBackColor = true;
            this.grayOttenkiButton.Click += new System.EventHandler(this.grayOttenkiButton_Click);
            // 
            // grayOttenki
            // 
            this.grayOttenki.Location = new System.Drawing.Point(332, 48);
            this.grayOttenki.Name = "grayOttenki";
            this.grayOttenki.Size = new System.Drawing.Size(270, 370);
            this.grayOttenki.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.grayOttenki.TabIndex = 3;
            this.grayOttenki.TabStop = false;
            // 
            // preparirovaniePicture
            // 
            this.preparirovaniePicture.Location = new System.Drawing.Point(650, 48);
            this.preparirovaniePicture.Name = "preparirovaniePicture";
            this.preparirovaniePicture.Size = new System.Drawing.Size(270, 370);
            this.preparirovaniePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.preparirovaniePicture.TabIndex = 4;
            this.preparirovaniePicture.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(715, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Препарирование";
            // 
            // Preparirovanie
            // 
            this.Preparirovanie.FormattingEnabled = true;
            this.Preparirovanie.Items.AddRange(new object[] {
            "г: Контрастное масштабирование",
            "е: Контрастное масштабирование на черном фоне",
            "ж: Контрастное масштабирование на белом фоне",
            "з: Контрастное масштабирование на сером фоне"});
            this.Preparirovanie.Location = new System.Drawing.Point(621, 521);
            this.Preparirovanie.Name = "Preparirovanie";
            this.Preparirovanie.Size = new System.Drawing.Size(347, 28);
            this.Preparirovanie.TabIndex = 6;
            this.Preparirovanie.SelectedIndexChanged += new System.EventHandler(this.Preparirovanie_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(646, 476);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Диапазон от:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(834, 476);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "до:";
            // 
            // minPrepar
            // 
            this.minPrepar.Location = new System.Drawing.Point(753, 473);
            this.minPrepar.Name = "minPrepar";
            this.minPrepar.Size = new System.Drawing.Size(75, 26);
            this.minPrepar.TabIndex = 9;
            this.minPrepar.Text = "50";
            // 
            // maxPrepar
            // 
            this.maxPrepar.Location = new System.Drawing.Point(864, 473);
            this.maxPrepar.Name = "maxPrepar";
            this.maxPrepar.Size = new System.Drawing.Size(75, 26);
            this.maxPrepar.TabIndex = 10;
            this.maxPrepar.Text = "200";
            // 
            // maskFilter
            // 
            this.maskFilter.Location = new System.Drawing.Point(968, 48);
            this.maskFilter.Name = "maskFilter";
            this.maskFilter.Size = new System.Drawing.Size(270, 370);
            this.maskFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.maskFilter.TabIndex = 11;
            this.maskFilter.TabStop = false;
            // 
            // maskFilterButton
            // 
            this.maskFilterButton.Location = new System.Drawing.Point(1018, 443);
            this.maskFilterButton.Name = "maskFilterButton";
            this.maskFilterButton.Size = new System.Drawing.Size(187, 82);
            this.maskFilterButton.TabIndex = 12;
            this.maskFilterButton.Text = "Масочная фильтрация (рельефность)";
            this.maskFilterButton.UseVisualStyleBackColor = true;
            this.maskFilterButton.Click += new System.EventHandler(this.MaskFilterButton_Click);
            // 
            // zadanie4Button
            // 
            this.zadanie4Button.BackColor = System.Drawing.Color.DarkCyan;
            this.zadanie4Button.Location = new System.Drawing.Point(1156, 531);
            this.zadanie4Button.Name = "zadanie4Button";
            this.zadanie4Button.Size = new System.Drawing.Size(134, 41);
            this.zadanie4Button.TabIndex = 13;
            this.zadanie4Button.Text = "Задание 4";
            this.zadanie4Button.UseVisualStyleBackColor = false;
            this.zadanie4Button.Click += new System.EventHandler(this.zadanie4Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 574);
            this.Controls.Add(this.zadanie4Button);
            this.Controls.Add(this.maskFilterButton);
            this.Controls.Add(this.maskFilter);
            this.Controls.Add(this.maxPrepar);
            this.Controls.Add(this.minPrepar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Preparirovanie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.preparirovaniePicture);
            this.Controls.Add(this.grayOttenki);
            this.Controls.Add(this.grayOttenkiButton);
            this.Controls.Add(this.originalPicture);
            this.Controls.Add(this.originalPictureButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.originalPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grayOttenki)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparirovaniePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskFilter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button originalPictureButton;
        public System.Windows.Forms.PictureBox originalPicture;
        private System.Windows.Forms.Button grayOttenkiButton;
        private System.Windows.Forms.PictureBox grayOttenki;
        private System.Windows.Forms.PictureBox preparirovaniePicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Preparirovanie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox minPrepar;
        private System.Windows.Forms.TextBox maxPrepar;
        private System.Windows.Forms.PictureBox maskFilter;
        private System.Windows.Forms.Button maskFilterButton;
        private System.Windows.Forms.Button zadanie4Button;
    }
}

