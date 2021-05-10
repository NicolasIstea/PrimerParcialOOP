using System;
using SimulacionParcialPalabras;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNewOracion()
        {
            //Arrange
            Oracion oracion = null;
            //Act
            oracion = new Oracion();
            //Assert            
            Assert.AreEqual("Hola mundo", oracion.Texto);
        }

        [TestMethod]
        public void TestNewOracion1()
        {
            //Arrange
            Oracion oracion = null;
            //Act
            oracion = new Oracion("Soy un hombre honrado");
            //Assert            
            Assert.AreEqual("Soy un hombre honrado", oracion.Texto);
        }

        [TestMethod]
        public void TestNewOracion2()
        {
            //Arrange
            Oracion oracion = null;
            //Act
            oracion = new Oracion(new string[] { "Argentina", "un","país", "al", "margen", "de", "la", "ley"});
            //Assert            
            Assert.AreEqual("Argentina un país al margen de la ley", oracion.Texto);
        }

        [TestMethod]
        public void TestNewOracion3()
        {
            //Arrange
            Oracion oracion = null;
            //Act
            oracion = new Oracion(
                new Palabra[]
                {
                    new Palabra() { Texto= "Poso" },
                    new Palabra() { Texto= "de" },
                    new Palabra() { Texto= "sombras" }
                }                           
            );
            //Assert            
            Assert.AreEqual("Poso de sombras", oracion.Texto);
        }

        [TestMethod]
        public void TestGetPalabras()
        {
            //Arrange
            Oracion oracion = null;
            //Act
            oracion = new Oracion("Cualquiera es un ladrón");
            //Assert            
            Assert.AreEqual("Cualquiera", oracion.Palabras[0].Texto);
            Assert.AreEqual("es", oracion.Palabras[1].Texto);
            Assert.AreEqual("un", oracion.Palabras[2].Texto);
            Assert.AreEqual("ladrón", oracion.Palabras[3].Texto);
        }

        [TestMethod]
        public void TestBuscarPalabras_0()
        {
            //Arrange
            Oracion oracion = new Oracion ("Paso de sombras la noche.");
            //Act
            List<Palabra> palabrasEncontradas =
                oracion.BuscarPalabras("o");
            //Assert            
            Assert.AreEqual(3,palabrasEncontradas.Count);            
        }

        [TestMethod]
        public void TestBuscarPalabras_1()
        {
            //Arrange
            Oracion oracion = new Oracion("Parece un poso de sombras la noche.");
            //Act
            List<Palabra> palabrasEncontradas =
                oracion.BuscarPalabras("so", "rojo");
            //Assert            
            Assert.AreEqual(2, palabrasEncontradas.Count);
            Assert.AreEqual("rojo", palabrasEncontradas[0].Color);
            Assert.AreEqual("rojo", palabrasEncontradas[1].Color);
        }

        [TestMethod]
        public void TestReemplazar()
        {
            //Arrange
            Oracion oracion = new Oracion();
            oracion.Texto = "pin 1 pin 2 pin 3 FIN";
            //Act           
            oracion.Reemplazar("pin", "paso");
            //Assert            
            Assert.AreEqual("paso 1 paso 2 paso 3 FIN", oracion.Texto);
        }

        [ExpectedException(typeof(Exception), "El color no puede ser Blanco.")]
        [TestMethod]
        public void TestSetPalabraColorBlanco()
        {
            //Arrange
            Palabra palabra = new Palabra();
            //Act           
            palabra.Color = "BlaNco"; //Se espera un Exception
            //Assert                        
        }

        [ExpectedException(typeof(Exception), "El color no puede ser Magenta.")]
        [TestMethod]
        public void TestGetPalabraColorMagenta()
        {
            //Arrange
            Palabra palabra = new Palabra();
            palabra.Color = "magenTA";
            //Act           
            string color = palabra.Color; //Se espera un Exception
            //Assert                        
        }

        [TestMethod]
        public void TestGetPalabraColorRojo()
        {
            //Arrange
            Palabra palabra = new Palabra();
            palabra.Color = "Rojo";
            //Act           
            string color = palabra.Color;
            //Assert                     
            Assert.AreEqual("Rojo", color);
        }

    }
}
