using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    class Cuadrado
    {
        private readonly decimal ancho;

        public Cuadrado(decimal ancho_C)
        {
            this.ancho = ancho_C;
        }

        public decimal CalcularArea()
        {
            return this.ancho * this.ancho;
        }

        public decimal CalcularPerimetro()
        {
            return this.ancho * 4;
        }
    }
}
