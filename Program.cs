// Examen - Juego de la Ruleta
// Simula el giro de una ruleta de casino (0-36) donde el jugador
// puede apostar a un numero, color o a par/impar, gana o
// pierde dinero segun el resultado de cada giro.
namespace JuegodeRuleta
{
    internal class Program
    {
        static Ruleta ruleta = new Ruleta();
        static Player player;
        static void Main(string[] args)
        {
            Console.Write("Ingresa tu nombre: ");
            string nombre = Console.ReadLine();

            if (string.IsNullOrEmpty(nombre))
            {
                nombre = "Jugador";
            }

            player = new Player(nombre, 300);
            Console.WriteLine("Hola, bienvenido " + player.Nombre); 
            Console.WriteLine("Tu saldo inicial es: $" + player.Saldo);

            bool retirado = false;

            while (player.Saldo > 0 && !retirado)
            {
                Console.WriteLine("\nSaldo actual: $" + player.Saldo);
                Console.WriteLine("1. Apostar");
                Console.WriteLine("2. Ver historial");
                Console.WriteLine("3. Retirarse");
                Console.Write("Opcion: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Apostar();
                        break;
                    case "2":
                        player.MostrarHistorial();
                        break;
                    case "3":
                        retirado = true;
                        break;
                    default:
                        Console.WriteLine("Opcion invalida.");
                        break;
                }
            }

            MostrarResultadoFinal();
        }

        static void Apostar()
        {
            Console.Write("Cuanto quieres apostar? (multiplo de 10): ");
            decimal monto;
            if (!decimal.TryParse(Console.ReadLine(), out monto))
            {
                Console.WriteLine("Ingresa una cantidad valida.");
                return;
            }

            if (monto <= 0 || monto % 10 != 0 || monto > player.Saldo)
            {
                Console.WriteLine("Apuesta invalida.");
                Console.WriteLine("Debe ser multiplo de 10 y no mayor a tu saldo.");
                return;
            }

            Console.WriteLine("\nTipo de apuesta:");
            Console.WriteLine("1. Numero (0-36) -> x10");
            Console.WriteLine("2. Color (Rojo/Negro) -> x5");
            Console.WriteLine("3. Par/Impar -> x2");
            Console.Write("Opcion: ");
            string tipoOpcion = Console.ReadLine();

            Apostar apuesta = null;

            switch (tipoOpcion)
            {
                case "1":
                    Console.Write("Elige un numero (0-36): ");
                    string numeroTexto = Console.ReadLine();
                    apuesta = new Apostar("Numero", monto, numeroTexto, 10);
                    break;
                case "2":
                    Console.Write("Elige color (Rojo/Negro): ");
                    string colorTexto = Console.ReadLine();
                    apuesta = new Apostar("Color", monto, colorTexto, 5);
                    break;
                case "3":
                    Console.Write("Elige Par o Impar: ");
                    string paridadTexto = Console.ReadLine();
                    apuesta = new Apostar("Paridad", monto, paridadTexto, 2);
                    break;
                default:
                    Console.WriteLine("Opcion invalida.");
                    return;
            }

            player.Saldo = player.Saldo - monto;

            Numero resultado = ruleta.Girar();
            Console.WriteLine("\nLa ruleta giro y salio: " + resultado);

            if (apuesta.Gano(resultado))
            {
                decimal premio = monto * apuesta.Multiplicador;
                player.Saldo = player.Saldo + premio;
                Console.WriteLine("Ganaste $" + premio);
                player.Historial.Add(
                    "Salio " + resultado + " | " + apuesta + " | GANO +$" + premio
                );
            }
            else
            {
                Console.WriteLine("Perdiste esta apuesta.");
                player.Historial.Add(
                    "Salio " + resultado + " | " + apuesta + " | PERDIO"
                );
            }

            Console.WriteLine("Saldo actual: $" + player.Saldo);

            if (player.Saldo <= 0)
            {
                Console.WriteLine("\nTe quedaste sin dinero.");
                Console.WriteLine("El juego termina.");
            }
        }

        static void MostrarResultadoFinal()
        {
            player.MostrarHistorial();

            Console.WriteLine("\n=== Fin del juego ===");
            Console.WriteLine("Saldo final: $" + player.Saldo);

            decimal ganancia = player.Saldo - player.SaldoIni;

            if (ganancia > 0)
            {
                Console.WriteLine("Ganaste un total de $" + ganancia);
            }
            else if (ganancia < 0)
            {
                Console.WriteLine("Perdiste un total de $" + (-ganancia));
            }
            else
            {
                Console.WriteLine("Terminaste con el mismo dinero que tenias al empezar.");
            }

        }
    }
}
