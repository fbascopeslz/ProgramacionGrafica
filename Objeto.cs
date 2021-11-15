using OpenTK;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramacionGrafica
{
    class Objeto
    {        
        public List<Cara> caras;
        public Vector3 centro;
        public string nombre;

        public Objeto()
        {
            this.caras = new List<Cara>();
            this.centro = new Vector3(0f, 0f, 0f);
            this.nombre = "";
        }

        public Objeto(List<Cara> caras, Vector3 centro, string nombre)
        {
            this.caras = caras;
            this.centro = centro;
            this.nombre = nombre;
        }

        public List<Cara> getCaras()
        {
            return this.caras;
        }

        public void setCaras(List<Cara> caras)
        {
            this.caras = caras;
        }

        public Vector3 getCentro()
        {
            return this.centro;
        }

        public void setCentro(Vector3 centro)
        {
            this.centro = centro;
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public void agregarCara(Cara cara)
        {
            this.caras.Add(cara);
        }

        public void eliminarCara(int posicion)
        {
            this.caras.RemoveAt(posicion);
        }

        public void dibujar()
        {
            foreach (Cara cara in this.caras)
            {
                cara.dibujar();
            }
        }

    }
}
