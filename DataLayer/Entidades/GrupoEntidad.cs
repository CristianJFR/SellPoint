using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entidades
{
    public class GrupoEntidad
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string comentario { get; set; }
        public string estado { get; set; }
        public string noEliminable { get; set; }
        public DateTime date { get; set; }
    }
}
