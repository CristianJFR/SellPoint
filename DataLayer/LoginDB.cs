using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataLayer.Entidades;

namespace DataLayer
{
    public class LoginDB
    {
        private string connectionString = "Data Source = localhost;Initial Catalog=PRACTICAFINAL;" +
        "integrated security = true";

        public bool GetLogin(string nombre, string password)
        {

            string query = "select USER_NAME_ENTIDAD,PASSWORD_ENTIDAD from ENTIDADES" +
                " where (USER_NAME_ENTIDAD=@nombre and PASSWORD_ENTIDAD=@password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@password", password);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())//Obtenemos los datos de la columna y asignamos a los campos de la Cache de Usuario
                        {
                            Entidad oUsuario = new Entidad();
                            oUsuario.nombre = reader.GetString(0);
                            oUsuario.password = reader.GetString(1);

                        }
                        return true;
                    }
                    else
                        return false;
                }
                catch (Exception ex)
                {

                    throw new Exception("errorsaso en bd" + ex.Message);

                }
            }


        }
    }
}
