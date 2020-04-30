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

namespace Barberia
{
    public partial class Fondo : Form
    {
        public Fondo()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Fondo_Load_1(object sender, EventArgs e)
        {
            btnInicio_Click(null, e);
        }


        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnSlide_Click(object sender, EventArgs e)
        {
            if (menuVertical.Width == 250)
            {
                menuVertical.Width = 70;
            }
            else
                menuVertical.Width = 250;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

 

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            LX = this.Location.X;
            LY = this.Location.Y;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnMinimizar.Visible = true;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        int LX, LY;

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1300, 650);
            this.Location = new Point(LX, LY);
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }



        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void AbrirFormHija(object formhija)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Inicio());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Clientes());
        }

        private void btnBarberos_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Barberos());
        }

        private void btnCortes_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Cortes());
        }

        private void btnTurnos_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Turnos());
        }



    }
}
