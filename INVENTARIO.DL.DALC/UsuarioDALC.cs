using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using INVENTARIO.BL.BE;
using System.Configuration;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace INVENTARIO.DL.DALC
{
    public class UsuarioDALC
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ToString());
        SqlCommand cmd = new SqlCommand();

        public bool ValidarLogin(string usuario, string password)
        {
            bool ingresa = false;
            string usuarioLogeado = "";
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Usuario_Login",cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmUsuario = new SqlParameter();
                prmUsuario.ParameterName = "@usuario";
                prmUsuario.SqlDbType = SqlDbType.VarChar;
                prmUsuario.Size = 30;
                prmUsuario.Value  = usuario;

                SqlParameter prmPassword = new SqlParameter();
                prmPassword.ParameterName = "@password";
                prmPassword.SqlDbType = SqlDbType.VarChar;
                prmPassword.Size = 30;
                prmPassword.Value = password;

                cmd.Parameters.Add(prmUsuario);
                cmd.Parameters.Add(prmPassword);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    string nomb = dr["nombres"].ToString();
                    string apeP = dr["apellidoPaterno"].ToString();
                    string apeM = dr["apellidoMaterno"].ToString();
                    usuarioLogeado = nomb + " " + apeP;

                    ingresa = true;
                }
                cn.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return ingresa;
        }

        public List<UsuarioBE> ListaUsuarios()
        {
            List<UsuarioBE> lista = new List<UsuarioBE>();
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Usuario_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    UsuarioBE usuarioBE = new UsuarioBE();
                    usuarioBE.idUsuario = Convert.ToInt32(dr["ID"]);
                    usuarioBE.nombres = dr["Nombres"].ToString();
                    usuarioBE.apellidoPaterno = dr["Apellido Paterno"].ToString();
                    usuarioBE.apellidoMaterno = dr["Apellido Materno"].ToString();
                    usuarioBE.dni = dr["Dni"].ToString();
                    usuarioBE.telefono = dr["Telefono"].ToString();
                    usuarioBE.direccion = dr["Direccion"].ToString();
                    usuarioBE.ususario = dr["Usuario"].ToString();
                    usuarioBE.password = dr["Password"].ToString();
                    usuarioBE.intentos = Convert.ToInt32(dr["Intentos"]);
                    usuarioBE.estado = Convert.ToByte(dr["Estado"]);
                    usuarioBE.rolBE.rol = dr["Rol"].ToString();

                    lista.Add(usuarioBE);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        public List<UsuarioBE> ListaUsuariosBloqueados()
        {
            List<UsuarioBE> lista = new List<UsuarioBE>();
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Usuario_ListaBloqueados", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    UsuarioBE usuarioBE = new UsuarioBE();
                    usuarioBE.idUsuario = Convert.ToInt32(dr["ID"]);
                    usuarioBE.nombres = dr["Nombres"].ToString();
                    usuarioBE.apellidoPaterno = dr["Apellido Paterno"].ToString();
                    usuarioBE.apellidoMaterno = dr["Apellido Materno"].ToString();
                    usuarioBE.dni = dr["Dni"].ToString();
                    usuarioBE.telefono = dr["Telefono"].ToString();
                    usuarioBE.direccion = dr["Direccion"].ToString();
                    usuarioBE.ususario = dr["Usuario"].ToString();
                    usuarioBE.password = dr["Password"].ToString();
                    usuarioBE.intentos = Convert.ToInt32(dr["Intentos"]);
                    usuarioBE.estado = Convert.ToByte(dr["Estado"]);
                    usuarioBE.rolBE.rol = dr["Rol"].ToString();

                    lista.Add(usuarioBE);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        public UsuarioBE BuscarXid(int idUsuario)
        {
            UsuarioBE usuarioBE = new UsuarioBE();
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Usuario_BuscarXid", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmIdUsuario = new SqlParameter();
                prmIdUsuario.ParameterName = "@idUsuario";
                prmIdUsuario.SqlDbType = SqlDbType.Int;
                prmIdUsuario.Value = idUsuario;

                cmd.Parameters.Add(prmIdUsuario);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    usuarioBE.idUsuario = Convert.ToInt32(dr["ID"]);
                    usuarioBE.nombres = dr["Nombres"].ToString();
                    usuarioBE.apellidoPaterno = dr["Apellido Paterno"].ToString();
                    usuarioBE.apellidoMaterno = dr["Apellido Materno"].ToString();
                    usuarioBE.dni = dr["Dni"].ToString();
                    usuarioBE.telefono = dr["Telefono"].ToString();
                    usuarioBE.direccion = dr["Direccion"].ToString();
                    usuarioBE.ususario = dr["Usuario"].ToString();
                    usuarioBE.password = dr["Password"].ToString();
                    usuarioBE.intentos = Convert.ToInt32(dr["Intentos"]);
                    usuarioBE.estado = Convert.ToByte(dr["Estado"]);
                    usuarioBE.rolBE.rol = dr["Rol"].ToString();

                }
                cn.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return usuarioBE;
        }
        public bool AgregarUsuario(UsuarioBE usuarioBE)
        {
            bool agregado = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Usuario_Agregar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmNombres = new SqlParameter();
                prmNombres.ParameterName = "@nombres";
                prmNombres.SqlDbType = SqlDbType.VarChar;
                prmNombres.Size = 45;
                prmNombres.Value = usuarioBE.nombres;

                SqlParameter prmApellidoPaterno = new SqlParameter();
                prmApellidoPaterno.ParameterName = "@apellidoPaterno";
                prmApellidoPaterno.SqlDbType = SqlDbType.VarChar;
                prmApellidoPaterno.Size = 30;
                prmApellidoPaterno.Value = usuarioBE.apellidoPaterno;

                SqlParameter prmApellidoMaterno = new SqlParameter();
                prmApellidoMaterno.ParameterName = "@apellidoMaterno";
                prmApellidoMaterno.SqlDbType = SqlDbType.VarChar;
                prmApellidoMaterno.Size = 30;
                prmApellidoMaterno.Value = usuarioBE.apellidoMaterno;

                SqlParameter prmDNI = new SqlParameter();
                prmDNI.ParameterName = "@dni";
                prmDNI.SqlDbType = SqlDbType.Char;
                prmDNI.Size = 8;
                prmDNI.Value = usuarioBE.dni;

                SqlParameter prmTelefono = new SqlParameter();
                prmTelefono.ParameterName = "@telefono";
                prmTelefono.SqlDbType = SqlDbType.VarChar;
                prmTelefono.Size = 24;
                prmTelefono.Value = usuarioBE.telefono;

                SqlParameter prmDireccion = new SqlParameter();
                prmDireccion.ParameterName = "@direccion";
                prmDireccion.SqlDbType = SqlDbType.VarChar;
                prmDireccion.Size = 50;
                prmDireccion.Value = usuarioBE.direccion;

                SqlParameter prmUsuario = new SqlParameter();
                prmUsuario.ParameterName = "@usuario";
                prmUsuario.SqlDbType = SqlDbType.VarChar;
                prmUsuario.Size = 30;
                prmUsuario.Value = usuarioBE.ususario;

                SqlParameter prmIdRol = new SqlParameter();
                prmIdRol.ParameterName = "@idRol";
                prmIdRol.SqlDbType = SqlDbType.Int;
                prmIdRol.Value = usuarioBE.rolBE.idRol;

                cmd.Parameters.Add(prmNombres);
                cmd.Parameters.Add(prmApellidoPaterno);
                cmd.Parameters.Add(prmApellidoMaterno);
                cmd.Parameters.Add(prmDNI);
                cmd.Parameters.Add(prmTelefono);
                cmd.Parameters.Add(prmDireccion);
                cmd.Parameters.Add(prmUsuario);
                cmd.Parameters.Add(prmIdRol);

                cmd.ExecuteNonQuery();

                agregado = true;
            }
            catch (Exception)
            {
                throw;
            }
            return agregado;
        }

        public bool ActualizarUsuario(UsuarioBE usuarioBE)
        {
            bool actualizado = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Usuario_Actualizar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmIdUsuario = new SqlParameter();
                prmIdUsuario.ParameterName = "@idUsuario";
                prmIdUsuario.SqlDbType = SqlDbType.Int;
                prmIdUsuario.Value = usuarioBE.idUsuario;

                SqlParameter prmNombres = new SqlParameter();
                prmNombres.ParameterName = "@nombres";
                prmNombres.SqlDbType = SqlDbType.VarChar;
                prmNombres.Size = 45;
                prmNombres.Value = usuarioBE.nombres;

                SqlParameter prmApellidoPaterno = new SqlParameter();
                prmApellidoPaterno.ParameterName = "@apellidoPaterno";
                prmApellidoPaterno.SqlDbType = SqlDbType.VarChar;
                prmApellidoPaterno.Size = 30;
                prmApellidoPaterno.Value = usuarioBE.apellidoPaterno;

                SqlParameter prmApellidoMaterno = new SqlParameter();
                prmApellidoMaterno.ParameterName = "@apellidoMaterno";
                prmApellidoMaterno.SqlDbType = SqlDbType.VarChar;
                prmApellidoMaterno.Size = 30;
                prmApellidoMaterno.Value = usuarioBE.apellidoMaterno;

                SqlParameter prmDNI = new SqlParameter();
                prmDNI.ParameterName = "@dni";
                prmDNI.SqlDbType = SqlDbType.Char;
                prmDNI.Size = 8;
                prmDNI.Value = usuarioBE.dni;

                SqlParameter prmTelefono = new SqlParameter();
                prmTelefono.ParameterName = "@telefono";
                prmTelefono.SqlDbType = SqlDbType.VarChar;
                prmTelefono.Size = 24;
                prmTelefono.Value = usuarioBE.telefono;

                SqlParameter prmDireccion = new SqlParameter();
                prmDireccion.ParameterName = "@direccion";
                prmDireccion.SqlDbType = SqlDbType.VarChar;
                prmDireccion.Size = 50;
                prmDireccion.Value = usuarioBE.direccion;

                SqlParameter prmUsuario = new SqlParameter();
                prmUsuario.ParameterName = "@usuario";
                prmUsuario.SqlDbType = SqlDbType.VarChar;
                prmUsuario.Size = 30;
                prmUsuario.Value = usuarioBE.ususario;

                SqlParameter prmEstado = new SqlParameter();
                prmEstado.ParameterName = "@estado";
                prmEstado.SqlDbType = SqlDbType.Bit;
                prmEstado.Value = usuarioBE.estado;

                SqlParameter prmIdRol = new SqlParameter();
                prmIdRol.ParameterName = "@idRol";
                prmIdRol.SqlDbType = SqlDbType.Int;
                prmIdRol.Value = usuarioBE.rolBE.idRol;

                cmd.Parameters.Add(prmIdUsuario);
                cmd.Parameters.Add(prmNombres);
                cmd.Parameters.Add(prmApellidoPaterno);
                cmd.Parameters.Add(prmApellidoMaterno);
                cmd.Parameters.Add(prmDNI);
                cmd.Parameters.Add(prmTelefono);
                cmd.Parameters.Add(prmDireccion);
                cmd.Parameters.Add(prmUsuario);
                cmd.Parameters.Add(prmEstado);
                cmd.Parameters.Add(prmIdRol);

                cmd.ExecuteNonQuery();

                actualizado = true;
            }
            catch (Exception)
            {
                throw;
            }
            return actualizado;
        }

        public bool ExisteUsuario(string usuario)
        {
            bool existe = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Usuario_ExisteUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmUsuario = new SqlParameter();
                prmUsuario.ParameterName = "@usuario";
                prmUsuario.SqlDbType = SqlDbType.VarChar;
                prmUsuario.Size = 30;
                prmUsuario.Value = usuario;

                cmd.Parameters.Add(prmUsuario);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    string usu = dr["usuario"].ToString();
                    string pass = dr["password"].ToString();
                    existe = true;
                }
                cn.Close();
                
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
        }

        public void ActualizarIntenosSumar(string usuario)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Usuario_ActualizarIntentosSumar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmUsuario = new SqlParameter();
                prmUsuario.ParameterName = "@usuario";
                prmUsuario.SqlDbType = SqlDbType.VarChar;
                prmUsuario.Size = 30;
                prmUsuario.Value = usuario;

                cmd.Parameters.Add(prmUsuario);

                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void ActualizarIntenosCero(string usuario)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Usuarios_ActualizarIntentosCero", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmUsuario = new SqlParameter();
                prmUsuario.ParameterName = "@usuario";
                prmUsuario.SqlDbType = SqlDbType.VarChar;
                prmUsuario.Size = 30;
                prmUsuario.Value = usuario;

                cmd.Parameters.Add(prmUsuario);

                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ActualizarEstado(string usuario, byte estado)
        {
            bool actualizado = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Usuarios_ActualizarEstado", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmUsuario = new SqlParameter();
                prmUsuario.ParameterName = "@usuario";
                prmUsuario.SqlDbType = SqlDbType.VarChar;
                prmUsuario.Size = 30;
                prmUsuario.Value = usuario;

                SqlParameter prmEstado = new SqlParameter();
                prmEstado.ParameterName = "@estado";
                prmEstado.SqlDbType = SqlDbType.Bit;
                prmEstado.Value = estado;

                cmd.Parameters.Add(prmUsuario);
                cmd.Parameters.Add(prmEstado);

                cmd.ExecuteNonQuery();
                cn.Close();

                actualizado = true;
            }
            catch (Exception)
            {
                throw;
            }
            return actualizado;
        }
        public bool NuevoPassword(string usuario, string password, string passwordNuevo)
        {
            bool actualizado = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Usuario_NuevoPassword",cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmUsuario = new SqlParameter();
                prmUsuario.ParameterName = "@usuario";
                prmUsuario.SqlDbType = SqlDbType.VarChar;
                prmUsuario.Size = 30;
                prmUsuario.Value = usuario;

                SqlParameter prmPassword = new SqlParameter();
                prmPassword.ParameterName = "@password";
                prmPassword.SqlDbType = SqlDbType.VarChar;
                prmPassword.Size = 30;
                prmPassword.Value = password;

                SqlParameter prmPasswordNuevo = new SqlParameter();
                prmPasswordNuevo.ParameterName = "@password_Nuevo";
                prmPasswordNuevo.SqlDbType = SqlDbType.VarChar;
                prmPasswordNuevo.Size = 30;
                prmPasswordNuevo.Value = passwordNuevo;

                cmd.Parameters.Add(prmUsuario);
                cmd.Parameters.Add(prmPassword);
                cmd.Parameters.Add(prmPasswordNuevo);

                cmd.ExecuteNonQuery();
                cn.Close();

                actualizado = true;
            }
            catch (Exception)
            {
                throw;
            }
            return actualizado;
        }
        public bool ReestablecerPassword(int idUsuario)
        {
            bool actualizado = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Usuario_ReestablecerPassword", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmIdUsuario = new SqlParameter();
                prmIdUsuario.ParameterName = "@idUsuario";
                prmIdUsuario.SqlDbType = SqlDbType.Int;
                prmIdUsuario.Value = idUsuario;

                cmd.Parameters.Add(prmIdUsuario);

                cmd.ExecuteNonQuery();
                cn.Close();

                actualizado = true;
            }
            catch (Exception)
            {
                throw;
            }
            return actualizado;
        }
        public int VerificarEstado(string usuario)
        {
            byte estado = 0;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Usuario_VerEstado", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmUsuario = new SqlParameter();
                prmUsuario.ParameterName = "@usuario";
                prmUsuario.SqlDbType = SqlDbType.VarChar;
                prmUsuario.Size = 30;
                prmUsuario.Value = usuario;

                cmd.Parameters.Add(prmUsuario);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    estado = Convert.ToByte(dr["estado"]);
                }
                cn.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return estado;
        }

        public int VerificarIntentos(string usuario)
        {
            int intentos = 0;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Usuario_VerIntentos", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmUsuario = new SqlParameter();
                prmUsuario.ParameterName = "@usuario";
                prmUsuario.SqlDbType = SqlDbType.VarChar;
                prmUsuario.Size = 30;
                prmUsuario.Value = usuario;

                cmd.Parameters.Add(prmUsuario);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    intentos = Convert.ToInt32(dr["intentos"]);
                }
                cn.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return intentos;
        }

        public int VerificarRol(string usuario)
        {
            int rol = 0;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Usuario_VerRol", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmUsuario = new SqlParameter();
                prmUsuario.ParameterName = "@usuario";
                prmUsuario.SqlDbType = SqlDbType.VarChar;
                prmUsuario.Size = 30;
                prmUsuario.Value = usuario;

                cmd.Parameters.Add(prmUsuario);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    rol = Convert.ToInt32(dr["idRol"]);
                }
                cn.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return rol;
        }
        public string VerificarPasswordNuevo(string usuario)
        {
            string password = "";
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Usuario_VerPasswordNuevo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmUsuario = new SqlParameter();
                prmUsuario.ParameterName = "@usuario";
                prmUsuario.SqlDbType = SqlDbType.VarChar;
                prmUsuario.Size = 30;
                prmUsuario.Value = usuario;

                cmd.Parameters.Add(prmUsuario);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    password = dr["password"].ToString();
                }
                cn.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return password;
        }
        public bool Eliminar(int idUsuario)
        {
            bool eliminado = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Usuario_Eliminar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmIdUsuario = new SqlParameter();
                prmIdUsuario.ParameterName = "@idUsuario";
                prmIdUsuario.SqlDbType = SqlDbType.Int;
                prmIdUsuario.Value = idUsuario;

                cmd.Parameters.Add(prmIdUsuario);
                cmd.ExecuteNonQuery();

                eliminado = true;
            }
            catch (Exception)
            {
                throw;
            }

            return eliminado;
        }


    }
}
