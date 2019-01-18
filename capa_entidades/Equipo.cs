using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_entidades
{
    public class Equipo
    {
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Seleccionador { get; set; }

        public Equipo(string nombre, string pais, string seleccionador)
        {
            Nombre = nombre;
            Pais = pais;
            Seleccionador = seleccionador;
        }
    }
}
