using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_estudiantes.Personas
{
    public abstract class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }

        protected Persona(string nombre, string apellido, string cedula)
        {
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
        }

        public virtual string ObtenerNombreCompleto()
        {
            return $"{Nombre} {Apellido}";
        }

        public abstract void MostrarInformacion();
    }
}
