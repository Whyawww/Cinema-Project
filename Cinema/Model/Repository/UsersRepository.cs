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
    public class UsersRepository
    {
        private MySqlConnection _conn;
        private GrabUser grabUser;

        public UsersRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int FindByPhoneAndUsername(string phone, string username)
        {
            int result = 0;

            string sql = @"select count(*) from users where phone = @phone or username = @username";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@username", username);

                try
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.Print("Find By Phone error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Create(Users user)
        {
            int result = 0;

            if (FindByPhoneAndUsername(user.Phone, user.Username) > 0)
            {
                return 69;
            }

            string sql = @"insert into users (username, phone, password) values (@username, @phone, @password)";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@phone", user.Phone);
                cmd.Parameters.AddWithValue("@password", user.Password);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }

            return result;
        }

        public Users Login(string username, string password)
        {
            Users user = new Users();

            string sql = @"select * from users where username = @username and password = @password limit 1";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user.Id = Convert.ToInt32(reader["id"]);
                        user.Username = reader["username"].ToString();
                        user.Phone = reader["phone"].ToString();
                        user.Password = reader["password"].ToString();

                        grabUser = new GrabUser();
                        grabUser.WriteSession(user);
                    }
                }
            }

            return user;
        }
    }
}
