using System;
using System.Collections.Generic;

// Librerias de oracle.
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

using capa_entidades;

namespace capa_datos
{
    public class BD
    {
        private OracleConnection _bd;

        public BD()
        {
            // Creo la conexion con la BD
            try
            {

                _bd = new OracleConnection();
                _bd.ConnectionString = "User ID=system; Password=1234; " +
                                       "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=localhost)(PORT=1521)) " +
                                       "(CONNECT_DATA = (SERVICE_NAME = xe)))";

                _bd.Open();
            }
            catch (Exception ex)
            {
                int i = 0;
            }
        }

        

        public List<UsuarioType> LeerUsuarios()
        {
            OracleCommand cmd;
            List<UsuarioType> c = new List<UsuarioType>();
            UsuarioType u;

            cmd = new OracleCommand("SELECT * FROM USUARIO_APP", _bd);
            cmd.CommandType = System.Data.CommandType.Text;

            try
            {
                OracleDataReader aux = cmd.ExecuteReader();

                while (aux.Read())
                {
                    string usuario = aux["NICK_USUARIO_APP"].ToString();
                    string contraseña = aux["CONTRASENYA_USUARIO_APP"].ToString();
                    string email = aux["EMAIL_USUARIO_APP"].ToString();
                    string nombre = aux["NOMBRE_USUARIO_APP"].ToString();
                    string apellidos = aux["APELLIDOS_USUARIO_APP"].ToString();
                    DateTime fechaAlta = Convert.ToDateTime(aux["FECHA_ALTA_USUARIO_APP"]);
                    int rol = Convert.ToInt32(aux["ROL_USUARIO_APP"]);
                    string foto = aux["FOTO_USUARIO_APP"].ToString();

                    u = new UsuarioType(usuario, contraseña, email, nombre, apellidos, fechaAlta, rol, foto);

                    c.Add(u);
                }
            }
            catch (Exception ex)
            {
                return c;
            }

            return c;
        }

        public int AñadirUsuario(UsuarioType u)
        {
            string sql = "INSERT INTO USUARIO_APP (ID_USUARIO_APP,NICK_USUARIO_APP, EMAIL_USUARIO_APP, " +
                "NOMBRE_USUARIO_APP, APELLIDOS_USUARIO_APP,FECHA_ALTA_USUARIO_APP, ROL_USUARIO_APP, FOTO_USUARIO_APP) "
             + " VALUES (USUARIO_APP_SEQ.nextval,'" + u.Usuario+"','" + u.Email + "','" + u.Nombre + "','" 
             + u.Apellidos + "','" + u.FechaAlta.ToString("dd/MM/yyyy") + "'," + u.Rol + ",'" + u.Foto + "')";

            OracleCommand cmd = _bd.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;
        }

        public int BorrarUsuario(string usuario)
        {
            string sql = "DELETE FROM USUARIO_APP WHERE NICK_USUARIO_APP = '" + usuario + "'";

            OracleCommand cmd = _bd.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;
        }

        public int ModificarUsuario(UsuarioType usuarioModificado, string nickUsuarioModificar)
        {
            string sql = "UPDATE USUARIO_APP SET NICK_USUARIO_APP = '" + usuarioModificado.Usuario + "', CONTRASENYA_USUARIO_APP = '"+usuarioModificado.Contraseña+"'," +
                "EMAIL_USUARIO_APP = '" + usuarioModificado.Email + "', " + 
                "NOMBRE_USUARIO_APP = '" + usuarioModificado.Nombre + "', APELLIDOS_USUARIO_APP = '" + usuarioModificado.Apellidos + "', " +
                "ROL_USUARIO_APP = " + usuarioModificado.Rol + ", FOTO_USUARIO_APP = '" + usuarioModificado.Foto + "' " +
                "WHERE NICK_USUARIO_APP = '"+nickUsuarioModificar+"' ";

            OracleCommand cmd = _bd.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;
        }


        public List<Equipo> LeerEquipos()
        {
            OracleCommand cmd;
            List<Equipo> equipos = new List<Equipo>();
            Equipo e;

            cmd = new OracleCommand("SELECT * FROM EQUIPOS", _bd);
            cmd.CommandType = System.Data.CommandType.Text;

            try
            {
                OracleDataReader aux = cmd.ExecuteReader();

                while (aux.Read())
                {
                    string nombre = aux["EQUIPO"].ToString();
                    string pais = aux["PAIS"].ToString();
                    string seleccionador = aux["SELECCIONADOR"].ToString();

                    e = new Equipo(nombre, pais, seleccionador);

                    equipos.Add(e);
                }
            }
            catch (Exception ex)
            {
                return equipos;
            }

            return equipos;
        }


        public List<Jugador> LeerJugadores()
        {
            OracleCommand cmd;
            List<Jugador> jugadores = new List<Jugador>();
            Jugador j;

            cmd = new OracleCommand("SELECT * FROM JUGADOR", _bd);
            cmd.CommandType = System.Data.CommandType.Text;

            try
            {
                OracleDataReader aux = cmd.ExecuteReader();

                while (aux.Read())
                {
                    string nombre = aux["NOMBRE"].ToString();
                    string direccion = aux["DIRECCION"].ToString();
                    string puesto = aux["PUESTO_HAB"].ToString();
                    DateTime fechaNacimiento = Convert.ToDateTime("01/01/0001");
                    string equipo = aux["EQUIPO_JUGADOR"].ToString();

                    j = new Jugador(nombre,direccion,puesto,fechaNacimiento,equipo);

                    jugadores.Add(j);
                }
            }
            catch (Exception ex)
            {
                return jugadores;
            }

            return jugadores;
        }

        public int ModificarJugador(Jugador jugadorModificado, string nombreJugadorModificar)
        {
            string sql = "UPDATE JUGADOR SET nombre = '"+jugadorModificado.Nombre+"', " +
                "direccion = '" + jugadorModificado.Direccion + "', puesto_hab = '" + jugadorModificado.PuestoHab + "', " +
                "fecha_nac = '" + jugadorModificado.FechaNacimiento.ToString("dd/MM/yyyy") + "',equipo_jugador = '" + jugadorModificado.EquipoJugador + "' " +
                "WHERE nombre = '" + nombreJugadorModificar+"'";

            OracleCommand cmd = _bd.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;
        }


        public List<Jugar> LeerJuegos()
        {
            OracleCommand cmd;
            List<Jugar> juegos = new List<Jugar>();
            Jugar j;

            cmd = new OracleCommand("SELECT * FROM JUGAR", _bd);
            cmd.CommandType = System.Data.CommandType.Text;

            try
            {
                OracleDataReader aux = cmd.ExecuteReader();

                while (aux.Read())
                {
                    string nombreJugador = aux["NOMBRE_JUG"].ToString();
                    string equipoLocal = aux["EQUIPO_L_PART"].ToString();
                    string equipoVisitante = aux["EQUIPO_V_PART"].ToString();
                    DateTime fecha = Convert.ToDateTime(aux["FECHA_PART"]);
                    int minutosJugados = Convert.ToInt32(aux["MIN_JUGAR"]);
                    string puesto = aux["PUESTO_JUGAR"].ToString();
                    int dorsal = Convert.ToInt32(aux["DORSAL"]);

                    j = new Jugar(nombreJugador, equipoLocal, equipoVisitante, fecha, minutosJugados, puesto, dorsal);

                    juegos.Add(j);
                }
            }
            catch (Exception ex)
            {
                return juegos;
            }

            return juegos;
        }


        public List<Partido> LeerPartidos()
        {
            OracleCommand cmd;
            List<Partido> partidos = new List<Partido>();
            Partido p;

            cmd = new OracleCommand("SELECT * FROM PARTIDO", _bd);
            cmd.CommandType = System.Data.CommandType.Text;

            try
            {
                OracleDataReader aux = cmd.ExecuteReader();

                while (aux.Read())
                {
                    string equipo_l = aux["EQUIPO_L"].ToString();
                    string equipo_v = aux["EQUIPO_V"].ToString();
                    DateTime fecha = Convert.ToDateTime(aux["FECHA"]);
                    string hora = aux["HORA"].ToString();
                    string sede = aux["SEDE"].ToString();
                    int resultado_l = Convert.ToInt32(aux["RESULTADO_L"].ToString());
                    int resultado_v = Convert.ToInt32(aux["RESULTADO_V"].ToString());
                    int asistencia = aux["ASISTENCIA"].ToString() == "" ? 0 : Convert.ToInt32(aux["ASISTENCIA"].ToString());

                    p = new Partido(equipo_l, equipo_v, fecha, hora, sede, resultado_l,
                        resultado_v, asistencia);

                    partidos.Add(p);
                }
            }
            catch (Exception ex)
            {
                return partidos;
            }

            return partidos;
        }

        public int ModificarPartidos(Partido partidoMoficado, string nombrePartidoModificar)
        {
            string sql = " ";

            OracleCommand cmd = _bd.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;
        }


        public List<Gol> LeerGoles()
        {
            OracleCommand cmd;
            List<Gol> goles = new List<Gol>();
            Gol gol;

            cmd = new OracleCommand("SELECT * FROM GOL", _bd);
            cmd.CommandType = System.Data.CommandType.Text;

            try
            {
                OracleDataReader aux = cmd.ExecuteReader();

                while (aux.Read())
                {
                    int minuto = Convert.ToInt32(aux["MINUTO"]);
                    string jugador = aux["JUGADOR_GOL"].ToString();
                    string equipoLocal = aux["EQUIPO_L_GOL"].ToString();
                    string equipoVisitante = aux["EQUIPO_V_GOL"].ToString();
                    DateTime fecha = Convert.ToDateTime(aux["FECHA_GOL"]);

                    gol = new Gol(minuto, jugador, equipoLocal, equipoVisitante,fecha);

                    goles.Add(gol);
                }
            }
            catch (Exception ex)
            {
                return goles;
            }

            return goles;
        }

        public int BorrarGol(Gol g)
        {
            string sql = "DELETE FROM GOL " +
                "WHERE minuto = "+g.Minuto+" AND JUGADOR_GOL = '"+g.Jugador+"' " +
                "AND EQUIPO_L_GOL = '"+g.EquipoLocal+"' " +
                "AND EQUIPO_V_GOL = '"+g.EquipoVisitante+"' AND FECHA_GOL = '"+g.Fecha+"'";

            OracleCommand cmd = _bd.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;
        }

        public int AñadirGol(Gol g)
        {
            string sql = "INSERT INTO GOL VALUES (" +
                ""+g.Minuto+ ",'" + g.Jugador + "','" + g.EquipoLocal + "'," +
                "'" + g.EquipoVisitante + "','" + g.Fecha + "');";

            OracleCommand cmd = _bd.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;
        }

        // Destructor de clase.
        ~BD()
        {
            _bd.Close();
        }
    }
}
