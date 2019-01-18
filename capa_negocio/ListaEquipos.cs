using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capa_datos;
using capa_entidades;

namespace capa_negocio
{
    public class ListaEquipos
    {
        private BD bd;
        private List<Equipo> _equipos;

        public List<Equipo> equipos { get { return _equipos; } }

        public ListaEquipos(BD bd)
        {
            this.bd = bd;
            _equipos = bd.LeerEquipos();

        }

        public Equipo GetEquipo(string nombre)
        {
            foreach (Equipo equipo in equipos)
            {
                if (equipo.Nombre == nombre)
                {
                    return equipo;
                }
            }
            return null;
        }
        
    }
}
