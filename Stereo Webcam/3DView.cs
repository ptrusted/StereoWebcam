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
using SharpGL.SceneGraph.Assets;

namespace Stereo_Webcam
{
    public partial class _3DView : Form
    {
        OpenGL TheOpenGL;
        float[] Translation;
        float[] Rotation;
        Texture Background, Foreground, Actor1, Actor2, Actor3;

        public _3DView()
        {
            InitializeComponent();
        }
        
        private void SharpGL_Load(object o, EventArgs e)
        {
            TheOpenGL = this.ViewPort.OpenGL;
            Translation = new float[3] { 0f, 0f, -1.5f };
            Rotation = new float[3] { 0f, 0f, 0f };
            Background = new Texture(); Background.Create(TheOpenGL, "Theater Background 1.png");
            Foreground = new Texture(); Foreground.Create(TheOpenGL, "Theater Foreground 1.png");
            Actor1 = new Texture(); Actor1.Create(TheOpenGL, "Theater Actor 1.png");
            Actor2 = new Texture(); Actor2.Create(TheOpenGL, "Theater Actor 2.png");
            Actor3 = new Texture(); Actor3.Create(TheOpenGL, "Theater Actor 3.png");
        }

        private void SharpGL_Render(object o, RenderEventArgs e)
        {
            TheOpenGL = this.ViewPort.OpenGL;
            // Clear The Screen And The Depth Buffer
            TheOpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            // Reset The View
            TheOpenGL.LoadIdentity();
            // Re-Enable texture.
            TheOpenGL.Enable(OpenGL.GL_TEXTURE_2D);
            // Enable blend function.
            TheOpenGL.Enable(OpenGL.GL_BLEND);
            TheOpenGL.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);

            TheOpenGL.MatrixMode(SharpGL.Enumerations.MatrixMode.Modelview);
            TheOpenGL.Translate(Translation[0], Translation[1], Translation[2]);
            TheOpenGL.Rotate(Rotation[0], 1, 0, 0);
            TheOpenGL.Rotate(Rotation[1], 0, 1, 0);
            TheOpenGL.Rotate(Rotation[2], 0, 0, 1);
            // ########################################################################################
            // ########################################################################################

            DrawBackground();
            DrawActors();
            DrawForeground();

            // ########################################################################################
            // ########################################################################################
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

        private void DrawBackground()
        {
            TheOpenGL.PushMatrix();
            TheOpenGL.Translate(0f, 0f, -1f);
            TheOpenGL.Scale(2f, 2f, 2f);
            //TheOpenGL.Rotate(MainForm.OutputVectors[0].X, MainForm.OutputVectors[0].Y, MainForm.OutputVectors[0].Z);
            Background.Bind(TheOpenGL);
            TheOpenGL.Begin(OpenGL.GL_QUADS);
            TheOpenGL.Color(1f, 1f, 1f);
            TheOpenGL.TexCoord(0f, 1f); TheOpenGL.Vertex(-(1.280f / 2),-(0.720f / 2), 0f);
            TheOpenGL.TexCoord(1f, 1f); TheOpenGL.Vertex((1.280f / 2),-(0.720f / 2), 0f);
            TheOpenGL.TexCoord(1f, 0f); TheOpenGL.Vertex((1.280f / 2),(0.720f / 2), 0f);
            TheOpenGL.TexCoord(0f, 0f); TheOpenGL.Vertex(-(1.280f / 2),(0.720f / 2), 0f);
            TheOpenGL.End();
            TheOpenGL.PopMatrix();
        }

        private void DrawActors()
        {
            // Actor 1.
            TheOpenGL.PushMatrix();
            TheOpenGL.Translate(MainForm.OutputVectors[3].X*5f, MainForm.OutputVectors[3].Y*5f, -MainForm.OutputVectors[3].Z);
            TheOpenGL.Rotate(0f, 0f,
                (float)Math.Atan(
                (MainForm.OutputVectors[3].Y - MainForm.OutputVectors[4].Y) /
                (MainForm.OutputVectors[3].X - MainForm.OutputVectors[4].X)
                ) * 180f / (float)Math.PI
                );
            Actor1.Bind(TheOpenGL);
            TheOpenGL.Begin(OpenGL.GL_QUADS);
            TheOpenGL.Color(1f, 1f, 1f);
            TheOpenGL.TexCoord(0f, 1f); TheOpenGL.Vertex(-(0.239f / 2), -(0.326f / 2), 0f);
            TheOpenGL.TexCoord(1f, 1f); TheOpenGL.Vertex((0.239f / 2), -(0.326f / 2), 0f);
            TheOpenGL.TexCoord(1f, 0f); TheOpenGL.Vertex((0.239f / 2), (0.326f / 2), 0f);
            TheOpenGL.TexCoord(0f, 0f); TheOpenGL.Vertex(-(0.239f / 2), (0.326f / 2), 0f);
            TheOpenGL.End();
            TheOpenGL.PopMatrix();
            // Actor 2.
            TheOpenGL.PushMatrix();
            TheOpenGL.Translate(MainForm.OutputVectors[5].X*5f, MainForm.OutputVectors[5].Y*5f, -MainForm.OutputVectors[5].Z);
            TheOpenGL.Rotate(0f, 0f,
                (float)Math.Atan(
                (MainForm.OutputVectors[6].Y - MainForm.OutputVectors[5].Y) /
                (MainForm.OutputVectors[6].X - MainForm.OutputVectors[5].X)
                ) * 180f / (float)Math.PI
                );
            Actor2.Bind(TheOpenGL);
            TheOpenGL.Begin(OpenGL.GL_QUADS);
            TheOpenGL.Color(1f, 1f, 1f);
            TheOpenGL.TexCoord(0f, 1f); TheOpenGL.Vertex(-(0.239f / 2), -(0.326f / 2), 0f);
            TheOpenGL.TexCoord(1f, 1f); TheOpenGL.Vertex((0.239f / 2), -(0.326f / 2), 0f);
            TheOpenGL.TexCoord(1f, 0f); TheOpenGL.Vertex((0.239f / 2), (0.326f / 2), 0f);
            TheOpenGL.TexCoord(0f, 0f); TheOpenGL.Vertex(-(0.239f / 2), (0.326f / 2), 0f);
            TheOpenGL.End();
            TheOpenGL.PopMatrix();
            // Actor 3.
            //TheOpenGL.PushMatrix();
            //TheOpenGL.Translate(MainForm.OutputVectors[5].X, MainForm.OutputVectors[5].Y, -MainForm.OutputVectors[5].Z);
            //TheOpenGL.Rotate(0f, 0f,
            //    (float)Math.Atan(
            //    (MainForm.OutputVectors[6].Y - MainForm.OutputVectors[5].Y) /
            //    (MainForm.OutputVectors[6].X - MainForm.OutputVectors[5].X)
            //    ) * 180f / (float)Math.PI
            //    );
            //Actor3.Bind(TheOpenGL);
            //TheOpenGL.Begin(OpenGL.GL_QUADS);
            //TheOpenGL.Color(1f, 1f, 1f);
            //TheOpenGL.TexCoord(0f, 1f); TheOpenGL.Vertex(-(0.239f / 2), -(0.326f / 2), 0f);
            //TheOpenGL.TexCoord(1f, 1f); TheOpenGL.Vertex((0.239f / 2), -(0.326f / 2), 0f);
            //TheOpenGL.TexCoord(1f, 0f); TheOpenGL.Vertex((0.239f / 2), (0.326f / 2), 0f);
            //TheOpenGL.TexCoord(0f, 0f); TheOpenGL.Vertex(-(0.239f / 2), (0.326f / 2), 0f);
            //TheOpenGL.End();
            //TheOpenGL.PopMatrix();
        }

        private void DrawForeground()
        {
            Foreground.Bind(TheOpenGL);
            TheOpenGL.Begin(OpenGL.GL_QUADS);
            TheOpenGL.Color(1f, 1f, 1f);
            TheOpenGL.TexCoord(0f, 1f); TheOpenGL.Vertex(-(1.280f / 2), -(0.720f / 2), 0f);
            TheOpenGL.TexCoord(1f, 1f); TheOpenGL.Vertex((1.280f / 2), -(0.720f / 2), 0f);
            TheOpenGL.TexCoord(1f, 0f); TheOpenGL.Vertex((1.280f / 2), (0.720f / 2), 0f);
            TheOpenGL.TexCoord(0f, 0f); TheOpenGL.Vertex(-(1.280f / 2), (0.720f / 2), 0f);
            TheOpenGL.End();
        }
    }
}
