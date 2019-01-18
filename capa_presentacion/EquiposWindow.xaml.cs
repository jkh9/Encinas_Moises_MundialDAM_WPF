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
    /// Lógica de interacción para EquiposWindow.xaml
    /// </summary>
    public partial class EquiposWindow : Window
    {
        public EquiposWindow(capa_negocio.ListaEquipos listaEquipos, capa_negocio.ListaPartidos listaPartidos, capa_negocio.ListaGoles listaGoles)
        {
            InitializeComponent();
        }
    }
}
