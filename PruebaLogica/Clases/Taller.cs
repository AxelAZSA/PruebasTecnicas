using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLogica.Clases
{
    public class Taller
    {
        public int ID { get; set; } //identificador del taller ej. 1,2,3,4,5 hasta 10
        public List<Vehiculo> Vehiculos = new List<Vehiculo>(); // si un campo del arreglo no está
                                                 //asignado quiere decir que está disponible y si no está ocupado

        public async Task RealizarMantenimientos()
        {
            Console.WriteLine("Inicio mantenimiento");
            //este método devuelve si esta Disponible o en reparación y puede tardar hasta media 
            //hora en ejecutarse ya que se conecta a varios dispos<<<<<<<<<<<<<<<itivos fuentes externas. También asigna 
            //el vehiculo en la posición del talle y una vez finalice lo deja libre.
            //ejemplo: taller[posicion] = vehiculo;
            //realiza el proceso y luego taller[posicion]=null;
            Console.WriteLine(Vehiculos.Count());
            foreach (var item in Vehiculos)
            {
                Random rnd = new Random();
                int time = rnd.Next(1, 180);

                await Task.Delay(time * 1000);

            }

            Vehiculos = null;
        }
    }
}
//12 minutos maximo