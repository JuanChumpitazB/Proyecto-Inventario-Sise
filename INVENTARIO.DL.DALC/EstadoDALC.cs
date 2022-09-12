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
    public class EstadoDALC
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ToString());
        SqlCommand cmd = new SqlCommand();

        public List<EstadoBE> ListarEstado()
        {
            List<EstadoBE> listado = new List<EstadoBE>();
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Estado_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    EstadoBE estadoBE = new EstadoBE();
                    estadoBE.idEstado = Convert.ToInt32(dr["ID"]);
                    estadoBE.descripcion = dr["Descripcion"].ToString();

                    listado.Add(estadoBE);
                }
            }
            catch (Exception E)
            {
                throw;
            }
            return listado;
        }


        public bool AgregarEstado(EstadoBE estadoBE)
        {
            bool agregado = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Estado_Agregar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmDescripcion = new SqlParameter();
                prmDescripcion.ParameterName = "@descripcion";
                prmDescripcion.SqlDbType = SqlDbType.VarChar;
                prmDescripcion.Size = 15;
                prmDescripcion.Value = estadoBE.descripcion;

                cmd.Parameters.Add(prmDescripcion);

                cmd.ExecuteNonQuery();

                agregado = true;
            }
            catch (Exception)
            {
                throw;
            }
            return agregado;
        }




    }
}
