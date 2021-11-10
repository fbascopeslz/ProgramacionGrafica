using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramacionGrafica
{
    class Escenario
    {
        List<Cubo> objetos;
        public Escenario()
        {
            objetos = new List<Cubo>();
        }

        public void addObjeto(Cubo objeto)
        {
            objetos.Add(objeto);
        }

        public List<Cubo> getObjetos()
        {
            return this.objetos;
        }

        public void dibujar()
        {
            foreach (Cubo objeto in objetos)
            {
                objeto.dibujar2();
            }
        }

    }
}
