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
    public partial class FrmTipoEntidades : Form
    {
        private int? id;
        public FrmTipoEntidades()
        {
            InitializeComponent();
        }
        private void FrmGrupoEntidad_Load(object sender, EventArgs e)
        {
            Refrescar();
        }
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            Añadir();
            Refrescar();
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
            Refrescar();
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
                return int.Parse(dgvTipoEntidades.Rows[dgvTipoEntidades.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {

                return null;
            }

        }
        public void LoadData()
        {
            id = GetId();
            TipoEntidadBD tipoEntidadBD = new TipoEntidadBD();
            TipoEntidad tipoEntidad = tipoEntidadBD.Get(id);
            txtDescripcion.Text = tipoEntidad.descripcion;
            txtComentario.Text = tipoEntidad.comentario;
            cbEstado.Text = tipoEntidad.estado;
            cbNoEliminable.Text = tipoEntidad.noEliminable;
            dtpFecha.Value = tipoEntidad.date;
        }
        public void Refrescar()
        {
            SellPoint sellPoint = new SellPoint();
            dgvTipoEntidades.DataSource = sellPoint.RefreshTipoEntidades();
        }
        public void Añadir()
        {
            TipoEntidadBD tipoEntidadBD = new TipoEntidadBD();
            if (id == null)
                tipoEntidadBD.Añadir(txtDescripcion.Text, txtComentario.Text, Convert.ToString(cbEstado.SelectedItem), Convert.ToString(cbNoEliminable.SelectedItem), dtpFecha.Value);
            else
                tipoEntidadBD.Update(txtDescripcion.Text, txtComentario.Text, Convert.ToString(cbEstado.SelectedItem), Convert.ToString(cbNoEliminable.SelectedItem), dtpFecha.Value, id);
            id = null;
        }
        public void Eliminar()
        {
            id = GetId();
            TipoEntidadBD tipoEntidadBD = new TipoEntidadBD();
            TipoEntidad tipoEntidad = tipoEntidadBD.Get(id);
            cbNoEliminable.SelectedItem = tipoEntidad.noEliminable;

            if (id != null)
            {
                if (Convert.ToString(cbNoEliminable.SelectedItem).Equals("False"))
                {
                    tipoEntidadBD.Eliminar(id);
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
            txtComentario.Clear();
            cbEstado.Text = "";
            cbNoEliminable.Text = "";
           
        }

        #endregion

    
    }
}
