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
    public class FotoDALC
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ToString());
        SqlCommand cmd = new SqlCommand();

        public List<FotoBE> ListaFoto()
        {
            List<FotoBE> listado = new List<FotoBE>();
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Foto_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    FotoBE fotoBE = new FotoBE();
                    fotoBE.idFoto = Convert.ToInt32(dr["ID"]);
                    fotoBE.URL = dr["URL"].ToString();

                    listado.Add(fotoBE);
                }
            }
            catch (Exception E)
            {
                throw;
            }
            return listado;
        }


        public bool AgregarFoto(FotoBE fotoBE)
        {
            bool agregado = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Foto_Agregar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmURL = new SqlParameter();
                prmURL.ParameterName = "@URL";
                prmURL.SqlDbType = SqlDbType.VarChar;
                prmURL.Value = fotoBE.URL;

                cmd.Parameters.Add(prmURL);

                cmd.ExecuteNonQuery();

                agregado = true;

            }
            catch (Exception)
            {
                throw;
            }
            return agregado;
        }

        public int ExisteFotoSINOagregar_ObtenerID(string url)
        {
            int id = 0;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Foto_ExisteFotoSINOagregar",cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmURL = new SqlParameter();
                prmURL.ParameterName = "@URL";
                prmURL.SqlDbType = SqlDbType.VarChar;
                prmURL.Value = url;

                cmd.Parameters.Add(prmURL);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    id = Convert.ToInt32(dr["IDFOTO"]);
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            return id;
        }
    }
}
