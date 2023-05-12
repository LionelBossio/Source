using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    class TrapecioRectangulo
    {
        private readonly decimal altura;
        private readonly decimal baseMayor;
        private readonly decimal baseMenor;
        private readonly decimal ladoIzquierdo;
        private readonly decimal ladoDerecho;

        public TrapecioRectangulo(decimal altu, decimal bMayor, decimal Bmenor, decimal LIzq, decimal LDer)
        {
            this.altura = altu;
            this.baseMayor = bMayor;
            this.baseMenor = Bmenor;
            this.ladoIzquierdo = LIzq;
            this.ladoDerecho = LDer;
        }

        public decimal CalcularArea()
        {
            return ((this.baseMayor + this.baseMenor) / (decimal)2 ) * altura;
        }

        public decimal CalcularPerimetro()
        {
            return this.baseMayor + this.baseMenor + this.ladoIzquierdo + this.ladoDerecho;
        }
    }
}
