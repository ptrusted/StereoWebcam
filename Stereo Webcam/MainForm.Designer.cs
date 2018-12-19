namespace Stereo_Webcam
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
            this.ViewFinder = new System.Windows.Forms.PictureBox();
            this.CameraView1 = new AForge.Controls.VideoSourcePlayer();
            this.CameraView2 = new AForge.Controls.VideoSourcePlayer();
            this.KeyInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ViewFinder)).BeginInit();
            this.SuspendLayout();
            // 
            // ViewFinder
            // 
            this.ViewFinder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ViewFinder.BackColor = System.Drawing.SystemColors.Window;
            this.ViewFinder.Location = new System.Drawing.Point(31, 5);
            this.ViewFinder.Name = "ViewFinder";
            this.ViewFinder.Size = new System.Drawing.Size(640, 480);
            this.ViewFinder.TabIndex = 0;
            this.ViewFinder.TabStop = false;
            // 
            // CameraView1
            // 
            this.CameraView1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CameraView1.BackColor = System.Drawing.SystemColors.Window;
            this.CameraView1.Location = new System.Drawing.Point(31, 485);
            this.CameraView1.Name = "CameraView1";
            this.CameraView1.Size = new System.Drawing.Size(320, 240);
            this.CameraView1.TabIndex = 1;
            this.CameraView1.TabStop = false;
            this.CameraView1.VideoSource = null;
            this.CameraView1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.Camera1_Update);
            // 
            // CameraView2
            // 
            this.CameraView2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CameraView2.BackColor = System.Drawing.SystemColors.Window;
            this.CameraView2.Location = new System.Drawing.Point(351, 485);
            this.CameraView2.Name = "CameraView2";
            this.CameraView2.Size = new System.Drawing.Size(320, 240);
            this.CameraView2.TabIndex = 2;
            this.CameraView2.TabStop = false;
            this.CameraView2.VideoSource = null;
            this.CameraView2.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.Camera2_Update);
            // 
            // KeyInfo
            // 
            this.KeyInfo.AutoSize = true;
            this.KeyInfo.ForeColor = System.Drawing.Color.Yellow;
            this.KeyInfo.Location = new System.Drawing.Point(28, 472);
            this.KeyInfo.Name = "KeyInfo";
            this.KeyInfo.Size = new System.Drawing.Size(317, 13);
            this.KeyInfo.TabIndex = 3;
            this.KeyInfo.Text = "Press \'p\' to execute, press \'v\' to show 3d view, press \'end\' to stop.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(700, 749);
            this.Controls.Add(this.KeyInfo);
            this.Controls.Add(this.CameraView2);
            this.Controls.Add(this.CameraView1);
            this.Controls.Add(this.ViewFinder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(700, 766);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stereo Webcam";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ViewFinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ViewFinder;
        private AForge.Controls.VideoSourcePlayer CameraView1;
        private AForge.Controls.VideoSourcePlayer CameraView2;
        private System.Windows.Forms.Label KeyInfo;
    }
}

