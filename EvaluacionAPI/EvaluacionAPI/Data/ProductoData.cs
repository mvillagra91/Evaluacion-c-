using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApi.Data;
using EvaluacionAPI.Models;

namespace EvaluacionAPI.Data
{
    //Agregar producto
    public class ProductoData
    {
        public static bool Registrar(producto oProducto)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("registrar_producto", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", oProducto.id_product);
                cmd.Parameters.AddWithValue("@nombre", oProducto.name);
                cmd.Parameters.AddWithValue("@descripcion", oProducto.description);
                cmd.Parameters.AddWithValue("@categoria", oProducto.category);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    //Console.WriteLine($"Error: {ex.Message}");
                    return false;
                }
            }
        }

        //Modificar producto
        public static bool Modificar(producto oProducto)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("actualizar_producto", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", oProducto.id_product);
                cmd.Parameters.AddWithValue("@nombre", oProducto.name);
                cmd.Parameters.AddWithValue("@descripcion", oProducto.description);
                cmd.Parameters.AddWithValue("@categoria", oProducto.category);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    //Console.WriteLine($"Error al obtener productos: {ex.Message}");
                    return false;
                }
            }
        }

        //Listar productos
        public static List<producto> Listar()
        {
            List<producto> oListaProducto = new List<producto>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("producto_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaProducto.Add(new producto()
                            {
                                id_product = Convert.ToInt32(dr["id_product"]),
                                name = dr["name"].ToString(),
                                description = dr["description"].ToString(),
                                category = dr["category"].ToString(),
                            });
                        }
                    }

                    return oListaProducto;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return oListaProducto;
                }
            }
        }

        //Borrar producto

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("producto_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@identificador_producto", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return false;
                }
            }
        }
    }
}