using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>()));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>()));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> { new FormaGeometrica(1, 5) };

            var resumen = FormaGeometrica.Imprimir(cuadrados);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            var cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica(1, 5),
                new FormaGeometrica(1, 1),
                new FormaGeometrica(1, 3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(1, 5),
                new FormaGeometrica(2, 3),
                new FormaGeometrica(3, 4),
                new FormaGeometrica(1, 2),
                new FormaGeometrica(3, 9),
                new FormaGeometrica(2, 2.75m),
                new FormaGeometrica(3, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(1, 5),
                new FormaGeometrica(2, 3),
                new FormaGeometrica(3, 4),
                new FormaGeometrica(1, 2),
                new FormaGeometrica(3, 9),
                new FormaGeometrica(2, 2.75m),
                new FormaGeometrica(3, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("it");
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(1, 5),
                new FormaGeometrica(2, 3),
                new FormaGeometrica(3, 4),
                new FormaGeometrica(1, 2),
                new FormaGeometrica(3, 9),
                new FormaGeometrica(2, 2.75m),
                new FormaGeometrica(3, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Rapporto moduli</h1>2 Piazze | La zona 29 | Perimetro 28 <br/>2 cerchi | La zona 13,01 | Perimetro 18,06 <br/>3 triangoli | La zona 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 forme Perimetro 97,66 La zona 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConTrapecioRectangulo()
        {
            
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(4,7,5,3,6,9)
            };

            var resumen = FormaGeometrica.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>1 Trapecio Rectángulo | Area 28 | Perimetro 23 <br/>TOTAL:<br/>1 formas Perimetro 23 Area 28",
                resumen);
        }
    }
}
