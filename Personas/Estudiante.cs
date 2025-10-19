using Gestion_de_estudiantes.Clase;
using Gestion_de_estudiantes.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_estudiantes.Personas
{
    public abstract class Estudiante : Persona
    {
        public string Matricula { get; set; }
        private ArrayList calificaciones; 

        protected Estudiante(string nombre, string apellido, string cedula, string matricula)
            : base(nombre, apellido, cedula)
        {
            Matricula = matricula;
            calificaciones = new ArrayList();
        }

        public OperationResult AgregarCalificacion(Calificacion calificacion)
        {
            try
            {
                if (calificacion.Nota < 0 || calificacion.Nota > 100)
                {
                    return new OperationResult(false, "La calificación debe estar entre 0 y 100");
                }

                calificaciones.Add(calificacion);
                return new OperationResult(true, "Calificación agregada con exito :)", calificacion);
            }
            catch (Exception ex)
            {
                return new OperationResult(false, $"Error al agregar calificación: {ex.Message}");
            }
        }

        public double CalcularPromedio()
        {
            if (calificaciones.Count == 0) return 0;

            double suma = 0;
            foreach (Calificacion cal in calificaciones)
            {
                suma += cal.Nota;
            }
            return suma / calificaciones.Count;
        }

        public bool EstaAprobado()
        {
            return CalcularPromedio() >= 70;
        }

        public ArrayList ObtenerCalificaciones()
        {
            return calificaciones;
        }

        public abstract string ObtenerTipoEstudiante();

        public override void MostrarInformacion()
        {
            Console.WriteLine($"\n--- Estudiante info ---");
            Console.WriteLine($"Tipo: {ObtenerTipoEstudiante()}");
            Console.WriteLine($"Nombre: {ObtenerNombreCompleto()}");
            Console.WriteLine($"Matrícula: {Matricula}");
            Console.WriteLine($"Cedula: {Cedula}");
            Console.WriteLine($"Promedio: {CalcularPromedio():F2}");
            Console.WriteLine($"Estado: {(EstaAprobado() ? "APROBADO" : "REPROBADO")}");

            if (calificaciones.Count > 0)
            {
                Console.WriteLine("\nCalificaciones:");
                foreach (Calificacion cal in calificaciones)
                {
                    Console.WriteLine($"  - {cal}");
                }
            }
            else
            {
                Console.WriteLine("Sin calificaciones registradas hasta el momento.");
            }
        }
    }
}
