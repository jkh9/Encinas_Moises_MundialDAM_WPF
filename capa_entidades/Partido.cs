using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_entidades
{
    public class Partido
    {
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Sede { get; set; }
        public int ResultadoLocal { get; set; }
        public int ResultadoVisitante { get; set; }
        public int Asistencia { get; set; }

        public Partido(string equipoLocal, string equipoVisitante, DateTime fecha, 
            string hora, string sede, int resultadoLocal, int resultadoVisitante, int asistencia)
        {
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            Fecha = fecha;
            Hora = hora;
            Sede = sede;
            ResultadoLocal = resultadoLocal;
            ResultadoVisitante = resultadoVisitante;
            Asistencia = asistencia;
        }
    }
}
