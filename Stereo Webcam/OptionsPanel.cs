using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stereo_Webcam
{
    public partial class OptionsPanel : Form
    {
        public OptionsPanel()
        {
            InitializeComponent();
        }

        private void Form_Exit(object sender, EventArgs e)
        {
            
        }

        private void SaturationLeft_Scroll(object sender, EventArgs e)
        {
            if (MainForm.FilterSaturateLeft != null)
                MainForm.FilterSaturateLeft.AdjustValue = SaturationLeft.Value / 10f;
        }

        private void SaturationRight_Scroll(object sender, EventArgs e)
        {
            if (MainForm.FilterSaturateRight != null)
                MainForm.FilterSaturateRight.AdjustValue = SaturationRight.Value / 10f;
        }
    }
}
