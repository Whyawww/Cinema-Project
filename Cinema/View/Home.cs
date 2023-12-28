using Cinema.Help;
using System.Drawing;
using System.Windows.Forms;

namespace Cinema.View
{
    public partial class Home : Form
    {
        private GrabUser user;
        public Home()
        {
            InitializeComponent();
            this.CenterToScreen();

            user = new GrabUser();

            txtUsrnmHome.Text = user.Data().Username;
            txtNoTlpHome.Text = user.Data().Phone;
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
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

        private void pctMarvl_Click(object sender, System.EventArgs e)
        {
            Checkout(pctMarvl.Image, 2);
        }

        private void pctNaga_Click(object sender, System.EventArgs e)
        {
            Checkout(pctNaga.Image, 3);
        }

        private void pctCgv_Click(object sender, System.EventArgs e)
        {
            CGV cgv = new CGV();
            cgv.Show();
            Visible = false;
        }
    }
}
