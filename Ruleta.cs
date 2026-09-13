using System;
using System.Collections.Generic;
using System.Text;

namespace JuegodeRuleta
{
    internal class Ruleta
    {
        private List<Numero> casillas = new List<Numero>();
        private Random random = new Random();

        public Ruleta()
        {
            int[] rojos = [1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36];

            casillas.Add(new Numero(0, "Verda"));

            for (int i = 1; i < rojos.Length; i++)
            {
                string color = rojos.Contains(i) ? "Rojo" : "Negro ";
                casillas.Add(new Numero(i, color));
            }
        }
        public Numero Girar()
        {
            int indice = random.Next(0, casillas.Count);
            return casillas[indice];
        }
    }
}
