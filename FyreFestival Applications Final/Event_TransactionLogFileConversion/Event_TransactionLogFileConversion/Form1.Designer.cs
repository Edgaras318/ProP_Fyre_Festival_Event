namespace Event_TransactionLogFileConversion
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
            this.lbInfo = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogFile = new System.Windows.Forms.Button();
            this.btnShowLog = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbInfo
            // 
            this.lbInfo.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.FormattingEnabled = true;
            this.lbInfo.ItemHeight = 29;
            this.lbInfo.Location = new System.Drawing.Point(12, 179);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(509, 497);
            this.lbInfo.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(159, 148);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnLogFile
            // 
            this.btnLogFile.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnLogFile.Font = new System.Drawing.Font("Castellar", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogFile.ForeColor = System.Drawing.Color.Red;
            this.btnLogFile.Location = new System.Drawing.Point(564, 179);
            this.btnLogFile.Name = "btnLogFile";
            this.btnLogFile.Size = new System.Drawing.Size(216, 125);
            this.btnLogFile.TabIndex = 26;
            this.btnLogFile.Text = "LOG FILE";
            this.btnLogFile.UseVisualStyleBackColor = false;
            this.btnLogFile.Click += new System.EventHandler(this.btnLogFile_Click);
            // 
            // btnShowLog
            // 
            this.btnShowLog.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnShowLog.Font = new System.Drawing.Font("Castellar", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowLog.ForeColor = System.Drawing.Color.Red;
            this.btnShowLog.Location = new System.Drawing.Point(564, 372);
            this.btnShowLog.Name = "btnShowLog";
            this.btnShowLog.Size = new System.Drawing.Size(216, 120);
            this.btnShowLog.TabIndex = 27;
            this.btnShowLog.Text = "Show LOG";
            this.btnShowLog.UseVisualStyleBackColor = false;
            this.btnShowLog.Click += new System.EventHandler(this.btnShowLog_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnProcess.Font = new System.Drawing.Font("Castellar", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.ForeColor = System.Drawing.Color.Red;
            this.btnProcess.Location = new System.Drawing.Point(564, 556);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(216, 120);
            this.btnProcess.TabIndex = 28;
            this.btnProcess.Text = "PROCESS LOG";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.ForeColor = System.Drawing.Color.Gold;
            this.lblFileName.Location = new System.Drawing.Point(190, 30);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(97, 25);
            this.lblFileName.TabIndex = 29;
            this.lblFileName.Text = "File name";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Gold;
            this.lblStatus.Location = new System.Drawing.Point(190, 88);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(68, 25);
            this.lblStatus.TabIndex = 30;
            this.lblStatus.Text = "Status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 688);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnShowLog);
            this.Controls.Add(this.btnLogFile);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbInfo);
            this.Name = "Form1";
            this.Text = "Fyre Festival BankTranscations Converter";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogFile;
        private System.Windows.Forms.Button btnShowLog;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblStatus;
    }
}

