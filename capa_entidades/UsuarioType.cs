using System;

namespace capa_entidades
{
    public class UsuarioType
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaAlta { get; set; }
        public int Rol { get; set; }
        public string Foto { get; set; }

        public UsuarioType(string usuario, string contraseña, string email,
            string nombre, string apellidos, DateTime fechaAlta, int rol, string foto)
        {
            Usuario = usuario;
            Contraseña = contraseña;
            Email = email;
            Nombre = nombre;
            Apellidos = apellidos;
            FechaAlta = fechaAlta;
            Rol = rol;
            Foto = foto;
        }

        public UsuarioType(string usuario, string email, 
            string nombre, string apellidos, int rol, string foto)
        {
            Usuario = usuario;
            Email = email;
            Nombre = nombre;
            Apellidos = apellidos;
            FechaAlta = DateTime.Now;
            Rol = rol;
            Foto = foto;
        }

    }
}
