namespace BigRunner.WinFormsApp
{
	partial class Main
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
			this.lblConnectionString = new System.Windows.Forms.Label();
			this.txtConnectionString = new System.Windows.Forms.TextBox();
			this.txtHugeSqlScript = new System.Windows.Forms.TextBox();
			this.lblHugeSqlScript = new System.Windows.Forms.Label();
			this.ofdDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btnChooseFile = new System.Windows.Forms.Button();
			this.btnChooseFile2 = new System.Windows.Forms.Button();
			this.txtLogSqlScript = new System.Windows.Forms.TextBox();
			this.lblLogSqlScript = new System.Windows.Forms.Label();
			this.btnRun = new System.Windows.Forms.Button();
			this.rtbStatus = new System.Windows.Forms.RichTextBox();
			this.cbEnableLog = new System.Windows.Forms.CheckBox();
			this.lblStatus = new System.Windows.Forms.Label();
			this.ofdDialog2 = new System.Windows.Forms.OpenFileDialog();
			this.lblExampleConnectionString = new System.Windows.Forms.Label();
			this.lbMoreConnectionString = new System.Windows.Forms.LinkLabel();
			this.lblSampleBigSqlScript = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.bwRunBigSqlScript = new System.ComponentModel.BackgroundWorker();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lbCopyConnectionString = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// lblConnectionString
			// 
			this.lblConnectionString.AutoSize = true;
			this.lblConnectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblConnectionString.Location = new System.Drawing.Point(12, 24);
			this.lblConnectionString.Name = "lblConnectionString";
			this.lblConnectionString.Size = new System.Drawing.Size(139, 17);
			this.lblConnectionString.TabIndex = 2;
			this.lblConnectionString.Text = "Connection String(*):";
			// 
			// txtConnectionString
			// 
			this.txtConnectionString.Location = new System.Drawing.Point(154, 24);
			this.txtConnectionString.Name = "txtConnectionString";
			this.txtConnectionString.Size = new System.Drawing.Size(429, 20);
			this.txtConnectionString.TabIndex = 3;
			// 
			// txtHugeSqlScript
			// 
			this.txtHugeSqlScript.Location = new System.Drawing.Point(155, 80);
			this.txtHugeSqlScript.Name = "txtHugeSqlScript";
			this.txtHugeSqlScript.Size = new System.Drawing.Size(394, 20);
			this.txtHugeSqlScript.TabIndex = 5;
			// 
			// lblHugeSqlScript
			// 
			this.lblHugeSqlScript.AutoSize = true;
			this.lblHugeSqlScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.lblHugeSqlScript.Location = new System.Drawing.Point(13, 78);
			this.lblHugeSqlScript.Name = "lblHugeSqlScript";
			this.lblHugeSqlScript.Size = new System.Drawing.Size(130, 17);
			this.lblHugeSqlScript.TabIndex = 4;
			this.lblHugeSqlScript.Text = "Big Sql File Path(*):";
			// 
			// ofdDialog1
			// 
			this.ofdDialog1.Filter = "Sql files (*.sql;*.txt)|*.sql;*.txt";
			this.ofdDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdDialog1_FileOk);
			// 
			// btnChooseFile
			// 
			this.btnChooseFile.Location = new System.Drawing.Point(554, 78);
			this.btnChooseFile.Name = "btnChooseFile";
			this.btnChooseFile.Size = new System.Drawing.Size(29, 23);
			this.btnChooseFile.TabIndex = 6;
			this.btnChooseFile.Text = "...";
			this.btnChooseFile.UseVisualStyleBackColor = true;
			this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
			// 
			// btnChooseFile2
			// 
			this.btnChooseFile2.Enabled = false;
			this.btnChooseFile2.Location = new System.Drawing.Point(554, 121);
			this.btnChooseFile2.Name = "btnChooseFile2";
			this.btnChooseFile2.Size = new System.Drawing.Size(29, 23);
			this.btnChooseFile2.TabIndex = 9;
			this.btnChooseFile2.Text = "...";
			this.btnChooseFile2.UseVisualStyleBackColor = true;
			this.btnChooseFile2.Click += new System.EventHandler(this.btnChooseFile_Click);
			// 
			// txtLogSqlScript
			// 
			this.txtLogSqlScript.Enabled = false;
			this.txtLogSqlScript.Location = new System.Drawing.Point(155, 122);
			this.txtLogSqlScript.Name = "txtLogSqlScript";
			this.txtLogSqlScript.Size = new System.Drawing.Size(394, 20);
			this.txtLogSqlScript.TabIndex = 8;
			// 
			// lblLogSqlScript
			// 
			this.lblLogSqlScript.AutoSize = true;
			this.lblLogSqlScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.lblLogSqlScript.Location = new System.Drawing.Point(13, 120);
			this.lblLogSqlScript.Name = "lblLogSqlScript";
			this.lblLogSqlScript.Size = new System.Drawing.Size(126, 17);
			this.lblLogSqlScript.TabIndex = 7;
			this.lblLogSqlScript.Text = "Log Text File Path:";
			// 
			// btnRun
			// 
			this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.btnRun.Location = new System.Drawing.Point(155, 184);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(95, 30);
			this.btnRun.TabIndex = 12;
			this.btnRun.Text = "Run";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// rtbStatus
			// 
			this.rtbStatus.Location = new System.Drawing.Point(12, 247);
			this.rtbStatus.Name = "rtbStatus";
			this.rtbStatus.ReadOnly = true;
			this.rtbStatus.Size = new System.Drawing.Size(619, 195);
			this.rtbStatus.TabIndex = 13;
			this.rtbStatus.Text = "";
			// 
			// cbEnableLog
			// 
			this.cbEnableLog.AutoSize = true;
			this.cbEnableLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.cbEnableLog.Location = new System.Drawing.Point(155, 161);
			this.cbEnableLog.Name = "cbEnableLog";
			this.cbEnableLog.Size = new System.Drawing.Size(122, 17);
			this.cbEnableLog.TabIndex = 14;
			this.cbEnableLog.Text = "Enable log to the file";
			this.cbEnableLog.UseVisualStyleBackColor = true;
			this.cbEnableLog.CheckedChanged += new System.EventHandler(this.cbEnableLog_CheckedChanged);
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.lblStatus.Location = new System.Drawing.Point(12, 224);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(51, 17);
			this.lblStatus.TabIndex = 15;
			this.lblStatus.Text = "Output";
			// 
			// ofdDialog2
			// 
			this.ofdDialog2.FileName = "openFileDialog1";
			this.ofdDialog2.Filter = "Text files (*.txt)|*.txt";
			this.ofdDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdDialog2_FileOk);
			// 
			// lblExampleConnectionString
			// 
			this.lblExampleConnectionString.AutoSize = true;
			this.lblExampleConnectionString.Location = new System.Drawing.Point(154, 45);
			this.lblExampleConnectionString.Name = "lblExampleConnectionString";
			this.lblExampleConnectionString.Size = new System.Drawing.Size(366, 13);
			this.lblExampleConnectionString.TabIndex = 16;
			this.lblExampleConnectionString.Text = "e.g: Server=localhost;Database=DatabaseName;User Id=sa;Password=123;";
			// 
			// lbMoreConnectionString
			// 
			this.lbMoreConnectionString.AutoSize = true;
			this.lbMoreConnectionString.LinkVisited = true;
			this.lbMoreConnectionString.Location = new System.Drawing.Point(153, 60);
			this.lbMoreConnectionString.Name = "lbMoreConnectionString";
			this.lbMoreConnectionString.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbMoreConnectionString.Size = new System.Drawing.Size(115, 13);
			this.lbMoreConnectionString.TabIndex = 17;
			this.lbMoreConnectionString.TabStop = true;
			this.lbMoreConnectionString.Text = "More connection string";
			this.lbMoreConnectionString.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbMoreConnectionString_LinkClicked);
			// 
			// lblSampleBigSqlScript
			// 
			this.lblSampleBigSqlScript.AutoSize = true;
			this.lblSampleBigSqlScript.Location = new System.Drawing.Point(155, 103);
			this.lblSampleBigSqlScript.Name = "lblSampleBigSqlScript";
			this.lblSampleBigSqlScript.Size = new System.Drawing.Size(110, 13);
			this.lblSampleBigSqlScript.TabIndex = 18;
			this.lblSampleBigSqlScript.Text = "e.g: c:\\bigsqlscript.sql";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(155, 145);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 13);
			this.label1.TabIndex = 19;
			this.label1.Text = "e.g: c:\\log.txt";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(369, 187);
			this.progressBar1.MarqueeAnimationSpeed = 30;
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(262, 23);
			this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.progressBar1.TabIndex = 20;
			this.progressBar1.Visible = false;
			// 
			// bwRunBigSqlScript
			// 
			this.bwRunBigSqlScript.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRunBigSqlScript_DoWork);
			this.bwRunBigSqlScript.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRunBigSqlScript_RunWorkerCompleted);
			// 
			// btnCancel
			// 
			this.btnCancel.Enabled = false;
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.btnCancel.Location = new System.Drawing.Point(256, 184);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(95, 30);
			this.btnCancel.TabIndex = 21;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lbCopyConnectionString
			// 
			this.lbCopyConnectionString.AutoSize = true;
			this.lbCopyConnectionString.LinkVisited = true;
			this.lbCopyConnectionString.Location = new System.Drawing.Point(266, 60);
			this.lbCopyConnectionString.Name = "lbCopyConnectionString";
			this.lbCopyConnectionString.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbCopyConnectionString.Size = new System.Drawing.Size(115, 13);
			this.lbCopyConnectionString.TabIndex = 22;
			this.lbCopyConnectionString.TabStop = true;
			this.lbCopyConnectionString.Text = "Copy connection string";
			this.lbCopyConnectionString.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbCopyConnectionString_LinkClicked);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(643, 452);
			this.Controls.Add(this.lbCopyConnectionString);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblSampleBigSqlScript);
			this.Controls.Add(this.lbMoreConnectionString);
			this.Controls.Add(this.lblExampleConnectionString);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.cbEnableLog);
			this.Controls.Add(this.rtbStatus);
			this.Controls.Add(this.btnRun);
			this.Controls.Add(this.btnChooseFile2);
			this.Controls.Add(this.txtLogSqlScript);
			this.Controls.Add(this.lblLogSqlScript);
			this.Controls.Add(this.btnChooseFile);
			this.Controls.Add(this.txtHugeSqlScript);
			this.Controls.Add(this.lblHugeSqlScript);
			this.Controls.Add(this.txtConnectionString);
			this.Controls.Add(this.lblConnectionString);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BigRunner tool";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblConnectionString;
		private System.Windows.Forms.TextBox txtConnectionString;
		private System.Windows.Forms.TextBox txtHugeSqlScript;
		private System.Windows.Forms.Label lblHugeSqlScript;
		private System.Windows.Forms.OpenFileDialog ofdDialog1;
		private System.Windows.Forms.Button btnChooseFile;
		private System.Windows.Forms.Button btnChooseFile2;
		private System.Windows.Forms.TextBox txtLogSqlScript;
		private System.Windows.Forms.Label lblLogSqlScript;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.RichTextBox rtbStatus;
		private System.Windows.Forms.CheckBox cbEnableLog;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.OpenFileDialog ofdDialog2;
		private System.Windows.Forms.Label lblExampleConnectionString;
		private System.Windows.Forms.LinkLabel lbMoreConnectionString;
		private System.Windows.Forms.Label lblSampleBigSqlScript;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.ComponentModel.BackgroundWorker bwRunBigSqlScript;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.LinkLabel lbCopyConnectionString;
	}
}