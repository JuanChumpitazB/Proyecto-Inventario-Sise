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
    public class CategoriaDALC
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ToString());
        SqlCommand cmd = new SqlCommand();

        public List<CategoriaBE> ListarCategorias()
        {
            List<CategoriaBE> lista = new List<CategoriaBE>();
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Categoria_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    CategoriaBE categoriaBE = new CategoriaBE();
                    categoriaBE.idCategoria = Convert.ToInt32(dr["ID"]);
                    categoriaBE.categoria = dr["Categoria"].ToString();
                    categoriaBE.descripcion = dr["Descripcion"].ToString();

                    lista.Add(categoriaBE);
                }
            }
            catch (Exception E)
            {
                throw;
            }
            return lista;
        }

        public bool AgregarCategoria(CategoriaBE categoriaBE)
        {
            bool agregado = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Categoria_Agregar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmCategoria = new SqlParameter();
                prmCategoria.ParameterName = "@categoria";
                prmCategoria.SqlDbType = SqlDbType.VarChar;
                prmCategoria.Size = 40;
                prmCategoria.Value = categoriaBE.categoria;

                SqlParameter prmDescripcion = new SqlParameter();
                prmDescripcion.ParameterName = "@descripcion";
                prmDescripcion.SqlDbType = SqlDbType.VarChar;
                prmDescripcion.Size = 100;
                prmDescripcion.Value = categoriaBE.descripcion;

                cmd.Parameters.Add(prmCategoria);
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
