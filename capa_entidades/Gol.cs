using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_entidades
{
    public class Gol
    {
        public int Minuto { get; set; }
        public string Jugador { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public DateTime Fecha { get; set; }

        public Gol(int minuto, string jugador, string equipoLocal, string equipoVisitante, DateTime fecha)
        {
            Minuto = minuto;
            Jugador = jugador;
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            Fecha = fecha;
        }
    }
}
