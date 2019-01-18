using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capa_entidades;
using capa_datos;

namespace capa_negocio
{
    public class ListaJugar
    {
        private BD bd;
        private List<Jugar> _juegos;

        public List<Jugar> juegos { get { return _juegos; } }

        public ListaJugar(BD bd)
        {
            this.bd = bd;
            _juegos = bd.LeerJuegos();

        }

        public Jugar GetJugadorPartido(Partido partidoActual, string nombreJugador)
        {
            foreach (Jugar juego in juegos)
            {
                if (juego.EquipoLocal == partidoActual.EquipoLocal && juego.EquiposVisitante == partidoActual.EquipoVisitante
                    && juego.NombreJugador == nombreJugador)
                {
                    return juego;
                }
            }

            return null;
        }

        public List<Jugar> GetJugadoresPartido(Partido partidoActual)
        {
            List<Jugar> jugadoresPartido = new List<Jugar>();

            foreach (Jugar juego in juegos)
            {
                if(juego.EquipoLocal == partidoActual.EquipoLocal && juego.EquiposVisitante == partidoActual.EquipoVisitante)
                {
                    jugadoresPartido.Add(juego);
                }
            }

            jugadoresPartido.Sort((x, y) => y.MinutosJugados.CompareTo(x.MinutosJugados));

            return jugadoresPartido;
        }

        public Jugar GetPortero(List<Jugar> titulares)
        {
            foreach (Jugar juego in titulares)
            {
                if (juego.Puesto == "AR")
                {
                    return juego;
                }
            }

            return null;
        }

        public List<Jugar> GetDefensas(List<Jugar> titulares)
        {
            List<Jugar> defensas = new List<Jugar>();

            foreach (Jugar juego in titulares)
            {
                if (juego.Puesto == "DF")
                {
                    defensas.Add(juego);
                }
            }

            return defensas;
        }

        public List<Jugar> GetMedioCampos(List<Jugar> titulares)
        {
            List<Jugar> medioCampos = new List<Jugar>();

            foreach (Jugar juego in titulares)
            {
                if (juego.Puesto == "MC")
                {
                    medioCampos.Add(juego);
                }
            }

            return medioCampos;
        }

        public List<Jugar> GetDelanteros(List<Jugar> titulares)
        {
            List<Jugar> delanteros = new List<Jugar>();

            foreach (Jugar juego in titulares)
            {
                if (juego.Puesto == "DL")
                {
                    delanteros.Add(juego);
                }
            }

            return delanteros;
        }
    }
}
