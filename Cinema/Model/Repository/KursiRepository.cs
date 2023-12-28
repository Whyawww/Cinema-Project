using Cinema.Help;
using Cinema.Model.Entity;
using Ecommerce.Model.Context;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.Model.Repository
{
    public class KursiRepository
    {
        private MySqlConnection _conn;
        private GrabUser grabUser;

        public KursiRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public List<Kursi> ReadAll(int mv_id, int jadwal, int studio)
        {
            List<Kursi> listSold = new List<Kursi>();

            try
            {
                string sqlSold = @"SELECT
                            id_kursi
                        FROM
                            transaction 
                        WHERE
                            id_movie = @id_movie AND id_jadwal = @id_jadwal AND id_studio = @id_studio";

                using (MySqlCommand cmdSold = new MySqlCommand(sqlSold, _conn))
                {
                    cmdSold.Parameters.AddWithValue("@id_movie", mv_id);
                    cmdSold.Parameters.AddWithValue("@id_jadwal", jadwal);
                    cmdSold.Parameters.AddWithValue("@id_studio", studio);

                    using (MySqlDataReader dtrSold = cmdSold.ExecuteReader())
                    {
                        while (dtrSold.Read())
                        {
                            Kursi p = new Kursi();
                            p.Id = dtrSold.GetInt32("id_kursi");
                            listSold.Add(p);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }

            List<Kursi> list = new List<Kursi>();

            try
            {
                string sqlAll = @"SELECT
                        id,
                        no_kursi
                    FROM
                        template_kursi
                    WHERE
                        id NOT IN (" + string.Join(",", listSold.Select(k => k.Id)) + ")";

                using (MySqlCommand cmdAll = new MySqlCommand(sqlAll, _conn))
                {
                    using (MySqlDataReader dtrAll = cmdAll.ExecuteReader())
                    {
                        while (dtrAll.Read())
                        {
                            Kursi p = new Kursi();
                            p.Id = dtrAll.GetInt32("id");
                            p.NoKursi = dtrAll.GetInt32("no_kursi");
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
