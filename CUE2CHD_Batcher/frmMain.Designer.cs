namespace CUE2CHD_Batcher
{
    partial class frmMain
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
            try
            {
                base.Dispose(disposing);
            }catch { }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.txtOut = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCUE = new System.Windows.Forms.Button();
            this.txtCUE = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCHD = new System.Windows.Forms.Button();
            this.txtCHD = new System.Windows.Forms.TextBox();
            this.fbdCUE = new System.Windows.Forms.FolderBrowserDialog();
            this.fbdCHD = new System.Windows.Forms.FolderBrowserDialog();
            this.chkReverse = new System.Windows.Forms.CheckBox();
            this.gbCurrent = new System.Windows.Forms.GroupBox();
            this.pbCurrent = new System.Windows.Forms.ProgressBar();
            this.lblCurrentCompression = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbCurrent.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(723, 435);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtOut
            // 
            this.txtOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOut.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOut.Location = new System.Drawing.Point(12, 126);
            this.txtOut.Multiline = true;
            this.txtOut.Name = "txtOut";
            this.txtOut.ReadOnly = true;
            this.txtOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOut.Size = new System.Drawing.Size(783, 237);
            this.txtOut.TabIndex = 1;
            this.txtOut.WordWrap = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnCUE);
            this.groupBox1.Controls.Add(this.txtCUE);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 51);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CUE Directory";
            // 
            // btnCUE
            // 
            this.btnCUE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCUE.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCUE.Location = new System.Drawing.Point(736, 18);
            this.btnCUE.Name = "btnCUE";
            this.btnCUE.Size = new System.Drawing.Size(42, 22);
            this.btnCUE.TabIndex = 1;
            this.btnCUE.Text = "...";
            this.btnCUE.UseVisualStyleBackColor = true;
            this.btnCUE.Click += new System.EventHandler(this.btnCUE_Click);
            // 
            // txtCUE
            // 
            this.txtCUE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCUE.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCUE.Location = new System.Drawing.Point(6, 19);
            this.txtCUE.Name = "txtCUE";
            this.txtCUE.ReadOnly = true;
            this.txtCUE.Size = new System.Drawing.Size(724, 22);
            this.txtCUE.TabIndex = 0;
            this.txtCUE.Text = "C:\\Users\\aphex\\Desktop\\X";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnCHD);
            this.groupBox2.Controls.Add(this.txtCHD);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(783, 51);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CHD Directory";
            // 
            // btnCHD
            // 
            this.btnCHD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCHD.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCHD.Location = new System.Drawing.Point(736, 18);
            this.btnCHD.Name = "btnCHD";
            this.btnCHD.Size = new System.Drawing.Size(42, 22);
            this.btnCHD.TabIndex = 1;
            this.btnCHD.Text = "...";
            this.btnCHD.UseVisualStyleBackColor = true;
            this.btnCHD.Click += new System.EventHandler(this.btnCHD_Click);
            // 
            // txtCHD
            // 
            this.txtCHD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCHD.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCHD.Location = new System.Drawing.Point(6, 18);
            this.txtCHD.Name = "txtCHD";
            this.txtCHD.ReadOnly = true;
            this.txtCHD.Size = new System.Drawing.Size(724, 22);
            this.txtCHD.TabIndex = 0;
            this.txtCHD.Text = "C:\\Users\\aphex\\Desktop\\X\\";
            // 
            // fbdCUE
            // 
            this.fbdCUE.Description = "Choose path containing CUE\'s (inc Subfolders)";
            this.fbdCUE.ShowNewFolderButton = false;
            // 
            // fbdCHD
            // 
            this.fbdCHD.Description = "Choose the directory to write the CHD\'s to";
            // 
            // chkReverse
            // 
            this.chkReverse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkReverse.AutoSize = true;
            this.chkReverse.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReverse.Location = new System.Drawing.Point(12, 441);
            this.chkReverse.Name = "chkReverse";
            this.chkReverse.Size = new System.Drawing.Size(119, 17);
            this.chkReverse.TabIndex = 4;
            this.chkReverse.Text = "CHD to CUE mode";
            this.chkReverse.UseVisualStyleBackColor = true;
            this.chkReverse.Visible = false;
            // 
            // gbCurrent
            // 
            this.gbCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCurrent.Controls.Add(this.pbCurrent);
            this.gbCurrent.Location = new System.Drawing.Point(12, 369);
            this.gbCurrent.Name = "gbCurrent";
            this.gbCurrent.Size = new System.Drawing.Size(699, 57);
            this.gbCurrent.TabIndex = 6;
            this.gbCurrent.TabStop = false;
            this.gbCurrent.Text = "Progress";
            // 
            // pbCurrent
            // 
            this.pbCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCurrent.Location = new System.Drawing.Point(6, 21);
            this.pbCurrent.Name = "pbCurrent";
            this.pbCurrent.Size = new System.Drawing.Size(687, 21);
            this.pbCurrent.TabIndex = 0;
            // 
            // lblCurrentCompression
            // 
            this.lblCurrentCompression.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentCompression.Location = new System.Drawing.Point(6, 21);
            this.lblCurrentCompression.Name = "lblCurrentCompression";
            this.lblCurrentCompression.Size = new System.Drawing.Size(69, 21);
            this.lblCurrentCompression.TabIndex = 1;
            this.lblCurrentCompression.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblCurrentCompression);
            this.groupBox3.Location = new System.Drawing.Point(717, 369);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(81, 57);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Compression";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 470);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbCurrent);
            this.Controls.Add(this.chkReverse);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtOut);
            this.Controls.Add(this.btnStart);
            this.MinimumSize = new System.Drawing.Size(417, 313);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CUE2CHD Batcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbCurrent.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCUE;
        private System.Windows.Forms.TextBox txtCUE;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCHD;
        private System.Windows.Forms.TextBox txtCHD;
        private System.Windows.Forms.FolderBrowserDialog fbdCUE;
        private System.Windows.Forms.FolderBrowserDialog fbdCHD;
        private System.Windows.Forms.CheckBox chkReverse;
        private System.Windows.Forms.GroupBox gbCurrent;
        private System.Windows.Forms.ProgressBar pbCurrent;
        private System.Windows.Forms.Label lblCurrentCompression;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

