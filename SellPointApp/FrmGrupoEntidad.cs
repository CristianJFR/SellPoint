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
    public partial class FrmGrupoEntidad : Form
    {
        //testing commit-2
        private int? id;
        public FrmGrupoEntidad()
        {
            InitializeComponent();
        }
        private void FrmGrupoEntidad_Load(object sender, EventArgs e)
        {
            Refresh();
        }
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            Añadir();
            Refresh();
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
            Refresh();
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
                return int.Parse(dgvGrupoEntidades.Rows[dgvGrupoEntidades.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {

                return null;
            }

        }
        public void LoadData()
        {
            id = GetId();
            GrupoEntidadesDB grupoEntidadesDB = new GrupoEntidadesDB();
            GrupoEntidad grupoEntidad = grupoEntidadesDB.Get(id);
            txtDescripcion.Text = grupoEntidad.descripcion;
            txtComentario.Text = grupoEntidad.comentario;
            cbEstado.Text = grupoEntidad.estado;
            cbNoEliminable.Text = grupoEntidad.noEliminable;
            dtpFecha.Value = grupoEntidad.date;
        }
        public void Refresh()
        {
            SellPoint sellPoint = new SellPoint();
            dgvGrupoEntidades.DataSource = sellPoint.RefreshGrupoEntidades();
        }
        public void Añadir()
        {
            GrupoEntidadesDB grupoEntidadesDB = new GrupoEntidadesDB();
            if (id == null)
                grupoEntidadesDB.Añadir(txtDescripcion.Text, txtComentario.Text, Convert.ToString(cbEstado.SelectedItem), Convert.ToString(cbNoEliminable.SelectedItem), dtpFecha.Value);
            else
                grupoEntidadesDB.Update(txtDescripcion.Text, txtComentario.Text, Convert.ToString(cbEstado.SelectedItem), Convert.ToString(cbNoEliminable.SelectedItem), dtpFecha.Value, id);
            id = null;
        }
        public void Eliminar()
        {
            id = GetId();
            GrupoEntidadesDB grupoEntidadesDB = new GrupoEntidadesDB();
            GrupoEntidad grupoEntidad = grupoEntidadesDB.Get(id);
            cbNoEliminable.SelectedItem = grupoEntidad.noEliminable;

            if (id != null)
            {
                if (Convert.ToString(cbNoEliminable.SelectedItem).Equals("False"))
                {
                    grupoEntidadesDB.Eliminar(id);
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
