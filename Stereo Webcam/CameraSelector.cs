using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AForge.Video.DirectShow;

namespace Stereo_Webcam
{
    public partial class CameraSelector : Form
    {
        private FilterInfoCollection DetectedCameraDevices;
        public string SelectedCamera;
        public int SelectedOption;

        public CameraSelector()
        {
            InitializeComponent();
        }

        private void CameraSelector_Load(object sender, EventArgs e)
        {
            EnumerateCameraDevices();
        }

        private void EnumerateCameraDevices()
        {
            ButtonOkay.Enabled = false;
            try
            {
                // Enumerate video devices.
                DetectedCameraDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (DetectedCameraDevices.Count == 0)
                    throw new ApplicationException();
                foreach (FilterInfo cameraItem in DetectedCameraDevices)
                    CameraName.Items.Add(cameraItem.Name);
            }
            catch (ApplicationException e)
            {
                CameraName.Items.Add("I'm sorry, no camera detected !");
                CameraName.Enabled = false;
                ButtonOkay.Enabled = false;
            }
        }

        private void CameraName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedCamera = DetectedCameraDevices[CameraName.SelectedIndex].MonikerString;
            ButtonOkay.Enabled = true;
            CameraOption.Items.Clear();
            VideoCaptureDevice theCamera = new VideoCaptureDevice(SelectedCamera);
            foreach (VideoCapabilities option in theCamera.VideoCapabilities)
                CameraOption.Items.Add(option.FrameSize.Width.ToString() + " x " +
                    option.FrameSize.Height.ToString() + " : " +
                    option.AverageFrameRate.ToString());
            CameraOption.SelectedIndex = 0;
            theCamera.SignalToStop();
            theCamera.WaitForStop();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            SelectedCamera = DetectedCameraDevices[CameraName.SelectedIndex].MonikerString;
            SelectedOption = CameraOption.SelectedIndex;
        }
    }
}
