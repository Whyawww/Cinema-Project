using Cinema.Help;
using Cinema.Model.Entity;
using Ecommerce.Model.Context;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model.Repository
{
    public class StudioRepository
    {
        private MySqlConnection _conn;
        private GrabUser grabUser;

        public StudioRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public List<Studio> ReadAll(int id)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Studio> list = new List<Studio>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"SELECT
                                    *
                                FROM
                                    template_studio
                                WHERE
                                    id_jadwal = @id";
                // membuat objek command menggunakan blok using
                using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Studio p = new Studio();
                            p.Id = dtr.GetInt32("id");
                            p.NoStudio = dtr.GetInt32("studio");

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
