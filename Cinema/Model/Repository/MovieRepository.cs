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
    public class MovieRepository
    {
        private MySqlConnection _conn;
        private GrabUser grabUser;

        public MovieRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public Movie Data(int id)
        {
            Movie movie = new Movie();

            try
            {
                string sql = @"SELECT
                                *
                            FROM
                                movie
                            WHERE 
                                id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    using (MySqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            movie.Id = id;
                            movie.Name = dtr.GetString("name");
                            movie.Price = dtr.GetInt32("harga");
                            return movie;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }

            return movie;
        }
    }
}
