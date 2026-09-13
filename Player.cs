using System;
using System.Collections.Generic;
using System.Text;

namespace JuegodeRuleta
{
    public class Player
    {
        public string Nombre {  get; set; }
        public decimal Saldo { get; set; }
        public decimal SaldoIni { get; set; }
        public List<string> Historial { get; set; } = new List<string>();

        public Player(string nombre, decimal saldoini)
        {
            Nombre = nombre;
            Saldo = saldoini;
            SaldoIni = saldoini;
        }

        public List<string> BuscarHistorial(string texto)
        {
            return Historial.Where(linea => linea.Contains(texto, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        
        public void MostrarHistorial()
        {
            if (Historial.Count == 0)
            {
                Console.WriteLine("No hay giros");
                return;
            }

            Console.WriteLine("\n=== Historial ===");
            for (int i = 0; i < Historial.Count; i++)
            {
                Console.WriteLine((i + 1) + ". "+ Historial[i]);
            }
            Console.WriteLine("============\n");
        }

    }
}
