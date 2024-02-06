namespace KG_LR4
{
    partial class Form2
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
            this.zadanie1_3Button = new System.Windows.Forms.Button();
            this.hafButton = new System.Windows.Forms.Button();
            this.hafPicture = new System.Windows.Forms.PictureBox();
            this.wavePicture = new System.Windows.Forms.PictureBox();
            this.evristicPicture = new System.Windows.Forms.PictureBox();
            this.evristicButton = new System.Windows.Forms.Button();
            this.firstPicture = new System.Windows.Forms.PictureBox();
            this.firstPictureButton = new System.Windows.Forms.Button();
            this.waveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.hafPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wavePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evristicPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // zadanie1_3Button
            // 
            this.zadanie1_3Button.BackColor = System.Drawing.Color.DarkCyan;
            this.zadanie1_3Button.Location = new System.Drawing.Point(1161, 535);
            this.zadanie1_3Button.Name = "zadanie1_3Button";
            this.zadanie1_3Button.Size = new System.Drawing.Size(134, 41);
            this.zadanie1_3Button.TabIndex = 27;
            this.zadanie1_3Button.Text = "Задание 1-3";
            this.zadanie1_3Button.UseVisualStyleBackColor = false;
            this.zadanie1_3Button.Click += new System.EventHandler(this.zadanie1_3Button_Click);
            // 
            // hafButton
            // 
            this.hafButton.Enabled = false;
            this.hafButton.Location = new System.Drawing.Point(1009, 434);
            this.hafButton.Name = "hafButton";
            this.hafButton.Size = new System.Drawing.Size(201, 95);
            this.hafButton.TabIndex = 26;
            this.hafButton.Text = "Векторизация растровых изображений. Преобразование Хафа";
            this.hafButton.UseVisualStyleBackColor = true;
            this.hafButton.Visible = false;
            this.hafButton.Click += new System.EventHandler(this.HafButton_Click);
            // 
            // hafPicture
            // 
            this.hafPicture.Location = new System.Drawing.Point(973, 52);
            this.hafPicture.Name = "hafPicture";
            this.hafPicture.Size = new System.Drawing.Size(270, 370);
            this.hafPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hafPicture.TabIndex = 25;
            this.hafPicture.TabStop = false;
            // 
            // wavePicture
            // 
            this.wavePicture.Location = new System.Drawing.Point(655, 52);
            this.wavePicture.Name = "wavePicture";
            this.wavePicture.Size = new System.Drawing.Size(270, 370);
            this.wavePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.wavePicture.TabIndex = 18;
            this.wavePicture.TabStop = false;
            // 
            // evristicPicture
            // 
            this.evristicPicture.Location = new System.Drawing.Point(332, 52);
            this.evristicPicture.Name = "evristicPicture";
            this.evristicPicture.Size = new System.Drawing.Size(270, 370);
            this.evristicPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.evristicPicture.TabIndex = 17;
            this.evristicPicture.TabStop = false;
            // 
            // evristicButton
            // 
            this.evristicButton.Location = new System.Drawing.Point(383, 447);
            this.evristicButton.Name = "evristicButton";
            this.evristicButton.Size = new System.Drawing.Size(176, 66);
            this.evristicButton.TabIndex = 16;
            this.evristicButton.Text = "Эвристический алгоритм ";
            this.evristicButton.UseVisualStyleBackColor = true;
            this.evristicButton.Click += new System.EventHandler(this.Evristicheskiy_algoritmButton_Click);
            // 
            // firstPicture
            // 
            this.firstPicture.Location = new System.Drawing.Point(17, 52);
            this.firstPicture.Name = "firstPicture";
            this.firstPicture.Size = new System.Drawing.Size(270, 370);
            this.firstPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.firstPicture.TabIndex = 15;
            this.firstPicture.TabStop = false;
            // 
            // firstPictureButton
            // 
            this.firstPictureButton.Location = new System.Drawing.Point(55, 447);
            this.firstPictureButton.Name = "firstPictureButton";
            this.firstPictureButton.Size = new System.Drawing.Size(176, 66);
            this.firstPictureButton.TabIndex = 14;
            this.firstPictureButton.Text = "Загрузить изображение";
            this.firstPictureButton.UseVisualStyleBackColor = true;
            this.firstPictureButton.Click += new System.EventHandler(this.originalPictureButton_Click);
            // 
            // waveButton
            // 
            this.waveButton.Location = new System.Drawing.Point(704, 448);
            this.waveButton.Name = "waveButton";
            this.waveButton.Size = new System.Drawing.Size(176, 66);
            this.waveButton.TabIndex = 28;
            this.waveButton.Text = "Волновой алгоритм ";
            this.waveButton.UseVisualStyleBackColor = true;
            this.waveButton.Click += new System.EventHandler(this.WaveButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 574);
            this.Controls.Add(this.waveButton);
            this.Controls.Add(this.zadanie1_3Button);
            this.Controls.Add(this.hafButton);
            this.Controls.Add(this.hafPicture);
            this.Controls.Add(this.wavePicture);
            this.Controls.Add(this.evristicPicture);
            this.Controls.Add(this.evristicButton);
            this.Controls.Add(this.firstPicture);
            this.Controls.Add(this.firstPictureButton);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.hafPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wavePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evristicPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button zadanie1_3Button;
        private System.Windows.Forms.Button hafButton;
        private System.Windows.Forms.PictureBox hafPicture;
        private System.Windows.Forms.PictureBox wavePicture;
        private System.Windows.Forms.PictureBox evristicPicture;
        private System.Windows.Forms.Button evristicButton;
        private System.Windows.Forms.PictureBox firstPicture;
        private System.Windows.Forms.Button firstPictureButton;
        private System.Windows.Forms.Button waveButton;
    }
}