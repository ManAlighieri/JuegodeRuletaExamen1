using System;
using System.Collections.Generic;
using System.Text;

namespace JuegodeRuleta
{
    public class Numero
    {
        public int Valor {  get; set; }
        public string Color { get; set; }
        public Numero(int valor, string color) 
        { 
            Valor = valor;
            Color = color;
        }

        public bool EsPar()
        {
            if (Valor == 0) return false;
            return Valor % 2 == 0;
        }
        public override string ToString()
        {
            return Valor + "(" + Color + ")";
        }
    }
}
