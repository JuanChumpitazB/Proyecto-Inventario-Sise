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
    public class UnidadDeMedidaDALC
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ToString());
        SqlCommand cmd = new SqlCommand();

        public List<UnidadDeMedidaBE> ListarMarcas()
        {
            List<UnidadDeMedidaBE> listado = new List<UnidadDeMedidaBE>();
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_UnidadDeMedida_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    UnidadDeMedidaBE unidadDeMedidaBE = new UnidadDeMedidaBE();
                    unidadDeMedidaBE.idUnidad = Convert.ToInt32(dr["ID"]);
                    unidadDeMedidaBE.descripcion = dr["Descripcion"].ToString();
                    unidadDeMedidaBE.simbolo = dr["Simbolo"].ToString();

                    listado.Add(unidadDeMedidaBE);
                }
            }
            catch (Exception E)
            {
                throw;
            }
            return listado;
        }

        public bool AgregarUnidadDeMedida(UnidadDeMedidaBE unidadDeMedidaBE)
        {
            bool agregado = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_UnidadDeMedida_Agregar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmDescripcion = new SqlParameter();
                prmDescripcion.ParameterName = "@descripcion";
                prmDescripcion.SqlDbType = SqlDbType.VarChar;
                prmDescripcion.Size = 10;
                prmDescripcion.Value = unidadDeMedidaBE.descripcion;

                SqlParameter prmSimbolo = new SqlParameter();
                prmSimbolo.ParameterName = "@simbolo";
                prmSimbolo.SqlDbType = SqlDbType.VarChar;
                prmSimbolo.Size = 5;
                prmSimbolo.Value = unidadDeMedidaBE.simbolo;

                cmd.Parameters.Add(prmDescripcion);
                cmd.Parameters.Add(prmSimbolo);

                cmd.ExecuteNonQuery();

                agregado = true;

            }
            catch(Exception)
            {
                throw;
            }
            return agregado;
        }
    }
}
