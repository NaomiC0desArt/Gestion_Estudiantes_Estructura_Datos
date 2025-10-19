using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_estudiantes.Personas
{
    public class EstudiantePresencial : Estudiante
    {
        public string Aula { get; set; }
        public string Horario { get; set; }

        public EstudiantePresencial(string nombre, string apellido, string cedula,
                                   string matricula, string aula, string horario)
            : base(nombre, apellido, cedula, matricula)
        {
            Aula = aula;
            Horario = horario;
        }

        public override string ObtenerTipoEstudiante()
        {
            return "Presencial";
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Aula: {Aula}");
            Console.WriteLine($"Horario: {Horario}");
        }
    }
}
