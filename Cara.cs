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
        public List<Vector3> vertices;
        public Vector3 centro; 
        public Color color;
        

        public Cara()
        {
            this.vertices = new List<Vector3>();            
            this.centro = new Vector3(0f, 0f, 0f); ;
            this.color = Color.White;
        }

        public Cara(List<Vector3> vertices, Vector3 centro, Color color)
        {
            this.vertices = vertices;            
            this.centro = centro;
            this.color = color;
        }

        public List<Vector3> getVertices()
        {
            return this.vertices;
        }

        public void setVertices(List<Vector3> vertices)
        {
            this.vertices = vertices;
        }

        public Vector3 getCentro()
        {
            return this.centro;
        }

        public void setCentro(Vector3 centro)
        {
            this.centro = centro;
        }

        public Color getColor()
        {
            return this.color;
        }

        public void setColor(Color color)
        {
            this.color = color;
        }                       

        public void agregarVertice(Vector3 vertice)
        {
            this.vertices.Add(vertice);
        }

        public void eliminarVertice(int posicion)
        {
            this.vertices.RemoveAt(posicion);
        }

        public void dibujar()
        {
            GL.Color3(this.color);
            GL.Begin(PrimitiveType.Polygon);
            
            foreach (Vector3 vertice in this.vertices)
            {               
                GL.Vertex3(
                    vertice.X + this.centro.X, 
                    vertice.Y + this.centro.Y, 
                    vertice.Z + this.centro.Z
                    );
            }

            GL.End();
        }

    }
}
