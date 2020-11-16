namespace Event_RFID_AttachToTicket_APP
{
    partial class lblFullName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(lblFullName));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbInfo = new System.Windows.Forms.ListBox();
            this.lblDbStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUpdateDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPushChanges = new System.Windows.Forms.Button();
            this.btnReadingFromFile = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRfid = new System.Windows.Forms.Label();
            this.tbFullName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 148);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lbInfo
            // 
            this.lbInfo.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.FormattingEnabled = true;
            this.lbInfo.ItemHeight = 29;
            this.lbInfo.Location = new System.Drawing.Point(181, 12);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(986, 149);
            this.lbInfo.TabIndex = 5;
            // 
            // lblDbStatus
            // 
            this.lblDbStatus.AutoSize = true;
            this.lblDbStatus.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblDbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDbStatus.ForeColor = System.Drawing.Color.Gold;
            this.lblDbStatus.Location = new System.Drawing.Point(294, 245);
            this.lblDbStatus.Name = "lblDbStatus";
            this.lblDbStatus.Size = new System.Drawing.Size(0, 39);
            this.lblDbStatus.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlText;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(12, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 39);
            this.label2.TabIndex = 21;
            this.label2.Text = "Database Status: ";
            // 
            // lblUpdateDate
            // 
            this.lblUpdateDate.AutoSize = true;
            this.lblUpdateDate.BackColor = System.Drawing.Color.Black;
            this.lblUpdateDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateDate.ForeColor = System.Drawing.Color.Gold;
            this.lblUpdateDate.Location = new System.Drawing.Point(322, 183);
            this.lblUpdateDate.Name = "lblUpdateDate";
            this.lblUpdateDate.Size = new System.Drawing.Size(0, 39);
            this.lblUpdateDate.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlText;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(13, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 39);
            this.label1.TabIndex = 19;
            this.label1.Text = "Database updated: ";
            // 
            // btnPushChanges
            // 
            this.btnPushChanges.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnPushChanges.Font = new System.Drawing.Font("Castellar", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPushChanges.ForeColor = System.Drawing.Color.Red;
            this.btnPushChanges.Location = new System.Drawing.Point(695, 496);
            this.btnPushChanges.Name = "btnPushChanges";
            this.btnPushChanges.Size = new System.Drawing.Size(460, 114);
            this.btnPushChanges.TabIndex = 24;
            this.btnPushChanges.Text = "Push changes to database";
            this.btnPushChanges.UseVisualStyleBackColor = false;
            this.btnPushChanges.Click += new System.EventHandler(this.btnPushChanges_Click_1);
            // 
            // btnReadingFromFile
            // 
            this.btnReadingFromFile.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnReadingFromFile.Font = new System.Drawing.Font("Castellar", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadingFromFile.ForeColor = System.Drawing.Color.Red;
            this.btnReadingFromFile.Location = new System.Drawing.Point(695, 322);
            this.btnReadingFromFile.Name = "btnReadingFromFile";
            this.btnReadingFromFile.Size = new System.Drawing.Size(459, 119);
            this.btnReadingFromFile.TabIndex = 23;
            this.btnReadingFromFile.Text = "START READING FROM A FILE";
            this.btnReadingFromFile.UseVisualStyleBackColor = false;
            this.btnReadingFromFile.Click += new System.EventHandler(this.btnReadingFromFile_Click_1);
            // 
            // btnAttach
            // 
            this.btnAttach.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnAttach.Font = new System.Drawing.Font("Castellar", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttach.ForeColor = System.Drawing.Color.Red;
            this.btnAttach.Location = new System.Drawing.Point(19, 491);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(545, 119);
            this.btnAttach.TabIndex = 25;
            this.btnAttach.Text = "ATTACH RFID";
            this.btnAttach.UseVisualStyleBackColor = false;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Sitka Small", 16F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 40);
            this.label3.TabIndex = 26;
            this.label3.Text = "Full Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Sitka Small", 16F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(78, 404);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 40);
            this.label4.TabIndex = 27;
            this.label4.Text = "RFID: ";
            // 
            // lblRfid
            // 
            this.lblRfid.AutoSize = true;
            this.lblRfid.BackColor = System.Drawing.SystemColors.Control;
            this.lblRfid.Font = new System.Drawing.Font("Sitka Small", 16F, System.Drawing.FontStyle.Bold);
            this.lblRfid.ForeColor = System.Drawing.Color.Lime;
            this.lblRfid.Location = new System.Drawing.Point(196, 404);
            this.lblRfid.Name = "lblRfid";
            this.lblRfid.Size = new System.Drawing.Size(72, 40);
            this.lblRfid.TabIndex = 28;
            this.lblRfid.Text = "rfid";
            // 
            // tbFullName
            // 
            this.tbFullName.Font = new System.Drawing.Font("Sitka Small", 16F, System.Drawing.FontStyle.Bold);
            this.tbFullName.Location = new System.Drawing.Point(215, 322);
            this.tbFullName.Name = "tbFullName";
            this.tbFullName.Size = new System.Drawing.Size(361, 41);
            this.tbFullName.TabIndex = 29;
            // 
            // lblFullName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 630);
            this.Controls.Add(this.tbFullName);
            this.Controls.Add(this.lblRfid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAttach);
            this.Controls.Add(this.btnPushChanges);
            this.Controls.Add(this.btnReadingFromFile);
            this.Controls.Add(this.lblDbStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblUpdateDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.pictureBox1);
            this.Name = "lblFullName";
            this.Text = "Fyre Festival RFID Attacher Application";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lbInfo;
        private System.Windows.Forms.Label lblDbStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUpdateDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPushChanges;
        private System.Windows.Forms.Button btnReadingFromFile;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRfid;
        private System.Windows.Forms.TextBox tbFullName;
    }
}

