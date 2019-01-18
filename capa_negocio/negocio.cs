using capa_datos;
using System.Threading;

namespace capa_negocio
{
    public class Negocio
    {
        // atributos
        private BD bd;
        public ListaUsuarios listaUsuarios { get; set; }
        public ListaJugadores listaJugadores { get; set; }
        public ListaEquipos listaEquipos { get; set; }
        public ListaPartidos listaPartidos { get; set; }
        public ListaJugar listaJugar { get; set; }
        public ListaGoles listaGoles { get; set; }

        public Negocio()
        {
            // Creo la Base de datos si no existia
            bd = new BD();

            listaUsuarios = new ListaUsuarios(bd);

            (new Thread(() =>
            {
                    listaEquipos = new ListaEquipos(bd);
            })).Start();

            (new Thread(() =>
            {
                listaJugadores = new ListaJugadores(bd);
            })).Start();

            (new Thread(() =>
            {
                    listaPartidos = new ListaPartidos(bd);
            })).Start();

            (new Thread(() =>
            {
                    listaJugar = new ListaJugar(bd);
            })).Start();

            (new Thread(() =>
            {
                    listaGoles = new ListaGoles(bd, listaJugadores);
            })).Start();
        }
    }
}
