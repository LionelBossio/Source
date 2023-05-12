/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using DevelopmentChallenge.Data.Classes.Formas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        #region Formas

        private Cuadrado cuadrado;
        private Circulo circulo;
        private TrianguloEquilatero triangulo;
        private TrapecioRectangulo trapecioRec;
        /*public const int Trapecio = 4;*/

        #endregion

        private readonly decimal _lado;
        private readonly decimal altura;
        private readonly decimal baseMayor;
        private readonly decimal baseMenor;
        private readonly decimal ladoIzquierdo;
        private readonly decimal ladoDerecho;

        

        public int Tipo { get; set; }

        public FormaGeometrica(int tipo, decimal ancho)
        {
            Tipo = tipo;
            _lado = ancho;
        }

        public FormaGeometrica(int tipo,decimal altu, decimal bMayor, decimal Bmenor, decimal LIzq, decimal LDer)
        {
            Tipo = tipo;
            this.altura = altu;
            this.baseMayor = bMayor;
            this.baseMenor = Bmenor;
            this.ladoIzquierdo = LIzq;
            this.ladoDerecho = LDer;
        }

        public static string Imprimir(List<FormaGeometrica> formas)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append(Resources.Idioma.ListaVacia);
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append(Resources.Idioma.PorLoMenosUna);

                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;
                var numeroTrapecioRec = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;
                var areaTrapecioRec = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;
                var perimetroTrapecioRec = 0m;


                for (var i = 0; i < formas.Count; i++)
                {
                    if (formas[i].Tipo == 1)
                    {
                        formas[i].cuadrado = new Cuadrado(formas[i]._lado);
                        numeroCuadrados++;
                        areaCuadrados += formas[i].cuadrado .CalcularArea();
                        perimetroCuadrados += formas[i].cuadrado.CalcularPerimetro();
                    }
                    if (formas[i].Tipo == 2)
                    {
                        formas[i].circulo = new Circulo(formas[i]._lado);
                        numeroCirculos++;
                        areaCirculos += formas[i].circulo.CalcularArea();
                        perimetroCirculos += formas[i].circulo.CalcularPerimetro();
                    }
                    if (formas[i].Tipo == 3)
                    {
                        formas[i].triangulo = new TrianguloEquilatero(formas[i]._lado);
                        numeroTriangulos++;
                        areaTriangulos += formas[i].triangulo.CalcularArea();
                        perimetroTriangulos += formas[i].triangulo.CalcularPerimetro();
                    }
                    if (formas[i].Tipo == 4)
                    {
                        formas[i].trapecioRec = new TrapecioRectangulo(formas[i].altura, formas[i].baseMayor, formas[i].baseMenor, formas[i].ladoIzquierdo, formas[i].ladoDerecho);
                        numeroTrapecioRec++;
                        areaTrapecioRec += formas[i].trapecioRec.CalcularArea();
                        perimetroTrapecioRec += formas[i].trapecioRec.CalcularPerimetro();
                    }
                }


                sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, 1));
                sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, 2));
                sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, 3));
                sb.Append(ObtenerLinea(numeroTrapecioRec, areaTrapecioRec, perimetroTrapecioRec, 4));

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + numeroTrapecioRec + " " + Resources.Idioma.formas + " ");
                sb.Append((Resources.Idioma.Perimetro) + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos + perimetroTrapecioRec).ToString("#.##") + " ");
                sb.Append(Resources.Idioma.Area + (areaCuadrados + areaCirculos + areaTriangulos + areaTrapecioRec).ToString("#.##"));
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo)
        {
            var sba = new StringBuilder();
            if (cantidad > 0)
            {
                sba.Append(cantidad + " " + TraducirForma(tipo, cantidad) + Resources.Idioma.ObtenerLineaArea).AppendFormat("{0:#.##}", area).Append(Resources.Idioma.ObtenerLineaPerimetro).AppendFormat("{0:#.##}", perimetro).Append(" <br/>");
            }
            return sba.ToString();
        }

        private static string TraducirForma(int tipo, int cantidad)
        {
            switch (tipo)
            {
                case 1:
                    return cantidad == 1 ? Resources.Idioma.Cuadrado : Resources.Idioma.Cuadrados;
                case 2:
                    return cantidad == 1 ? Resources.Idioma.Círculo : Resources.Idioma.Círculos;
                case 3:
                    return cantidad == 1 ? Resources.Idioma.Triángulo : Resources.Idioma.Triángulos;
                case 4:
                    return cantidad == 1 ? Resources.Idioma.Trapecio_Rectángulo : Resources.Idioma.Trapecios_Rentángulos;
            }
            return string.Empty;
        }
    }
}
