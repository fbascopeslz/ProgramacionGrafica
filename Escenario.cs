using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramacionGrafica
{
    class Escenario
    {        
        public Dictionary<string, Objeto> objetos;

        public Escenario(Dictionary<string, Objeto>  objetos)
        {
            this.objetos = objetos;
        }

        public Escenario()
        {
            this.objetos = new Dictionary<string, Objeto>();
        }

        public Dictionary<string, Objeto> getObjetos()
        {
            return this.objetos;
        }

        public void setObjetos(Dictionary<string, Objeto> objetos)
        {
            this.objetos = objetos;
        }

        public void agregarObjeto(string nombre, Objeto objeto)
        {
            this.objetos.Add(nombre, objeto);
        }

        public void eliminarObjeto(string nombre)
        {
            this.objetos.Remove(nombre);
        }
        
        public void dibujar()
        {
            foreach (KeyValuePair<string, Objeto> objeto in objetos)
            {
                objeto.Value.dibujar();
            }
        }

    }
}
