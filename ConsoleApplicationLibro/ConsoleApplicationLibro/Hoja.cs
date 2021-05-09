using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationLibro
{
    /// <summary>
    /// Representación en objetos de una hoja.
    /// </summary>
    public class Hoja
    {
        public Hoja() { }

        public Hoja(int numero)
        {
            this.Numero = numero;
            //Genera 20 renglones a la hoja.
            for (int nroRenglon = 0; nroRenglon < 20; nroRenglon++)
            {
                this.Renglones.Add(new Renglon());
            }
        }

        /// <summary>
        /// Numero de hoja.
        /// </summary>
        public int Numero { set; get; }

        /// <summary>
        /// Renglones que componen la hoja.
        /// </summary>
        public List<Renglon> Renglones = new List<Renglon>();
    }
}
