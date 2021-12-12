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

namespace SellPointApp
{
    public partial class Form1 : Form
    {
        private string user;
        private string user1;
        public Form1()
        {
            InitializeComponent();
            

        }

        private void entidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEntidad entidad = new FrmEntidad();
            panel1.Visible = false;
            entidad.Show();
            this.Hide();
        }
        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGrupoEntidad grupoEntidad = new FrmGrupoEntidad();
           
            panel1.Visible = false;
            grupoEntidad.Show();
            this.Hide();
        }
        private void tiposEntidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoEntidades tipoEntidad = new FrmTipoEntidades();
            panel1.Visible = false;
            tipoEntidad.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void btnAcercaDe_Click(object sender, EventArgs e)
        {
            FrmAcercaDe frmAcercaDe = new FrmAcercaDe();
            frmAcercaDe.Show();
            this.Hide();
        }

        //Methods Region
        #region

        public void Datos(string nombre)
        {
            user = nombre;
            
            lblUsuario.Text = user;
            lblUsuario1.Text = user;
        }
        #endregion


    }
}
