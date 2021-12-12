using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataLayer.Entidades;
using System.Data;


namespace DataLayer
{
    public class EntidadBD
    {
        private string connectionString = "Data Source = localhost;Initial Catalog=PRACTICAFINAL;" +
     "integrated security = true";

        public List<Entidad> Get()
        {
            List<Entidad> entidad = new List<Entidad>();

            string query = "select ID_ENTIDAD,DESCRIPCION,DIRECCION,LOCALIDAD,TIPO_ENTIDAD,TIPO_DOCUMENTO,NUMERO_DOCUMENTO," +
                "TELEFONO,URL_PAGINAWEB,URL_FACEBOOK,URL_INSTAGRAM,URL_TWITTER,URL_TIKTOK," +
                "LIMITE_CREDITO,USER_NAME_ENTIDAD,PASSWORD_ENTIDAD,ROLL_USER_ENTIDAD,COMENTARIO,ESTADO,NOELIMINABLE,FECHA_REGISTRO from ENTIDADES";





            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Entidad oEntidad = new Entidad();
                        oEntidad.id = reader.GetInt32(0);
                        oEntidad.descripcion = reader.GetString(1);
                        oEntidad.direccion = reader.GetString(2);
                        oEntidad.localidad = reader.GetString(3);
                        oEntidad.tipoEntidad = reader.GetString(4);
                        oEntidad.tipoDocumento = reader.GetString(5);
                        oEntidad.numeroDocumento = reader.GetInt32(6);
                        oEntidad.telefono = reader.GetString(7);
                        oEntidad.paginaWeb = reader.GetString(8);
                        oEntidad.facebook = reader.GetString(9);
                        oEntidad.instagram = reader.GetString(10);
                        oEntidad.twitter = reader.GetString(11);
                        oEntidad.tiktok = reader.GetString(12);
                        oEntidad.limiteCredito = reader.GetDecimal(13);
                        oEntidad.nombre = reader.GetString(14);
                        oEntidad.password = reader.GetString(15);
                        oEntidad.rollUser = reader.GetString(16);
                        oEntidad.comentario = reader.GetString(17);
                        oEntidad.estado = reader.GetString(18);
                        oEntidad.noEliminable = reader.GetString(19);
                        oEntidad.date = reader.GetDateTime(20);

                        entidad.Add(oEntidad);

                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("errorsaso en bd" + ex.Message);

                }
            }

            return entidad;
        }
        public Entidad Get(int? id)
        {

            string query = "select ID_ENTIDAD,DESCRIPCION,DIRECCION,LOCALIDAD,TIPO_ENTIDAD,TIPO_DOCUMENTO,NUMERO_DOCUMENTO," +
                "TELEFONO,URL_PAGINAWEB,URL_FACEBOOK,URL_INSTAGRAM,URL_TWITTER,URL_TIKTOK," +
                "LIMITE_CREDITO,USER_NAME_ENTIDAD,PASSWORD_ENTIDAD,ROLL_USER_ENTIDAD,COMENTARIO,ESTADO,NOELIMINABLE,FECHA_REGISTRO from ENTIDADES where ID_ENTIDAD=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    Entidad oEntidad = new Entidad();
                    oEntidad.id = reader.GetInt32(0);
                    oEntidad.descripcion = reader.GetString(1);
                    oEntidad.direccion = reader.GetString(2);
                    oEntidad.localidad = reader.GetString(3);
                    oEntidad.tipoEntidad = reader.GetString(4);
                    oEntidad.tipoDocumento = reader.GetString(5);
                    oEntidad.numeroDocumento = reader.GetInt32(6);
                    oEntidad.telefono = reader.GetString(7);
                    oEntidad.paginaWeb = reader.GetString(8);
                    oEntidad.facebook = reader.GetString(9);
                    oEntidad.instagram = reader.GetString(10);
                    oEntidad.twitter = reader.GetString(11);
                    oEntidad.tiktok = reader.GetString(12);
                    oEntidad.limiteCredito = reader.GetDecimal(13);
                    oEntidad.nombre = reader.GetString(14);
                    oEntidad.password = reader.GetString(15);
                    oEntidad.rollUser = reader.GetString(16);
                    oEntidad.comentario = reader.GetString(17);
                    oEntidad.estado = reader.GetString(18);
                    oEntidad.noEliminable = reader.GetString(19);
                    oEntidad.date = reader.GetDateTime(20);

                    reader.Close();
                    connection.Close();
                    return oEntidad;


                }
                catch (Exception ex)
                {
                    throw new Exception("errorsaso en bd" + ex.Message);

                }
            }

        }

        public void Añadir(string descripcion, string direccion,string localidad,int tipoEntidad,string tipoDocumento,int numeroDocumento,string telefono,string paginaWeb,string facebook,string instagram,string twitter,string tiktok,decimal credito,string user,string password,string roll,string comentario, string estado, string noEliminable, DateTime fecha)
        {
            string query = "insert into ENTIDADES (DESCRIPCION,DIRECCION,LOCALIDAD,TIPO_ENTIDAD,TIPO_DOCUMENTO,NUMERO_DOCUMENTO,TELEFONO,URL_PAGINAWEB,URL_FACEBOOK,URL_INSTAGRAM,URL_TWITTER,URL_TIKTOK,LIMITE_CREDITO,USER_NAME_ENTIDAD,PASSWORD_ENTIDAD,ROLL_USER_ENTIDAD,COMENTARIO,ESTADO,NOELIMINABLE,FECHA_REGISTRO) values" +
                "(@descripcion,@direccion,@localidad,@tipoEntidad,@tipoDocumneto,@numeroDocumento,@telefono,@paginaWeb,@facebook,@instagram,@twitter,@tiktok,@credito,@user,@password,@roll,@comentario,@estado,@noEliminable,@fecha)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@direccion", direccion);
                command.Parameters.AddWithValue("@localidad", localidad);
                command.Parameters.AddWithValue("@tipoEntidad", tipoEntidad);
                command.Parameters.AddWithValue("@tipoDocumneto", tipoDocumento);
                command.Parameters.AddWithValue("@numeroDocumento", numeroDocumento);
                command.Parameters.AddWithValue("@telefono", telefono);
                command.Parameters.AddWithValue("@paginaWeb", paginaWeb);
                command.Parameters.AddWithValue("@facebook", facebook);
                command.Parameters.AddWithValue("@instagram", instagram);
                command.Parameters.AddWithValue("@twitter", twitter);
                command.Parameters.AddWithValue("@tiktok", tiktok);
                command.Parameters.AddWithValue("@credito", credito);
                command.Parameters.AddWithValue("@user", user);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@roll", roll);
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
        public void Update(string descripcion, string direccion, string localidad, int tipoEntidad, string tipoDocumento, int numeroDocumento, string telefono, string paginaWeb, string facebook, string instagram, string twitter, string tiktok, decimal credito, string user, string password, string roll, string comentario, string estado, string noEliminable, DateTime fecha, int? id)
        {
            string query = "update ENTIDADES set DESCRIPCION=@descripcion, DIRECCION=@direccion,LOCALIDAD=@localidad," +
                "TIPO_ENTIDAD=@tipoEntidad,TIPO_DOCUMENTO=@tipoDocumneto,NUMERO_DOCUMENTO=@numeroDocumento,TELEFONO=@telefono," +
                "URL_PAGINAWEB=@paginaWeb,URL_FACEBOOK=@facebook,URL_INSTAGRAM=@instagram,URL_TWITTER=@twitter,URL_TIKTOK=@tiktok," +
                "LIMITE_CREDITO=@credito,USER_NAME_ENTIDAD=@user,PASSWORD_ENTIDAD=@password,ROLL_USER_ENTIDAD=@roll,COMENTARIO=@comentario, ESTADO=@estado, " +
                "NOELIMINABLE=@noEliminable, FECHA_REGISTRO=@fecha where ID_ENTIDAD=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@direccion", direccion);
                command.Parameters.AddWithValue("@localidad", localidad);
                command.Parameters.AddWithValue("@tipoEntidad", tipoEntidad);
                command.Parameters.AddWithValue("@tipoDocumneto", tipoDocumento);
                command.Parameters.AddWithValue("@numeroDocumento", numeroDocumento);
                command.Parameters.AddWithValue("@telefono", telefono);
                command.Parameters.AddWithValue("@paginaWeb", paginaWeb);
                command.Parameters.AddWithValue("@facebook", facebook);
                command.Parameters.AddWithValue("@instagram", instagram);
                command.Parameters.AddWithValue("@twitter", twitter);
                command.Parameters.AddWithValue("@tiktok", tiktok);
                command.Parameters.AddWithValue("@credito", credito);
                command.Parameters.AddWithValue("@user", user);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@roll", roll);
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


        public DataTable GetGrupo()
        {
            DataTable tabla = new DataTable();
            string query = "select ID_TIPO_IDENTIDAD,DESCRIPCION from TIPOSENTIDADES";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader LeerFilas;
                LeerFilas = command.ExecuteReader();
                tabla.Load(LeerFilas);
                LeerFilas.Close();
                return tabla;
            }
        }
    }
}
