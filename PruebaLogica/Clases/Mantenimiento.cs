using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PruebaLogica.Clases
{
    public class Mantenimiento
    {
        public async Task ProcesarMantenimiento(List<Vehiculo> Lista, List<Taller> Talleres)
        
        {
            foreach (var vehiculo in Lista) {            
                if (vehiculo.Estado == "En Reparacion")
                {
                    var Taller = Talleres.FirstOrDefault(t => t.Vehiculos.Count() < 4);

                    if (Taller != null)
                    {
                        Taller.Vehiculos.Add(vehiculo);
                        var item = Talleres.FirstOrDefault(u => u.ID == Taller.ID);

                        Talleres.Remove(item); Talleres.Add(Taller);
                    }
                    else
                    {
                        vehiculo.Estado = "Taller Mecanico";
                    }
                }
            }

            List<Task> listOfTasks = new List<Task>();
            foreach (var item in Talleres)
            {
                listOfTasks.Add(item.RealizarMantenimientos());
            }

            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine("Espere resultados...");
            await Task.WhenAll(listOfTasks).ConfigureAwait(false);
            sw.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = sw.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("Tiempo de ejecución: " + elapsedTime);

            List<Vehiculo> listaTemp = Lista;
            foreach (var vehiculo in Lista.ToList())
            {
                if (vehiculo.Estado == "En Reparacion")
                {
                    vehiculo.Estado = "Disponible";
                    Lista.Remove(vehiculo); Lista.Add(vehiculo);
                }
            }
            Console.WriteLine("Finalizado: ");
            foreach (var vehiculo in Lista.ToList())
            {
                var json = JsonSerializer.Serialize(vehiculo);
                Console.WriteLine(json);
                
            }
        }

    }
}
