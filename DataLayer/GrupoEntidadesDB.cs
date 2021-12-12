using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataLayer.Entidades;

namespace DataLayer
{
    public class GrupoEntidadesDB
    {
        private string connectionString = "Data Source = localhost;Initial Catalog=PRACTICAFINAL;" +
       "integrated security = true";

        public List<GrupoEntidad> Get()
        {
            List<GrupoEntidad> grupoEntidads = new List<GrupoEntidad>();

            string query = "select ID_GRUPO_ENTIDADES,DESCRIPCION,COMENTARIO,ESTADO,NOELIMINABLE,FECHA_REGISTRO from GRUPOSENTIDADES";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        GrupoEntidad oGrupoEntidad = new GrupoEntidad();
                        oGrupoEntidad.id = reader.GetInt32(0);
                        oGrupoEntidad.descripcion = reader.GetString(1);
                        oGrupoEntidad.comentario = reader.GetString(2);
                        oGrupoEntidad.estado = reader.GetString(3);
                        oGrupoEntidad.noEliminable = reader.GetString(4);
                        oGrupoEntidad.date = reader.GetDateTime(5);

                        grupoEntidads.Add(oGrupoEntidad);

                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("errorsaso en bd" + ex.Message);

                }
            }

            return grupoEntidads;
        }
        public GrupoEntidad Get(int? id)
        {

            string query = "select ID_GRUPO_ENTIDADES,DESCRIPCION,COMENTARIO,ESTADO,NOELIMINABLE,FECHA_REGISTRO from GRUPOSENTIDADES" +
                " where ID_GRUPO_ENTIDADES=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    GrupoEntidad oGrupoEntidad = new GrupoEntidad();
                    oGrupoEntidad.id = reader.GetInt32(0);
                    oGrupoEntidad.descripcion = reader.GetString(1);
                    oGrupoEntidad.comentario = reader.GetString(2);
                    oGrupoEntidad.estado = reader.GetString(3);
                    oGrupoEntidad.noEliminable = reader.GetString(4);
                    oGrupoEntidad.date = reader.GetDateTime(5);

                    reader.Close();
                    connection.Close();
                    return oGrupoEntidad;


                }
                catch (Exception ex)
                {
                    throw new Exception("errorsaso en bd" + ex.Message);

                }
            }

        }

        public void Añadir(string descripcion, string comentario, string estado, string noEliminable, DateTime fecha)
        {
            string query = "insert into GRUPOSENTIDADES (DESCRIPCION,COMENTARIO,ESTADO,NOELIMINABLE,FECHA_REGISTRO) values" +
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
            string query = "update GRUPOSENTIDADES set DESCRIPCION=@descripcion, COMENTARIO=@comentario, ESTADO=@estado, " +
                "NOELIMINABLE=@noEliminable, FECHA_REGISTRO=@fecha where ID_GRUPO_ENTIDADES=@id";

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
