using Cinema.Help;
using Cinema.Model.Entity;
using Ecommerce.Model.Context;
using MySql.Data.MySqlClient;
using System;
using System.Text;

namespace Cinema.Model.Repository
{
    public class TransactionRepository
    {
        private MySqlConnection _conn;
        private GrabUser grabUser;
        private Random random = new Random();

        public TransactionRepository(DbContext context)
        {
            _conn = context.Conn;
            grabUser = new GrabUser();
        }

        private string BuatKode()
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder invoiceNumber = new StringBuilder();

            for (int i = 0; i < 6; i++)
            {
                int index = random.Next(characters.Length);
                invoiceNumber.Append(characters[index]);
            }

            return invoiceNumber.ToString();
        }

        public string Create(int id_mv, int id_kursi, int id_jadwal, int id_studio)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            string result = string.Empty;
            try
            {
                // deklarasi perintah SQL
                string sql = @"insert into transaction (kode, id_movie, id_kursi, id_jadwal, id_studio, id_user) values (@kode, @id_movie, @id_kursi, @id_jadwal, @id_studio, @id_user)";
                // membuat objek command menggunakan blok using
                using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
                {
                    string kode = BuatKode();
                    cmd.Parameters.AddWithValue("@kode", kode);
                    cmd.Parameters.AddWithValue("@id_movie", id_mv);
                    cmd.Parameters.AddWithValue("@id_kursi", id_kursi);
                    cmd.Parameters.AddWithValue("@id_jadwal", id_jadwal);
                    cmd.Parameters.AddWithValue("@id_studio", id_studio);
                    cmd.Parameters.AddWithValue("@id_user", grabUser.Data().Id);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        result = kode;
                    }
                    catch (MySqlException ex)
                    {
                        System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                    }
                }
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }

            return result;
        }

        public Transaction Read(string kode)
        {
            Transaction trx = new Transaction();

            string sql = @"SELECT
                            t.id,
                            t.kode,
                            m.name AS judul_movie,
                            m.harga AS harga_movie,
                            tk.no_kursi,
                            ts.studio,
                            u.username,
                            tj.jadwal
                        FROM
                            transaction t
                        JOIN
                            movie m ON t.id_movie = m.id
                        JOIN
                            template_kursi tk ON t.id_kursi = tk.id
                        JOIN
                            template_jadwal tj ON t.id_jadwal = tj.id
                        JOIN
                            template_studio ts ON t.id_studio = ts.id
                        JOIN
                            users u ON t.id_user = u.id;
                        ";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@kode", kode);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        trx.Id = Convert.ToInt32(reader["id"]);
                        trx.Kode = reader.GetString("kode");
                        trx.Judul = reader.GetString("judul_movie");
                        trx.Harga = reader.GetInt32("harga_movie");
                        trx.Kursi = reader.GetInt32("no_kursi");
                        trx.Jadwal = reader.GetDateTime("jadwal");
                        trx.Studio = reader.GetInt32("studio");
                        trx.Username = reader.GetString("username");

                        return trx;

                    }
                }
            }

            return trx;
        }
    }
}
