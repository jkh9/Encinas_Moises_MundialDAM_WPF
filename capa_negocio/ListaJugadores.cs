using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capa_datos;
using capa_entidades;

namespace capa_negocio
{
    public class ListaJugadores
    {
        private BD bd;
        private List<Jugador> _jugadores;

        public List<Jugador> jugadores { get { return _jugadores; } }

        public ListaJugadores(BD bd)
        {
            this.bd = bd;

            _jugadores = bd.LeerJugadores();
        }

        public Jugador GetJugador(string nombre)
        {
            foreach (Jugador jugador in jugadores)
            {
                if (jugador.Nombre == nombre)
                {
                    return jugador;
                }
            }
            return null;
        }

        public int Modificar(Jugador jugadorModificado, string nombreJugadorModificar)
        {
            int filas_almacenadas;
           
            filas_almacenadas = bd.ModificarJugador(jugadorModificado, nombreJugadorModificar);

            modificarJugador(jugadorModificado, nombreJugadorModificar);

            return filas_almacenadas;
        }

        public List<Jugador> jugadoresBuscados(string busqueda)
        {
            List <Jugador> jugadoresBuscados= new List<Jugador>();

            busqueda = busqueda.ToLower();

            foreach(Jugador j in jugadores)
            {
                if(j.Nombre.ToLower().Contains(busqueda) ||
                    j.EquipoJugador.ToLower().Contains(busqueda))
                {
                    jugadoresBuscados.Add(j);
                }
            }

            return jugadoresBuscados;
        }

        private void modificarJugador(Jugador jugadorModificado, string nombreJugadorModificar)
        {
            for (int i = 0; i < _jugadores.Count; i++)
            {
                if (_jugadores[i].Nombre == nombreJugadorModificar)
                {
                    _jugadores[i] = jugadorModificado;
                }
            }
        }
    }
}
