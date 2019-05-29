namespace MyKinect
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
            this.components = new System.ComponentModel.Container();
            this.video = new System.Windows.Forms.PictureBox();
            this.video2 = new System.Windows.Forms.PictureBox();
            this.video3 = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.rtbStats = new System.Windows.Forms.RichTextBox();
            this.rtbHead = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.video)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.video2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.video3)).BeginInit();
            this.SuspendLayout();
            // 
            // video
            // 
            this.video.Location = new System.Drawing.Point(12, 12);
            this.video.Name = "video";
            this.video.Size = new System.Drawing.Size(956, 515);
            this.video.TabIndex = 0;
            this.video.TabStop = false;
            // 
            // video2
            // 
            this.video2.Location = new System.Drawing.Point(991, 12);
            this.video2.Name = "video2";
            this.video2.Size = new System.Drawing.Size(437, 266);
            this.video2.TabIndex = 1;
            this.video2.TabStop = false;
            // 
            // video3
            // 
            this.video3.Location = new System.Drawing.Point(1008, 363);
            this.video3.Name = "video3";
            this.video3.Size = new System.Drawing.Size(437, 266);
            this.video3.TabIndex = 2;
            this.video3.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // rtbStats
            // 
            this.rtbStats.Location = new System.Drawing.Point(12, 533);
            this.rtbStats.Name = "rtbStats";
            this.rtbStats.Size = new System.Drawing.Size(77, 96);
            this.rtbStats.TabIndex = 3;
            this.rtbStats.Text = "";
            // 
            // rtbHead
            // 
            this.rtbHead.Location = new System.Drawing.Point(167, 533);
            this.rtbHead.Name = "rtbHead";
            this.rtbHead.Size = new System.Drawing.Size(100, 96);
            this.rtbHead.TabIndex = 4;
            this.rtbHead.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1457, 641);
            this.Controls.Add(this.rtbHead);
            this.Controls.Add(this.rtbStats);
            this.Controls.Add(this.video3);
            this.Controls.Add(this.video2);
            this.Controls.Add(this.video);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.video)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.video2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.video3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox video;
        private System.Windows.Forms.PictureBox video2;
        private System.Windows.Forms.PictureBox video3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.RichTextBox rtbStats;
        private System.Windows.Forms.RichTextBox rtbHead;
    }
}

