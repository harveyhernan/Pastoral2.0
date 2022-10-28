using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfas_Grafica
{
    public partial class FormPrincipalxx : Form
    {
        public FormPrincipalxx()
        {
            InitializeComponent();
        }
        #region Funcionalidades del formulario 
        private int tolerance = 12;
            private const int WM_NCHITTEST = 132;
            private const int HTBOTTOMRIGHT = 17;
            private Rectangle sizeGripRectangle;
protected override void WndProc(ref Message m)
{
    switch (m.Msg)
    {
        case WM_NCHITTEST:
            base.WndProc(ref m);
            var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
            if (sizeGripRectangle.Contains(hitPoint))
                m.Result = new IntPtr(HTBOTTOMRIGHT);
            break;
        default:
            base.WndProc(ref m);
            break;
    }
}

protected override void OnSizeChanged(EventArgs e)
{
    base.OnSizeChanged(e);
    var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
    sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
    region.Exclude(sizeGripRectangle);
    this.panelContenedor.Region = region;
    this.Invalidate();
}

protected override void OnPaint(PaintEventArgs e)
{
    SolidBrush blueBrush = new SolidBrush(Color.FromArgb(219, 185, 95));
    e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
    base.OnPaint(e);
    ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
}

    private void btnCerrar_Click(object sender, EventArgs e)
    {
    Application.Exit();
    }
    //Capturar posicion y tamaño antes de maximizar para restaurar 
    int lx, ly;
    int sw, sh;
    private void btnMaximizar_Click(object sender, EventArgs e)
    {
        lx = this.Location.X;
        ly = this.Location.Y;
        sw = this.Size.Width;
        sh = this.Size.Height;
        btnMaximizar.Visible = false;
        btnRestaurar.Visible = true;
        this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        this.Location = Screen.PrimaryScreen.WorkingArea.Location;
    }

    private void btnRestaurar_Click(object sender, EventArgs e)
    {
        btnMaximizar.Visible = true;
        btnRestaurar.Visible = false;
        this.Size = new Size(sw,sh);
        this.Location = new Point(lx,ly); 
    }

    [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
    private extern static void ReleaseCapture();
    [DllImport("user32.DLL", EntryPoint = "SendMessage")]
    private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

    private void btnMinimizar_Click(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Minimized;
    }

    private void panelBarraTitulo_MouseMove(object sender, MouseEventArgs e)
    {
        ReleaseCapture();
        SendMessage(this.Handle, 0x112, 0xf012, 0);
    }
        #endregion
        //Metodo para abrir los formularios dentro del panel 
    private void AbrirFormulario<MiForm>() where MiForm : Form, new()
    {
        Form formulario;
        formulario = panelFormularios.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
        //si el formulario/instancia no existe
        if (formulario == null)
        {
            formulario = new MiForm();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panelFormularios.Controls.Add(formulario);
            panelFormularios.Tag = formulario;
            formulario.Show();
            formulario.BringToFront();
            formulario.FormClosed += new FormClosedEventHandler(CloseForms);
        }
        //si el formulario/instancia existe
        else
        {
            formulario.BringToFront();
        }
    }
    private void CloseForms(object sender, FormClosedEventArgs e)
    {
        if (Application.OpenForms["Form1"] == null)
            button1.BackColor = Color.FromArgb(83, 118, 54);
        if (Application.OpenForms["Form2"] == null)
            button2.BackColor = Color.FromArgb(83, 118, 54);
        if (Application.OpenForms["Form3"] == null)
            button3.BackColor = Color.FromArgb(83, 118, 54);
        if (Application.OpenForms["Form4"] == null)
            button4.BackColor = Color.FromArgb(83, 118, 54);
        if (Application.OpenForms["Form5"] == null)
            button5.BackColor = Color.FromArgb(83, 118, 54);
        if (Application.OpenForms["Form6"] == null)
            button6.BackColor = Color.FromArgb(83, 118, 54);
        if (Application.OpenForms["Form7"] == null)
            button7.BackColor = Color.FromArgb(83, 118, 54);
        if (Application.OpenForms["Form8"] == null)
            button8.BackColor = Color.FromArgb(83, 118, 54);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        AbrirFormulario<Form1>();
        button1.BackColor = Color.FromArgb(219, 185, 95);
    }

    private void button3_Click(object sender, EventArgs e)
    {
        AbrirFormulario<Form3>();
        button3.BackColor = Color.FromArgb(219, 185, 95);
    }

    private void button2_Click(object sender, EventArgs e)
    {
        AbrirFormulario<Form2>();
        button2.BackColor = Color.FromArgb(219, 185, 95);
    }

    private void button4_Click(object sender, EventArgs e)
    {
        AbrirFormulario<Form4>();
        button4.BackColor = Color.FromArgb(219, 185, 95);
    }

    private void button5_Click(object sender, EventArgs e)
    {
        AbrirFormulario<Form5>();
        button5.BackColor = Color.FromArgb(219, 185, 95);
    }

    private void button6_Click(object sender, EventArgs e)
    {
        AbrirFormulario<Form6>();
        button6.BackColor = Color.FromArgb(219, 185, 95);
    }

    private void button7_Click(object sender, EventArgs e)
    {
        AbrirFormulario<Form7>();
        button7.BackColor = Color.FromArgb(219, 185, 95);
    }

    private void button8_Click(object sender, EventArgs e)
    {
        AbrirFormulario<Form8>();
        button8.BackColor = Color.FromArgb(219, 185, 95);
    }

    private void panelFormularios_Paint(object sender, PaintEventArgs e)
    {

    }
    }
}
