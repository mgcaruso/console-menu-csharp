/*
Se necesita desarrollar una aplicación para administrar la información de los estudiantes de una escuela. Cada estudiante tiene un nombre, un número de identificación único y una edad. Además, se requiere registrar información adicional dependiendo de si el estudiante es de primaria o secundaria. Para los estudiantes de primaria, se debe registrar el grado en el que están y la sección a la que pertenecen (por ejemplo, "4to A"). Para los estudiantes de secundaria, se debe registrar el año en el que están y el número de cursos aprobados.

La aplicación debe ofrecer un menú con las siguientes opciones:

Agregar estudiante
Eliminar estudiante
Mostrar lista de estudiantes
Salir
Para agregar un estudiante, se debe pedir al usuario que ingrese el nombre, el número de identificación y la edad del estudiante, así como la información adicional dependiendo de si es de primaria o secundaria.

Para eliminar un estudiante, se debe pedir al usuario que ingrese el número de identificación del estudiante que desea eliminar, y luego eliminarlo de la lista de estudiantes.

Para mostrar la lista de estudiantes, se debe imprimir en pantalla la información de todos los estudiantes registrados.

El programa debe funcionar correctamente con las clases definidas y debe gestionar la creación y eliminación de estudiantes de manera adecuada
*/
using System.Drawing;
using System.Linq;

namespace POO
{
    class Program
    {
        static void mostrarMenu()
        {
            Console.WriteLine("-----------MENU-----------");
            Console.WriteLine("1. Agregar estudiante de primaria.");
            Console.WriteLine("2. Agregar estudiante de secundaria.");
            Console.WriteLine("3. Mostrar estudiantes.");
            Console.WriteLine("4. Eliminar estudiantes.");
            Console.WriteLine("5. Buscar estudiante.");
            Console.WriteLine("0. Salir");

            Console.WriteLine("--------------------------");
        }

        static Estudiante tomarDatos(int opcion)
        {
            Console.WriteLine("Ingrese Id del estudiante:");
            int id = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Ingrese el nombre:");
            string nombre = Console.ReadLine()!;
            Console.WriteLine("Ingrese la edad:");
            int edad = int.Parse(Console.ReadLine()!);

            if (opcion == 1)
            {
                Console.WriteLine("Ingrese grado:");
                string grado = Console.ReadLine()!;
                Console.WriteLine("Ingrese seccion:");
                char seccion = char.Parse(Console.ReadLine()!);
                var estPrimaria = new EstudiantePrimaria(id, nombre, edad, grado, seccion);
                //ingreso est primaria
                return estPrimaria;

            }
            else
            {
                Console.WriteLine("Ingrese año:");
                string anio = Console.ReadLine()!;
                Console.WriteLine("Ingrese cursos aprobados:");
                int cursosAprobados = int.Parse(Console.ReadLine()!);
                var estSecundaria = new EstudianteSecundaria(id, nombre, edad, anio, cursosAprobados);
                //ingreso est secundaria

                return estSecundaria;

            }
        }

        static int buscarEstudiante(Estudiante[] estudiantesArr, int cantidad)
        {
            Console.WriteLine("Ingrese el id del estudiante:");
            int id = int.Parse(Console.ReadLine()!);
            int flag = -1;
            for (var i = 0; i < cantidad; i++)
            {

                if (estudiantesArr[i].getId() == id)
                {
                    Console.WriteLine(estudiantesArr[i].ToString());
                    flag = i;
                }
            }

            if (flag == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay estudiantes con ese id.");
                Console.ResetColor();
            }
            return flag;
        }

        static void eliminarEstudiante(Estudiante[] estudiantesArr, ref int cantidad)
        {
            int indice = buscarEstudiante(estudiantesArr, cantidad);
            if (indice != -1)
            {
                for (var i = indice; i < cantidad - 1; i++)
                    estudiantesArr[i] = estudiantesArr[i + 1];
                cantidad--;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Estudiante eliminado con éxito.");
                Console.ResetColor();
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Indique la capacidad máxima de almacenamiento del programa (número entero):");
            
            int capacidad = int.Parse(Console.ReadLine()!);
            var estudiantesArr = new Estudiante[capacidad];
            int cantidad = 0;

            mostrarMenu();
            int eleccion = int.Parse(Console.ReadLine()!);

            do
            {
                switch (eleccion)
                {
                    case 1:
                    case 2:
                        //tomar datos
                        if (cantidad < capacidad)
                        {
                            var estudiante = tomarDatos(eleccion);
                            estudiantesArr[cantidad] = estudiante;
                            cantidad++;
                        }
                        else
                        {
                            Console.WriteLine("ERROR. Almacenamiento completo.");
                        }
                        break;
                    case 3:
                        //mostrar
                        if (cantidad > 0)
                        {
                            for (int i = 0; i < cantidad; i++)
                            {
                                Console.WriteLine(estudiantesArr[i].ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay estudiantes por mostrar.");
                        }
                        break;
                    case 4:
                        //chequeo si hay estudiantes en el array
                        if (cantidad < 1)
                        {
                            Console.WriteLine("No hay estudiantes para eliminar.");
                        }
                        else
                        {
                            //elimino 
                            eliminarEstudiante(estudiantesArr, ref cantidad);

                        }

                        break;
                    case 5:
                        if (cantidad > 0)

                            buscarEstudiante(estudiantesArr, cantidad);
                        else
                            Console.WriteLine("No hay estudiantes guardados aún.");

                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }

                if (eleccion != 0)
                {
                    //vuelvo a pedir los datos
                    mostrarMenu();
                    eleccion = int.Parse(Console.ReadLine()!);
                }



            } while (eleccion != 0);
        }
    }
}


