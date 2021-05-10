using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionParcialPalabras
{
    public class Oracion
    {
        /// <summary>
        /// Cadena de caracteres que representa el 
        /// texto de la oración.
        /// </summary>
        public string Texto { set; get; }

        /// <summary>
        /// Crea una oración  a partir de establecer la 
        /// propiedad Texto de la palabra a "Hola mundo"
        /// </summary>
        public Oracion()
        {
            Texto = "Hola mundo";
        }

        /// <summary>
        /// Crea una oración  a partir de 
        /// establecer la propiedad Texto de la palabra al 
        /// valor del parámetro.
        /// </summary>
        /// <param name="texto">
        /// Texto de la oración.
        /// </param>
        public Oracion(string texto)
        {
            Texto = texto;
        }

        /// <summary>
        /// Crea una oración  a partir de una colección 
        /// o listado  de palabras separadas por espacio.
        /// </summary>
        /// <param name="textos">
        /// Colección o listado  de palabras 
        /// separadas por espacio.
        /// </param>
        public Oracion(string[] textos)
        {
            Texto = string.Join(" ", textos);
        }

        /// <summary>
        /// Crea una oración  a partir de un array de objetos del tipo Palabra.
        /// </summary>
        /// <param name="palabras"></param>
        public Oracion(Palabra[] palabras)
        {
            Texto = string.Join(" ", palabras.Select(p => p.Texto));
        }

        /// <summary>
        /// Propiedad de solo lectura que retorna la colección de 
        /// palabras que forman la oración.
        /// </summary>
        public List<Palabra> Palabras
        {
            get
            {
                return Texto
                    .Split(' ')
                    .ToList()
                    .Select(p => new Palabra() { Texto = p })
                    .ToList();
            }
        }

        /// <summary>
        /// Busca las palabras que contengan el valor pasado como parámetro.
        /// </summary>
        /// <param name="textoABuscar">
        /// </param>
        /// <returns></returns>
        public List<Palabra> BuscarPalabras(string textoABuscar)
        {
            return Palabras
                .Where(p => p.Texto.Contains(textoABuscar))
                .ToList();
        }

        /// <summary>
        /// Busca las palabras que contengan el valor pasado como parámetro
        /// y las colorea.
        /// </summary>
        /// <param name="textoABuscar">        
        /// texto a buscar
        /// </param>
        /// <param name="colorDeLaPalabra">
        /// Color que debe poseer cada palabra de la lista retornada.
        /// </param>
        /// <returns></returns>
        public List<Palabra> BuscarPalabras(string textoABuscar, string colorDeLaPalabra)
        {
            List<Palabra> palabras = Palabras
                .Where(p => p.Texto.Contains(textoABuscar))
                .ToList();

            palabras
                .ForEach(p => p.Color = colorDeLaPalabra);

            return palabras;
        }

        /// <summary>
        /// Busca y reemplaza una palabra, de manera similar a un editor de texto.
        /// </summary>
        /// <param name="viejo">
        /// Texto de la palabra a buscar.
        /// </param>
        /// <param name="nuevo">
        /// Texto de la palabra a reemplazar.
        /// </param>
        public void Reemplazar(string viejo, string nuevo)
        {
            Texto = Texto.Replace(viejo, nuevo);
        }
    }
}
