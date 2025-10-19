using Gestion_de_estudiantes.Helpers;
using Gestion_de_estudiantes.Personas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_estudiantes.Clase
{
    public class Grupo
    {
        public string Codigo { get; set; }
        public string NombreGrupo { get; set; }
        private ArrayList estudiantes;

        public Grupo(string codigo, string nombreGrupo)
        {
            Codigo = codigo;
            NombreGrupo = nombreGrupo;
            estudiantes = new ArrayList();
        }

        public OperationResult AgregarEstudiante(Estudiante estudiante)
        {
            try
            {
                foreach (Estudiante est in estudiantes)
                {
                    if (est.Matricula == estudiante.Matricula)
                    {
                        return new OperationResult(false, "El estudiante ya está registrado en este grupo");
                    }
                }

                estudiantes.Add(estudiante);
                return new OperationResult(true, "Estudiante agregado exitosamente :)", estudiante);
            }
            catch (Exception ex)
            {
                return new OperationResult(false, $"Error al agregar estudiante: {ex.Message}");
            }
        }

        public ArrayList ObtenerEstudiantes()
        {
            return estudiantes;
        }

        public int ContarEstudiantes()
        {
            return estudiantes.Count;
        }

        public int ContarAprobados()
        {
            int aprobados = 0;
            foreach (Estudiante est in estudiantes)
            {
                if (est.EstaAprobado())
                {
                    aprobados++;
                }
            }
            return aprobados;
        }

        public double CalcularPorcentajeAprobados()
        {
            if (estudiantes.Count == 0) return 0;
            return ContarAprobados() * 100.0 / estudiantes.Count;
        }

        public Estudiante BuscarEstudiantePorMatricula(string matricula)
        {
            foreach (Estudiante est in estudiantes)
            {
                if (est.Matricula == matricula)
                {
                    return est;
                }
            }
            return null;
        }

        public void MostrarListadoCalificaciones()
        {
            Console.WriteLine($"\n╔════════════════════════════════════════════════════════════ ╗");
            Console.WriteLine($"║  Calificaciones - Grupo: {NombreGrupo,-23}                   ║");
            Console.WriteLine($"║  Código: {Codigo,-49}                                        ║");
            Console.WriteLine($"╚══════════════════════════════════════════════════════════════╝");

            if (estudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados en este grupo.");
                return;
            }

            Console.WriteLine($"\n{"Matrícula",-12} {"Nombre",-25} {"Tipo",-12} {"Promedio",-10} {"Estado",-10}");
            Console.WriteLine(new string('-', 80));

            foreach (Estudiante est in estudiantes)
            {
                string estado = est.EstaAprobado() ? "APROBADO" : "REPROBADO";
                Console.WriteLine($"{est.Matricula,-12} {est.ObtenerNombreCompleto(),-25} " +
                                $"{est.ObtenerTipoEstudiante(),-12} {est.CalcularPromedio(),-10:F2} {estado,-10}");
            }

            Console.WriteLine(new string('-', 80));
            Console.WriteLine($"\nTotal estudiantes: {ContarEstudiantes()}");
            Console.WriteLine($"Aprobados: {ContarAprobados()}");
            Console.WriteLine($"Reprobados: {estudiantes.Count - ContarAprobados()}");
            Console.WriteLine($"Porcentaje de aprobación: {CalcularPorcentajeAprobados():F2}%");
        }
    }

}
