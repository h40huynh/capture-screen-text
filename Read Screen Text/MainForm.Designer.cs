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
            ((System.ComponentModel.ISupportInitialize)(this.pbImageCapture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(12, 12);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(75, 23);
            this.btnCapture.TabIndex = 0;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // pbImageCapture
            // 
            this.pbImageCapture.Location = new System.Drawing.Point(12, 41);
            this.pbImageCapture.Name = "pbImageCapture";
            this.pbImageCapture.Size = new System.Drawing.Size(569, 279);
            this.pbImageCapture.TabIndex = 1;
            this.pbImageCapture.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 332);
            this.Controls.Add(this.pbImageCapture);
            this.Controls.Add(this.btnCapture);
            this.Name = "MainForm";
            this.Text = "Read Screen Text";
            ((System.ComponentModel.ISupportInitialize)(this.pbImageCapture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.PictureBox pbImageCapture;
    }
}

