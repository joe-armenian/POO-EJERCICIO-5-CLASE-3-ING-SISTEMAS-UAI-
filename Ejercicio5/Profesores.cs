using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5
{
     public  class Profesores
    {
        public string Nombre { get; set; }

        public int Edad { get; set; }

        public char Sexo { get; set; }

        public string Materia { get; set; }
        public bool Disponible { get; set; }
        public Profesores() { }

        public Profesores(string nombre,int edad,char sexo,string materia)
        {
            Nombre = nombre;
            Edad = edad;
            Sexo = sexo;
            Materia = materia;
            Disponible = true; //x defecto el profe, esta disponble.
        }

        public virtual void Ausentar()
        {
            Random rnd = new Random();
            if (rnd.Next(5)==0) //20% de posibilidades que no este.
            {
                Disponible = false;
                Console.WriteLine($"{Nombre} no esta disponbile en este momento.");
            }
        }




    }
}
