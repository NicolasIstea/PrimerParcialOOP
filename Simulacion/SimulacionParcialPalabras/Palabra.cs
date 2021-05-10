using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionParcialPalabras
{
    public class Palabra
    {
        public string Texto { set; get; }

        private string _color;
        /// <summary>
        /// SETTER
        /// La escritura (setter) de esta propiedad, debe lanzar una excepción del tipo 
        /// “System.Exception” en caso que el valor sea “blanco” o cualquiera de 
        /// sus variantes de mayúsculas y minúsculas, por ejemplo: “Blanco”, “BLANco”, etc.
        /// 
        /// 
        /// GETTER
        /// La lectura (getter) de esta propiedad, debe lanzar una excepción del tipo 
        /// “System.Exception” en caso que el valor sea “magenta” o cualquiera de 
        /// sus variantes de mayúsculas y minúsculas, por ejemplo: “magenTA”, “maGEnta”, etc.
        /// </summary>
        public string Color 
        {
            set 
            {
                if(value.Trim().ToUpper() == "BLANCO")
                {
                    throw new Exception();
                }

                _color = value;
            }
            get 
            {
                if(_color.Trim().ToUpper() == "MAGENTA")
                {
                    throw new Exception();
                }

                return _color;
            }
        }
    }
}
