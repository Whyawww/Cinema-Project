using Cinema.Help;
using Cinema.Model.Entity;
using Cinema.Model.Repository;
using Ecommerce.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Controller
{
    public class UsersController
    {
        private UsersRepository _userRepository;
        private GrabUser grabUser;

        public int Register(Users user)
        {
            int result = 0;

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                _userRepository = new UsersRepository(context);
                result = _userRepository.Create(user);
            }

            return result;
        }

        public int Login(string username, string password)
        {
            Users user = new Users();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                grabUser = new GrabUser();
                _userRepository = new UsersRepository(context);
                user = _userRepository.Login(username, password);

                return (grabUser.CheckSession()) ? 2 : 1;
            }
        }

        public int Logout()
        {
            grabUser = new GrabUser();

            return (grabUser.DeleteSession()) ? 1 : 0;
        }
    }
}
