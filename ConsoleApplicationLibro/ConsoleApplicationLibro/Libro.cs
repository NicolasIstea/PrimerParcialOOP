/**********************************************************************************
 * Apellido, nombre: Mendez, Nicolàs
 **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationLibro
{
    /// <summary>
    /// Representación en objetos de un libro.
    /// </summary>
    public class Libro
    {
        public Libro()
        {
            this.Hojas = new List<Hoja>();
            //Genera las 10 hojas del libro.
            for (int numero = 0; numero < 10; numero++)
            {
                this.Hojas.Add(new Hoja(numero));
            }
        }

        private string _Titulo;

        /// <summary>
        /// Titulo del libro.
        /// </summary>
        /// <remarks>
        /// set: 
        /// El título del libro no puede tomar un valor nulo ni vacío, 
        /// entiéndase vacío como un string del largo cero.
        /// En caso de no cumplir con la validación solicitada 
        /// debe lanzarse una excepción “throw new Exception()”.
        /// 
        /// get: 
        /// La lectura de la propiedad debe ser libre.
        /// </remarks>
        public string Titulo
        {
            set
            {
                if (value != null && value.Length != 0)
                {
                    _Titulo = value;
                }
                else
                {
                    throw new Exception();
                }
            }

            get
            {
                return _Titulo;
            }
        }

        /// <summary>
        /// Hojas del libro.
        /// </summary>
        public List<Hoja> Hojas { set; get; }

        /// <summary>
        /// Invierte el orden de las hojas del libro.
        /// </summary>
        /// <remarks>
        /// Luego de la inversión, la que era la ultima hoja del libro 
        /// pasara a ser la primera y la que era la primera pasara a 
        /// ser la última. Y del mismo modo con el resto de las hojas 
        /// que componen el libro.
        ///     1) La propiedad “Hoja.Numero” debe ser alterada luego de la inversión, 
        ///        indicando su correcta posición. Por ejemplo: Si la hoja numero 5 
        ///        paso a ser la 1 después del proceso de inversión, su nuevo número 
        ///        de hoja debe ser 1 y no 5.        
        /// </remarks>
        /// <returns>
        /// La lista de hojas con el orden invertido.
        /// </returns>
        public List<Hoja> InvertirOrdenHojas()
        {
            List<Hoja> hojasInvertidas = new List<Hoja>();

            int newHojaNumero = 0;
            for (int i = Hojas.Count - 1; i >= 0; i--)
            {
                var hoja = Hojas[i];
                hoja.Numero = newHojaNumero;
                hojasInvertidas.Add(hoja);

                newHojaNumero++;
            }

            return hojasInvertidas;
        }

        /// <summary>
        /// Busca aquellas hojas que contengan el texto indicado 
        /// y colorea los renglones que contienen el texto.
        /// </summary>
        /// <param name="buscado">
        /// Texto a buscar.
        /// </param>       
        /// <param name="colorear">
        /// Indica si desea colorear el renglón que contiene el texto encontrado.
        /// </param>
        /// <remarks>
        /// Si el parámetro vale nulo (null) el método debe 
        /// retornar un una lista con cero ítems.
        /// </remarks>
        /// <returns>
        /// Lista de hojas que contienen el texto buscado, en caso de 
        /// no encontrarlo debe retornar una lista con cero ítems, 
        /// nunca retorna null.
        /// </returns>
        public List<Hoja> Buscar(string buscado, bool colorear)
        {
            List<Hoja> hojas = new List<Hoja>();
            if (buscado != null)
            {
                foreach (var hoja in Hojas)
                {
                    bool adherirHoja = false;
                    foreach (var renglon in hoja.Renglones)
                    {
                        if (renglon.Texto.Contains(buscado))
                        {
                            if (colorear)
                            {
                                renglon.Coloreado = colorear;
                            }

                            adherirHoja = true;
                        }
                    }

                    if (adherirHoja)
                    {
                        hojas.Add(hoja);
                    }
                }
            }

            return hojas;
        }

        /// <summary>
        /// Busca aquellas hojas del libro que contengan el texto indicado
        /// sin colorearlas, esto es colorear = false.
        /// </summary>
        /// <param name="buscado">
        /// Texto a buscar.
        /// </param>
        /// <remarks>
        /// Si el parámetro vale nulo (null) el método debe 
        /// retornar un una lista con cero ítems.
        /// </remarks>
        /// <returns>
        /// Lista de hojas que contienen el texto buscado, en caso de 
        /// no encontrarlo debe retornar una lista con cero ítems, 
        /// nunca retorna null.
        /// </returns>
        public List<Hoja> Buscar(string buscado)
        {
            return Buscar(buscado, false);
        }

        /// <summary>
        /// Reemplaza un texto por otro en cada una de las hojas del libro.
        /// </summary>
        /// <param name="buscado">
        /// Texto a buscar.
        /// </param>
        /// <param name="reemplazo">
        /// Texto de reemplazo.
        /// </param>
        /// <returns>
        /// Lista de hojas que contienen el texto buscado. 
        /// En caso de no encontrarlo debe retornar una lista con cero ítems, 
        /// nunca retorna null.
        /// Si alguno de los parámetros es nulo debe retornar una lista con cero ítems.
        /// </returns>
        public List<Hoja> Reemplazar(string buscado, string reemplazo)
        {
            List<Hoja> hojas = new List<Hoja>();
            if (buscado != null && reemplazo != null)
            {
                foreach (var hoja in Hojas)
                {
                    bool encontrado = false;
                    foreach (var renglon in hoja.Renglones)
                    {
                        if (renglon.Texto.Contains(buscado))
                        {
                            encontrado = true;
                            renglon.Texto = renglon.Texto.Replace(buscado, reemplazo);
                        }
                    }

                    if (encontrado)
                    {
                        hojas.Add(hoja);
                    }

                }
            }

            return hojas;
        }

        /// <summary>
        /// Retorna las hojas del libro que posea la mayor cantidad de renglones.
        /// </summary>
        /// <example>
        /// Si las hojas 2 y 6 contienen 100 renglones y el resto 90 renglones, 
        /// el método debe retornar una lista con dos hojas, la 2 y la 6.
        /// </example>
        /// <returns></returns>
        public List<Hoja> TraerHojasConMasRenglones()
        {
            List<Hoja> hojas = new List<Hoja>();

            int indiceMax = Hojas.Count - 1;

            for (int i = Hojas.Count - 1; i >= 0; i--)
            {
                if (Hojas[indiceMax].Renglones.Count <= Hojas[i].Renglones.Count)
                {
                    hojas.Add(Hojas[i]);
                }
            }

            return hojas;
        }

        /// <summary>
        /// Elimina las hojas que están repetidas.
        /// Dos hojas están repetidas cunado poseen el mismo número de hoja,
        /// en otras palabras elimina las copias y deja la original.
        /// Por ejemplo si hay 3 hojas repartidas solo deja una, 
        /// eliminando las 2 copias.
        /// </summary>
        /// <returns>
        /// Retorna la lista de hojas que fueron eliminadas. 
        /// En caso de no encontrar hojas repetidas, debe retornar una lista con cero ítems, 
        /// nunca retorna null.
        /// </returns>
        public List<Hoja> EliminarHojasRepetidas()
        {
            List<Hoja> hojasUnicas = new List<Hoja>();

            for (int i = Hojas.Count - 1; i >= 0; i--)
            {
                bool estaRepetido = false;
                foreach (var hoja in hojasUnicas)
                {
                    if (Hojas[i].Numero == hoja.Numero)
                        estaRepetido = true;
                }

                if (!estaRepetido)
                {
                    hojasUnicas.Add(Hojas[i]);
                }
                    
            }

            List<Hoja> hojasBorradas = Hojas.Except(hojasUnicas).ToList();
            Hojas = new List<Hoja>();
            Hojas.AddRange(hojasUnicas);

            return hojasBorradas;
        }
    }
}
