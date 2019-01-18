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
using capa_entidades;
using capa_negocio;

namespace capa_presentacion
{
    /// <summary>
    /// Lógica de interacción para FormLogIn.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        Negocio negocio;
        int intentos;
        UsuarioType usuario;


        public LogInWindow()
        {
            InitializeComponent();
            negocio = new Negocio();
            intentos = 0;
        }

        private void btnAcceder_Click(object sender, RoutedEventArgs e)
        {
            if (checkNewUser())
            {
                CambioDePasswordWindow formCambioContraseña = new CambioDePasswordWindow(txtPass.Password);
                formCambioContraseña.ShowDialog();

                string nuevaContraseña = formCambioContraseña.Password;
                if (nuevaContraseña != null)
                {
                    negocio.listaUsuarios.ModificarContraseña(nuevaContraseña, txtUsuario.Text);

                    this.Visibility = Visibility.Hidden;
                    PrincipalWindow formPrincipal = new PrincipalWindow(negocio.listaUsuarios.GetUsuario(txtUsuario.Text), negocio);
                    formPrincipal.ShowDialog();
                    this.Close();

                }
            }
            else
            {
                usuario = checkLogin();

                if (usuario != null)
                {
                    this.Visibility = Visibility.Hidden;
                    PrincipalWindow formPrincipal = new PrincipalWindow(usuario, negocio);
                    formPrincipal.ShowDialog();
                    this.Close();
                }
                else
                {
                    if (intentos == 3)
                    {
                        MessageBox.Show("Demasiados intentos se cerrara la aplicación");
                        this.Close();
                    }

                    MessageBox.Show("Nombre o contraseña incorrectos", "ERROR");
                    txtUsuario.Focus();
                    intentos++;
                }
            }
        }

        private UsuarioType checkLogin()
        {
            string user = txtUsuario.Text;
            string pass = txtPass.Password;

            return negocio.listaUsuarios.CheckLogin(user, pass);
        }

        private bool checkNewUser()
        {
            UsuarioType u = negocio.listaUsuarios.GetUsuario(txtPass.Password);

            if (u != null)
            {
                return u.Email == txtPass.Password;
            }

            return false;
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                if (MessageBox.Show("¿Esta seguro que desea salir?", "Salir de la aplicación", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
