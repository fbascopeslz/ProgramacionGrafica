using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramacionGrafica
{
    class Objeto
    {
        List<Cara> caras;
        String nombreArchivo;

        public Objeto()
        {
            this.caras = new List<Cara>();
        }

        public Objeto(String nombreObjeto)
        {
            this.caras = new List<Cara>();
            this.nombreArchivo = nombreObjeto;
        }

        public void rotar(int s)
        {
            
        }

        public void dibujar()
        {
            foreach (var face in this.caras)
            {
                face.dibujar();
            }
        }

        public void dibujar2()
        {
            
        }

    }
}
