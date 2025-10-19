using Gestion_de_estudiantes.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_estudiantes.Clase
{
    public class Asignatura
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        private ArrayList grupos;

        public Asignatura(string codigo, string nombre, int creditos)
        {
            Codigo = codigo;
            Nombre = nombre;
            Creditos = creditos;
            grupos = new ArrayList();
        }

        public OperationResult AgregarGrupo(Grupo grupo)
        {
            try
            {
                foreach (Grupo g in grupos)
                {
                    if (g.Codigo == grupo.Codigo)
                    {
                        return new OperationResult(false, "El grupo ya existe en esta asignatura");
                    }
                }

                grupos.Add(grupo);
                return new OperationResult(true, "Grupo agregado exitosamente", grupo);
            }
            catch (Exception ex)
            {
                return new OperationResult(false, $"Error al agregar grupo: {ex.Message}");
            }
        }

        public ArrayList ObtenerGrupos()
        {
            return grupos;
        }

        public Grupo BuscarGrupoPorCodigo(string codigo)
        {
            foreach (Grupo g in grupos)
            {
                if (g.Codigo == codigo)
                {
                    return g;
                }
            }
            return null;
        }

        public void MostrarResumen()
        {
            Console.WriteLine($"\n═══════════════════════════════════════════");
            Console.WriteLine($"  Asignatura: {Nombre}");
            Console.WriteLine($"  Código: {Codigo} | Créditos: {Creditos}");
            Console.WriteLine($"═══════════════════════════════════════════");
            Console.WriteLine($"Cantidad de grupos: {grupos.Count}");

            foreach (Grupo grupo in grupos)
            {
                Console.WriteLine($"\n  → Grupo: {grupo.NombreGrupo} ({grupo.Codigo})");
                Console.WriteLine($"    No. Estudiantes: {grupo.ContarEstudiantes()}");
                Console.WriteLine($"    Aprobados: {grupo.ContarAprobados()}");
                Console.WriteLine($"    % Aprobación: {grupo.CalcularPorcentajeAprobados():F2}%");
            }
        }
    }

}
