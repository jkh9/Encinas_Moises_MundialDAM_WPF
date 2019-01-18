using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capa_datos;
using capa_entidades;

namespace capa_negocio
{
    public class ListaPartidos
    {
        private BD bd;
        private List<Partido> _partidos;

        public List<Partido> partidos { get { return _partidos; } }

        public ListaPartidos(BD bd)
        {
            this.bd = bd;
            _partidos = bd.LeerPartidos();
        }

        public int MundialesJugados(string equipo)
        {
            List<int> fechas = new List<int>();

            foreach(Partido p in partidos)
            { 
                if(p.EquipoLocal == equipo || p.EquipoVisitante == equipo)
                {
                    if(!fechas.Contains(p.Fecha.Year))
                    {
                        fechas.Add(p.Fecha.Year);
                    }
                }
            }

            return fechas.Count;
        }

        public int GolesAFavor(string equipo)
        {
            int count = 0;

            foreach (Partido p in partidos)
            {
                if (p.EquipoLocal == equipo)
                {
                    count += p.ResultadoLocal;
                }
                else if (p.EquipoVisitante == equipo)
                {
                    count += p.ResultadoVisitante;
                }
            }

            return count;
        }

        public int GolesEnContra(string equipo)
        {
            int count = 0;

            foreach (Partido p in partidos)
            {
                if (p.EquipoLocal == equipo)
                {
                    count += p.ResultadoVisitante;
                }
                else if (p.EquipoVisitante == equipo)
                {
                    count += p.ResultadoLocal;
                }
            }

            return count;
        }

        public List<Jugar> GetTitularesLocales(List<Jugar> jugadores, ListaJugadores listaJugadores)
        {
            List<Jugar> titulares = new List<Jugar>();

            foreach(Jugar j in jugadores)
            {
                if (j.EquipoLocal == listaJugadores.GetJugador(j.NombreJugador).EquipoJugador)
                {
                    titulares.Add(j);
                }
            }

            return titulares;
        }

        public List<Jugar> GetTitularesVisitantes(List<Jugar> jugadores, ListaJugadores listaJugadores)
        {
            List<Jugar> titulares = new List<Jugar>();

            foreach (Jugar j in jugadores)
            {
                if (j.EquiposVisitante == listaJugadores.GetJugador(j.NombreJugador).EquipoJugador)
                {
                    titulares.Add(j);
                }
            }

            return titulares;
        }

        public List<Gol> GetGolesL(List<Gol> goles, ListaJugadores listaJugadores)
        {
            List<Gol> golesL = new List<Gol>();

            foreach (Gol g in goles)
            {
                if (g.EquipoLocal == listaJugadores.GetJugador(g.Jugador).EquipoJugador)
                {
                    golesL.Add(g);
                }
            }

            return golesL;
        }

        public List<Gol> GetGolesV(List<Gol> goles, ListaJugadores listaJugadores)
        {
            List<Gol> golesV = new List<Gol>();

            foreach (Gol g in goles)
            {
                if (g.EquipoVisitante == listaJugadores.GetJugador(g.Jugador).EquipoJugador)
                {
                    golesV.Add(g);
                }
            }

            return golesV;
        }

        public Partido GetPartido(string equipoLocal, string equipoVisitante)
        {
            foreach (Partido p in partidos)
            {
                if (p.EquipoLocal == equipoLocal && p.EquipoVisitante == equipoVisitante)
                {
                    return p;
                }
            }

            return null;

        }

        public List<Partido> PartidosBuscados(string text)
        {
            text = text.ToLower();

            List<Partido> partidosBuscados = new List<Partido>();

            foreach(Partido p in partidos)
            {
                if (p.EquipoLocal.ToLower().Contains(text) ||
                    p.EquipoVisitante.ToLower().Contains(text) ||
                    p.EquipoLocal.ToLower().Contains(text))
                {
                    partidosBuscados.Add(p);
                }
            }

            return partidosBuscados;
        }

        public List<Partido> GetPartidosFecha(DateTime fecha)
        {
            List<Partido> partidosBuscados = new List<Partido>();

            foreach (Partido p in partidos)
            {
                if (p.Fecha.ToString("dd/MM/yyyy") == fecha.ToString("dd/MM/yyyy"))
                {
                    partidosBuscados.Add(p);
                }
            }

            return partidosBuscados;
        }

    }
}
