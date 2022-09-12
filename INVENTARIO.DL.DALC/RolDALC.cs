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
     public class RolDALC
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ToString());
        SqlCommand cmd = new SqlCommand();

        public List<RolBE> ListarRol()
        {
            List<RolBE> listado = new List<RolBE>();
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Rol_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    RolBE rolBE = new RolBE();
                    rolBE.idRol = Convert.ToInt32(dr["ID"]);
                    rolBE.rol = dr["Rol"].ToString();

                    listado.Add(rolBE);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listado;
        }
    }
}
