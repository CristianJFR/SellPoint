using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataLayer.Entidades;

namespace DataLayer
{
    public class TipoEntidadBD
    {
        private string connectionString = "Data Source = localhost;Initial Catalog=PRACTICAFINAL;" +
      "integrated security = true";

        public List<TipoEntidad> Get() 
        {
      
            List<TipoEntidad> tipoEntidad = new List<TipoEntidad>();

            string query = "select ID_TIPO_IDENTIDAD,DESCRIPCION,COMENTARIO,ESTADO,NOELIMINABLE,FECHA_REGISTRO from TIPOSENTIDADES";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TipoEntidad oTipoEntidad = new TipoEntidad();
                        oTipoEntidad.id = reader.GetInt32(0);
                        oTipoEntidad.descripcion = reader.GetString(1);
                        oTipoEntidad.comentario = reader.GetString(2);
                        oTipoEntidad.estado = reader.GetString(3);
                        oTipoEntidad.noEliminable = reader.GetString(4);
                        oTipoEntidad.date = reader.GetDateTime(5);

                        tipoEntidad.Add(oTipoEntidad);

                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("errorsaso en bd" + ex.Message);

                }
            }

            return tipoEntidad;
        }
        public TipoEntidad Get(int? id)
        {

            string query = "select ID_TIPO_IDENTIDAD,DESCRIPCION,COMENTARIO,ESTADO,NOELIMINABLE,FECHA_REGISTRO from TIPOSENTIDADES" +
                " where ID_TIPO_IDENTIDAD=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    TipoEntidad oTipoEntidad = new TipoEntidad();
                    oTipoEntidad.id = reader.GetInt32(0);
                    oTipoEntidad.descripcion = reader.GetString(1);
                    oTipoEntidad.comentario = reader.GetString(2);
                    oTipoEntidad.estado = reader.GetString(3);
                    oTipoEntidad.noEliminable = reader.GetString(4);
                    oTipoEntidad.date = reader.GetDateTime(5);

                    reader.Close();
                    connection.Close();
                    return oTipoEntidad;


                }
                catch (Exception ex)
                {
                    throw new Exception("errorsaso en bd" + ex.Message);

                }
            }

        }

        public void Añadir(string descripcion, string comentario, string estado, string noEliminable, DateTime fecha)
        {
            string query = "insert into TIPOSENTIDADES (DESCRIPCION,COMENTARIO,ESTADO,NOELIMINABLE,FECHA_REGISTRO) values" +
                "(@descripcion,@comentario,@estado,@noEliminable,@fecha)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@comentario", comentario);
                command.Parameters.AddWithValue("@estado", estado);
                command.Parameters.AddWithValue("@noEliminable", noEliminable);
                command.Parameters.AddWithValue("@fecha", fecha);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("errorsaso en bd" + ex.Message);

                }
            }
        }
        public void Update(string descripcion, string comentario, string estado, string noEliminable, DateTime fecha, int? id)
        {
            string query = "update TIPOSENTIDADES set DESCRIPCION=@descripcion, COMENTARIO=@comentario, ESTADO=@estado, " +
                "NOELIMINABLE=@noEliminable, FECHA_REGISTRO=@fecha where ID_TIPO_IDENTIDAD=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@comentario", comentario);
                command.Parameters.AddWithValue("@estado", estado);
                command.Parameters.AddWithValue("@noEliminable", noEliminable);
                command.Parameters.AddWithValue("@fecha", fecha);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("errorsaso en bd" + ex.Message);

                }
            }
        }
        public void Eliminar(int? id)
        {

            string query = "delete from ENTIDADES where ID_ENTIDAD=@id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("errorsaso en bd" + ex.Message);

                }
            }

        }
    }
}
