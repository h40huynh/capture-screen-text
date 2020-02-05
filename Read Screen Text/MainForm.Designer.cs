namespace Read_Screen_Text
{
    partial class MainForm
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
            this.btnCapture = new System.Windows.Forms.Button();
            this.pbImageCapture = new System.Windows.Forms.PictureBox();
            this.rtTextFromImage = new System.Windows.Forms.RichTextBox();
            this.bwExtractText = new System.ComponentModel.BackgroundWorker();
            this.progressMain = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageCapture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(14, 14);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(87, 27);
            this.btnCapture.TabIndex = 0;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // pbImageCapture
            // 
            this.pbImageCapture.Location = new System.Drawing.Point(14, 178);
            this.pbImageCapture.Name = "pbImageCapture";
            this.pbImageCapture.Size = new System.Drawing.Size(560, 23);
            this.pbImageCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImageCapture.TabIndex = 1;
            this.pbImageCapture.TabStop = false;
            // 
            // rtTextFromImage
            // 
            this.rtTextFromImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtTextFromImage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtTextFromImage.Location = new System.Drawing.Point(14, 47);
            this.rtTextFromImage.Name = "rtTextFromImage";
            this.rtTextFromImage.Size = new System.Drawing.Size(560, 125);
            this.rtTextFromImage.TabIndex = 2;
            this.rtTextFromImage.Text = "";
            // 
            // bwExtractText
            // 
            this.bwExtractText.WorkerReportsProgress = true;
            this.bwExtractText.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwExtractText_DoWork);
            this.bwExtractText.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwExtractText_ProgressChanged);
            this.bwExtractText.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwExtractText_RunWorkerCompleted);
            // 
            // progressMain
            // 
            this.progressMain.Location = new System.Drawing.Point(238, 14);
            this.progressMain.Name = "progressMain";
            this.progressMain.Size = new System.Drawing.Size(334, 27);
            this.progressMain.TabIndex = 3;
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(118, 20);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(55, 15);
            this.lblProgress.TabIndex = 4;
            this.lblProgress.Text = "Progress";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 183);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressMain);
            this.Controls.Add(this.rtTextFromImage);
            this.Controls.Add(this.pbImageCapture);
            this.Controls.Add(this.btnCapture);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "Read Screen Text";
            ((System.ComponentModel.ISupportInitialize)(this.pbImageCapture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.PictureBox pbImageCapture;
        private System.Windows.Forms.RichTextBox rtTextFromImage;
        private System.ComponentModel.BackgroundWorker bwExtractText;
        private System.Windows.Forms.ProgressBar progressMain;
        private System.Windows.Forms.Label lblProgress;
    }
}

