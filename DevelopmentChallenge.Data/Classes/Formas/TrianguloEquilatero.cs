using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    class TrianguloEquilatero
    {
        private readonly decimal ancho;

        public TrianguloEquilatero(decimal ancho_T)
        {
            this.ancho = ancho_T;
        }

        public decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * this.ancho * this.ancho;
        }

        public decimal CalcularPerimetro()
        {
            return this.ancho * 3;
        }
    }
}
