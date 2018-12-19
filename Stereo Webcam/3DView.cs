using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SharpGL;

namespace Stereo_Webcam
{
    public partial class _3DView : Form
    {
        OpenGL TheOpenGL;
        float[] Translation;
        float[] Rotation;

        public _3DView()
        {
            InitializeComponent();
        }
        
        private void SharpGL_Load(object o, EventArgs e)
        {
            TheOpenGL = this.ViewPort.OpenGL;
            Translation = new float[3] { 0f, 0.25f, -1.5f };
            Rotation = new float[3] { 15f, 0f, 0f };
        }

        private void SharpGL_Render(object o, RenderEventArgs e)
        {
            TheOpenGL = this.ViewPort.OpenGL;
            // Clear The Screen And The Depth Buffer
            TheOpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            // Reset The View
            TheOpenGL.LoadIdentity();
            TheOpenGL.MatrixMode(SharpGL.Enumerations.MatrixMode.Modelview);
            TheOpenGL.Translate(Translation[0], Translation[1], Translation[2]);
            TheOpenGL.Rotate(Rotation[0], 1, 0, 0);
            TheOpenGL.Rotate(Rotation[1], 0, 1, 0);
            TheOpenGL.Rotate(Rotation[2], 0, 0, 1);

            TheOpenGL.PointSize(15f);
            TheOpenGL.Begin(SharpGL.Enumerations.BeginMode.Points);
            for (int a = 0; a < MainForm.ObjectDescLeft.Length; a++)
            {
                TheOpenGL.Color(
                    MainForm.ObjectDescLeft[a].ColorMean.R / 255f,
                    MainForm.ObjectDescLeft[a].ColorMean.G / 255f,
                    MainForm.ObjectDescLeft[a].ColorMean.B / 255f);
                TheOpenGL.Vertex(MainForm.ObjectDescLeft[a].X, MainForm.ObjectDescLeft[a].Y, -MainForm.ObjectDescLeft[a].Z);
            }
            TheOpenGL.End();

            TheOpenGL.LineWidth(1.5f);
            TheOpenGL.Begin(SharpGL.Enumerations.BeginMode.Lines);
            for (int a = 0; a < MainForm.ObjectDescLeft.Length; a++)
            {
                TheOpenGL.Color(1f, 1f, 1f);
                TheOpenGL.Vertex(MainForm.ObjectDescLeft[a].X, MainForm.ObjectDescLeft[a].Y, -MainForm.ObjectDescLeft[a].Z);
                if (a < MainForm.ObjectDescLeft.Length-1)
                    TheOpenGL.Vertex(MainForm.ObjectDescLeft[a+1].X, MainForm.ObjectDescLeft[a+1].Y, -MainForm.ObjectDescLeft[a+1].Z);
                else
                    TheOpenGL.Vertex(MainForm.ObjectDescLeft[0].X, MainForm.ObjectDescLeft[0].Y, -MainForm.ObjectDescLeft[0].Z);
            }
            TheOpenGL.End();

            TheOpenGL.Enable(OpenGL.GL_BLEND); // Enable blend function.
            TheOpenGL.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
            TheOpenGL.Begin(SharpGL.Enumerations.BeginMode.Quads);
            // Plane.
            TheOpenGL.Color(1f, 1f, 1f, 0.1f);
            TheOpenGL.Vertex(-1f, 0f, -1f);
            TheOpenGL.Vertex(1f, 0f, -1f);
            TheOpenGL.Vertex(1f, 0f, 1f);
            TheOpenGL.Vertex(-1f, 0f, 1f);
            // Center.
            TheOpenGL.Color(1f, 1f, 1f, 0.1f);
            TheOpenGL.Vertex(-0.05f, 0.01f, -0.05f);
            TheOpenGL.Vertex(0.05f, 0.01f, -0.05f);
            TheOpenGL.Vertex(0.05f, 0.01f, 0.05f);
            TheOpenGL.Vertex(-0.05f, 0.01f, 0.05f);
            TheOpenGL.Vertex(-0.025f, 0.01f, 0.05f);
            TheOpenGL.Vertex(0.025f, 0.01f, 0.05f);
            TheOpenGL.Vertex(0.025f, 0.01f, -0.1f);
            TheOpenGL.Vertex(-0.025f, 0.01f, -0.1f);
            TheOpenGL.End();

            TheOpenGL.Flush();
        }

        private void SharpGL_KeyHandle(object o, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                Translation[0] -= .1f;
            else if (e.KeyCode == Keys.D)
                Translation[0] += .1f;

            if (e.KeyCode == Keys.W)
                Translation[1] += .1f;
            else if (e.KeyCode == Keys.S)
                Translation[1] -= .1f;

            if (e.KeyCode == Keys.Q)
                Translation[2] -= .1f;
            else if (e.KeyCode == Keys.E)
                Translation[2] += .1f;

            if (e.KeyCode == Keys.J)
                Rotation[1] -= 5f;
            else if (e.KeyCode == Keys.L)
                Rotation[1] += 5f;

            if (e.KeyCode == Keys.I)
                Rotation[0] -= 5f;
            else if (e.KeyCode == Keys.K)
                Rotation[0] += 5f;

            if (e.KeyCode == Keys.U)
                Rotation[2] -= 5f;
            else if (e.KeyCode == Keys.O)
                Rotation[2] += 5f;
        }
    }
}
