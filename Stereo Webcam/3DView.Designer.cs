namespace Stereo_Webcam
{
    partial class _3DView
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
            this.ViewPort = new SharpGL.OpenGLControl();
            ((System.ComponentModel.ISupportInitialize)(this.ViewPort)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.ViewPort.BackColor = System.Drawing.SystemColors.WindowText;
            this.ViewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewPort.Location = new System.Drawing.Point(0, 0);
            this.ViewPort.DrawFPS = true;
            this.ViewPort.Name = "pictureBox1";
            this.ViewPort.Size = new System.Drawing.Size(624, 441);
            this.ViewPort.TabIndex = 0;
            this.ViewPort.TabStop = false;
            this.ViewPort.Load += new System.EventHandler(this.SharpGL_Load);
            this.ViewPort.OpenGLDraw += new SharpGL.RenderEventHandler(this.SharpGL_Render);
            this.ViewPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SharpGL_KeyHandle);
            // 
            // _3DView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.ViewPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "_3DView";
            this.Text = "_3DView";
            ((System.ComponentModel.ISupportInitialize)(this.ViewPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SharpGL.OpenGLControl ViewPort;
    }
}