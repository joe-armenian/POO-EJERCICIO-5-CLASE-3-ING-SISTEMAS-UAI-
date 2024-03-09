using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio5
{
     public class Program
    {
        static void Main(string[] args)
        {
            string nombre, edad, materia, linea;
            
            Console.WriteLine("Por favor, cargue los datos de el profesor. Necesitamos nombre,edad,sexo y materia.");
            do
            {
                Console.Write("Nombre:"); nombre = Console.ReadLine();
                Console.Write("Edad:");  edad = Console.ReadLine();
                Console.Write("Sexo:"); linea = Console.ReadLine();
                Console.Write("Materia:");materia = Console.ReadLine();

                if (!ValidarLetras(nombre) || (!ValidarLetras(materia)) || (!ValidarNumeros(edad)) || (!ValidarLetras(linea)) || Convert.ToInt32(edad)>100 || (!ValidarSexo(linea)))
                {
                    Console.Write("Error en los datos ingresados,intente nuevamente!\n");
                    continue;
                }

                break;
            } while (true);

            char[] sexoProfesor = linea.ToCharArray();
            sexoProfesor[0] = char.ToUpper(sexoProfesor[0]);
            Profesores unProfesor = new Profesores();
            materia = materia.ToLower();
            unProfesor = new Profesores(nombre, Convert.ToInt32(edad), sexoProfesor[0],materia);
            Console.WriteLine($"Datos del profesor:\nNombre:{unProfesor.Nombre}\nSexo:{unProfesor.Sexo}\nEdad:{unProfesor.Edad}\nMateria:{unProfesor.Materia}");


            //if (ValidarLetras(nombre) && ValidarLetras(materia) && ValidarNumeros(edad) && ValidarLetras(linea))
            //{
            //    char[] sexo = linea.ToCharArray();
            //    sexo[0] = char.ToUpper(sexo[0]);

            //    if (sexo[0] == 'M' || sexo[0] == 'F')
            //    {

            //        materia = materia.ToLower();
            //        unProfesor = new Profesores(nombre, Convert.ToInt32(edad), sexo[0], materia);
            //        Console.WriteLine($"Datos del profesor:\nNombre:{unProfesor.Nombre}\nSexo:{unProfesor.Sexo}\nEdad:{unProfesor.Edad}\nMateria:{unProfesor.Materia}");
            //    }
            //}

            //else
            //{

            //    Console.WriteLine("Error en la entrada de datos");
            //}

            int cantidadEstudiantes = 0;
            do
            {
                Console.Write("Ingrese la cantidad de estudiantes: ");
                string linea2 = Console.ReadLine();

                if (!ValidarNumeros(linea2))
                {
                    Console.WriteLine("Error en la entrada. Por favor, ingrese un número válido.");
                    continue; // Continúa con la siguiente iteración del bucle
                }

                 cantidadEstudiantes = Convert.ToInt32(linea2);
                // Si llegamos aquí, la entrada es válida y podemos salir del bucle
               
                break;
            } while (true);

            
            
            List<Estudiantes> estudiantes = new List<Estudiantes>();



            for (int i=0;i<cantidadEstudiantes;i++)
            {
                do
                {
                    Console.Write($"Ingrese el nombre del estudiante{i + 1}:");
                    string nombreEstudiante= Console.ReadLine();
                    if (!ValidarLetras(nombreEstudiante))
                    {
                        Console.WriteLine("Error en la entrada, por favor ingrese un nombre valido.");
                        continue;
                    }


                    Console.Write($"Ingrese la edad  del estudiante{i + 1}:");
                    string edadEstudiante=Console.ReadLine();
                    if (!ValidarNumeros(edadEstudiante) || Convert.ToInt32(edadEstudiante)>100)
                    {
                        Console.WriteLine("Error en la entrada, por favor ingrese una edad valida.");
                        continue;
                    }


                    Console.Write($"Ingrese el sexo del estudiante{i + 1}:");
                    string sexoEstudiante = Console.ReadLine();
                    if (!ValidarSexo(sexoEstudiante))
                    {
                        Console.WriteLine("Error en la entrada, por favor ingrese un sexo valido.");
                        continue;
                    }
                    char[] sexo = sexoEstudiante.ToCharArray();
                    sexo[0] = char.ToUpper(sexo[0]);

                    
                    Console.Write($"Ingrese la calificacion del estudiante{i + 1}:");
                    string calificacion = Console.ReadLine();
                    if (!ValidarDouble(calificacion) || Convert.ToDouble(calificacion)>10)
                    {
                        Console.WriteLine("Error en la entrada, por favor ingrese una nota valida.");
                        continue;
                    }

                    estudiantes.Add(new Estudiantes(nombreEstudiante, Convert.ToInt32(edadEstudiante), sexo[0], Convert.ToDouble(calificacion)));
                    break;
                } while (true);
            }

            string identificadorAula;
            string capacidadMaxima;
            string materiaAula;

            Console.WriteLine("Por favor a continuación,cargue los datos del Aula.");

            do
            {
                Console.Write("Ingrese el numero identificador del aula:");
                identificadorAula = Console.ReadLine();

                Console.Write("Ingrese la capacidad maxima del aula:");
                capacidadMaxima = Console.ReadLine();
                Console.Write("Ingrese la materia del aula:");
                materiaAula= Console.ReadLine();

                if (!ValidarNumeros(identificadorAula) || (!ValidarNumeros(capacidadMaxima) || (!ValidarLetras(materiaAula))))
                {
                    Console.WriteLine("Error en la entrada, por favor ingrese especificaciones validas");
                    continue;
                }

              break;
            } while (true);

            materiaAula = materiaAula.ToLower();

            Aula unAula = new Aula(Convert.ToInt32(identificadorAula), Convert.ToInt32(capacidadMaxima), materiaAula, unProfesor);

            foreach (Estudiantes agregarEstudiantes in estudiantes) 
            {
                 unAula.Estudiantes.Add(agregarEstudiantes);
            }

            if (unAula.PuedeDarClase())
            {
                Console.Write($"Se puede dar clases en el aula de:{materiaAula}\n");
                Console.WriteLine("Listado y datos de estudiantes:");
                foreach (var estado in estudiantes)
                {
                    Console.Write($"Nombre:{estado.Nombre}\nEdad:{estado.Edad}\nSexo:{estado.Sexo}\nCalificacion:{estado.Calificacion}\n");
                }

                unAula.ContarEstudiantesAprobados();
            }
            else
            {
                Console.Write($"No se puede dar clases en el aula de:{materiaAula},muchas gracias.\n");
            }

            //Aula aulaMatematicas = new Aula(1, 6, "Matematicas", unProfesor);
            //foreach (Estudiantes agregarEstudiantes in estudiantes)
            //{
            //    aulaMatematicas.Estudiantes.Add(agregarEstudiantes);
            //}

            ////Determinar si se puede dar clase
            //if (aulaMatematicas.PuedeDarClase())
            //{
            //    Console.WriteLine("Se puede dar clase en el aula de Matemáticas.");

            //    Console.WriteLine("Listado y datos de estudiantes:");

            //    foreach (var estado in estudiantes)
            //    {

            //        Console.Write($"Nombre:{estado.Nombre}\nEdad:{estado.Edad}\nSexo:{estado.Sexo}\nCalificacion:{estado.Calificacion}\n");
            //    }
            //    aulaMatematicas.ContarEstudiantesAprobados();
            //}
            //else
            //{
            //    Console.WriteLine("No se puede dar clase en el aula de Matemáticas.");
            //}

            Console.ReadKey();
        }
        public static bool ValidarSexo(string linea)
        {
            return Regex.IsMatch(linea, @"^[MFmf]$");
        }


        public static bool ValidarDouble(string linea)
        {
            return Regex.IsMatch(linea, @"^[0,0-9,9]+$");
        }


        public static bool ValidarNumeros(string linea)
        {
            return Regex.IsMatch(linea, @"^[0-9]+$");
        }

        public static bool ValidarLetras(string linea)
        {
            return Regex.IsMatch(linea, @"^[a-zA-Z]+$");
        }




    }
}
