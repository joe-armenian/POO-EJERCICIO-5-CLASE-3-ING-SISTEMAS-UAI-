using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5
{
    public class Estudiantes
    {
        public string Nombre { get; set; }

        public int Edad { get; set; }

        public char Sexo { get; set; }

        public double Calificacion { get; set; }

        public Estudiantes(string nombre,int edad,char sexo,double calificacion)
        {
            Nombre = nombre;
            Edad = edad;
            Sexo = sexo;
            Calificacion = calificacion;
        }
        /// <summary>
        /// Metodo para que el estudiante realice tareas de extension
        /// </summary>
        public virtual void RealizarTareaExtensio()
        {
            Random rnd = new Random();

            if (rnd.Next(2)==0) //50  de posibilidad
            {
                Console.WriteLine($"{Nombre} esta realizando una tarea de extension");

            }
            else
            {
                Console.WriteLine($"{Nombre} asistira a clase normalmente.");
            }

        }

    }
}
