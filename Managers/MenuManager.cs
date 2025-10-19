using Gestion_de_estudiantes.Clase;
using Gestion_de_estudiantes.Helpers;
using Gestion_de_estudiantes.Personas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_estudiantes.Managers
{
    public class MenuManager
    {
        private Docente docenteActual;

        public MenuManager(Docente docente)
        {
            docenteActual = docente;
        }

        #region Menú Principal

        public void MostrarMenuPrincipal()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                 Sistema gestión de estudiantes                     ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝");
                Console.WriteLine($"Docente: {docenteActual.ObtenerNombreCompleto()}\n");
                Console.WriteLine("[1] Gestión de Asignaturas");
                Console.WriteLine("[2] Gestión de Grupos");
                Console.WriteLine("[3] Gestión de Estudiantes");
                Console.WriteLine("[4] Gestión de Calificaciones");
                Console.WriteLine("[5] Reportes y Estadísticas");
                Console.WriteLine("[6] Información del Docente");
                Console.WriteLine("[0] Salir");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MenuAsignaturas();
                        break;
                    case "2":
                        MenuGrupos();
                        break;
                    case "3":
                        MenuEstudiantes();
                        break;
                    case "4":
                        MenuCalificaciones();
                        break;
                    case "5":
                        MenuReportes();
                        break;
                    case "6":
                        docenteActual.MostrarInformacion();
                        UIHelper.PausarPantalla();
                        break;
                    case "0":
                        continuar = false;
                        Console.WriteLine("\nHasta pronto.");
                        break;
                    default:
                        UIHelper.MostrarError("Opción inválida");
                        UIHelper.PausarPantalla();
                        break;
                }
            }
        }

        #endregion

        #region Menú de Asignaturas

        private void MenuAsignaturas()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                              ASIGNATURAS                           ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝\n");
                Console.WriteLine("[1] Agregar nueva asignatura");
                Console.WriteLine("[2] Listar asignaturas");
                Console.WriteLine("[3] Ver info de asignatura");
                Console.WriteLine("[0] Volver al menú principal");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarAsignatura();
                        break;
                    case "2":
                        ListarAsignaturas();
                        break;
                    case "3":
                        VerResumenAsignatura();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        UIHelper.MostrarError("Opción inválida");
                        UIHelper.PausarPantalla();
                        break;
                }
            }
        }

        private void AgregarAsignatura()
        {
            Console.Clear();
            Console.WriteLine("═══ Agregar nueva asignatura ═══\n");

            Console.Write("Código de la asignatura: ");
            string codigo = Console.ReadLine();

            Console.Write("Nombre de la asignatura: ");
            string nombre = Console.ReadLine();

            Console.Write("Créditos: ");
            if (!int.TryParse(Console.ReadLine(), out int creditos))
            {
                UIHelper.MostrarError("Los créditos deben ser un número entero");
                UIHelper.PausarPantalla();
                return;
            }

            Asignatura asignatura = new Asignatura(codigo, nombre, creditos);
            OperationResult resultado = docenteActual.AgregarAsignatura(asignatura);

            UIHelper.MostrarResultado(resultado);
            UIHelper.PausarPantalla();
        }

        private void ListarAsignaturas()
        {
            Console.Clear();
            Console.WriteLine("═══ Lista de asiganturas ═══\n");

            ArrayList asignaturas = docenteActual.ObtenerAsignaturas();

            if (asignaturas.Count == 0)
            {
                Console.WriteLine("No hay asignaturas registradas en este momento.");
            }
            else
            {
                Console.WriteLine($"{"Código",-10} {"Nombre",-35} {"Créditos",-10} {"Grupos",-10}");
                Console.WriteLine(new string('-', 70));

                foreach (Asignatura asig in asignaturas)
                {
                    Console.WriteLine($"{asig.Codigo,-10} {asig.Nombre,-35} {asig.Creditos,-10} {asig.ObtenerGrupos().Count,-10}");
                }
            }

            UIHelper.PausarPantalla();
        }

        private void VerResumenAsignatura()
        {
            Console.Clear();
            Console.WriteLine("═══ Info Asignatura ═══\n");

            Console.Write("Ingrese el código de la asignatura: ");
            string codigo = Console.ReadLine();

            Asignatura asignatura = docenteActual.BuscarAsignaturaPorCodigo(codigo);

            if (asignatura == null)
            {
                UIHelper.MostrarError("Asignatura no encontrada");
            }
            else
            {
                asignatura.MostrarResumen();
            }

            UIHelper.PausarPantalla();
        }

        #endregion

        #region Menú de Grupos

        private void MenuGrupos()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                                 GRUPOS                             ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝\n");
                Console.WriteLine("1. Agregar nuevo grupo a una asignatura");
                Console.WriteLine("2. Listar grupos de una asignatura");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarGrupo();
                        break;
                    case "2":
                        ListarGrupos();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        UIHelper.MostrarError("Opción inválida");
                        UIHelper.PausarPantalla();
                        break;
                }
            }
        }

        private void AgregarGrupo()
        {
            Console.Clear();
            Console.WriteLine("═══ Agregar grupo ═══\n");

            Console.Write("Código de la asignatura: ");
            string codigoAsignatura = Console.ReadLine();

            Asignatura asignatura = docenteActual.BuscarAsignaturaPorCodigo(codigoAsignatura);

            if (asignatura == null)
            {
                UIHelper.MostrarError("Asignatura no encontrada");
                UIHelper.PausarPantalla();
                return;
            }

            Console.Write("Código del grupo: ");
            string codigoGrupo = Console.ReadLine();

            Console.Write("Nombre del grupo: ");
            string nombreGrupo = Console.ReadLine();

            Grupo grupo = new Grupo(codigoGrupo, nombreGrupo);
            OperationResult resultado = asignatura.AgregarGrupo(grupo);

            UIHelper.MostrarResultado(resultado);
            UIHelper.PausarPantalla();
        }

        private void ListarGrupos()
        {
            Console.Clear();
            Console.WriteLine("═══ Grupos ═══\n");

            Console.Write("Código de la asignatura: ");
            string codigoAsignatura = Console.ReadLine();

            Asignatura asignatura = docenteActual.BuscarAsignaturaPorCodigo(codigoAsignatura);

            if (asignatura == null)
            {
                UIHelper.MostrarError("Asignatura no encontrada");
            }
            else
            {
                ArrayList grupos = asignatura.ObtenerGrupos();

                if (grupos.Count == 0)
                {
                    Console.WriteLine("\nNo hay grupos registrados en esta asignatura.");
                }
                else
                {
                    Console.WriteLine($"\nAsignatura: {asignatura.Nombre}\n");
                    Console.WriteLine($"{"Código",-15} {"Nombre",-25} {"Estudiantes",-15}");
                    Console.WriteLine(new string('-', 60));

                    foreach (Grupo grupo in grupos)
                    {
                        Console.WriteLine($"{grupo.Codigo,-15} {grupo.NombreGrupo,-25} {grupo.ContarEstudiantes(),-15}");
                    }
                }
            }

            UIHelper.PausarPantalla();
        }

        #endregion

        #region Menú de Estudiantes

        private void MenuEstudiantes()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                    GESTIÓN DE ESTUDIANTES                          ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝\n");
                Console.WriteLine("[1] Agregar estudiante presencial");
                Console.WriteLine("[2] Agregar estudiante a distancia");
                Console.WriteLine("[3] Listar estudiantes de un grupo");
                Console.WriteLine("[4] Ver información de un estudiante");
                Console.WriteLine("[0] Volver al menú principal");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarEstudiantePresencial();
                        break;
                    case "2":
                        AgregarEstudianteDistancia();
                        break;
                    case "3":
                        ListarEstudiantesGrupo();
                        break;
                    case "4":
                        VerInformacionEstudiante();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        UIHelper.MostrarError("Opción inválida");
                        UIHelper.PausarPantalla();
                        break;
                }
            }
        }

        private void AgregarEstudiantePresencial()
        {
            Console.Clear();
            Console.WriteLine("═══ Agregar estudiante presencial ═══\n");

            Grupo grupo = SeleccionarGrupo();
            if (grupo == null) return;

            Console.Write("\nNombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();

            Console.Write("Cedula: ");
            string cedula = Console.ReadLine();

            Console.Write("Matrícula: ");
            string matricula = Console.ReadLine();

            Console.Write("Aula: ");
            string aula = Console.ReadLine();

            Console.Write("Horario: ");
            string horario = Console.ReadLine();

            EstudiantePresencial estudiante = new EstudiantePresencial(
                nombre, apellido, cedula, matricula, aula, horario);

            OperationResult resultado = grupo.AgregarEstudiante(estudiante);
            UIHelper.MostrarResultado(resultado);
            UIHelper.PausarPantalla();
        }

        private void AgregarEstudianteDistancia()
        {
            Console.Clear();
            Console.WriteLine("═══ Agregar estudiante virtual ═══\n");

            Grupo grupo = SeleccionarGrupo();
            if (grupo == null) return;

            Console.Write("\nNombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();

            Console.Write("Cedula: ");
            string cedula = Console.ReadLine();

            Console.Write("Matrícula: ");
            string matricula = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            EstudianteVIrtual estudiante = new EstudianteVIrtual(
                nombre, apellido, cedula, matricula, email);

            OperationResult resultado = grupo.AgregarEstudiante(estudiante);
            UIHelper.MostrarResultado(resultado);
            UIHelper.PausarPantalla();
        }

        private void ListarEstudiantesGrupo()
        {
            Console.Clear();
            Console.WriteLine("═══ Estudiantes por grupo ═══\n");

            Grupo grupo = SeleccionarGrupo();
            if (grupo == null) return;

            ArrayList estudiantes = grupo.ObtenerEstudiantes();

            if (estudiantes.Count == 0)
            {
                Console.WriteLine("\nNo hay estudiantes registrados en este grupo.");
            }
            else
            {
                Console.WriteLine($"\n{"Matrícula",-12} {"Nombre",-25} {"Tipo",-15} {"Promedio",-10}");
                Console.WriteLine(new string('-', 70));

                foreach (Estudiante est in estudiantes)
                {
                    Console.WriteLine($"{est.Matricula,-12} {est.ObtenerNombreCompleto(),-25} " +
                                    $"{est.ObtenerTipoEstudiante(),-15} {est.CalcularPromedio(),-10:F2}");
                }
            }

            UIHelper.PausarPantalla();
        }

        private void VerInformacionEstudiante()
        {
            Console.Clear();
            Console.WriteLine("═══ Info Estudiantes ═══\n");

            Grupo grupo = SeleccionarGrupo();
            if (grupo == null) return;

            Console.Write("\nMatrícula del estudiante: ");
            string matricula = Console.ReadLine();

            Estudiante estudiante = grupo.BuscarEstudiantePorMatricula(matricula);

            if (estudiante == null)
            {
                UIHelper.MostrarError("El estudiante no fue encontrado en este grupo");
            }
            else
            {
                estudiante.MostrarInformacion();
            }

            UIHelper.PausarPantalla();
        }

        #endregion

        #region Menú de Calificaciones

        private void MenuCalificaciones()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                          CALIFICACIONES                            ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝\n");
                Console.WriteLine("[1] Registrar calificación de examen");
                Console.WriteLine("[2] Registrar calificación de práctica");
                Console.WriteLine("[3] Ver calificaciones de un estudiante");
                Console.WriteLine("[0] Volver al menú principal");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarCalificacion(TipoCalificacion.Examen);
                        break;
                    case "2":
                        RegistrarCalificacion(TipoCalificacion.Practica);
                        break;
                    case "3":
                        VerCalificacionesEstudiante();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        UIHelper.MostrarError("Opción inválida");
                        UIHelper.PausarPantalla();
                        break;
                }
            }
        }

        private void RegistrarCalificacion(TipoCalificacion tipo)
        {
            Console.Clear();
            Console.WriteLine($"═══ Registrar calificación de {tipo.ToString().ToUpper()} ═══\n");

            Grupo grupo = SeleccionarGrupo();
            if (grupo == null) return;

            Console.Write("\nMatrícula del estudiante: ");
            string matricula = Console.ReadLine();

            Estudiante estudiante = grupo.BuscarEstudiantePorMatricula(matricula);

            if (estudiante == null)
            {
                UIHelper.MostrarError("Estudiante no encontrado en este grupo");
                UIHelper.PausarPantalla();
                return;
            }

            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine();

            Console.Write("Nota (0-100): ");
            if (!double.TryParse(Console.ReadLine(), out double nota))
            {
                UIHelper.MostrarError("La nota debe ser un número");
                UIHelper.PausarPantalla();
                return;
            }

            Calificacion calificacion = new Calificacion(tipo, nota, descripcion);
            OperationResult resultado = estudiante.AgregarCalificacion(calificacion);

            UIHelper.MostrarResultado(resultado);

            if (resultado.Success)
            {
                Console.WriteLine($"Promedio actual del estudiante: {estudiante.CalcularPromedio():F2}");
            }

            UIHelper.PausarPantalla();
        }

        private void VerCalificacionesEstudiante()
        {
            Console.Clear();
            Console.WriteLine("═══ Ver calificaciones por estudiante ═══\n");

            Grupo grupo = SeleccionarGrupo();
            if (grupo == null) return;

            Console.Write("\nMatrícula del estudiante: ");
            string matricula = Console.ReadLine();

            Estudiante estudiante = grupo.BuscarEstudiantePorMatricula(matricula);

            if (estudiante == null)
            {
                UIHelper.MostrarError("Estudiante no encontrado en este grupo");
            }
            else
            {
                estudiante.MostrarInformacion();
            }

            UIHelper.PausarPantalla();
        }

        #endregion

        #region Menú de Reportes

        private void MenuReportes()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                               REPORTES                             ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝\n");
                Console.WriteLine("[1] Listado de calificaciones de un grupo");
                Console.WriteLine("[2] Estadísticas de aprobación de un grupo");
                Console.WriteLine("[0] Volver al menú principal");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MostrarListadoCalificaciones();
                        break;
                    case "2":
                        MostrarEstadisticasGrupo();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        UIHelper.MostrarError("Opción inválida");
                        UIHelper.PausarPantalla();
                        break;
                }
            }
        }

        private void MostrarListadoCalificaciones()
        {
            Console.Clear();
            Grupo grupo = SeleccionarGrupo();
            if (grupo == null) return;

            grupo.MostrarListadoCalificaciones();
            UIHelper.PausarPantalla();
        }

        private void MostrarEstadisticasGrupo()
        {
            Console.Clear();
            Console.WriteLine("═══ ESTADÍSTICAS DE APROBACIÓN ═══\n");

            Grupo grupo = SeleccionarGrupo();
            if (grupo == null) return;

            int totalEstudiantes = grupo.ContarEstudiantes();
            int aprobados = grupo.ContarAprobados();
            int reprobados = totalEstudiantes - aprobados;
            double porcentajeAprobacion = grupo.CalcularPorcentajeAprobados();

            Console.WriteLine($"\n╔═══════════════════════════════════════════╗");
            Console.WriteLine($"║  ESTADÍSTICAS - GRUPO: {grupo.NombreGrupo,-17}║");
            Console.WriteLine($"╚═══════════════════════════════════════════╝");
            Console.WriteLine($"\nTotal de estudiantes:      {totalEstudiantes}");
            Console.WriteLine($"Estudiantes aprobados:     {aprobados}");
            Console.WriteLine($"Estudiantes reprobados:    {reprobados}");
            Console.WriteLine($"Porcentaje de aprobación:  {porcentajeAprobacion:F2}%");

            ArrayList estudiantes = grupo.ObtenerEstudiantes();
            double sumaPromedios = 0;
            int estudiantesConNotas = 0;

            foreach (Estudiante est in estudiantes)
            {
                if (est.ObtenerCalificaciones().Count > 0)
                {
                    sumaPromedios += est.CalcularPromedio();
                    estudiantesConNotas++;
                }
            }

            if (estudiantesConNotas > 0)
            {
                double promedioGrupo = sumaPromedios / estudiantesConNotas;
                Console.WriteLine($"Promedio general del grupo: {promedioGrupo:F2}");
            }

            UIHelper.PausarPantalla();
        }


        #endregion

        #region Métodos Auxiliares

        private Grupo SeleccionarGrupo()
        {
            Console.Write("Código de la asignatura: ");
            string codigoAsignatura = Console.ReadLine();

            Asignatura asignatura = docenteActual.BuscarAsignaturaPorCodigo(codigoAsignatura);

            if (asignatura == null)
            {
                UIHelper.MostrarError("Asignatura no encontrada");
                UIHelper.PausarPantalla();
                return null;
            }

            Console.Write("Código del grupo: ");
            string codigoGrupo = Console.ReadLine();

            Grupo grupo = asignatura.BuscarGrupoPorCodigo(codigoGrupo);

            if (grupo == null)
            {
                UIHelper.MostrarError("Grupo no encontrado");
                UIHelper.PausarPantalla();
                return null;
            }

            return grupo;
        }

        #endregion
    }
}

