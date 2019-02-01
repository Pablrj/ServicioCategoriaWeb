using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public class CategoriaService : CategoriaIService
{
    String cadenaConexion = ConfigurationManager.ConnectionStrings["ProductoCategoria"].ConnectionString;
    public miCategoria buscarContrato(int idCategoria)
    {
        miCategoria micate = new miCategoria();
        try
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Delete from Categoria where CategoriaID= @CategoriaID", cnn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@CategoriaID", idCategoria);

            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                if (rd.Read())
                {
                    micate.CategoriaID = rd.GetInt32(0);
                    micate.CategoriaNombre = rd.GetString(1);
                    micate.Descripcion = rd.GetString(2);
                }
            }else
            {
                throw new Exception("No hay Registros");
            }
            
        }
        catch (Exception ex)
        {

            throw new Exception("Error al Eliminar", ex);
        }
        return micate;
    }

    public int EditarCategoria(miCategoria categoria)
    {
        int res = 0;
        try
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Update into Categorias (CategoriaNombre,Descripcion) values (@CategoriaNombre,@Descripcion)", cnn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@CategoriaNombre", categoria.CategoriaNombre);
            cmd.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);

            res = cmd.ExecuteNonQuery();
            cnn.Close();
        }
        catch (Exception ex)
        {

            throw new Exception("Error al Editar", ex);
        }
        return res;
    }


    public int EliminarCategoria(int idCategoria)
    {
        int res = 0;
        try
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Delete from Categoria where CategoriaID= @CategoriaID", cnn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@CategoriaID", idCategoria);
     

            res = cmd.ExecuteNonQuery();
            cnn.Close();
        }
        catch (Exception ex)
        {

            throw new Exception("Error al Eliminar", ex);
        }
        return res;
    }

    public List<miCategoria> listaCategoria()
    {
        List<miCategoria> lista = new List<miCategoria>();
        try
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Categoria", cnn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@CategoriaID", "");

            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    lista.Add(new miCategoria
                    {
                        CategoriaID = rd.GetInt32(0),
                        CategoriaNombre = rd.GetString(1),
                        Descripcion = rd.GetString(2)
                    });
                }
            }
            else
            {
                throw new Exception("No hay Registros");
            }

        }
        catch (Exception ex)
        {

            throw new Exception("Error al Eliminar", ex);
        }
        return lista;
    }

    public int NuevaCategoria(miCategoria categoria)
    {
        int res = 0;
        try
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("insert into Categorias (CategoriaNombre,Descripcion) values (@CategoriaNombre,@Descripcion)", cnn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@CategoriaNombre",categoria.CategoriaNombre);
            cmd.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);

            res = cmd.ExecuteNonQuery();
            cnn.Close();
        }
        catch (Exception ex)
        {

            throw new Exception("Error al Insertar",ex);
        }
        return res;
    }
}
