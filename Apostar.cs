using System;
using System.Collections.Generic;
using System.Text;

namespace JuegodeRuleta
{
    public class Apostar
    {
        public string Tipo { get; set; }
        public decimal Monto { get; set; }
        public string ValorApuesta { get; set; }

        public int Multiplicador { get; set; }
        public Apostar(string tipo, decimal monto, string valorapuesta ,int multiplicador) 
        { 
            Tipo = tipo;
            Monto = monto;
            ValorApuesta = valorapuesta;
            Multiplicador = multiplicador;
        }

        public bool Gano(Numero resultado)
        {
            switch (Tipo)
            {
                case "Numero":
                    return ValorApuesta == resultado.Valor.ToString();
                case "Color":
                    return ValorApuesta == resultado.Color;
                case "SiPar":
                    string paridadResultado = resultado.EsPar() ? "Par" : "Impar";
                    return ValorApuesta == paridadResultado;
                default:
                    return false;
            }
        }

        public override string ToString() 
        {
            return "Apuesta a" + Tipo + "(" + ValorApuesta + ") por $" + Monto;
        }
    }
}
