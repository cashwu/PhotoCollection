namespace LabPhotoCollection
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.boxPhoto = new System.Windows.Forms.ListBox();
            this.boxErrorFile = new System.Windows.Forms.ListBox();
            this.imgBox = new System.Windows.Forms.PictureBox();
            this.btnMove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            this.SuspendLayout();
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(22, 12);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(117, 53);
            this.btnSelectPath.TabIndex = 0;
            this.btnSelectPath.Text = "Select Path";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // boxPhoto
            // 
            this.boxPhoto.FormattingEnabled = true;
            this.boxPhoto.HorizontalScrollbar = true;
            this.boxPhoto.ItemHeight = 20;
            this.boxPhoto.Location = new System.Drawing.Point(22, 127);
            this.boxPhoto.Name = "boxPhoto";
            this.boxPhoto.ScrollAlwaysVisible = true;
            this.boxPhoto.Size = new System.Drawing.Size(243, 284);
            this.boxPhoto.TabIndex = 1;
            this.boxPhoto.SelectedIndexChanged += new System.EventHandler(this.boxPhoto_SelectedIndexChanged);
            // 
            // boxErrorFile
            // 
            this.boxErrorFile.FormattingEnabled = true;
            this.boxErrorFile.HorizontalScrollbar = true;
            this.boxErrorFile.ItemHeight = 20;
            this.boxErrorFile.Location = new System.Drawing.Point(291, 127);
            this.boxErrorFile.Name = "boxErrorFile";
            this.boxErrorFile.ScrollAlwaysVisible = true;
            this.boxErrorFile.Size = new System.Drawing.Size(240, 284);
            this.boxErrorFile.TabIndex = 2;
            // 
            // imgBox
            // 
            this.imgBox.Location = new System.Drawing.Point(553, 87);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(302, 214);
            this.imgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBox.TabIndex = 3;
            this.imgBox.TabStop = false;
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(156, 12);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(125, 53);
            this.btnMove.TabIndex = 4;
            this.btnMove.Text = "Start Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "File List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Error File List";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 434);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.imgBox);
            this.Controls.Add(this.boxErrorFile);
            this.Controls.Add(this.boxPhoto);
            this.Controls.Add(this.btnSelectPath);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "Photo Collection";
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.ListBox boxPhoto;
        private System.Windows.Forms.ListBox boxErrorFile;
        private System.Windows.Forms.PictureBox imgBox;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

