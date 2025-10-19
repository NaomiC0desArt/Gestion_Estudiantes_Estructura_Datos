using Gestion_de_estudiantes.Helpers;


namespace Gestion_de_estudiantes.Clase
{
    public class Calificacion
    {
        public TipoCalificacion Tipo { get; set; }
        public double Nota { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public Calificacion(TipoCalificacion tipo, double nota, string descripcion)
        {
            Tipo = tipo;
            Nota = nota;
            Descripcion = descripcion;
            Fecha = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Tipo} - {Descripcion}: {Nota:F2} pts";
        }
    }
}
