using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplicationLibro;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectLibro
{
    [TestClass]
    public class UnitTest1
    {
        private static Libro _Libro;

        [TestInitialize()]
        public void Initialize()
        {
            _Libro = new Libro();
            _Libro.Hojas = new List<Hoja>();
            //Genera las 10 hojas iniciales del libro.
            for (int numero = 0; numero < 10; numero++)
            {
                _Libro.Hojas.Add(new Hoja(numero));
            }        
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Set_Titulo_1()
        {
            //Arrange
            Libro libro = new Libro();
            //Act
            libro.Titulo = "";
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Set_Titulo_2()
        {
            //Arrange
            Libro libro = new Libro();
            //Act
            libro.Titulo = null;
            //Assert
        }

        [TestMethod]       
        public void Get_Titulo()
        {
            //Arrange
            string titulo = "la guerra de los yacares" + Guid.NewGuid().ToString();
            Libro libro = new Libro();
            libro.Titulo = titulo;
            //Act
            string librotLitulo = libro.Titulo; //Comprueba la lectura de la propiedad.
            //Assert
            Assert.AreEqual(titulo, librotLitulo);
        }

        [TestMethod]
        public void TraerHojaConMasRenglones_0()
        {
            foreach (Hoja hoja in _Libro.Hojas)
            {
                hoja.Renglones.Clear();
            }

            _Libro.Hojas[5].Renglones.Add(new Renglon());
            _Libro.Hojas[5].Renglones.Add(new Renglon());
            _Libro.Hojas[5].Renglones.Add(new Renglon());
            _Libro.Hojas[5].Renglones.Add(new Renglon());
            _Libro.Hojas[5].Renglones.Add(new Renglon());

            _Libro.Hojas[9].Renglones.Add(new Renglon());
            _Libro.Hojas[9].Renglones.Add(new Renglon());
            _Libro.Hojas[9].Renglones.Add(new Renglon());
            _Libro.Hojas[9].Renglones.Add(new Renglon());
            _Libro.Hojas[9].Renglones.Add(new Renglon());
           
            List<Hoja> hojasConMaxRenglones = _Libro.TraerHojasConMasRenglones();

            Assert.AreEqual(2, hojasConMaxRenglones.Count);
            Assert.AreEqual(2, hojasConMaxRenglones.Where(h => h.Numero == 5 || h.Numero == 9).ToList().Count);
        }

        [TestMethod]
        public void TraerHojaConMasRenglones_1()
        {
            _Libro.Hojas[9].Renglones.Add(new Renglon());

            List<Hoja> hojasConMaxRenglones = _Libro.TraerHojasConMasRenglones();

            Assert.AreEqual(1, hojasConMaxRenglones.Count);
            Assert.AreEqual(9, hojasConMaxRenglones[0].Numero);
            Assert.AreEqual(21, hojasConMaxRenglones[0].Renglones.Count);
        }

        [TestMethod]
        public void EliminarHojasRepetidas_0()
        {
            _Libro.Hojas.Add(new Hoja(9));
            _Libro.Hojas.Add(new Hoja(9));
            _Libro.Hojas.Add(new Hoja(9));

            List<Hoja> hojas = _Libro.EliminarHojasRepetidas();

            Assert.AreEqual(3, hojas.Count);
            Assert.AreEqual(10, _Libro.Hojas.Count);
        }
        
        [TestMethod]
        public void EliminarHojasRepetidas_1()
        {
            _Libro.Hojas.Clear();
            _Libro.Hojas.Add(new Hoja(0));
            _Libro.Hojas.Add(new Hoja(2));
            _Libro.Hojas.Add(new Hoja(2));  //Se debe eliminar
            _Libro.Hojas.Add(new Hoja(2));  //Se debe eliminar
            _Libro.Hojas.Add(new Hoja(1));
            _Libro.Hojas.Add(new Hoja(1));  //Se debe eliminar
            _Libro.Hojas.Add(new Hoja(2));  //Se debe eliminar

            List<Hoja> hojasEliminadas = _Libro.EliminarHojasRepetidas();
            Assert.AreEqual(4, hojasEliminadas.Count);
            Assert.AreEqual(3, _Libro.Hojas.Count);

            #region Sumatoria número de hojas originales.
            int suma = 0;
            foreach (Hoja hoja in _Libro.Hojas)
            {
                suma += hoja.Numero;
            }

            Assert.AreEqual(3, suma);
            #endregion

            #region Sumatoria número de hojas eliminadas.
            int sumaEliminadas = 0;
            foreach (Hoja hoja in hojasEliminadas)
            {
                sumaEliminadas += hoja.Numero;
            }

            Assert.AreEqual(7, sumaEliminadas);
            #endregion
        }

        [TestMethod]
        public void EliminarHojasRepetidas_2()
        {
            _Libro.Hojas.Clear();
            _Libro.Hojas.Add(new Hoja(0));            
            _Libro.Hojas.Add(new Hoja(1));
            _Libro.Hojas.Add(new Hoja(2));

            List<Hoja> hojasEliminadas = _Libro.EliminarHojasRepetidas();
            Assert.AreEqual(0, hojasEliminadas.Count);
            Assert.AreEqual(3, _Libro.Hojas.Count);

            #region Sumatoria número de hojas originales.
            int suma = 0;
            foreach (Hoja hoja in _Libro.Hojas)
            {
                suma += hoja.Numero;
            }

            Assert.AreEqual(3, suma);
            #endregion
        }

        [TestMethod]
        public void Reemplazar_0()
        {
            Hoja hojaConTexto = _Libro.Hojas[9];

            hojaConTexto.Renglones[0].Texto = "Si fui yo y no me arrepiento.";
            hojaConTexto.Renglones[1].Texto = "arrepiento";
            hojaConTexto.Renglones[2].Texto = "no arrepiento";

            List<Hoja> hojas = _Libro.Reemplazar("arrepiento", "asusta");

            Assert.AreEqual(1, hojas.Count);
            Assert.AreEqual("Si fui yo y no me asusta.", hojaConTexto.Renglones[0].Texto);
            Assert.AreEqual("asusta", hojaConTexto.Renglones[1].Texto);
            Assert.AreEqual("no asusta", hojaConTexto.Renglones[2].Texto);
        }
      
        [TestMethod]
        public void Reemplazar_1()
        {           
            List<Hoja> hojas = _Libro.Reemplazar(null, "asusta");

            Assert.AreEqual(0, hojas.Count);            
        }

        [TestMethod]
        public void Reemplazar_2()
        {
            List<Hoja> hojas = _Libro.Reemplazar("", null);

            Assert.AreEqual(0, hojas.Count);
        }

        [TestMethod]
        public void Reemplazar_3()
        {
            List<Hoja> hojas = _Libro.Reemplazar(null, null);

            Assert.AreEqual(0, hojas.Count);
        }

        [TestMethod]
        public void Buscar_0()
        {
            const int nroHoja_1 = 3;
            const int nroHoja_2 = 5;

            _Libro.Hojas[nroHoja_1].Renglones[5].Texto = "en la casa de pinocho";
            _Libro.Hojas[nroHoja_1].Renglones[6].Texto = "pinocho";
            _Libro.Hojas[nroHoja_1].Renglones[7].Texto = "su fue pinocho";

            _Libro.Hojas[nroHoja_2].Renglones[8].Texto = "su fue pinocho";

            List<Hoja> hojas =_Libro.Buscar("pinocho");

            Assert.AreEqual(2, hojas.Count);
            Assert.AreEqual(nroHoja_1, hojas[0].Numero);
            Assert.AreEqual(nroHoja_2, hojas[1].Numero);

            #region Comprobación de NO coloreo
            Assert.AreEqual(false, hojas[0].Renglones[5].Coloreado);
            Assert.AreEqual(false, hojas[0].Renglones[6].Coloreado);
            Assert.AreEqual(false, hojas[0].Renglones[7].Coloreado);

            Assert.AreEqual(false, hojas[1].Renglones[8].Coloreado);
            #endregion
        }

        [TestMethod]
        public void Buscar_1()
        {
            
            List<Hoja> hojas = _Libro.Buscar(null);

            Assert.AreEqual(0, hojas.Count);            
        }
       
        [TestMethod]
        public void Buscar_y_colorear_0()
        {
            const int nroHoja_1 = 3;
            const int nroHoja_2 = 5;

            _Libro.Hojas[nroHoja_1].Renglones[5].Texto = "en la casa de pinocho";
            _Libro.Hojas[nroHoja_1].Renglones[6].Texto = "pinocho";
            _Libro.Hojas[nroHoja_1].Renglones[7].Texto = "su fue pinocho";

            _Libro.Hojas[nroHoja_2].Renglones[8].Texto = "su fue pinocho";

            List<Hoja> hojas = _Libro.Buscar("pinocho", true);

            Assert.AreEqual(2, hojas.Count);
            Assert.AreEqual(nroHoja_1, hojas[0].Numero);
            Assert.AreEqual(nroHoja_2, hojas[1].Numero);

            #region Comprobación de coloreo
            Assert.AreEqual(false, hojas[0].Renglones[4].Coloreado);
            Assert.AreEqual(true, hojas[0].Renglones[5].Coloreado);
            Assert.AreEqual(true, hojas[0].Renglones[6].Coloreado);
            Assert.AreEqual(true, hojas[0].Renglones[7].Coloreado);
            Assert.AreEqual(false, hojas[0].Renglones[8].Coloreado);

            Assert.AreEqual(true, hojas[1].Renglones[8].Coloreado);
            #endregion
        }

        [TestMethod]
        public void Buscar_y_colorear_1()
        {
            List<Hoja> hojas = _Libro.Buscar(null, true);

            Assert.AreEqual(0, hojas.Count);            
        }

        [TestMethod]
        public void InvertirOrdenHojas_0()
        {
            //Arrange (Preparar)
            int ultimoIndex = _Libro.Hojas.Count - 1;
            int anteUltimoIndex = ultimoIndex - 1;

            _Libro.Hojas[0].Renglones[0]= (
                new Renglon() { Texto = "Sadosky" });
            _Libro.Hojas[1].Renglones[0] = (
                new Renglon() { Texto = "Fvavaloro" });

            _Libro.Hojas[anteUltimoIndex].Renglones[0] = (
                new Renglon() { Texto = "Balseiro" });
            _Libro.Hojas[ultimoIndex].Renglones[0] = (
                new Renglon() { Texto = "Sabato" });

            //Act (Actuar)
            List<Hoja> hojasOrdenInvertido = 
                _Libro.InvertirOrdenHojas();
            
            //Assert (Afirmar)
            Assert.AreEqual("Sabato", 
                hojasOrdenInvertido[0].Renglones[0].Texto);

            Assert.AreEqual("Balseiro",
                hojasOrdenInvertido[1].Renglones[0].Texto);

            Assert.AreEqual("Fvavaloro",
                hojasOrdenInvertido[anteUltimoIndex].Renglones[0].Texto);

            Assert.AreEqual("Sadosky",
                hojasOrdenInvertido[ultimoIndex].Renglones[0].Texto);

            Assert.AreEqual(10, hojasOrdenInvertido.Count);
        }

        [TestMethod]
        public void InvertirOrdenHojas_1()
        {
            //Arrange (Preparar)
            int ultimoIndex = _Libro.Hojas.Count - 1;
            int anteUltimoIndex = ultimoIndex - 1;

            _Libro.Hojas[0].Renglones[0] = (
                new Renglon() { Texto = "Sadosky" });
            _Libro.Hojas[1].Renglones[0] = (
                new Renglon() { Texto = "Fvavaloro" });

            _Libro.Hojas[anteUltimoIndex].Renglones[0] = (
                new Renglon() { Texto = "Balseiro" });
            _Libro.Hojas[ultimoIndex].Renglones[0] = (
                new Renglon() { Texto = "Sabato" });

            //Act (Actuar)
            List<Hoja> hojasOrdenInvertido =
                _Libro.InvertirOrdenHojas();

            //Assert (Afirmar)
            Hoja hojaPrimera    = hojasOrdenInvertido.First(h => h.Renglones.Any(r => r.Texto == "Sabato"));
            Hoja hojaSegunda    = hojasOrdenInvertido.First(h => h.Renglones.Any(r => r.Texto == "Balseiro"));
            Hoja hojaAnteUltima = hojasOrdenInvertido.First(h => h.Renglones.Any(r => r.Texto == "Fvavaloro"));
            Hoja hojaUltima     = hojasOrdenInvertido.First(h => h.Renglones.Any(r => r.Texto == "Sadosky"));

            Assert.AreEqual(0, hojaPrimera.Numero);
            Assert.AreEqual(1, hojaSegunda.Numero);
            Assert.AreEqual(anteUltimoIndex, hojaAnteUltima.Numero);
            Assert.AreEqual(ultimoIndex, hojaUltima.Numero);

            Assert.AreEqual(10, hojasOrdenInvertido.Count);
        }

        [TestMethod]
        public void InvertirOrdenHojas_2()
        {
            //Arrange (Preparar)
            List<string> textos = new List<string>();
            textos.Add(Guid.NewGuid().ToString());
            textos.Add(Guid.NewGuid().ToString());
            textos.Add(Guid.NewGuid().ToString());
            textos.Add(Guid.NewGuid().ToString());

            int ultimoIndex = _Libro.Hojas.Count - 1;
            int anteUltimoIndex = ultimoIndex - 1;

            _Libro.Hojas[0].Renglones[0] = (
                new Renglon() { Texto = textos[0] });
            _Libro.Hojas[1].Renglones[0] = (
                new Renglon() { Texto = textos[1] });

            _Libro.Hojas[anteUltimoIndex].Renglones[0] = (
                new Renglon() { Texto = textos[2] });
            _Libro.Hojas[ultimoIndex].Renglones[0] = (
                new Renglon() { Texto = textos[3] });

            //Act (Actuar)
            List<Hoja> hojasOrdenInvertido =
                _Libro.InvertirOrdenHojas();

            //Assert (Afirmar)
            Assert.AreEqual(textos[3],
                hojasOrdenInvertido[0].Renglones[0].Texto);

            Assert.AreEqual(textos[2],
                hojasOrdenInvertido[1].Renglones[0].Texto);

            Assert.AreEqual(textos[1],
                hojasOrdenInvertido[anteUltimoIndex].Renglones[0].Texto);

            Assert.AreEqual(textos[0],
                hojasOrdenInvertido[ultimoIndex].Renglones[0].Texto);            
        }
    }
}
