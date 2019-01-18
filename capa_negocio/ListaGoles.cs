using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capa_entidades;
using capa_datos;

namespace capa_negocio
{
    public class ListaGoles
    {
        private BD bd;
        private ListaJugadores listaJugadores;
        private List<Gol> _goles;

        public List<Gol> goles { get { return _goles; } }

        public ListaGoles(BD bd, ListaJugadores listaJugadores)
        {
            this.bd = bd;
            this.listaJugadores = listaJugadores;
            _goles = bd.LeerGoles();
        }

        public int Borrar(Gol g)
        {
            int filas_almacenadas;

            filas_almacenadas = bd.BorrarGol(g);

            _goles.Remove(g);

            return filas_almacenadas;
        }

        public int Añadir(Gol g)
        {
            int filas_almacenadas;

            filas_almacenadas = bd.AñadirGol(g);

            _goles.Add(g);

            return filas_almacenadas;
        }

        public string MaximoGoleador(string equipo)
        {
            int cont = 0;
            string name = "";

            foreach(Gol g in goles)
            {
                if(listaJugadores.GetJugador(g.Jugador).EquipoJugador == equipo)
                {
                    int jugadorCont = 0;
                    foreach (Gol g1 in goles)
                    {
                        if (g.Jugador == g1.Jugador)
                        {
                            jugadorCont++;
                        }
                    }
                    if (jugadorCont > cont)
                    {
                        cont = jugadorCont;
                        name = g.Jugador;
                    }
                }
            }

            return name;
        }

        public Gol GetGol(int minuto, string nombre, List<Gol> golesPartido)
        {
            foreach (Gol g in golesPartido)
            {
                if (g.Minuto == minuto && g.Jugador == nombre)
                {
                    return g;
                }
            }
            return null;
        }

        public List<Gol> GetGoles(Partido partido)
        {
            List<Gol> golesPartido = new List<Gol>();

            foreach (Gol g in goles)
            {
                if(g.EquipoLocal == partido.EquipoLocal && g.EquipoVisitante == partido.EquipoVisitante)
                {
                    golesPartido.Add(g);
                }
            }

            return golesPartido;
        }
    }
}
