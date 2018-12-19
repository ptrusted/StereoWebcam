namespace Stereo_Webcam
{
    partial class CameraSelector
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
            this.ButtonOkay = new System.Windows.Forms.Button();
            this.CameraName = new System.Windows.Forms.ComboBox();
            this.CameraOption = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ButtonOkay
            // 
            this.ButtonOkay.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOkay.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonOkay.Location = new System.Drawing.Point(0, 66);
            this.ButtonOkay.Name = "ButtonOkay";
            this.ButtonOkay.Size = new System.Drawing.Size(284, 23);
            this.ButtonOkay.TabIndex = 0;
            this.ButtonOkay.Text = "Okay";
            this.ButtonOkay.UseVisualStyleBackColor = true;
            this.ButtonOkay.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // CameraName
            // 
            this.CameraName.Dock = System.Windows.Forms.DockStyle.Top;
            this.CameraName.FormattingEnabled = true;
            this.CameraName.Location = new System.Drawing.Point(0, 0);
            this.CameraName.Name = "CameraName";
            this.CameraName.Size = new System.Drawing.Size(284, 21);
            this.CameraName.TabIndex = 1;
            this.CameraName.SelectedIndexChanged += new System.EventHandler(this.CameraName_SelectedIndexChanged);
            // 
            // CameraOption
            // 
            this.CameraOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.CameraOption.FormattingEnabled = true;
            this.CameraOption.Location = new System.Drawing.Point(0, 21);
            this.CameraOption.Name = "CameraOption";
            this.CameraOption.Size = new System.Drawing.Size(284, 21);
            this.CameraOption.TabIndex = 2;
            // 
            // CameraSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 89);
            this.Controls.Add(this.CameraOption);
            this.Controls.Add(this.CameraName);
            this.Controls.Add(this.ButtonOkay);
            this.Name = "CameraSelector";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Camera Selector";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CameraSelector_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonOkay;
        private System.Windows.Forms.ComboBox CameraName;
        private System.Windows.Forms.ComboBox CameraOption;
    }
}