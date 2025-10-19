using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_estudiantes.Helpers
{
    public static class UIHelper
    {
        public static void MostrarBienvenida()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                                    ║");
            Console.WriteLine("║                    {GESTIÓN DE ESTUDIANTES}                        ║");
            Console.WriteLine("║                             ITLA                                   ║");
            Console.WriteLine("║                      -Estructura de datos-                         ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
        }

        public static void PausarPantalla()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        public static void MostrarError(string mensaje)
        {
            Console.WriteLine($"\n Error: {mensaje}.");
        }

        public static void MostrarExito(string mensaje)
        {
            Console.WriteLine($"\n✓ {mensaje}");
        }

        public static void MostrarResultado(OperationResult result)
        {
            if (result.Success)
            {
                MostrarExito(result.Message);
            }
            else
            {
                MostrarError(result.Message);
            }
        }

        public static string SolicitarTexto(string mensaje)
        {
            Console.Write($"{mensaje}: ");
            return Console.ReadLine();
        }

       
        public static bool SolicitarEntero(string mensaje, out int numero)
        {
            Console.Write($"{mensaje}: ");
            return int.TryParse(Console.ReadLine(), out numero);
        }

        public static bool SolicitarDouble(string mensaje, out double numero)
        {
            Console.Write($"{mensaje}: ");
            return double.TryParse(Console.ReadLine(), out numero);
        }

        public static void MostrarSeparador(char caracter = '=', int longitud = 70)
        {
            Console.WriteLine(new string(caracter, longitud));
        }

        public static void MostrarTitulo(string titulo)
        {
            Console.Clear();
            Console.WriteLine($"═══ {titulo} ═══\n");
        }
    }
}
