using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    class Circulo
    {
        private readonly decimal ancho;

        public Circulo(decimal ancho_C)
        {
            this.ancho = ancho_C;
        }

        public decimal CalcularArea()
        {
            return (decimal)Math.PI * (this.ancho / 2) * (this.ancho / 2);
        }

        public decimal CalcularPerimetro()
        {
            return ((decimal)Math.PI * this.ancho);
        }
    }
}

