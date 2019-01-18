using System;
using System.Windows;
using capa_entidades;
using capa_negocio;

namespace capa_presentacion
{
    /// <summary>
    /// Lógica de interacción para FormPrincipal.xaml
    /// </summary>
    public partial class PrincipalWindow : Window
    {
        public UsuarioType usuario;
        public Negocio negocio;

        public PrincipalWindow(UsuarioType usuario, Negocio negocio)
        {
            InitializeComponent();
            this.usuario = usuario;
            lblNombre.Text = usuario.Nombre;
            lblTipo.Text = usuario.Rol == 1001 ? "Común" : "Administrador";

            comprobarPermisos();

            this.negocio = negocio;

            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void comprobarPermisos()
        {
            if (usuario.Rol == 1001)
            {
                lblUsuarioAPP.IsEnabled = false;
            }
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea salir?", "Salir de la aplicación", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnWindowClosing(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblHoraSistema.Text = DateTime.Now.ToString("HH:mm:ss");
            lblHorasUso.Text = Convert.ToDateTime(lblHorasUso.Text).AddMilliseconds(1000).ToString("HH:mm:ss");
        }

        private void UsuariosAPP_Click(object sender, RoutedEventArgs e)
        {
        
            UsuariosWindow usuariosWindow = new UsuariosWindow(negocio.listaUsuarios,this.lblStatus, usuario.Usuario);
            VentanaContenedora.Children.Clear();
            VentanaContenedora.HorizontalAlignment = HorizontalAlignment.Center;
            VentanaContenedora.VerticalAlignment = VerticalAlignment.Center;
            VentanaContenedora.Children.Add(usuariosWindow);
        }

        private void Jugadores_Click(object sender, RoutedEventArgs e)
        {
            //JugadoresWindow jugadoresWindow = new JugadoresWindow(negocio.listaJugadores, negocio.listaEquipos);
            //VentanaContenedora.Children.Clear();
            //VentanaContenedora.Children.Add(jugadoresWindow);
        }

        private void Equipos_Click(object sender, RoutedEventArgs e)
        {
            //EquiposWindow equiposWindow = new EquiposWindow(negocio.listaEquipos, negocio.listaPartidos, negocio.listaGoles);
            //VentanaContenedora.Children.Clear();
            //VentanaContenedora.Children.Add(equiposWindow);
        }

        private void Partidos_Click(object sender, RoutedEventArgs e)
        {
            //PartidosWindow partidosWindow = new PartidosWindow(negocio.listaPartidos, negocio.listaJugar,
            //    negocio.listaGoles, negocio.listaJugadores, this);
            //VentanaContenedora.Children.Clear();
            //VentanaContenedora.Children.Add(partidosWindow);
        }

        private void InformePartido_Click(object sender, RoutedEventArgs e)
        {
            //InformePartidoWindow informePartidoWindow = new InformePartidoWindow(negocio.listaEquipos.equipos[0]);
            //VentanaContenedora.Children.Clear();
            //VentanaContenedora.Children.Add(informePartidoWindow);
        }

        private void InformePartidos_Click(object sender, RoutedEventArgs e)
        {
            //InformePartidosWindow informePartidosWindow = new InformePartidosWindow();
            //VentanaContenedora.Children.Clear();
            //VentanaContenedora.Children.Add(informePartidosWindow);
        }

        private void AcercaDe_Click(object sender, RoutedEventArgs e)
        {
            //AcercaDeWindow acercaDeWindow = new AcercaDeWindow();
            //VentanaContenedora.Children.Clear();
            //VentanaContenedora.Children.Add(acercaDeWindow);
        }
    }
}
