using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_estudiantes.Personas
{
    public class EstudianteVIrtual : Estudiante
    {
        public string Email { get; set; }

        public EstudianteVIrtual(string nombre, string apellido, string cedula,
                                  string matricula, string email)
            : base(nombre, apellido, cedula, matricula)
        {
            Email = email;
        }

        public override string ObtenerTipoEstudiante()
        {
            return "Virtual";
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Email: {Email}");
        }
    }
}
