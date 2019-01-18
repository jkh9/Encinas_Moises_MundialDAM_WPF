using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_entidades
{
    public class Jugar
    {
        public string NombreJugador { get; set; }
        public string EquipoLocal { get; set; }
        public string EquiposVisitante { get; set; }
        public DateTime Fecha { get; set; }
        public int MinutosJugados { get; set; }
        public string Puesto { get; set; }
        public int Dorsal { get; set; }

        public Jugar(string nombreJugador, string equipoLocal, string equiposVisitante, DateTime fecha, int minutosJugados, string puesto, int dorsal)
        {
            NombreJugador = nombreJugador;
            EquipoLocal = equipoLocal;
            EquiposVisitante = equiposVisitante;
            Fecha = fecha;
            MinutosJugados = minutosJugados;
            Puesto = puesto;
            Dorsal = dorsal;
        }
    }
}
