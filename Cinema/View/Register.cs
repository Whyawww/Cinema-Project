using Cinema.Controller;
using Cinema.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Cinema.View
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void linkLblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Visible = false;
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnDftr_Click(object sender, EventArgs e)
        {
            int result = 0;

            if (String.IsNullOrEmpty(txtNameDftr.Text) || String.IsNullOrEmpty(txtKonfPass.Text) || String.IsNullOrEmpty(txtTelp.Text) || String.IsNullOrEmpty(txtUtkPass.Text))
            {
                MessageBox.Show("Lengkapi Data.", "Perhatian!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtUtkPass.TextLength < 4)
            {
                MessageBox.Show("Password minimal 4 karakter.", "Perhatian!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtUtkPass.Text != txtKonfPass.Text)
            {
                MessageBox.Show("Password konfirmasi harus sama.", "Perhatian!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Users user = new Users();
            user.Username = txtNameDftr.Text;
            user.Phone = txtTelp.Text;
            user.Password = txtUtkPass.Text;

            UsersController controller = new UsersController();
            result = controller.Register(user);
            if (result == 69)
            {
                MessageBox.Show("Telepon atau Username telah terdaftar", "Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelp.Text = "";
                txtNameDftr.Text = "";
            }
            else if (result > 0)
            {
                txtKonfPass.Text = "";
                txtNameDftr.Text = "";
                txtTelp.Text = "";
                txtUtkPass.Text = "";

                DialogResult dialogResult = MessageBox.Show("Akun berhasil didaftarkan.", "Berhasil!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Login login = new Login();
                login.Show();
                Visible = false;
            }
            else
            {
                MessageBox.Show("Akun gagal didaftarkan.", "Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return;
        }
    }
}
