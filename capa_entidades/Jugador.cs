using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_entidades
{
    public class Jugador
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string PuestoHab { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string EquipoJugador { get; set; }

        public Jugador(string nombre, string direccion, string puestoHab, DateTime fechaNacimiento,
            string equipo)
        {
            Nombre = nombre;
            Direccion = direccion;
            PuestoHab = puestoHab;
            FechaNacimiento = fechaNacimiento;
            EquipoJugador = equipo;
        }

        public Jugador()
        {
        }
    }
}
