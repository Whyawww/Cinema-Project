using Cinema.Controller;
using Cinema.Help;
using Cinema.Model.Entity;
using Cinema.Model.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.View
{
    public partial class Checkout : Form
    {
        private MovieController _mvCon;
        private JadwalController _jdwlCon;
        private KursiController _krsiCon;
        private StudioController _stdioCon;
        private TransactionController _trxCon;
        private int mv_id;
        private int harga;
        private List<Jadwal> listJdwl;
        private List<Studio> listStdio;
        private List<Kursi> listKursi;
        public Checkout()
        {
            InitializeComponent();
            this.CenterToScreen();

            comboJadwal.DropDownStyle = ComboBoxStyle.DropDownList;
            comboKursi.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;

            comboKursi.Enabled = false;
            comboBox4.Enabled = false;

            _mvCon = new MovieController();
            _jdwlCon = new JadwalController();
            _krsiCon = new KursiController();
            _stdioCon = new StudioController();
            _trxCon = new TransactionController();
        }

        public Checkout(Image img, int id_movie) : this()
        {
            GrabUser user = new GrabUser();
            txtNamePemb.Text = user.Data().Username;
            txtTelpembelian.Text = user.Data().Phone;

            mv_id = id_movie;

            pictPembelian.Image = img;
            pictPembelian.SizeMode = PictureBoxSizeMode.StretchImage;

            Movie mv = new Movie();
            mv = _mvCon.GetMovie(id_movie);
            txtJudul.Text = mv.Name;
            harga = mv.Price;
            txtHargaPemb.Text = "Rp. " + Regex.Replace(mv.Price.ToString("N2", new System.Globalization.CultureInfo("id-ID")), @"(?<=\d)(?=(\d{3})+(?!\d))", ".");

            listJdwl = _jdwlCon.ReadAll(id_movie);
            comboJadwal.Items.Clear();
            foreach (Jadwal jd in listJdwl)
            {
                comboJadwal.Items.Add(jd.JadwalTayang);
            }
        }

        private void Checkout_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void loadKursi(int jadwal, int studio)
        {
            listKursi = _krsiCon.ReadAll(mv_id, listJdwl[jadwal].Id, listStdio[studio].Id);
            comboKursi.Items.Clear();

            foreach (Kursi kursi in listKursi)
            {
                comboKursi.Items.Add(kursi.NoKursi);
            }
        }

        private void loadStudio(int jadwal)
        {
            listStdio = _stdioCon.ReadAll(listJdwl[jadwal].Id);
            comboBox4.Items.Clear();

            foreach (Studio jd in listStdio)
            {
                comboBox4.Items.Add("Studio " + jd.NoStudio);
            }
        }

        private void comboJadwal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int jadwal = comboJadwal.SelectedIndex;
            int studio = comboBox4.SelectedIndex;

            if(jadwal >= 0)
            {
                loadStudio(jadwal);
                comboBox4.Enabled = true;
            } else { 
                comboBox4.Enabled = false;
            }

            if(jadwal >= 0 && studio >= 0)
            {
                loadKursi(jadwal, studio);
                comboKursi.Enabled = true;
            } else
            {
                comboKursi.Enabled = false;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int jadwal = comboJadwal.SelectedIndex;
            int studio = comboBox4.SelectedIndex;

            if (jadwal >= 0 && studio >= 0)
            {
                loadKursi(jadwal, studio);
                comboKursi.Enabled = true;
            } else
            {
                comboKursi.Enabled = false;
            }
        }

        private void btnPesanPemb_Click(object sender, EventArgs e)
        {
            int jadwal = comboJadwal.SelectedIndex;
            int studio = comboBox4.SelectedIndex;
            int kursi = comboKursi.SelectedIndex;
            int test;

            if (jadwal < 0 || studio < 0 || kursi < 0)
            {
                MessageBox.Show("Lengkapi semua data.", "Perhatian!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Masukkan uang Anda.", "Perhatian!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if (Convert.ToInt32(textBox1.Text) < harga)
            {
                MessageBox.Show("Uang Anda tidak mencukupi.", "Perhatian!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if (!int.TryParse(textBox1.Text, out test)) {
                MessageBox.Show("Uang harus berupa angka.", "Perhatian!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else
            {
                string result = _trxCon.Create(mv_id, listKursi[kursi].Id, listJdwl[jadwal].Id, listStdio[studio].Id);

                if (!string.IsNullOrEmpty(result))
                {
                    int kembalian = Convert.ToInt32(textBox1.Text) - harga;

                    MessageBox.Show("Terima kasih telah memesan. Kembalian Anda : Rp. " + Regex.Replace(kembalian.ToString("N2", new System.Globalization.CultureInfo("id-ID")), @"(?<=\d)(?=(\d{3})+(?!\d))", "."), "Info!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    comboJadwal.SelectedIndex = -1;
                    comboBox4.SelectedIndex = -1;
                    comboKursi.SelectedIndex = -1;
                    textBox1.Text = "";

                    Nota nota = new Nota(result);
                    nota.Show();
                    Visible = false;

                } else
                {
                    MessageBox.Show("Gagal memesan.", "Perhatian!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            Visible = false;
        }
    }
}
