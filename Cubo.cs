using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;


namespace ProgramacionGrafica
{
    class Cubo : Objeto
    {
        private List<Cara> caras;
        public Cubo()
        {
            this.caras = new List<Cara>();
        }

        public void rotar(int s)
        {
            GL.Rotate(s, 0.0f, 1.0f, 0.0f);
        }

        public void addFaces()
        {
            GL.PushMatrix();
            List<Vector3> lista1 = new List<Vector3>();
            lista1.Add(new Vector3(-1.0f, 1.0f, 1.0f));
            lista1.Add(new Vector3(-1.0f, 1.0f, -1.0f));
            lista1.Add(new Vector3(-1.0f, -1.0f, -1.0f));
            lista1.Add(new Vector3(-1.0f, -1.0f, 1.0f));
            Cara cara = new Cara();
            cara.addVertices(lista1);
            cara.addColor(1.0f, 1.0f, 0.0f);
            this.caras.Add(cara);

            List<Vector3> lista2 = new List<Vector3>();
            lista2.Add(new Vector3(1.0f, 1.0f, 1.0f));
            lista2.Add(new Vector3(1.0f, 1.0f, -1.0f));
            lista2.Add(new Vector3(1.0f, -1.0f, -1.0f));
            lista2.Add(new Vector3(1.0f, -1.0f, 1.0f));
            cara = new Cara();
            cara.addVertices(lista2);
            cara.addColor(1.0f, 0.0f, 1.0f);
            this.caras.Add(cara);

            List<Vector3> lista3 = new List<Vector3>();
            lista3.Add(new Vector3(1.0f, -1.0f, 1.0f));
            lista3.Add(new Vector3(1.0f, -1.0f, -1.0f));
            lista3.Add(new Vector3(-1.0f, -1.0f, -1.0f));
            lista3.Add(new Vector3(-1.0f, -1.0f, 1.0f));
            cara = new Cara();
            cara.addVertices(lista3);
            cara.addColor(0.0f, 1.0f, 1.0f);
            this.caras.Add(cara);

            List<Vector3> lista4 = new List<Vector3>();
            lista4.Add(new Vector3(1.0f, 1.0f, 1.0f));
            lista4.Add(new Vector3(1.0f, 1.0f, -1.0f));
            lista4.Add(new Vector3(-1.0f, 1.0f, -1.0f));
            lista4.Add(new Vector3(-1.0f, 1.0f, 1.0f));
            cara = new Cara();
            cara.addVertices(lista4);
            cara.addColor(1.0f, 0.0f, 0.0f);
            this.caras.Add(cara);

            List<Vector3> lista5 = new List<Vector3>();
            lista5.Add(new Vector3(1.0f, 1.0f, -1.0f));
            lista5.Add(new Vector3(1.0f, -1.0f, -1.0f));
            lista5.Add(new Vector3(-1.0f, -1.0f, -1.0f));
            lista5.Add(new Vector3(-1.0f, 1.0f, -1.0f));

            cara = new Cara();
            cara.addVertices(lista5);
            cara.addColor(0.0f, 1.0f, 0.0f);
            this.caras.Add(cara);

            List<Vector3> lista6 = new List<Vector3>();
            lista6.Add(new Vector3(1.0f, 1.0f, 1.0f));
            lista6.Add(new Vector3(1.0f, -1.0f, 1.0f));
            lista6.Add(new Vector3(-1.0f, -1.0f, 1.0f));
            lista6.Add(new Vector3(-1.0f, 1.0f, 1.0f));
            cara = new Cara();
            cara.addVertices(lista6);
            cara.addColor(0.0f, 0.0f, 1.0f);
            this.caras.Add(cara);

        }

        public void dibujar2()
        {
            addFaces();
            GL.Begin(PrimitiveType.Quads);
            foreach (var face in this.caras)
            {
                face.dibujar();
            }
            GL.End();
            GL.PopMatrix();
        }
    }
}
