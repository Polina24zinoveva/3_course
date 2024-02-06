namespace WindowsFormsApp1
{
    partial class NewZakazchikForm
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
            this.telephoneTextBox = new System.Windows.Forms.TextBox();
            this.FIOPredstavitelaTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.nameZakazchikaTextBox = new System.Windows.Forms.TextBox();
            this.zakluchitContractButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(149, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = " Регистрация заказчика:";
            // 
            // telephoneTextBox
            // 
            this.telephoneTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.telephoneTextBox.ForeColor = System.Drawing.Color.Gray;
            this.telephoneTextBox.Location = new System.Drawing.Point(125, 324);
            this.telephoneTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.telephoneTextBox.Name = "telephoneTextBox";
            this.telephoneTextBox.Size = new System.Drawing.Size(350, 34);
            this.telephoneTextBox.TabIndex = 11;
            this.telephoneTextBox.Text = "Телефон";
            this.telephoneTextBox.Click += new System.EventHandler(this.telephoneTextBox_Click);
            // 
            // FIOPredstavitelaTextBox
            // 
            this.FIOPredstavitelaTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.FIOPredstavitelaTextBox.ForeColor = System.Drawing.Color.Gray;
            this.FIOPredstavitelaTextBox.Location = new System.Drawing.Point(125, 376);
            this.FIOPredstavitelaTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FIOPredstavitelaTextBox.Name = "FIOPredstavitelaTextBox";
            this.FIOPredstavitelaTextBox.Size = new System.Drawing.Size(350, 34);
            this.FIOPredstavitelaTextBox.TabIndex = 9;
            this.FIOPredstavitelaTextBox.Text = "Ф.И.О. представителя";
            this.FIOPredstavitelaTextBox.Click += new System.EventHandler(this.FIOPredstavitelaTextBox_Click);
            // 
            // addressTextBox
            // 
            this.addressTextBox.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addressTextBox.ForeColor = System.Drawing.Color.Gray;
            this.addressTextBox.Location = new System.Drawing.Point(125, 272);
            this.addressTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(350, 34);
            this.addressTextBox.TabIndex = 8;
            this.addressTextBox.Text = "Адрес";
            this.addressTextBox.Click += new System.EventHandler(this.addressTextBox_Click);
            // 
            // nameZakazchikaTextBox
            // 
            this.nameZakazchikaTextBox.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameZakazchikaTextBox.ForeColor = System.Drawing.Color.Gray;
            this.nameZakazchikaTextBox.Location = new System.Drawing.Point(125, 220);
            this.nameZakazchikaTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nameZakazchikaTextBox.Name = "nameZakazchikaTextBox";
            this.nameZakazchikaTextBox.Size = new System.Drawing.Size(350, 34);
            this.nameZakazchikaTextBox.TabIndex = 7;
            this.nameZakazchikaTextBox.Text = "Имя заказчика";
            this.nameZakazchikaTextBox.Click += new System.EventHandler(this.nameTextBox_Click);
            // 
            // zakluchitContractButton
            // 
            this.zakluchitContractButton.BackColor = System.Drawing.Color.DarkCyan;
            this.zakluchitContractButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zakluchitContractButton.ForeColor = System.Drawing.Color.White;
            this.zakluchitContractButton.Location = new System.Drawing.Point(125, 501);
            this.zakluchitContractButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.zakluchitContractButton.Name = "zakluchitContractButton";
            this.zakluchitContractButton.Size = new System.Drawing.Size(350, 70);
            this.zakluchitContractButton.TabIndex = 12;
            this.zakluchitContractButton.Text = "Зарегистрироваться";
            this.zakluchitContractButton.UseVisualStyleBackColor = false;
            this.zakluchitContractButton.Click += new System.EventHandler(this.addZakazchikButton_Click);
            // 
            // NewZakazchikForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(578, 694);
            this.Controls.Add(this.zakluchitContractButton);
            this.Controls.Add(this.telephoneTextBox);
            this.Controls.Add(this.FIOPredstavitelaTextBox);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.nameZakazchikaTextBox);
            this.Controls.Add(this.label1);
            this.Name = "NewZakazchikForm";
            this.Text = "NewZakazchikForm";
            this.Load += new System.EventHandler(this.NewZakazchikForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox telephoneTextBox;
        private System.Windows.Forms.TextBox FIOPredstavitelaTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox nameZakazchikaTextBox;
        private System.Windows.Forms.Button zakluchitContractButton;
    }
}