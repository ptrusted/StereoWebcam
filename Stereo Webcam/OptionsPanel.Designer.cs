namespace Stereo_Webcam
{
    partial class OptionsPanel
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MaxBlue = new System.Windows.Forms.NumericUpDown();
            this.MaxGreen = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.MaxRed = new System.Windows.Forms.NumericUpDown();
            this.MinBlue = new System.Windows.Forms.NumericUpDown();
            this.MinGreen = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.MinRed = new System.Windows.Forms.NumericUpDown();
            this.MaxError = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.FocalLength = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CameraDistance = new System.Windows.Forms.NumericUpDown();
            this.SaturationLeft = new System.Windows.Forms.TrackBar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.SaturationRight = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxError)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FocalLength)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaturationLeft)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaturationRight)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MaxBlue);
            this.groupBox1.Controls.Add(this.MaxGreen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.MaxRed);
            this.groupBox1.Controls.Add(this.MinBlue);
            this.groupBox1.Controls.Add(this.MinGreen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.MinRed);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color Filter";
            // 
            // MaxBlue
            // 
            this.MaxBlue.Location = new System.Drawing.Point(126, 45);
            this.MaxBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MaxBlue.Name = "MaxBlue";
            this.MaxBlue.ReadOnly = true;
            this.MaxBlue.Size = new System.Drawing.Size(39, 20);
            this.MaxBlue.TabIndex = 7;
            this.MaxBlue.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // MaxGreen
            // 
            this.MaxGreen.Location = new System.Drawing.Point(81, 45);
            this.MaxGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MaxGreen.Name = "MaxGreen";
            this.MaxGreen.ReadOnly = true;
            this.MaxGreen.Size = new System.Drawing.Size(39, 20);
            this.MaxGreen.TabIndex = 6;
            this.MaxGreen.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Max";
            // 
            // MaxRed
            // 
            this.MaxRed.Location = new System.Drawing.Point(36, 45);
            this.MaxRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MaxRed.Name = "MaxRed";
            this.MaxRed.ReadOnly = true;
            this.MaxRed.Size = new System.Drawing.Size(39, 20);
            this.MaxRed.TabIndex = 4;
            this.MaxRed.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // MinBlue
            // 
            this.MinBlue.Location = new System.Drawing.Point(126, 19);
            this.MinBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MinBlue.Name = "MinBlue";
            this.MinBlue.ReadOnly = true;
            this.MinBlue.Size = new System.Drawing.Size(39, 20);
            this.MinBlue.TabIndex = 3;
            this.MinBlue.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // MinGreen
            // 
            this.MinGreen.Location = new System.Drawing.Point(81, 19);
            this.MinGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MinGreen.Name = "MinGreen";
            this.MinGreen.ReadOnly = true;
            this.MinGreen.Size = new System.Drawing.Size(39, 20);
            this.MinGreen.TabIndex = 2;
            this.MinGreen.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Min";
            // 
            // MinRed
            // 
            this.MinRed.Location = new System.Drawing.Point(36, 19);
            this.MinRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MinRed.Name = "MinRed";
            this.MinRed.ReadOnly = true;
            this.MinRed.Size = new System.Drawing.Size(39, 20);
            this.MinRed.TabIndex = 0;
            this.MinRed.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // MaxError
            // 
            this.MaxError.DecimalPlaces = 1;
            this.MaxError.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.MaxError.Location = new System.Drawing.Point(36, 19);
            this.MaxError.Maximum = new decimal(new int[] {
            12800,
            0,
            0,
            131072});
            this.MaxError.Name = "MaxError";
            this.MaxError.ReadOnly = true;
            this.MaxError.Size = new System.Drawing.Size(129, 20);
            this.MaxError.TabIndex = 1;
            this.MaxError.Value = new decimal(new int[] {
            100,
            0,
            0,
            65536});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MaxError);
            this.groupBox2.Location = new System.Drawing.Point(0, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 54);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Error Distance";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.FocalLength);
            this.groupBox3.Location = new System.Drawing.Point(0, 145);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 54);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Focal Length (in mm)";
            // 
            // FocalLength
            // 
            this.FocalLength.DecimalPlaces = 2;
            this.FocalLength.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.FocalLength.Location = new System.Drawing.Point(36, 19);
            this.FocalLength.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.FocalLength.Name = "FocalLength";
            this.FocalLength.ReadOnly = true;
            this.FocalLength.Size = new System.Drawing.Size(129, 20);
            this.FocalLength.TabIndex = 1;
            this.FocalLength.Value = new decimal(new int[] {
            85,
            0,
            0,
            131072});
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CameraDistance);
            this.groupBox4.Location = new System.Drawing.Point(0, 205);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 54);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Camera Distance (in mm)";
            // 
            // CameraDistance
            // 
            this.CameraDistance.DecimalPlaces = 1;
            this.CameraDistance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.CameraDistance.Location = new System.Drawing.Point(36, 19);
            this.CameraDistance.Name = "CameraDistance";
            this.CameraDistance.ReadOnly = true;
            this.CameraDistance.Size = new System.Drawing.Size(129, 20);
            this.CameraDistance.TabIndex = 1;
            this.CameraDistance.Value = new decimal(new int[] {
            4950,
            0,
            0,
            131072});
            // 
            // SaturationLeft
            // 
            this.SaturationLeft.Location = new System.Drawing.Point(9, 18);
            this.SaturationLeft.Name = "SaturationLeft";
            this.SaturationLeft.Size = new System.Drawing.Size(178, 45);
            this.SaturationLeft.TabIndex = 5;
            this.SaturationLeft.Scroll += new System.EventHandler(this.SaturationLeft_Scroll);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.SaturationRight);
            this.groupBox5.Controls.Add(this.SaturationLeft);
            this.groupBox5.Location = new System.Drawing.Point(0, 265);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 105);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Saturation (0.0 to 1.0)";
            // 
            // SaturationRight
            // 
            this.SaturationRight.Location = new System.Drawing.Point(9, 54);
            this.SaturationRight.Name = "SaturationRight";
            this.SaturationRight.Size = new System.Drawing.Size(178, 45);
            this.SaturationRight.TabIndex = 6;
            this.SaturationRight.Scroll += new System.EventHandler(this.SaturationRight_Scroll);
            // 
            // OptionsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(212, 382);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionsPanel";
            this.Text = "OptionsPanel";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Exit);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxError)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FocalLength)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CameraDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaturationLeft)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaturationRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown MaxBlue;
        public System.Windows.Forms.NumericUpDown MaxGreen;
        public System.Windows.Forms.NumericUpDown MaxRed;
        public System.Windows.Forms.NumericUpDown MinBlue;
        public System.Windows.Forms.NumericUpDown MinGreen;
        public System.Windows.Forms.NumericUpDown MinRed;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.NumericUpDown MaxError;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.NumericUpDown FocalLength;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.NumericUpDown CameraDistance;
        private System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.TrackBar SaturationLeft;
        public System.Windows.Forms.TrackBar SaturationRight;
    }
}