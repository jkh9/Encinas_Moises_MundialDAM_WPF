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
    /// Lógica de interacción para CambioDePasswordWindow.xaml
    /// </summary>
    public partial class CambioDePasswordWindow : Window
    {
        public string Password { get; set; }
        private string passwordActual;

        public CambioDePasswordWindow(string passwordActual)
        {
            this.passwordActual = passwordActual;
            InitializeComponent();
        }

        public CambioDePasswordWindow()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            string contra1 = txtPassword.Password;
            string contra2 = txtConfirmarPassword.Password;

            if (contra1 == "" || contra2 == "")
            {
                MessageBox.Show("No pueden haber campos vacíos");
            }
            else if (contra1 == contra2 && contra1 == passwordActual)
            {
                MessageBox.Show("La misma contraseña no es válida");
            }
            else if (contra1 == contra2)
            {
                Password = contra1;
                this.Close();
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden");
            }
        }
    }
}
