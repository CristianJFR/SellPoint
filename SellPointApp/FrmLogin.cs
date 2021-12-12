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
    public partial class FrmLogin : Form
    {
       
        /*EventsControl events = new EventsControl();*/
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            EnterUsuario();
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            LeaveUsuario();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            EnterPassword();
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            LeavePassword();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            
            Verificacion();
        }

        //Methods Region
        #region
        public void EnterUsuario()
        {
            if (txtUsuario.Text.Equals("Usuario"))
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
                lblUsuario.ForeColor = Color.LightGray;
            }
        }

        public void LeaveUsuario()
        {
            if (txtUsuario.Text.Equals(""))
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.DarkGray;
                lblUsuario.ForeColor = Color.DarkGray;
            }
        }

        public void EnterPassword()
        {
            if (txtPassword.Text.Equals("Contraseña"))
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.LightGray;
                lblPassword.ForeColor = Color.LightGray;
            }
        }

        public void LeavePassword()
        {
            if (txtPassword.Text.Equals(""))
            {
                txtPassword.Text = "Contraseña";
                txtPassword.ForeColor = Color.DarkGray;
                lblPassword.ForeColor = Color.DarkGray;
            }
        }
        public void Verificacion()
        {
            SellPoint sellPoint = new SellPoint();
            if (txtUsuario.Text != "Usuario" && txtPassword.Text != "Contraseña")
            {
                var usuario = sellPoint.validarLogin(txtUsuario.Text, txtPassword.Text);
                if (usuario)
                {
                   
                    Form1 form = new Form1();
                    form.Datos(txtUsuario.Text);
                    form.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Datos incorrectos");
                }
            }
            else
            {
                msgError.Text = "     Cajas vacias";
                msgError.ForeColor = Color.Red;
                msgError.Visible = true;
            }
           
           
        }

     
        #endregion

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
