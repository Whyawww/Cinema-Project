using Cinema.Help;
using Cinema.Model.Entity;
using Ecommerce.Model.Context;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model.Repository
{
    public class JadwalRepository
    {
        private MySqlConnection _conn;
        private GrabUser grabUser;

        public JadwalRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public List<Jadwal> ReadAll(int id)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Jadwal> list = new List<Jadwal>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"SELECT
                                    *
                                FROM
                                    template_jadwal
                                WHERE
                                    id_movie = @id";
                // membuat objek command menggunakan blok using
                using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Jadwal p = new Jadwal();
                            p.Id = dtr.GetInt32("id");
                            p.JadwalTayang = dtr.GetMySqlDateTime("jadwal");

                            list.Add(p);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }
            return list;
        }
    }
}
