using PruebaLogica.Clases;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

List<Vehiculo> vehiculos = new List<Vehiculo>();
List<Taller> Talleres = new List<Taller>()
{
    new Taller {ID=1}
};
Mantenimiento mantenimiento = new Mantenimiento();
int i = 0;
//Console.ReadLine()

for (i = 1; i <= 8; i++)
{
    Vehiculo vehiculo = new Vehiculo()
    {
        Matricula = "MMAB-0" + i
    };
    vehiculos.Add(vehiculo);
};
Console.WriteLine(vehiculos.Count());


List<string> respuestas = new List<string>();
foreach (var vehiculo in vehiculos.ToList())
{
    bool errorFatal = false;
    vehiculo.CheckListOk = true;

    string resp = "";

    Random rnd = new Random();

    Console.WriteLine(" Nivel de Aceite Adecuado: ");
    if (rnd.Next(0, 3) == 0)
    {
        Console.WriteLine("No");
        vehiculo.CheckListOk = false;
        Console.WriteLine("Agregar comentario");
        resp = Console.ReadLine().ToLower();
        respuestas.Add(resp);
        resp = "";
    }
    else
    {
        Console.WriteLine("Si");
    }


    Console.WriteLine(" Llantas niveladas: ");
    if (rnd.Next(0, 3) == 0)
    {
        Console.WriteLine("No");
        vehiculo.CheckListOk = false;
        Console.WriteLine("Agregar comentario");
        resp = Console.ReadLine().ToLower();
        respuestas.Add(resp);
        resp = "";
    }
    else
    {
        Console.WriteLine("Si");
    }

    Console.WriteLine(" Motor Funcionando: ");
    if (rnd.Next(0, 3) == 0)
    {
        Console.WriteLine("No");
        vehiculo.CheckListOk = false;
        Console.WriteLine("Agregar comentario");
        resp = Console.ReadLine().ToLower();
        respuestas.Add(resp);
        errorFatal = true;
        resp = "";
    }
    else
    {
        Console.WriteLine("Si");
    }

    Console.WriteLine(" Bateria Cargada: ");
    if (rnd.Next(0, 3) == 0)
    {
        vehiculo.CheckListOk = false;
        Console.WriteLine("Agregar comentario");
        resp = Console.ReadLine().ToLower();
        respuestas.Add(resp);
        resp = "";
    }
    else
    {
        Console.WriteLine("Si");
    }

    if (!vehiculo.CheckListOk)
    {
        if (!errorFatal)
        {
            vehiculo.Estado = "En Reparacion";

        }
        else
        {
            vehiculo.Estado = "Taller Mecanico";
        }
    }
    else
    {
        vehiculo.Estado = "Disponible";
    }

    vehiculos.Remove(vehiculo);vehiculos.Add(vehiculo);
}
    Console.WriteLine("Estado de los vehiculos: ");
    foreach (var vehiculo in vehiculos.ToList())
    {
    var json = JsonSerializer.Serialize(vehiculo);
    Console.WriteLine(json);

    }

    var respJson = JsonSerializer.Serialize(respuestas);
    Console.WriteLine(respJson);

    await mantenimiento.ProcesarMantenimiento(vehiculos, Talleres);

    Console.ReadLine();

