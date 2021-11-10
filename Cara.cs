using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;


namespace ProgramacionGrafica
{
    class Cara
    {
        private List<Vector3> vectores;
        private Vector3 color;
        public Cara()
        {
            vectores = new List<Vector3>();
        }

        public void addVertice(Vector3 vertice)
        {
            vectores.Add(vertice);
        }

        public void addVertices(List<Vector3> vertices)
        {
            this.vectores = vertices;
        }

        public void addColor(Vector3 color)
        {
            this.color = color;
        }

        public void addColor(float r, float a, float b)
        {
            this.color = new Vector3(r, a, b);
        }

        public void dibujar()
        {
            GL.Color3(this.color);
            foreach (var vector in vectores)
            {
                GL.Vertex3(vector);
            }
        }
    }
}
