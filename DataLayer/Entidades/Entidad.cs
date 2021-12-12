using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entidades
{
    public class Entidad
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }
        public string tipoEntidad { get; set; }
        public string tipoDocumento { get; set; }
        public int numeroDocumento { get; set; }
        public string telefono { get; set; }
        public string paginaWeb { get; set; }
        public string facebook { get; set; }
        public string instagram { get; set; }
        public string twitter { get; set; }
        public string tiktok { get; set; }
        public int idGrupoEntidad { get; set; }
        public int idTipoEntidad { get; set; }
        public decimal limiteCredito { get; set; }
        public string nombre { get; set; }
        public string password { get; set; }
        public string rollUser { get; set; }
        public string comentario { get; set; }
        public string estado { get; set; }
        public string noEliminable { get; set; }
        public DateTime date { get; set; }
    }
}
