using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLogica.Clases
{
    public class Vehiculo
    {
        public string Matricula { get; set; } //es un dato unico
        public bool CheckListOk { get; set; }// si todo el checklist fue OK dará True si no False
        public string Estado { get; set; } // “Disponible” o “En Reparación” en caso de ser 
                                           //enviado a un taller externo
    }

}

