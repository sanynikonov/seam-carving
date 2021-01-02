
namespace SeamCarving.Client.WinForms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sourcePictureBox = new System.Windows.Forms.PictureBox();
            this.gradientPictureBox = new System.Windows.Forms.PictureBox();
            this.processButton = new System.Windows.Forms.Button();
            this.pixelPathPictureBox = new System.Windows.Forms.PictureBox();
            this.shortestPathPictureBox = new System.Windows.Forms.PictureBox();
            this.openSourceFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.uploadSourceButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelPathPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortestPathPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("sourcePictureBox.Image")));
            this.sourcePictureBox.Location = new System.Drawing.Point(12, 12);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(316, 312);
            this.sourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sourcePictureBox.TabIndex = 0;
            this.sourcePictureBox.TabStop = false;
            // 
            // gradientPictureBox
            // 
            this.gradientPictureBox.Location = new System.Drawing.Point(334, 12);
            this.gradientPictureBox.Name = "gradientPictureBox";
            this.gradientPictureBox.Size = new System.Drawing.Size(312, 312);
            this.gradientPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gradientPictureBox.TabIndex = 1;
            this.gradientPictureBox.TabStop = false;
            // 
            // processButton
            // 
            this.processButton.Location = new System.Drawing.Point(592, 332);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(113, 37);
            this.processButton.TabIndex = 2;
            this.processButton.Text = "Process";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.ProcessButton_Click);
            // 
            // pixelPathPictureBox
            // 
            this.pixelPathPictureBox.Location = new System.Drawing.Point(652, 12);
            this.pixelPathPictureBox.Name = "pixelPathPictureBox";
            this.pixelPathPictureBox.Size = new System.Drawing.Size(312, 312);
            this.pixelPathPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pixelPathPictureBox.TabIndex = 3;
            this.pixelPathPictureBox.TabStop = false;
            // 
            // shortestPathPictureBox
            // 
            this.shortestPathPictureBox.Location = new System.Drawing.Point(970, 12);
            this.shortestPathPictureBox.Name = "shortestPathPictureBox";
            this.shortestPathPictureBox.Size = new System.Drawing.Size(312, 312);
            this.shortestPathPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.shortestPathPictureBox.TabIndex = 4;
            this.shortestPathPictureBox.TabStop = false;
            // 
            // openSourceFileDialog
            // 
            this.openSourceFileDialog.FileName = "openFileDialog1";
            // 
            // uploadSourceButton
            // 
            this.uploadSourceButton.Location = new System.Drawing.Point(12, 332);
            this.uploadSourceButton.Name = "uploadSourceButton";
            this.uploadSourceButton.Size = new System.Drawing.Size(75, 26);
            this.uploadSourceButton.TabIndex = 5;
            this.uploadSourceButton.Text = "Upload...";
            this.uploadSourceButton.UseVisualStyleBackColor = true;
            this.uploadSourceButton.Click += new System.EventHandler(this.UploadSourceButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 381);
            this.Controls.Add(this.uploadSourceButton);
            this.Controls.Add(this.shortestPathPictureBox);
            this.Controls.Add(this.pixelPathPictureBox);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.gradientPictureBox);
            this.Controls.Add(this.sourcePictureBox);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelPathPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortestPathPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox sourcePictureBox;
        private System.Windows.Forms.PictureBox gradientPictureBox;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.PictureBox pixelPathPictureBox;
        private System.Windows.Forms.PictureBox shortestPathPictureBox;
        private System.Windows.Forms.OpenFileDialog openSourceFileDialog;
        private System.Windows.Forms.Button uploadSourceButton;
    }
}

