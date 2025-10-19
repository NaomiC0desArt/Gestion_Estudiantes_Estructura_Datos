using Gestion_de_estudiantes.Helpers;
using System.Collections;
using Gestion_de_estudiantes.Personas;
using Gestion_de_estudiantes.Clase;
using Gestion_de_estudiantes.Managers;

class Program {
    static void Main(string[] args)
    {
        
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        UIHelper.MostrarBienvenida();

        Docente docente = InicializarDocente();

        MenuManager menuManager = new MenuManager(docente);

        menuManager.MostrarMenuPrincipal();
    }

    private static Docente InicializarDocente()
    {
        Console.WriteLine("Favor ingresar sus datos como docente:\n");

        string nombre = UIHelper.SolicitarTexto("Nombre");
        string apellido = UIHelper.SolicitarTexto("Apellido");
        string cedula = UIHelper.SolicitarTexto("Cedula");
        string identificacionEmpleado = UIHelper.SolicitarTexto("Identificación de Empleado");
        string departamento = UIHelper.SolicitarTexto("Departamento");

        Docente docente = new Docente(nombre, apellido, cedula, identificacionEmpleado, departamento);

        Console.WriteLine($"\n¡Bienvenido(a), {docente.ObtenerNombreCompleto()}!");
        UIHelper.PausarPantalla();

        return docente;
    }
}