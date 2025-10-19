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
    public class Docente : Persona
    {
        public string IdentificacionEmpleado { get; set; }
        public string Departamento { get; set; }
        private ArrayList asignaturas;

        public Docente(string nombre, string apellido, string identificacion,
                      string codigoEmpleado, string departamento)
            : base(nombre, apellido, identificacion)
        {
            IdentificacionEmpleado = codigoEmpleado;
            Departamento = departamento;
            asignaturas = new ArrayList();
        }

        public OperationResult AgregarAsignatura(Asignatura asignatura)
        {
            try
            {
                foreach (Asignatura asig in asignaturas)
                {
                    if (asig.Codigo == asignatura.Codigo)
                    {
                        return new OperationResult(false, "La asignatura ya está asignada a este docente");
                    }
                }

                asignaturas.Add(asignatura);
                return new OperationResult(true, "Asignatura agregada con exito", asignatura);
            }
            catch (Exception ex)
            {
                return new OperationResult(false, $"Error al agregar asignatura: {ex.Message}");
            }
        }

        public ArrayList ObtenerAsignaturas()
        {
            return asignaturas;
        }

        public Asignatura BuscarAsignaturaPorCodigo(string codigo)
        {
            foreach (Asignatura asig in asignaturas)
            {
                if (asig.Codigo == codigo)
                {
                    return asig;
                }
            }
            return null;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine($"\n╔═════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║  Info profesor                                               ║");
            Console.WriteLine($"╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine($"Nombre: {ObtenerNombreCompleto()}");
            Console.WriteLine($"Identidicación empleado: {IdentificacionEmpleado}");
            Console.WriteLine($"Departamento: {Departamento}");
            Console.WriteLine($"Cedula: {Cedula}");
            Console.WriteLine($"Asignaturas impartidas: {asignaturas.Count}");
        }
    }
}
