using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace capa_presentacion
{
    /// <summary>
    /// Lógica de interacción para JugadoresWindow.xaml
    /// </summary>
    public partial class JugadoresWindow : Window
    {
        public JugadoresWindow(capa_negocio.ListaJugadores listaJugadores, capa_negocio.ListaEquipos listaEquipos)
        {
            InitializeComponent();
        }
    }
}
