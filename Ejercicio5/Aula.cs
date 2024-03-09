using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5
{
    public class Aula
    {
        public int Identificador { get; set; }
        public int CapacidadMax {  get; set; }
        public string Materia { get; set; }
        public Profesores Profesor { get; set; }
        public List<Estudiantes> Estudiantes { get; set; }

        public Aula(int identificador,int capacidadMaxima,string materia,Profesores profesor)
        {
            Identificador = identificador;
            CapacidadMax = capacidadMaxima;
            Materia = materia;
            Profesor = profesor;
            Estudiantes = new List<Estudiantes>();
        }
        public bool PuedeDarClase()
        {
            //Verifica si el profesor esta disponible y de la materia correspondiente.
            if (!Profesor.Disponible || Profesor.Materia!=Materia)
            {
               return false;
            }

            //Verificar si hay mas del 50% de estudiantes.
            int cantidadEstudiantes = Estudiantes.Count;

            int porcentajeEstudiantes = (cantidadEstudiantes * 100) / CapacidadMax;
           
            if (porcentajeEstudiantes<=50)
            {
                return false;
            }

            return true;
        
        }

        public void ContarEstudiantesAprobados()
        {
            int aprobadosMasculinos = 0, aprobadosFemeninos = 0;
            
            foreach(var estudiante in Estudiantes)
            {
                if (estudiante.Calificacion>=6)
                {
                    if (estudiante.Sexo=='M')
                    {
                        aprobadosMasculinos++;
                    }
                    else if (estudiante.Sexo=='F')
                    {
                        aprobadosFemeninos++;
                    }
                }
            }

        Console.WriteLine($"Cantidad de estudiantes masculinos aprobados:{aprobadosMasculinos}");
        Console.WriteLine($"Cantidad de estudiantes  femeninos aprobados:{aprobadosFemeninos}");


        }




    }
}
