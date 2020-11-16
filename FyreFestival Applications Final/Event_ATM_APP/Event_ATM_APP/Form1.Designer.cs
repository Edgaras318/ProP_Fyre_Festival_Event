namespace Event_ATM_APP
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblRfid = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDeposit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeposit5 = new System.Windows.Forms.Button();
            this.btnDeposit10 = new System.Windows.Forms.Button();
            this.btnDeposit50 = new System.Windows.Forms.Button();
            this.btnDeposit20 = new System.Windows.Forms.Button();
            this.lblRfidConnetion = new System.Windows.Forms.Label();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 148);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblRfid
            // 
            this.lblRfid.AutoSize = true;
            this.lblRfid.BackColor = System.Drawing.SystemColors.Control;
            this.lblRfid.Font = new System.Drawing.Font("Sitka Small", 16F, System.Drawing.FontStyle.Bold);
            this.lblRfid.ForeColor = System.Drawing.Color.Lime;
            this.lblRfid.Location = new System.Drawing.Point(384, 108);
            this.lblRfid.Name = "lblRfid";
            this.lblRfid.Size = new System.Drawing.Size(72, 40);
            this.lblRfid.TabIndex = 33;
            this.lblRfid.Text = "rfid";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Sitka Small", 16F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(266, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 40);
            this.label4.TabIndex = 32;
            this.label4.Text = "RFID: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Sitka Small", 16F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(401, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 40);
            this.label3.TabIndex = 31;
            this.label3.Text = "Enter amount:";
            // 
            // btnDeposit
            // 
            this.btnDeposit.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnDeposit.Font = new System.Drawing.Font("Castellar", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeposit.ForeColor = System.Drawing.Color.Red;
            this.btnDeposit.Location = new System.Drawing.Point(408, 255);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(377, 86);
            this.btnDeposit.TabIndex = 30;
            this.btnDeposit.Text = "Add Amount";
            this.btnDeposit.UseVisualStyleBackColor = false;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnDeposit5);
            this.groupBox1.Controls.Add(this.btnDeposit10);
            this.groupBox1.Controls.Add(this.btnDeposit50);
            this.groupBox1.Controls.Add(this.btnDeposit20);
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(13, 184);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(381, 370);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(95, 314);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(233, 17);
            this.label14.TabIndex = 9;
            this.label14.Text = "To deposit 50 euros on the account";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(95, 242);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(233, 17);
            this.label12.TabIndex = 7;
            this.label12.Text = "To deposit 20 euros on the account";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(95, 167);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(233, 17);
            this.label11.TabIndex = 6;
            this.label11.Text = "To deposit 10 euros on the account";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(95, 90);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(225, 17);
            this.label10.TabIndex = 5;
            this.label10.Text = "To deposit 5 euros on the account";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(76, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quick Transaction";
            // 
            // btnDeposit5
            // 
            this.btnDeposit5.Location = new System.Drawing.Point(8, 71);
            this.btnDeposit5.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeposit5.Name = "btnDeposit5";
            this.btnDeposit5.Size = new System.Drawing.Size(76, 53);
            this.btnDeposit5.TabIndex = 1;
            this.btnDeposit5.Text = "5";
            this.btnDeposit5.UseVisualStyleBackColor = true;
            this.btnDeposit5.Click += new System.EventHandler(this.btnDeposit5_Click);
            // 
            // btnDeposit10
            // 
            this.btnDeposit10.Location = new System.Drawing.Point(8, 149);
            this.btnDeposit10.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeposit10.Name = "btnDeposit10";
            this.btnDeposit10.Size = new System.Drawing.Size(76, 54);
            this.btnDeposit10.TabIndex = 1;
            this.btnDeposit10.Text = "10";
            this.btnDeposit10.UseVisualStyleBackColor = true;
            this.btnDeposit10.Click += new System.EventHandler(this.btnDeposit10_Click);
            // 
            // btnDeposit50
            // 
            this.btnDeposit50.Location = new System.Drawing.Point(8, 295);
            this.btnDeposit50.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeposit50.Name = "btnDeposit50";
            this.btnDeposit50.Size = new System.Drawing.Size(76, 54);
            this.btnDeposit50.TabIndex = 1;
            this.btnDeposit50.Text = "50";
            this.btnDeposit50.UseVisualStyleBackColor = true;
            this.btnDeposit50.Click += new System.EventHandler(this.btnDeposit50_Click);
            // 
            // btnDeposit20
            // 
            this.btnDeposit20.Location = new System.Drawing.Point(8, 224);
            this.btnDeposit20.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeposit20.Name = "btnDeposit20";
            this.btnDeposit20.Size = new System.Drawing.Size(76, 54);
            this.btnDeposit20.TabIndex = 1;
            this.btnDeposit20.Text = "20";
            this.btnDeposit20.UseVisualStyleBackColor = true;
            this.btnDeposit20.Click += new System.EventHandler(this.btnDeposit20_Click);
            // 
            // lblRfidConnetion
            // 
            this.lblRfidConnetion.AutoSize = true;
            this.lblRfidConnetion.BackColor = System.Drawing.SystemColors.Control;
            this.lblRfidConnetion.Font = new System.Drawing.Font("Sitka Small", 16F, System.Drawing.FontStyle.Bold);
            this.lblRfidConnetion.ForeColor = System.Drawing.Color.Blue;
            this.lblRfidConnetion.Location = new System.Drawing.Point(266, 47);
            this.lblRfidConnetion.Name = "lblRfidConnetion";
            this.lblRfidConnetion.Size = new System.Drawing.Size(258, 40);
            this.lblRfidConnetion.TabIndex = 36;
            this.lblRfidConnetion.Text = "RFID Connection";
            // 
            // nudAmount
            // 
            this.nudAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAmount.Location = new System.Drawing.Point(648, 210);
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(120, 26);
            this.nudAmount.TabIndex = 37;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 561);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.lblRfidConnetion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblRfid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDeposit);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Fyre Festival ATM Application";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblRfid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeposit5;
        private System.Windows.Forms.Button btnDeposit10;
        private System.Windows.Forms.Button btnDeposit50;
        private System.Windows.Forms.Button btnDeposit20;
        private System.Windows.Forms.Label lblRfidConnetion;
        private System.Windows.Forms.NumericUpDown nudAmount;
    }
}

