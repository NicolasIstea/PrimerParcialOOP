using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationLibro
{
    /// <summary>
    /// Representación en objetos de un rengon.
    /// </summary>
    public class Renglon
    {
        public Renglon() { this.Texto = ""; }
        /// <summary>
        /// Texto contenido en el renglón.
        /// </summary>
        public string Texto { set; get; }
        /// <summary>
        /// Indica si el renglón se encuentra o no coloreado.
        /// </summary>
        public bool Coloreado { set; get; }
    }
}
