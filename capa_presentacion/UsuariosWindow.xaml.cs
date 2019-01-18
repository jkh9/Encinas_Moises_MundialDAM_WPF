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

using capa_negocio;
using capa_entidades;
using System.ComponentModel;
using System.Net.Mail;
using Microsoft.Win32;
using System.IO;
using System.Data;

namespace capa_presentacion
{
    /// <summary>
    /// Lógica de interacción para UsuariosWindow.xaml
    /// </summary>
    public partial class UsuariosWindow : UserControl
    {
        public string Status { get; set; }
        ListaUsuarios listaUsuarios;
        TextBlock status;
        UsuarioType usuarioActual;
        string usuarioLoggeado;
        DataTable dt;

        public UsuariosWindow(ListaUsuarios listaUsuarios, TextBlock status, string usuarioLoggeado)
        {
            this.usuarioLoggeado = usuarioLoggeado;
            this.status = status;
            this.listaUsuarios = listaUsuarios;
            usuarioActual = null;
            InitializeComponent();
            cargarDataGrid();
        }

        private void cargarDataGrid()
        {
            dt = new DataTable();

            DataColumn usuario = new DataColumn("Usuario", typeof(string));
            DataColumn email = new DataColumn("Email", typeof(string));
            DataColumn nombre = new DataColumn("Nombre", typeof(string));
            DataColumn apellidos = new DataColumn("Apellidos", typeof(string));
            DataColumn fechaAlta = new DataColumn("FechaAlta", typeof(string));
            DataColumn administrador = new DataColumn("Administrador", typeof(bool));
            DataColumn foto = new DataColumn("Foto", typeof(BitmapImage));

            dt.Columns.Add(usuario);
            dt.Columns.Add(email);
            dt.Columns.Add(nombre);
            dt.Columns.Add(apellidos);
            dt.Columns.Add(fechaAlta);
            dt.Columns.Add(administrador);
            dt.Columns.Add(foto);

            dgvUsuarios.ItemsSource = dt.AsDataView();

            dgvUsuarios.CanUserDeleteRows = false;

            mostrarUsuarios();
        }

        private bool isValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool usuarioValido()
        {
            status.Foreground = new SolidColorBrush(Colors.Red);
            if (txtUsuario.Text == "")
            {
                status.Text = ("El campo no puede estar vacio");
                return false;
            }
            else if (listaUsuarios.GetUsuario(txtUsuario.Text) != null)
            {
                status.Text = ("Usuario en uso");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool nombreValido()
        {
            status.Foreground = new SolidColorBrush(Colors.Red);
            if (txtNombre.Text == "")
            {
                status.Text = ("El campo no puede estar vacio");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool apellidosValido()
        {
            status.Foreground = new SolidColorBrush(Colors.Red);
            if (txtApellidos.Text == "")
            {
                status.Text = ("El campo no puede estar vacio");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool emailValido()
        {
            status.Foreground = new SolidColorBrush(Colors.Red);
            if (txtEmail.Text == "")
            {
                status.Text = ("El campo no puede estar vacio");
                return false;
            }
            else if (!isValid(txtEmail.Text))
            {
                status.Text = ("Email incorrecto");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void mostrarUsuarios()
        {
            dt.Rows.Clear();

            List<UsuarioType> aux;

            aux = listaUsuarios.usuarios;

            for (int i = 0; i < aux.Count; i++)
            {
                DataRow row = dt.NewRow();
                row[0] = aux[i].Usuario;
                row[1] = aux[i].Email;
                row[2] = aux[i].Nombre;
                row[3] = aux[i].Apellidos;
                row[4] = aux[i].FechaAlta.ToString("dd/MM/yyyy");
                row[5] = aux[i].Rol == 1000 ? true : false;
                try
                {
                    row[6] = new BitmapImage(new Uri(aux[i].Foto, UriKind.Absolute));
                }
                catch (Exception e)
                {
                    row[6] = new BitmapImage(new Uri("imgs/No-image-available.jpg", UriKind.Relative));
                }
                dt.Rows.Add(row);
            }

            dgvUsuarios.DataContext = dt;
        }

        private void showModifyRow()
        {
            txtUsuarioModify.Text = usuarioActual.Usuario;
            txtNombreModify.Text = usuarioActual.Nombre;
            txtApellidosModify.Text = usuarioActual.Apellidos;
            txtEmailModify.Text = usuarioActual.Email;
            cbRolModify.SelectedIndex = usuarioActual.Rol == 1001 ? 1 : 0;
            try
            {
                pbImageModify.Source = new BitmapImage(new Uri(usuarioActual.Foto));
            }
            catch (Exception)
            {
                pbImageModify.Source = new BitmapImage(new Uri("imgs/No-image-available.jpg", UriKind.Relative));
            }
        }

        private bool usuarioModificadoValido()
        {
            status.Foreground = new SolidColorBrush(Colors.Red);
            if (txtUsuarioModify.Text == "")
            {
                status.Text = ("El campo no puede estar vacio");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool nombreModificadoValido()
        {
            status.Foreground = new SolidColorBrush(Colors.Red);
            if (txtNombreModify.Text == "")
            {
                status.Text = ("El campo no puede estar vacio");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool apellidosModificadoValido()
        {
            status.Foreground = new SolidColorBrush(Colors.Red);
            if (txtApellidosModify.Text == "")
            {
                status.Text = ("El campo no puede estar vacio");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool emailModificadoValido()
        {
            status.Foreground = new SolidColorBrush(Colors.Red);
            if (txtEmailModify.Text == "")
            {
                status.Text = ("El campo no puede estar vacio");
                return false;
            }
            else if (!isValid(txtEmailModify.Text))
            {
                status.Text = ("Email incorrecto");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void pbImage_Click(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog getImage = new OpenFileDialog();
            getImage.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"imgs\";
            getImage.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)(*.png)| " +
                "*.jpg;*.jpeg;*.png; | All files(*.*) | *.* ";
            if (getImage.ShowDialog() == true)
            {
                string fileName = getImage.FileName.Substring(
                                        getImage.FileName.LastIndexOf('\\'));

                string sourceFile = getImage.FileName;
                string destFile =
                    AppDomain.CurrentDomain.BaseDirectory + @"imgs" + fileName;

                if (!File.Exists(destFile))
                {
                    File.Copy(sourceFile, destFile, true);
                }

                this.pbImage.Source = new BitmapImage(new Uri(destFile));
            }
            else
            {
                MessageBox.Show("No se selecciono ninguna imagen");
            }
        }

        private void imageModify_Click(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog getImage = new OpenFileDialog();
            getImage.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"imgs\";
            getImage.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)(*.png)| " +
                "*.jpg;*.jpeg;*.png; | All files(*.*) | *.* ";
            if (getImage.ShowDialog() == true)
            {
                string fileName = getImage.FileName.Substring(
                                        getImage.FileName.LastIndexOf('\\'));

                string sourceFile = getImage.FileName;
                string destFile =
                    AppDomain.CurrentDomain.BaseDirectory + @"imgs" + fileName;

                if (!File.Exists(destFile))
                {
                    File.Copy(sourceFile, destFile, true);
                }

                this.pbImageModify.Source = new BitmapImage(new Uri(destFile));
            }
            else
            {
                MessageBox.Show("No se selecciono ninguna imagen");
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;

            if (row_selected != null)
            {
                usuarioActual = listaUsuarios.GetUsuario(row_selected["usuario"].ToString());
                showModifyRow();
            }

            if (dgvUsuarios.SelectedIndex != -1)


                if (usuarioActual != null)
                    showModifyRow();
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            bool error = false;

            if (!usuarioValido())
            {
                txtUsuario.Focus();
                error = true;
            }
            if (!nombreValido())
            {
                txtNombre.Focus();
                error = true;
            }
            if (!apellidosValido())
            {
                txtApellidos.Focus();
                error = true;
            }
            if (!emailValido())
            {
                txtEmail.Focus();
                error = true;
            }

            if (!error)
            {
                string nombre = txtNombre.Text;
                string apellidos = txtApellidos.Text;
                string usuario = txtUsuario.Text;
                string email = txtEmail.Text;
                int rol = cbRol.SelectedItem.ToString() ==
                    "Administrador" ? 1000 : 1001;
                string imagePath = pbImage.Source.ToString();

                if (listaUsuarios.Añadir(usuario, email, nombre, apellidos,
                    rol, imagePath) != 0)
                {
                    status.Foreground = new SolidColorBrush(Colors.Green);
                    status.Text = "Insercion correcta     Durante el primer inicio tu contraseña será igual al correo";

                    mostrarUsuarios();

                    txtNombre.Clear();
                    txtApellidos.Clear();
                    txtUsuario.Clear();
                    txtEmail.Clear();
                    cbRol.SelectedIndex = 0;
                    pbImage.Source = new BitmapImage(new Uri("imgs/No-image-available.jpg", UriKind.Relative));
                }
                else
                {
                    status.Foreground = new SolidColorBrush(Colors.Red);
                    status.Text = "Problemas en la insercion";
                }
            }
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (usuarioActual != null)
            {
                if (usuarioActual.Usuario != usuarioLoggeado)
                {
                    if (listaUsuarios.Borrar(usuarioActual) != -1)
                    {
                        mostrarUsuarios();

                        status.Foreground = new SolidColorBrush(Colors.Green);
                        status.Text = "Borrado correctamente";

                        txtApellidosModify.Clear();
                        txtEmailModify.Clear();
                        txtNombreModify.Clear();
                        txtUsuarioModify.Clear();
                        cbRolModify.SelectedIndex = -1;
                        pbImageModify.Source = new BitmapImage(new Uri("imgs/No-image-available.jpg", UriKind.Relative));

                        usuarioActual = null;
                    }
                    else
                    {
                        status.Foreground = new SolidColorBrush(Colors.Red);
                        status.Text = "Problemas borrando de la bd";
                    }
                }
                else
                {
                    status.Foreground = new SolidColorBrush(Colors.Red);
                    status.Text = "No puedes borrar el usuario loggeado";
                }
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (usuarioActual != null)
            {
                bool error = false;

                if (!usuarioModificadoValido())
                {
                    txtUsuarioModify.Focus();
                    error = true;
                }

                if (!nombreModificadoValido())
                {
                    txtNombreModify.Focus();
                    error = true;
                }

                if (!apellidosModificadoValido())
                {
                    txtApellidosModify.Focus();
                    error = true;
                }

                if (!emailModificadoValido())
                {
                    txtEmailModify.Focus();
                    error = true;
                }

                if (!error)
                {
                    string nombre = txtNombreModify.Text;
                    string apellidos = txtApellidosModify.Text;
                    string usuario = txtUsuarioModify.Text;
                    string email = txtEmailModify.Text;
                    int rol = cbRolModify.SelectedItem.ToString() ==
                        "Administrador" ? 1000 : 1001;
                    string imagePath = (pbImageModify.Source as BitmapImage).UriSource.AbsoluteUri;

                    if (listaUsuarios.Modificar(usuario, email, nombre, apellidos,
                        rol, imagePath, usuarioActual) != 0)
                    {
                        status.Foreground = new SolidColorBrush(Colors.Green);
                        status.Text = "Modificacion correcta";

                        usuarioActual = listaUsuarios.GetUsuario(usuario);

                        mostrarUsuarios();

                        this.showModifyRow();
                    }
                    else
                    {
                        status.Foreground = new SolidColorBrush(Colors.Red);
                        status.Text = "Problemas en la modificación";
                    }
                    status.Foreground = new SolidColorBrush(Colors.Black);
                }
            }
        }
    }
}
