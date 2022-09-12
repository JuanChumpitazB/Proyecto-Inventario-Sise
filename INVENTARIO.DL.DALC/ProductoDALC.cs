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
    public class ProductoDALC
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ToString());
        SqlCommand cmd = new SqlCommand();

        public List<ProductoBE> ListarProductos()
        {
            List<ProductoBE> listado = new List<ProductoBE>();
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Producto_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ProductoBE productoBE = new ProductoBE();

                    productoBE.idProducto = Convert.ToInt32(dr["ID"]);
                    productoBE.descripcion = dr["Descripcion"].ToString();
                    productoBE.marcaBE.categoriaBE.categoria = dr["Categoria"].ToString();
                    productoBE.marcaBE.marca = dr["Marca"].ToString();
                    productoBE.medida = dr["Medida"].ToString();
                    productoBE.unidadDeMedidaBE.simbolo = dr["UnidadDeMedida"].ToString();
                    productoBE.unidadesEnExistencia = Convert.ToInt32(dr["UnidadesEnExistencia"]);
                    
                    //productoBE.fechaVencimiento = Convert.ToDateTime(string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(dr["FechaVencimiento"])));
                    productoBE.fechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]);
                    productoBE.estadoBE.descripcion = dr["Estado"].ToString();
                    productoBE.precio = Convert.ToDouble(dr["Precio"]);
                    productoBE.fotoBE.URL = dr["URL"].ToString();

                    listado.Add(productoBE);
                }
            }
            catch (Exception E)
            {
                throw;
            }
            return listado;
        }


        

        public List<ProductoBE> ListarProductosOptimo()
        {
            List<ProductoBE> listado = new List<ProductoBE>();
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Producto_ListarXoptimo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ProductoBE productoBE = new ProductoBE();

                    productoBE.idProducto = Convert.ToInt32(dr["ID"]);
                    productoBE.descripcion = dr["Descripcion"].ToString();
                    productoBE.marcaBE.categoriaBE.categoria = dr["Categoria"].ToString();
                    productoBE.marcaBE.marca = dr["Marca"].ToString();
                    productoBE.medida = dr["Medida"].ToString();
                    productoBE.unidadDeMedidaBE.simbolo = dr["UnidadDeMedida"].ToString();
                    productoBE.unidadesEnExistencia = Convert.ToInt32(dr["UnidadesEnExistencia"]);
                    productoBE.fechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]);
                    productoBE.estadoBE.descripcion = dr["Estado"].ToString();
                    productoBE.precio = Convert.ToDouble(dr["Precio"]);
                    productoBE.fotoBE.URL = dr["URL"].ToString();

                    listado.Add(productoBE);
                }
            }
            catch (Exception E)
            {
                throw;
            }
            return listado;
        }

        public List<ProductoBE> ListarProductosMerma()
        {
            List<ProductoBE> listado = new List<ProductoBE>();
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Producto_ListarXmerma", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ProductoBE productoBE = new ProductoBE();

                    productoBE.idProducto = Convert.ToInt32(dr["ID"]);
                    productoBE.descripcion = dr["Descripcion"].ToString();
                    productoBE.marcaBE.categoriaBE.categoria = dr["Categoria"].ToString();
                    productoBE.marcaBE.marca = dr["Marca"].ToString();
                    productoBE.medida = dr["Medida"].ToString();
                    productoBE.unidadDeMedidaBE.simbolo = dr["UnidadDeMedida"].ToString();
                    productoBE.unidadesEnExistencia = Convert.ToInt32(dr["UnidadesEnExistencia"]);
                    productoBE.fechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]);
                    productoBE.estadoBE.descripcion = dr["Estado"].ToString();
                    productoBE.precio = Convert.ToDouble(dr["Precio"]);
                    productoBE.fotoBE.URL = dr["URL"].ToString();

                    listado.Add(productoBE);
                }
            }
            catch (Exception E)
            {
                throw;
            }
            return listado;
        }

       
        public List<ProductoBE> ListarProductosXvencer()
        {
            List<ProductoBE> listado = new List<ProductoBE>();
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Producto_ListarProductoXvencer", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ProductoBE productoBE = new ProductoBE();

                    productoBE.idProducto = Convert.ToInt32(dr["ID"]);
                    productoBE.descripcion = dr["Descripcion"].ToString();
                    productoBE.marcaBE.categoriaBE.categoria = dr["Categoria"].ToString();
                    productoBE.marcaBE.marca = dr["Marca"].ToString();
                    productoBE.medida = dr["Medida"].ToString();
                    productoBE.unidadDeMedidaBE.simbolo = dr["UnidadDeMedida"].ToString();
                    productoBE.unidadesEnExistencia = Convert.ToInt32(dr["UnidadesEnExistencia"]);
                    productoBE.fechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]);
                    productoBE.estadoBE.descripcion = dr["Estado"].ToString();
                    productoBE.precio = Convert.ToDouble(dr["Precio"]);
                    productoBE.fotoBE.URL = dr["URL"].ToString();

                    listado.Add(productoBE);
                }
            }
            catch (Exception E)
            {
                throw;
            }
            return listado;
        }


        public List<ProductoBE> ProductosXagotarse()
        {
            List<ProductoBE> listado = new List<ProductoBE>();
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Producto_ProdustosXagotarse", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ProductoBE productoBE = new ProductoBE();

                    productoBE.idProducto = Convert.ToInt32(dr["ID"]);
                    productoBE.descripcion = dr["Descripcion"].ToString();
                    productoBE.marcaBE.categoriaBE.categoria = dr["Categoria"].ToString();
                    productoBE.marcaBE.marca = dr["Marca"].ToString();
                    productoBE.medida = dr["Medida"].ToString();
                    productoBE.unidadDeMedidaBE.simbolo = dr["UnidadDeMedida"].ToString();
                    productoBE.unidadesEnExistencia = Convert.ToInt32(dr["UnidadesEnExistencia"]);

                    //productoBE.fechaVencimiento = Convert.ToDateTime(string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(dr["FechaVencimiento"])));
                    productoBE.fechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]);
                    productoBE.estadoBE.descripcion = dr["Estado"].ToString();
                    productoBE.precio = Convert.ToDouble(dr["Precio"]);
                    productoBE.fotoBE.URL = dr["URL"].ToString();

                    listado.Add(productoBE);
                }
            }
            catch (Exception E)
            {
                throw;
            }
            return listado;
        }

        public bool AgregarProducto(ProductoBE productoBE)
        {
            bool agregado = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Producto_Agregar",cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmDescripcion = new SqlParameter();
                prmDescripcion.ParameterName = "@descripcion";
                prmDescripcion.SqlDbType = SqlDbType.VarChar;
                prmDescripcion.Size = 35;
                prmDescripcion.Value = productoBE.descripcion;


                SqlParameter prmIdMarca = new SqlParameter();
                prmIdMarca.ParameterName = "@idMarca";
                prmIdMarca.SqlDbType = SqlDbType.Int;
                prmIdMarca.Value = productoBE.marcaBE.idMarca;

                SqlParameter prmMedida = new SqlParameter();
                prmMedida.ParameterName = "@medida";
                prmMedida.SqlDbType = SqlDbType.VarChar;
                prmMedida.Size = 5;
                prmMedida.Value = productoBE.medida;

                SqlParameter prmIdUnidadDeMedida = new SqlParameter();
                prmIdUnidadDeMedida.ParameterName = "@idUnidadDeMedida";
                prmIdUnidadDeMedida.SqlDbType = SqlDbType.Int;
                prmIdUnidadDeMedida.Value = productoBE.unidadDeMedidaBE.idUnidad;

                SqlParameter prmUnidadesEnExistencia = new SqlParameter();
                prmUnidadesEnExistencia.ParameterName = "@unidadesEnExistencia";
                prmUnidadesEnExistencia.SqlDbType = SqlDbType.Int;
                prmUnidadesEnExistencia.Value = productoBE.unidadesEnExistencia;

                SqlParameter prmFechaVencimiento = new SqlParameter();
                prmFechaVencimiento.ParameterName = "@fechaVencimiento";
                prmFechaVencimiento.SqlDbType = SqlDbType.Date;
                prmFechaVencimiento.Value = productoBE.fechaVencimiento;

                SqlParameter prmIdEstado = new SqlParameter();
                prmIdEstado.ParameterName = "@idEstado";
                prmIdEstado.SqlDbType = SqlDbType.Int;
                prmIdEstado.Value = productoBE.estadoBE.idEstado;

                SqlParameter prmPrecio = new SqlParameter();
                prmPrecio.ParameterName = "@precio";
                prmPrecio.SqlDbType = SqlDbType.Decimal;
                prmPrecio.Value = productoBE.precio;

                SqlParameter prmIdFoto = new SqlParameter();
                prmIdFoto.ParameterName = "@idFoto";
                prmIdFoto.SqlDbType = SqlDbType.Int;
                prmIdFoto.Value = productoBE.fotoBE.idFoto;

                cmd.Parameters.Add(prmDescripcion);
                cmd.Parameters.Add(prmIdMarca);
                cmd.Parameters.Add(prmMedida);
                cmd.Parameters.Add(prmIdUnidadDeMedida);
                cmd.Parameters.Add(prmUnidadesEnExistencia);
                cmd.Parameters.Add(prmFechaVencimiento);
                cmd.Parameters.Add(prmIdEstado);
                cmd.Parameters.Add(prmPrecio);
                cmd.Parameters.Add(prmIdFoto);

                cmd.ExecuteNonQuery();

                agregado = true;
            }
            catch (Exception E)
            {
                throw;
            }
            return agregado;
        }

        public bool ActualizarProducto(ProductoBE productoBE)
        {
            bool actualizado = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Producto_Actualizar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmIdProducto = new SqlParameter();
                prmIdProducto.ParameterName = "@idProducto";
                prmIdProducto.SqlDbType = SqlDbType.Int;
                prmIdProducto.Value = productoBE.idProducto;

                SqlParameter prmDescripcion = new SqlParameter();
                prmDescripcion.ParameterName = "@descripcion";
                prmDescripcion.SqlDbType = SqlDbType.VarChar;
                prmDescripcion.Size = 35;
                prmDescripcion.Value = productoBE.descripcion;


                SqlParameter prmIdMarca = new SqlParameter();
                prmIdMarca.ParameterName = "@idMarca";
                prmIdMarca.SqlDbType = SqlDbType.Int;
                prmIdMarca.Value = productoBE.marcaBE.idMarca;

                SqlParameter prmMedida = new SqlParameter();
                prmMedida.ParameterName = "@medida";
                prmMedida.SqlDbType = SqlDbType.VarChar;
                prmMedida.Size = 5;
                prmMedida.Value = productoBE.medida;

                SqlParameter prmIdUnidadDeMedida = new SqlParameter();
                prmIdUnidadDeMedida.ParameterName = "@idUnidadDeMedida";
                prmIdUnidadDeMedida.SqlDbType = SqlDbType.Int;
                prmIdUnidadDeMedida.Value = productoBE.unidadDeMedidaBE.idUnidad;

                SqlParameter prmUnidadesEnExistencia = new SqlParameter();
                prmUnidadesEnExistencia.ParameterName = "@unidadesEnExistencia";
                prmUnidadesEnExistencia.SqlDbType = SqlDbType.Int;
                prmUnidadesEnExistencia.Value = productoBE.unidadesEnExistencia;

                SqlParameter prmFechaVencimiento = new SqlParameter();
                prmFechaVencimiento.ParameterName = "@fechaVencimiento";
                prmFechaVencimiento.SqlDbType = SqlDbType.Date;
                prmFechaVencimiento.Value = productoBE.fechaVencimiento;

                SqlParameter prmIdEstado = new SqlParameter();
                prmIdEstado.ParameterName = "@idEstado";
                prmIdEstado.SqlDbType = SqlDbType.Int;
                prmIdEstado.Value = productoBE.estadoBE.idEstado;

                SqlParameter prmPrecio = new SqlParameter();
                prmPrecio.ParameterName = "@precio";
                prmPrecio.SqlDbType = SqlDbType.Decimal;
                prmPrecio.Value = productoBE.precio;

                SqlParameter prmIdFoto = new SqlParameter();
                prmIdFoto.ParameterName = "@idFoto";
                prmIdFoto.SqlDbType = SqlDbType.Int;
                prmIdFoto.Value = productoBE.fotoBE.idFoto;

                cmd.Parameters.Add(prmIdProducto);
                cmd.Parameters.Add(prmDescripcion);
                cmd.Parameters.Add(prmIdMarca);
                cmd.Parameters.Add(prmMedida);
                cmd.Parameters.Add(prmIdUnidadDeMedida);
                cmd.Parameters.Add(prmUnidadesEnExistencia);
                cmd.Parameters.Add(prmFechaVencimiento);
                cmd.Parameters.Add(prmIdEstado);
                cmd.Parameters.Add(prmPrecio);
                cmd.Parameters.Add(prmIdFoto);

                cmd.ExecuteNonQuery();

                actualizado = true;
            }
            catch (Exception E)
            {
                throw;
            }
            return actualizado;
        }


        public ProductoBE BuscarProductoXid(int idProducto)
        {
            ProductoBE productoBE = new ProductoBE();
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Producto_BuscarXid", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmIdProducto = new SqlParameter();
                prmIdProducto.ParameterName = "@idProducto";
                prmIdProducto.SqlDbType = SqlDbType.Int;
                prmIdProducto.Value = idProducto;

                cmd.Parameters.Add(prmIdProducto);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    productoBE.idProducto = Convert.ToInt32(dr["ID"]);
                    productoBE.descripcion = dr["Descripcion"].ToString();
                    productoBE.marcaBE.categoriaBE.categoria = dr["Categoria"].ToString();
                    productoBE.marcaBE.marca = dr["Marca"].ToString();
                    productoBE.medida = dr["Medida"].ToString();
                    productoBE.unidadDeMedidaBE.simbolo = dr["UnidadDeMedida"].ToString();
                    productoBE.unidadesEnExistencia = Convert.ToInt32(dr["UnidadesEnExistencia"]);

                    //productoBE.fechaVencimiento = Convert.ToDateTime(string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(dr["FechaVencimiento"])));
                    productoBE.fechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]);
                    productoBE.estadoBE.descripcion = dr["Estado"].ToString();
                    productoBE.precio = Convert.ToDouble(dr["Precio"]);
                    productoBE.fotoBE.URL = dr["URL"].ToString();

                }
            }
            catch (Exception E)
            {
                throw;
            }
            return productoBE;
        }


        public bool EliminarProducto(int idProducto)
        {
            bool eliminado = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Producto_Eliminar",cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prmIdProducto = new SqlParameter();
                prmIdProducto.ParameterName = "@idProducto";
                prmIdProducto.SqlDbType = SqlDbType.Int;
                prmIdProducto.Value = idProducto;

                cmd.Parameters.Add(prmIdProducto);
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
