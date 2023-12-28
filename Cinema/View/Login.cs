using Cinema.Controller;
using Cinema.Help;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLblDaftar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int result = 0;

            if (String.IsNullOrEmpty(txtUsrnameLgn.Text) || String.IsNullOrEmpty(txtPassLogin.Text))
            {
                MessageBox.Show("Lengkapi semua data.", "Perhatian!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsersController controller = new UsersController();
            result = controller.Login(txtUsrnameLgn.Text, txtPassLogin.Text);

            if (result == 2)
            {
                Home home = new Home();
                home.Show();
                Visible = false;
            }
            else if (result < 2)
            {
                MessageBox.Show("Akun tidak ditemukan.", "Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("ERROR", "Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return;
        }
    }
}
