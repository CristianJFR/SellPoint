using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DataLayer;
using DataLayer.Entidades;

namespace SellPointApp
{
    public partial class FrmEntidad : Form
    {
        private int? id;
        public FrmEntidad()
        {
            InitializeComponent();
        }
        private void FrmGrupoEntidad_Load(object sender, EventArgs e)
        {
            Refrecar();
            CargarGrupos();
        }
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            Añadir();
            Refrecar();
            LimpiarCajas();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            LoadData();
           
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            LimpiarCajas();
            Refrecar();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        //Methods region

        #region
        public int? GetId()
        {
            try
            {
                return int.Parse(dgvEntidades.Rows[dgvEntidades.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {

                return null;
            }

        }
        public void LoadData()
        {
            id = GetId();
            EntidadBD entidadBD = new EntidadBD();
            Entidad entidad = entidadBD.Get(id);
            txtDescripcion.Text = entidad.descripcion;
            txtDireccion.Text = entidad.comentario;
            txtLocalidad.Text = entidad.localidad;
            cbTipoEntidad.Text = entidad.tipoEntidad;
            txtTipoDocumento.Text = entidad.tipoDocumento;
            txtNumeroDocumento.Text = Convert.ToString(entidad.numeroDocumento);
            txtTelefono.Text = entidad.telefono;
            txtPaginaWeb.Text = entidad.paginaWeb;
            txtFacebook.Text = entidad.facebook;
            txtInstagram.Text = entidad.instagram;
            txtTwitter.Text = entidad.twitter;
            txtTiktok.Text = entidad.tiktok;
            txtCredito.Text = Convert.ToString(entidad.limiteCredito);
            txtNombre.Text = entidad.nombre;
            txtPassword.Text = entidad.password;
            cbRoll.Text = entidad.rollUser;
            txtComentario.Text = entidad.comentario;
            cbEstado.Text = entidad.estado;
            cbNoEliminable.Text = entidad.noEliminable;
            dtpFecha.Value = entidad.date;
        }
        public void Refrecar()
        {
            EntidadBD sellPoint = new EntidadBD();
            dgvEntidades.DataSource = sellPoint.Get();
        }
        public void CargarGrupos()
        {
            EntidadBD sellPoint = new EntidadBD();
            cbTipoEntidad.DataSource = sellPoint.GetGrupo();
            cbTipoEntidad.DisplayMember = "DESCRIPCION";
            cbTipoEntidad.ValueMember = "ID_TIPO_IDENTIDAD";


        }
        public void Añadir()
        {
            EntidadBD entidadBD = new EntidadBD();
            if (id == null)
                entidadBD.Añadir(txtDescripcion.Text, txtDireccion.Text,txtLocalidad.Text, Convert.ToInt32(cbTipoEntidad.SelectedValue),txtTipoDocumento.Text,Int32.Parse(txtNumeroDocumento.Text),txtTelefono.Text,txtPaginaWeb.Text,txtFacebook.Text,txtInstagram.Text,txtTwitter.Text,txtTiktok.Text,Decimal.Parse(txtCredito.Text),txtNombre.Text,txtPassword.Text, Convert.ToString(cbRoll.SelectedItem),txtComentario.Text, Convert.ToString(cbEstado.SelectedItem), Convert.ToString(cbNoEliminable.SelectedItem), dtpFecha.Value);
            else
                entidadBD.Update(txtDescripcion.Text, txtDireccion.Text, txtLocalidad.Text, Convert.ToInt32(cbTipoEntidad.SelectedValue), txtTipoDocumento.Text, Int32.Parse(txtNumeroDocumento.Text), txtTelefono.Text, txtPaginaWeb.Text, txtFacebook.Text, txtInstagram.Text, txtTwitter.Text, txtTiktok.Text, Decimal.Parse(txtCredito.Text), txtNombre.Text, txtPassword.Text, Convert.ToString(cbRoll.SelectedItem), txtComentario.Text, Convert.ToString(cbEstado.SelectedItem), Convert.ToString(cbNoEliminable.SelectedItem), dtpFecha.Value, id);
            id = null;
        }
        public void Eliminar()
        {
            id = GetId();
            EntidadBD entidadBD = new EntidadBD();
            Entidad entidad = entidadBD.Get(id);
            cbNoEliminable.SelectedItem = entidad.noEliminable;

            if (id != null)
            {
                if (Convert.ToString(cbNoEliminable.SelectedItem).Equals("False"))
                {
                    entidadBD.Eliminar(id);
                    Refresh();
                }
                else
                {
                    MessageBox.Show("Este producto no puede ser eliminado");
                }

            }
            id = null;
        }

        public void LimpiarCajas()
        {
            txtDescripcion.Clear();
            txtDireccion.Clear();
            cbEstado.Text = "";
            cbNoEliminable.Text = "";
           
        }

        #endregion

    
    }
}
