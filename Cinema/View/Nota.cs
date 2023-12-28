using Cinema.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cinema.Model.Entity;
using System.Text.RegularExpressions;

namespace Cinema.View
{
    public partial class Nota : Form
    {
        private TransactionController controller;
        private Transaction trx;
        public Nota()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        public Nota(string kode) : this()
        {
            controller = new TransactionController();
            trx = controller.Read(kode);

            label3.Text = trx.Username;
            label5.Text = kode;
            label7.Text = trx.Judul;
            label9.Text = trx.Jadwal.ToString();
            label11.Text = "Studio " + trx.Studio.ToString();
            label13.Text = "Kursi " + trx.Kursi.ToString();
            label14.Text = "Rp. " + Regex.Replace(trx.Harga.ToString("N2", new System.Globalization.CultureInfo("id-ID")), @"(?<=\d)(?=(\d{3})+(?!\d))", ".");
        }

        private void Nota_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnPesanPemb_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            Visible = false;
        }
    }
}
