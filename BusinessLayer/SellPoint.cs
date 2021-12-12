using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entidades;


namespace BusinessLayer
{
    public class SellPoint
    {
        List<GrupoEntidad> grupoEntidads = new List<GrupoEntidad>();
        List<TipoEntidad> tipoEntidad = new List<TipoEntidad>();
        List<Entidad> entidad = new List<Entidad>();

        public bool validarLogin(string nombre, string password)
        {
            LoginDB oLogin = new LoginDB();
            return oLogin.GetLogin(nombre,password);
        }

        public List<GrupoEntidad> RefreshGrupoEntidades()
        {
            GrupoEntidadesDB grupoEntidadesDB = new GrupoEntidadesDB();
            grupoEntidads = grupoEntidadesDB.Get();

            return grupoEntidads;
        }
        public List<TipoEntidad> RefreshTipoEntidades()
        {
            TipoEntidadBD tipoEntidadBD = new TipoEntidadBD();
            tipoEntidad = tipoEntidadBD.Get();

            return tipoEntidad;
        }
        public List<Entidad> RefreshEntidades()
        {
            EntidadBD entidadBD = new EntidadBD();
            entidad = entidadBD.Get();

            return entidad;
        }
    }
}
