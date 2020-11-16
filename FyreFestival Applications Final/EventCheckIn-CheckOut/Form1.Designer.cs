namespace EventCheckIn_CheckOut
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
            this.lbInfo = new System.Windows.Forms.ListBox();
            this.btnReadingFromFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUpdateDate = new System.Windows.Forms.Label();
            this.pbCheckIn = new System.Windows.Forms.PictureBox();
            this.pbCheckOut = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDbStatus = new System.Windows.Forms.Label();
            this.btnPushChanges = new System.Windows.Forms.Button();
            this.rbnMay16 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.f = new System.Windows.Forms.GroupBox();
            this.rbnMay15 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCheckIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCheckOut)).BeginInit();
            this.f.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EventCheckIn_CheckOut.Properties.Resources.FMFblack;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 148);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbInfo
            // 
            this.lbInfo.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.FormattingEnabled = true;
            this.lbInfo.ItemHeight = 29;
            this.lbInfo.Location = new System.Drawing.Point(177, 12);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(986, 149);
            this.lbInfo.TabIndex = 4;
            // 
            // btnReadingFromFile
            // 
            this.btnReadingFromFile.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnReadingFromFile.Font = new System.Drawing.Font("Castellar", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadingFromFile.ForeColor = System.Drawing.Color.Red;
            this.btnReadingFromFile.Location = new System.Drawing.Point(616, 295);
            this.btnReadingFromFile.Name = "btnReadingFromFile";
            this.btnReadingFromFile.Size = new System.Drawing.Size(574, 123);
            this.btnReadingFromFile.TabIndex = 11;
            this.btnReadingFromFile.Text = "START READING FROM A FILE";
            this.btnReadingFromFile.UseVisualStyleBackColor = false;
            this.btnReadingFromFile.Click += new System.EventHandler(this.btnReadingFromFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlText;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(12, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 39);
            this.label1.TabIndex = 12;
            this.label1.Text = "Database updated: ";
            // 
            // lblUpdateDate
            // 
            this.lblUpdateDate.AutoSize = true;
            this.lblUpdateDate.BackColor = System.Drawing.Color.Black;
            this.lblUpdateDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateDate.ForeColor = System.Drawing.Color.Gold;
            this.lblUpdateDate.Location = new System.Drawing.Point(322, 182);
            this.lblUpdateDate.Name = "lblUpdateDate";
            this.lblUpdateDate.Size = new System.Drawing.Size(0, 39);
            this.lblUpdateDate.TabIndex = 13;
            // 
            // pbCheckIn
            // 
            this.pbCheckIn.Image = ((System.Drawing.Image)(resources.GetObject("pbCheckIn.Image")));
            this.pbCheckIn.Location = new System.Drawing.Point(12, 295);
            this.pbCheckIn.Name = "pbCheckIn";
            this.pbCheckIn.Size = new System.Drawing.Size(300, 300);
            this.pbCheckIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCheckIn.TabIndex = 15;
            this.pbCheckIn.TabStop = false;
            this.pbCheckIn.Visible = false;
            // 
            // pbCheckOut
            // 
            this.pbCheckOut.Image = ((System.Drawing.Image)(resources.GetObject("pbCheckOut.Image")));
            this.pbCheckOut.Location = new System.Drawing.Point(12, 295);
            this.pbCheckOut.Name = "pbCheckOut";
            this.pbCheckOut.Size = new System.Drawing.Size(300, 300);
            this.pbCheckOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCheckOut.TabIndex = 16;
            this.pbCheckOut.TabStop = false;
            this.pbCheckOut.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlText;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(12, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 39);
            this.label2.TabIndex = 17;
            this.label2.Text = "Database Status: ";
            // 
            // lblDbStatus
            // 
            this.lblDbStatus.AutoSize = true;
            this.lblDbStatus.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblDbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDbStatus.ForeColor = System.Drawing.Color.Gold;
            this.lblDbStatus.Location = new System.Drawing.Point(294, 244);
            this.lblDbStatus.Name = "lblDbStatus";
            this.lblDbStatus.Size = new System.Drawing.Size(0, 39);
            this.lblDbStatus.TabIndex = 18;
            // 
            // btnPushChanges
            // 
            this.btnPushChanges.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnPushChanges.Font = new System.Drawing.Font("Castellar", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPushChanges.ForeColor = System.Drawing.Color.Red;
            this.btnPushChanges.Location = new System.Drawing.Point(616, 472);
            this.btnPushChanges.Name = "btnPushChanges";
            this.btnPushChanges.Size = new System.Drawing.Size(574, 123);
            this.btnPushChanges.TabIndex = 19;
            this.btnPushChanges.Text = "Push changes to database";
            this.btnPushChanges.UseVisualStyleBackColor = false;
            this.btnPushChanges.Click += new System.EventHandler(this.btnPushChanges_Click);
            // 
            // rbnMay16
            // 
            this.rbnMay16.AutoSize = true;
            this.rbnMay16.Font = new System.Drawing.Font("Castellar", 12F, System.Drawing.FontStyle.Bold);
            this.rbnMay16.Location = new System.Drawing.Point(62, 139);
            this.rbnMay16.Name = "rbnMay16";
            this.rbnMay16.Size = new System.Drawing.Size(110, 29);
            this.rbnMay16.TabIndex = 21;
            this.rbnMay16.Text = "May16";
            this.rbnMay16.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Castellar", 12F, System.Drawing.FontStyle.Bold);
            this.radioButton2.Location = new System.Drawing.Point(62, 211);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(110, 29);
            this.radioButton2.TabIndex = 22;
            this.radioButton2.Text = "May17";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // f
            // 
            this.f.Controls.Add(this.radioButton2);
            this.f.Controls.Add(this.rbnMay16);
            this.f.Controls.Add(this.rbnMay15);
            this.f.Font = new System.Drawing.Font("Castellar", 12F, System.Drawing.FontStyle.Bold);
            this.f.Location = new System.Drawing.Point(335, 295);
            this.f.Name = "f";
            this.f.Size = new System.Drawing.Size(250, 299);
            this.f.TabIndex = 25;
            this.f.TabStop = false;
            this.f.Text = "SELECT DAY";
            // 
            // rbnMay15
            // 
            this.rbnMay15.AutoSize = true;
            this.rbnMay15.Checked = true;
            this.rbnMay15.Font = new System.Drawing.Font("Castellar", 12F, System.Drawing.FontStyle.Bold);
            this.rbnMay15.Location = new System.Drawing.Point(62, 67);
            this.rbnMay15.Name = "rbnMay15";
            this.rbnMay15.Size = new System.Drawing.Size(109, 29);
            this.rbnMay15.TabIndex = 20;
            this.rbnMay15.TabStop = true;
            this.rbnMay15.Text = "May15";
            this.rbnMay15.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1202, 676);
            this.Controls.Add(this.f);
            this.Controls.Add(this.btnPushChanges);
            this.Controls.Add(this.lblDbStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbCheckOut);
            this.Controls.Add(this.pbCheckIn);
            this.Controls.Add(this.lblUpdateDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReadingFromFile);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Fyre Festival Gate Check In- Check Out Application";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCheckIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCheckOut)).EndInit();
            this.f.ResumeLayout(false);
            this.f.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lbInfo;
        private System.Windows.Forms.Button btnReadingFromFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUpdateDate;
        private System.Windows.Forms.PictureBox pbCheckIn;
        private System.Windows.Forms.PictureBox pbCheckOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDbStatus;
        private System.Windows.Forms.Button btnPushChanges;
        private System.Windows.Forms.RadioButton rbnMay16;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox f;
        private System.Windows.Forms.RadioButton rbnMay15;
    }
}

