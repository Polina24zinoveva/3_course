namespace KG_LR5
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.peremeshenieXtrackBar = new System.Windows.Forms.TrackBar();
            this.povorotYtrackBar = new System.Windows.Forms.TrackBar();
            this.povorotXtrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.peremeshenieYtrackBar = new System.Windows.Forms.TrackBar();
            this.povorotZtrackBar = new System.Windows.Forms.TrackBar();
            this.mashtabirovanieTrackBar = new System.Windows.Forms.TrackBar();
            this.peremeshenieZtrackBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peremeshenieXtrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.povorotYtrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.povorotXtrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peremeshenieYtrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.povorotZtrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mashtabirovanieTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peremeshenieZtrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(-2, -2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(675, 675);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // peremeshenieXtrackBar
            // 
            this.peremeshenieXtrackBar.Location = new System.Drawing.Point(920, 22);
            this.peremeshenieXtrackBar.Name = "peremeshenieXtrackBar";
            this.peremeshenieXtrackBar.Size = new System.Drawing.Size(227, 69);
            this.peremeshenieXtrackBar.TabIndex = 1;
            this.peremeshenieXtrackBar.Value = 5;
            // 
            // povorotYtrackBar
            // 
            this.povorotYtrackBar.Location = new System.Drawing.Point(914, 510);
            this.povorotYtrackBar.Maximum = 360;
            this.povorotYtrackBar.Name = "povorotYtrackBar";
            this.povorotYtrackBar.Size = new System.Drawing.Size(227, 69);
            this.povorotYtrackBar.TabIndex = 2;
            this.povorotYtrackBar.Value = 180;
            // 
            // povorotXtrackBar
            // 
            this.povorotXtrackBar.Location = new System.Drawing.Point(914, 435);
            this.povorotXtrackBar.Maximum = 360;
            this.povorotXtrackBar.Name = "povorotXtrackBar";
            this.povorotXtrackBar.Size = new System.Drawing.Size(227, 69);
            this.povorotXtrackBar.TabIndex = 3;
            this.povorotXtrackBar.Value = 180;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(700, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Перемещение по оси  X:";
            // 
            // peremeshenieYtrackBar
            // 
            this.peremeshenieYtrackBar.Location = new System.Drawing.Point(920, 97);
            this.peremeshenieYtrackBar.Name = "peremeshenieYtrackBar";
            this.peremeshenieYtrackBar.Size = new System.Drawing.Size(227, 69);
            this.peremeshenieYtrackBar.TabIndex = 5;
            this.peremeshenieYtrackBar.Value = 5;
            // 
            // povorotZtrackBar
            // 
            this.povorotZtrackBar.Location = new System.Drawing.Point(914, 585);
            this.povorotZtrackBar.Maximum = 360;
            this.povorotZtrackBar.Name = "povorotZtrackBar";
            this.povorotZtrackBar.Size = new System.Drawing.Size(227, 69);
            this.povorotZtrackBar.TabIndex = 6;
            this.povorotZtrackBar.Value = 180;
            // 
            // mashtabirovanieTrackBar
            // 
            this.mashtabirovanieTrackBar.Location = new System.Drawing.Point(920, 298);
            this.mashtabirovanieTrackBar.Maximum = 80;
            this.mashtabirovanieTrackBar.Minimum = 30;
            this.mashtabirovanieTrackBar.Name = "mashtabirovanieTrackBar";
            this.mashtabirovanieTrackBar.Size = new System.Drawing.Size(227, 69);
            this.mashtabirovanieTrackBar.TabIndex = 7;
            this.mashtabirovanieTrackBar.Value = 55;
            // 
            // peremeshenieZtrackBar
            // 
            this.peremeshenieZtrackBar.Location = new System.Drawing.Point(920, 172);
            this.peremeshenieZtrackBar.Name = "peremeshenieZtrackBar";
            this.peremeshenieZtrackBar.Size = new System.Drawing.Size(227, 69);
            this.peremeshenieZtrackBar.TabIndex = 4;
            this.peremeshenieZtrackBar.Value = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(700, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Перемещение по оси  Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(700, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Перемещение по оси  Z:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(718, 585);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Поворот по оси  Z:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(718, 510);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Поворот по оси  Y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(718, 435);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Поворот по оси  X:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(719, 298);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "Масштабирование:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 674);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mashtabirovanieTrackBar);
            this.Controls.Add(this.povorotZtrackBar);
            this.Controls.Add(this.peremeshenieYtrackBar);
            this.Controls.Add(this.peremeshenieZtrackBar);
            this.Controls.Add(this.povorotXtrackBar);
            this.Controls.Add(this.povorotYtrackBar);
            this.Controls.Add(this.peremeshenieXtrackBar);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peremeshenieXtrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.povorotYtrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.povorotXtrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peremeshenieYtrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.povorotZtrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mashtabirovanieTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peremeshenieZtrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox;
        private System.Windows.Forms.Timer timer;
        private TrackBar peremeshenieXtrackBar;
        private TrackBar povorotYtrackBar;
        private TrackBar povorotXtrackBar;
        private Label label1;
        private TrackBar peremeshenieYtrackBar;
        private TrackBar povorotZtrackBar;
        private TrackBar mashtabirovanieTrackBar;
        private TrackBar peremeshenieZtrackBar;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}