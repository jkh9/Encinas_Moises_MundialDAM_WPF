using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capa_datos;
using capa_entidades;

namespace capa_negocio
{
    public class ListaUsuarios
    {
        private BD bd;
        private List<UsuarioType> _usuarios;

        public List<UsuarioType> usuarios { get { return _usuarios; } }

        public ListaUsuarios(BD bd)
        {
            this.bd = bd;
            _usuarios = bd.LeerUsuarios();

            crearUsuarioPredefinido();
        }

        public int Añadir(string usuario, string email, string nombre,
            string apellidos, int rol, string foto)
        {
            int filas_almacenadas;

            UsuarioType u = new UsuarioType(usuario, email, nombre, apellidos, rol, foto);

            if (usuarios.Contains(u))
            {
                return 0;
            }
            else
            {
                filas_almacenadas = bd.AñadirUsuario(u);

                _usuarios = bd.LeerUsuarios();
            }

            return filas_almacenadas;
        }

        public int Borrar(UsuarioType usuario)
        {
            int filas_almacenadas;

            filas_almacenadas = bd.BorrarUsuario(usuario.Usuario);

            _usuarios = bd.LeerUsuarios();

            return filas_almacenadas;
        }

        public UsuarioType CheckLogin(string nombre, string pass)
        {
            if (nombre == "" || pass == "")
            {
                return null;
            }

            foreach (UsuarioType usuario in usuarios)
            {
                if (usuario.Usuario == nombre && usuario.Contraseña == pass)
                {
                    return usuario;
                }
            }
            return null;
        }

        public UsuarioType GetUsuario(string nombre)
        {
            foreach (UsuarioType user in usuarios)
            {
                if (user.Usuario == nombre)
                {
                    return user;
                }
            }
            return null;
        }

        public int Modificar(string usuario, string email, string nombre,
            string apellidos, int rol, string foto, UsuarioType usuarioActual)
        {
            int filas_almacenadas;

            UsuarioType u = new UsuarioType(usuario, usuarioActual.Contraseña,
                email, nombre, apellidos, usuarioActual.FechaAlta, rol, foto);

            filas_almacenadas = bd.ModificarUsuario(u, usuarioActual.Usuario);

            _usuarios = bd.LeerUsuarios();

            return filas_almacenadas;
        }

        public int ModificarContraseña(string contraseña, string usuario)
        {
            int filas_almacenadas;

            UsuarioType u = GetUsuario(usuario);
            u.Contraseña = contraseña;

            filas_almacenadas = bd.ModificarUsuario(u, usuario);

            _usuarios = bd.LeerUsuarios();

            return filas_almacenadas;
        }

        private void crearUsuarioPredefinido()
        {
            if(GetUsuario("mario") == null)
            {
                Añadir("mario", "", "Mario", "", 1000, "");
                ModificarContraseña("1234", "mario");
            }
        }

    }
}
