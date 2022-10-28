using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LOGIN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string user = "admin";
        string pass = "admin";
        
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "USUARIO"){
                txtuser.Text = "";
                txtuser.ForeColor = Color.White;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "USUARIO";
                txtuser.ForeColor = Color.White;

            }

        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
             if (txtpass.Text == "CONTRASEÑA"){
                txtpass.Text = "";
                txtpass.ForeColor = Color.White;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
             if (txtpass.Text == ""){
                txtpass.Text = "CONTRASEÑA";
                txtpass.ForeColor = Color.White;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            // registro y contraseña
            string usuario = txtuser.Text;
            string contraseña = txtpass.Text;
            if (usuario.Equals(user))
            {
                if (contraseña.Equals(pass)) 
                {
                    //enlace de formularios 
                    this.Hide();
                    Interfas_Grafica.FormPrincipalxx administrador = new Interfas_Grafica.FormPrincipalxx();
                    administrador.ShowDialog();
                    MessageBox.Show("Acceso exitos");
                }
                   
                    else 
                    {
                        MessageBox.Show("Contraseña incorrecta ");
                    }
                }
                else 
                {
                    MessageBox.Show("Usuario no encontrado ");
                }
            }

        }
}

