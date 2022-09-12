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
    public class MarcaDALC
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ToString());
        SqlCommand cmd = new SqlCommand();

        public List<MarcaBE> ListarMarcas()
        {
            List<MarcaBE> listado = new List<MarcaBE>();
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Marca_Listar",cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    MarcaBE marcaBE = new MarcaBE();
                    marcaBE.idMarca = Convert.ToInt32(dr["ID"]);
                    marcaBE.marca = dr["Marca"].ToString();
                    marcaBE.categoriaBE.categoria = dr["Categoria"].ToString();

                    listado.Add(marcaBE);
                }
            }
            catch (Exception E)
            {
                throw;
            }
            return listado;
        }

        public bool AgregarMarca(MarcaBE marcaBE)
        {
            bool agregado = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Marca_Agregar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmMarca = new SqlParameter();
                prmMarca.ParameterName = "@marca";
                prmMarca.SqlDbType = SqlDbType.VarChar;
                prmMarca.Size = 40;
                prmMarca.Value = marcaBE.marca;

                SqlParameter prmIdCategoria = new SqlParameter();
                prmIdCategoria.ParameterName = "@idCategoria";
                prmIdCategoria.SqlDbType = SqlDbType.Int;
                prmIdCategoria.Value = marcaBE.categoriaBE.idCategoria;

                cmd.Parameters.Add(prmMarca);
                cmd.Parameters.Add(prmIdCategoria);

                cmd.ExecuteNonQuery();

                agregado = true;

                
            }
            catch (Exception E)
            {
                throw;
            }
            return agregado;
        }


        public MarcaBE BuscarMarcasXCategoria(int idCategoria)
        {
            MarcaBE marcaBE = new MarcaBE();
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Marca_BuscarXcategoriaID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmIdCategoria = new SqlParameter();
                prmIdCategoria.ParameterName = "@@idCategoria";
                prmIdCategoria.SqlDbType = SqlDbType.Int;
                prmIdCategoria.Value = idCategoria;

                cmd.Parameters.Add(prmIdCategoria);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                while (dr.Read())
                {
                    marcaBE.idMarca = Convert.ToInt32(dr["ID"]);
                    marcaBE.marca = dr["Marca"].ToString();
                    marcaBE.categoriaBE.categoria = dr["Categoria"].ToString();

                }
            }
            catch (Exception E)
            {
                throw;
            }
            return marcaBE;
        }
    }
}
