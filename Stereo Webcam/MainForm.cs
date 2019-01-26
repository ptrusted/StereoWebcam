using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Stereo_Webcam
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Some states.
        /// </summary>
        private bool CameraReady = false;
        private bool Executed = false;
        /// <summary>
        /// Some filters.
        /// </summary>
        public static SaturationCorrection FilterSaturateLeft, FilterSaturateRight;
        private Invert FilterInvert;
        private ColorFiltering FilterColor;
        /// <summary>
        /// Camera parameters.
        /// </summary>
        private int Wdth, Hght;
        private float[] FocalLengthLeft = new float[2] { 2003.955566f, 1977.458862f };
        private float[] FocalLengthRight = new float[2] { 1561.591187f, 1549.922241f };
        private float[] CameraCenterLeft = new float[2] { 514.895325f, 228.277451f };
        private float[] CameraCenterRight = new float[2] { 316.473846f, 383.084991f };
        /// <summary>
        /// Detected objects in both camera.
        /// </summary>
        private Rectangle[] ObjectsLeft, ObjectsRight;
        /// <summary>
        /// Detected objects descriptor.
        /// </summary>
        public struct Descriptor
        {
            public float RedMean; // Mean value of red.
            public float GreenMean; // Mean value of green.
            public float BlueMean; // Mean value of blue.
            public int ColorClass; // Classification index.
            public Color ColorMean; // Color mean (Red / Green / Blue).
            public float PercentR; // Percentage of red.
            public float PercentG; // Percentage of green.
            public float PercentB; // Percentage of blue.
            public float x; // Image position in x axis.
            public float y; // Image position in y axis.
            public float X; // World position in x axis.
            public float Y; // World position in y axis.
            public float Z; // World position in z axis.
        }
        public Descriptor[] ObjectDescLeft, ObjectDescRight;
        /// <summary>
        /// Final output of processed left and right image.
        /// </summary>
        private Bitmap ProcessedImage;
        /// <summary>
        /// Options form.
        /// </summary>
        public OptionsPanel OptionsControl;
        /// <summary>
        /// Vector object consisted of three floating number.
        /// </summary>
        public struct Vector3f
        {
            public float X;
            public float Y;
            public float Z;
        }
        public static Vector3f[] OutputVectors;


        // ==========================================================================
        // ==========================================================================
        // MAIN FUNCTIONS

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OptionsControl = new OptionsPanel();
            // Open camera devices.
            OpenCamera1();
            OpenCamera2();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P) // If key 'p' is pressed.
                Execute();
            if (e.KeyCode == Keys.End) // End camera streams.
            {
                CameraView1.SignalToStop();
                CameraView1.WaitForStop();
                CameraView2.SignalToStop();
                CameraView2.WaitForStop();
                Executed = false;
            }
            if (e.KeyCode == Keys.V)
            {
                _3DView view = new _3DView();
                view.Show();
            }
                
        }

        private void MainForm_Exit(object sender, EventArgs e)
        {
            
        }

        // ==========================================================================
        // ==========================================================================
        // AFORGE.NET RELATED AND IMAGE PROCESSING FUNCTIONS

        /// <summary>
        /// Open detected local camera.
        /// </summary>
        private void OpenCamera1()
        {
            // Show camera selection form.
            CameraSelector cameraSelection = new CameraSelector();
            if (cameraSelection.ShowDialog(this) == DialogResult.OK)
            {
                // Create video source from selected camera.
                VideoCaptureDevice theCamera = new VideoCaptureDevice(cameraSelection.SelectedCamera);
                // Close previous video source.
                CameraView1.SignalToStop();
                CameraView1.WaitForStop();
                // Choose video resolution.
                theCamera.VideoResolution = theCamera.VideoCapabilities[cameraSelection.SelectedOption];
                Wdth = theCamera.VideoResolution.FrameSize.Width;
                Hght = theCamera.VideoResolution.FrameSize.Height;
                // Set the new video source.
                CameraView1.VideoSource = theCamera;
                CameraView1.Start();
            }
        }

        /// <summary>
        /// Open detected local camera.
        /// </summary>
        private void OpenCamera2()
        {
            // Show camera selection form.
            CameraSelector cameraSelection = new CameraSelector();
            if (cameraSelection.ShowDialog(this) == DialogResult.OK)
            {
                // Create video source from selected camera.
                VideoCaptureDevice theCamera = new VideoCaptureDevice(cameraSelection.SelectedCamera);
                // Close previous video source.
                CameraView2.SignalToStop();
                CameraView2.WaitForStop();
                // Choose video resolution.
                theCamera.VideoResolution = theCamera.VideoCapabilities[cameraSelection.SelectedOption];
                // Set the new video source.
                CameraView2.VideoSource = theCamera;
                CameraView2.Start();
                OptionsControl.ShowDialog();
                CameraReady = true;
            }
        }

        /// <summary>
        /// Execute image processing.
        /// </summary>
        private void Execute()
        {
            if (CameraReady)
            {
                OutputVectors = new Vector3f[9];
                for (int a = 0; a < OutputVectors.Length; a++)
                {
                    OutputVectors[a].X = 0f; OutputVectors[a].Y = 0f; OutputVectors[a].Z = 0f;
                }
                ProcessedImage = new Bitmap(640, 480);
                FilterSaturateLeft = new SaturationCorrection(OptionsControl.SaturationLeft.Value / 10f);
                FilterSaturateRight = new SaturationCorrection(OptionsControl.SaturationRight.Value / 10f);
                FilterInvert = new Invert();
                FilterColor = new ColorFiltering(
                    new IntRange((int)OptionsControl.MinRed.Value, (int)OptionsControl.MaxRed.Value),
                    new IntRange((int)OptionsControl.MinGreen.Value, (int)OptionsControl.MaxGreen.Value),
                    new IntRange((int)OptionsControl.MinBlue.Value, (int)OptionsControl.MaxBlue.Value)
                    );
                OptionsControl.Show();
                Executed = true;
                Console.WriteLine("Executed!");
            }
        }

        /// <summary>
        /// Update routine for first camera.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="image"></param>
        private void Camera1_Update(object sender, ref Bitmap image)
        {
            if (Executed)
            {
                Bitmap invrt = FilterInvert.Apply(image);
                FilterColor.ApplyInPlace(invrt);
                FilterSaturateLeft.ApplyInPlace(image);
                // create an instance of blob counter algorithm.
                BlobCounter objCounter = new BlobCounter();
                objCounter.FilterBlobs = true;
                objCounter.CoupledSizeFiltering = true;
                objCounter.MinWidth = (int)(0.05f * Wdth);
                objCounter.MinHeight = (int)(0.05f * Hght);
                objCounter.MaxWidth = (int)(0.4f * Wdth);
                objCounter.MaxHeight = (int)(0.4f * Hght);
                // process image.
                objCounter.ProcessImage(invrt);
                ObjectsLeft = objCounter.GetObjectsRectangles();
                ObjectDescLeft = new Descriptor[ObjectsLeft.Length];
                // Draw lines.
                Graphics graphic = Graphics.FromImage(image);
                Pen pen = new Pen(Color.Yellow);
                pen.Width = 7;
                Font font = new Font("Courier", 14, FontStyle.Regular);
                SolidBrush brush = new SolidBrush(Color.Yellow);
                for (int a = 0; a < ObjectsLeft.Length; a++)
                {
                    // Set descriptor of each detected object.
                    SetDescriptor(ref ObjectDescLeft[a], ref ObjectsLeft[a], image);
                    pen.Color = ObjectDescLeft[a].ColorMean;
                    graphic.DrawRectangle(pen, ObjectsLeft[a]);
                    graphic.DrawString(a.ToString() + " | " + ObjectDescLeft[a].ColorClass +
                        "\n" + ObjectDescLeft[a].PercentR.ToString() + "%\n" + ObjectDescLeft[a].PercentG.ToString() +
                        "%\n" + ObjectDescLeft[a].PercentB.ToString() + "%",
                        font, brush, ObjectsLeft[a].X, ObjectsLeft[a].Y);
                }
                pen.Dispose();
                graphic.Dispose();
            }
            else
            {
                Graphics graphic = Graphics.FromImage(image);
                Pen pen = new Pen(Color.Yellow);
                pen.Width = 6;
                graphic.DrawRectangle(pen, new Rectangle(30, 30, Wdth - 60, Hght - 60));
                pen.Width = 3;
                graphic.DrawRectangle(pen, new Rectangle(90, 90, Wdth - 180, Hght - 180));
                pen.Dispose();
                graphic.Dispose();
            }
        }

        /// <summary>
        /// Update routine for second camera.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="image"></param>
        private void Camera2_Update(object sender, ref Bitmap image)
        {
            if (Executed)
            {
                Bitmap invrt = FilterInvert.Apply(image);
                FilterColor.ApplyInPlace(invrt);
                FilterSaturateRight.ApplyInPlace(image);
                // create an instance of blob counter algorithm.
                BlobCounter objCounter = new BlobCounter();
                objCounter.FilterBlobs = true;
                objCounter.CoupledSizeFiltering = true;
                objCounter.MinWidth = (int)(0.05f * Wdth);
                objCounter.MinHeight = (int)(0.05f * Hght);
                objCounter.MaxWidth = (int)(0.4f * Wdth);
                objCounter.MaxHeight = (int)(0.4f * Hght);
                // process image.
                objCounter.ProcessImage(invrt);
                ObjectsRight = objCounter.GetObjectsRectangles();
                ObjectDescRight = new Descriptor[ObjectsRight.Length];
                // Draw lines.
                Graphics graphic = Graphics.FromImage(image);
                Pen pen = new Pen(Color.Yellow);
                pen.Width = 7;
                Font font = new Font("Courier", 14, FontStyle.Regular);
                SolidBrush brush = new SolidBrush(Color.Yellow);
                for (int a = 0; a < ObjectsRight.Length; a++)
                {
                    // Set descriptor of each detected object.
                    SetDescriptor(ref ObjectDescRight[a], ref ObjectsRight[a], image);
                    pen.Color = ObjectDescRight[a].ColorMean;
                    graphic.DrawRectangle(pen, ObjectsRight[a]);
                    graphic.DrawString(a.ToString() + " | " + ObjectDescRight[a].ColorClass +
                        "\n" + ObjectDescRight[a].PercentR.ToString() + "%\n" + ObjectDescRight[a].PercentG.ToString() +
                        "%\n" + ObjectDescRight[a].PercentB.ToString() + "%",
                        font, brush, ObjectsRight[a].X, ObjectsRight[a].Y);
                }
                pen.Dispose();
                graphic.Dispose();
                FinalImageProcessing();
            }
            else
            {
                Graphics graphic = Graphics.FromImage(image);
                Pen pen = new Pen(Color.Yellow);
                pen.Width = 6;
                graphic.DrawRectangle(pen, new Rectangle(30, 30, Wdth - 60, Hght - 60));
                pen.Width = 3;
                graphic.DrawRectangle(pen, new Rectangle(90, 90, Wdth - 180, Hght - 180));
                pen.Dispose();
                graphic.Dispose();
            }
        }

        /// <summary>
        /// Final image processing routine.
        /// </summary>
        private void FinalImageProcessing()
        {
            if (Executed)
            {
                Graphics g = Graphics.FromImage(ProcessedImage);
                g.Clear(Color.Black);
                Font font = new Font("Courier", 10, FontStyle.Bold);
                SolidBrush brush = new SolidBrush(Color.Yellow);
                Pen pen = new Pen(Color.Red);
                pen.Width = 2f;

                if (ObjectsLeft != null && ObjectsRight != null)
                {
                    try
                    {
                        for (int a = 0; a < ObjectsLeft.Length; a++)
                        {
                            string txt = "...";
                            //float minER = 255f;
                            //float minEG = 255f;
                            //float minEB = 255f;
                            for (int b = 0; b < ObjectsRight.Length; b++)
                            {
                                if (ObjectDescLeft[a].ColorClass == ObjectDescRight[b].ColorClass)
                                {
                                    //float eR = Math.Abs(ObjectDescLeft[a].RedMeans - ObjectDescRight[b].RedMeans);
                                    //float eG = Math.Abs(ObjectDescLeft[a].GreenMeans - ObjectDescRight[b].GreenMeans);
                                    //float eB = Math.Abs(ObjectDescLeft[a].BlueMeans - ObjectDescRight[b].BlueMeans);
                                    //if ((eR <= (float)OptionsControl.MaxError.Value) &&
                                    //     (eG <= (float)OptionsControl.MaxError.Value) &&
                                    //     (eB <= (float)OptionsControl.MaxError.Value))
                                    //{
                                    //    if (eR <= minER && eG <= minEG && eB <= minEB)
                                    //    {
                                    //        minER = eR;
                                    //        minEG = eG;
                                    //        minEB = eB;
                                    ObjectDescLeft[a].Z = CalculateDepth(
                                        (float)OptionsControl.CameraDistance.Value,
                                        (float)OptionsControl.FocalLength.Value,
                                        ObjectDescLeft[a].x,
                                        ObjectDescRight[b].x,
                                        ObjectDescLeft[a].y,
                                        ObjectDescRight[b].y
                                    );
                                    ObjectDescLeft[a].X = CalculatePos(
                                        (float)OptionsControl.FocalLength.Value,
                                        ObjectDescLeft[a].Z,
                                        (float)OptionsControl.CameraDistance.Value,
                                        Wdth / 2,
                                        ObjectDescLeft[a].x
                                    );
                                    ObjectDescLeft[a].Y = -CalculatePos(
                                        (float)OptionsControl.FocalLength.Value,
                                        ObjectDescLeft[a].Z,
                                        (float)OptionsControl.CameraDistance.Value,
                                        Hght / 2,
                                        ObjectDescLeft[a].y
                                    );
                                    txt = a.ToString() + " with " + b.ToString() + "\n" +
                                        ObjectDescLeft[a].X.ToString() + "\n" +
                                        ObjectDescLeft[a].Y.ToString() + "\n" +
                                        ObjectDescLeft[a].Z.ToString();
                                    OutputVectors[ObjectDescLeft[a].ColorClass-1].X = ObjectDescLeft[a].X;
                                    OutputVectors[ObjectDescLeft[a].ColorClass-1].Y = ObjectDescLeft[a].Y;
                                    OutputVectors[ObjectDescLeft[a].ColorClass-1].Z = ObjectDescLeft[a].Z;
                                    //}
                                    //}
                                }
                            }
                            g.DrawRectangle(
                                pen,
                                (int)(ObjectsLeft[a].X / 1.454545), (int)(ObjectsLeft[a].Y / 1.454545),
                                ObjectsLeft[a].Width / 2, ObjectsLeft[a].Height / 2);
                            g.DrawString(txt, font, brush,
                                (int)(ObjectsLeft[a].X / 1.454545), (int)(ObjectsLeft[a].Y / 1.454545));
                        }
                    } catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine(e);
                    }
                }

                font.Dispose();
                brush.Dispose();
                g.Dispose();
                ViewFinder.Image = ProcessedImage;
            }
        }

        // ==========================================================================
        // ==========================================================================
        // OTHER FUNCTIONS

        /// <summary>
        /// Set value to specified descriptor.
        /// </summary>
        /// <param name="desc"></param>
        private void SetDescriptor(ref Descriptor desc, ref Rectangle rect, Bitmap img)
        {
            float sumR = 0f, sumG = 0f, sumB = 0;
            int totalR = 0, totalG = 0, totalB = 0;
            int totalPixel = 0;
            //-------------------------------------  answered May 23 '11 at 7:24 by hashi on stackoverflow.com.
            // Lock the bitmap's bits.  
            BitmapData bmpData = img.LockBits(new Rectangle(0,0,img.Width,img.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            // Declare an array to hold the bytes of the bitmap.
            int length = bmpData.Stride * bmpData.Height;
            byte[] rgbValues = new byte[length];

            // Copy the RGB values into the array.
            Marshal.Copy(bmpData.Scan0, rgbValues, 0, length);

            // Main loop around feature.
            int stride = bmpData.Stride;
            for (int h = rect.Y; h < rect.Y + rect.Height; h++)
            {
                for (int w = rect.X; w < rect.X + rect.Width; w++)
                {
                    float r, g, b;
                    b = (float)(rgbValues[(h * stride) + (w * 3)]); // Get B.
                    g = (float)(rgbValues[(h * stride) + (w * 3) + 1]); // Get G.
                    r = (float)(rgbValues[(h * stride) + (w * 3) + 2]); // Get R.
                    float max = Math.Max(Math.Max(r, g), b); // Get max of R, G, and B.
                    // If not white
                    if (!((Math.Abs(r-max) < 10) && (Math.Abs(g - max) < 10) && (Math.Abs(b - max) < 10)))
                    {
                        if (r > g)
                        {
                            if (r > b)
                            {
                                totalR++;
                                sumR += r;
                            }
                            else
                            {
                                totalB++;
                                sumB += b;
                            }
                        } else
                        {
                            if (g > b)
                            {
                                totalG++;
                                sumG += g;
                            }
                            else
                            {
                                totalB++;
                                sumB += b;
                            }
                        }
                        totalPixel++;
                    }
                }
            }
            //-------------------------------------------------------------------------------------------------
            // Set color mean.
            desc.RedMean = sumR / (float)totalR;
            desc.GreenMean = sumG / (float)totalG;
            desc.BlueMean = sumB / (float)totalB;
            // Set color percentages.
            desc.PercentR = 100f * ((float)totalR / (float)totalPixel);
            desc.PercentG = 100f * ((float)totalG / (float)totalPixel);
            desc.PercentB = 100f * ((float)totalB / (float)totalPixel);
            // Set feature position.
            desc.x = rect.X + (rect.Width / 2f);
            desc.y = rect.Y + (rect.Height / 2f);
            // Set color class.
            if (totalR > totalG)
            {
                if (totalR > totalB)
                {
                    if (desc.PercentG > 10f)
                        desc.ColorClass = 4;
                    else if (desc.PercentB > 10f)
                        desc.ColorClass = 5;
                    else
                        desc.ColorClass = 1;//(int)Math.Ceiling(desc.RedMean / 85f);
                    desc.ColorMean = Color.Red; // Save color value.
                }
                else
                {
                    if (desc.PercentR > 10f)
                        desc.ColorClass = 8;
                    else if (desc.PercentG > 10f)
                        desc.ColorClass = 9;
                    else
                        desc.ColorClass = 3;//(int)Math.Ceiling(desc.BlueMean / 85f) + 6;
                    desc.ColorMean = Color.Blue; // Save color value.
                }
            }
            else
            {
                if (totalG > totalB)
                {
                    if (desc.PercentR > 10f)
                        desc.ColorClass = 6;
                    else if (desc.PercentB > 10f)
                        desc.ColorClass = 7;
                    else
                        desc.ColorClass = 2;//(int)Math.Ceiling(desc.GreenMean / 85f) + 3;
                    desc.ColorMean = Color.Green; // Save color value.
                }
                else
                {
                    if (desc.PercentR > 10f)
                        desc.ColorClass = 8;
                    else if (desc.PercentG > 10f)
                        desc.ColorClass = 9;
                    else
                        desc.ColorClass = 3;
                    desc.ColorMean = Color.Blue; // Save color value.
                }
            }
            //Console.WriteLine(
            //    "(" + desc.RedMeans.ToString() + ", " +
            //    desc.GreenMeans.ToString() + ", " +
            //    desc.BlueMeans.ToString() + ") : " +
            //    desc.ColorClass.ToString()
            //    );
            // Normalize color means
            //float norm = 1f / (float)Math.Sqrt(
            //    desc.RedMeans * desc.RedMeans +
            //    desc.GreenMeans * desc.GreenMeans +
            //    desc.BlueMeans * desc.BlueMeans);
            //desc.RedMeans *= norm;
            //desc.GreenMeans *= norm;
            //desc.BlueMeans *= norm;
            // Set color percentage.
            img.UnlockBits(bmpData);
        }

        /// <summary>
        /// Get X or Y value of mathed feature.
        /// </summary>
        /// <param name="f"></param>
        /// <param name="Z"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        private float CalculatePos(float f, float Z, float b, float pos0, float pos1)
        {
            return ((pos1 - pos0) * Z - (b / 2f)) / f / 1000f;
        }
        
        /// <summary>
        /// Get Z value of matched feature.
        /// </summary>
        /// <param name="b"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        private float CalculateDepth(float b, float f, float x1, float x2, float y1, float y2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
            return (f * b) / (float)Math.Sqrt((dx * dx) + (dy * dy));
        }

        /// <summary>
        /// Clamp value into min and max range.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private int Clamp(int value, int min, int max)
        {
            if (value < min)
                value = min;
            else if (value > max)
                value = max;
            return value;
        }
    }
}