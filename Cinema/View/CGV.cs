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
    public partial class CGV : Form
    {
        private GrabUser user;

        public CGV()
        {
            InitializeComponent();
            this.CenterToScreen();
            user = new GrabUser();
            txtUsrnmHome.Text = user.Data().Username;
            txtNoTlpHome.Text = user.Data().Phone;
        }

        private void CGV_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void Checkout(Image img, int id)
        {
            /*pictureBox2.Image = img;*/
            Checkout ckout = new Checkout(img, id);
            ckout.Show();
            Visible = false;
        }

        private void pctTaliP_Click(object sender, System.EventArgs e)
        {
            Checkout(pctTaliP.Image, 1);
        }

        private void pctMarvl_Click_1(object sender, EventArgs e)
        {
            Checkout(pctMarvl.Image, 2);

        }

        private void pctNaga_Click_1(object sender, EventArgs e)
        {
            Checkout(pctNaga.Image, 3);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Checkout(pictureBox2.Image, 4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Checkout(pictureBox6.Image, 5);

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Checkout(pictureBox4.Image, 6);

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Checkout(pictureBox5.Image, 7);

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Checkout(pictureBox3.Image, 8);

        }

        private void btnPesanPemb_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            Visible = false;
        }
    }
}
