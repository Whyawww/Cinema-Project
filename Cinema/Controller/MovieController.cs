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
    public class MovieController
    {
        private MovieRepository _repo;
        public Movie GetMovie(int id)
        {
            // membuat objek collection
            Movie list = new Movie();
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repo = new MovieRepository(context);
                // panggil method GetAll yang ada di dalam class repository
                list = _repo.Data(id);
            }
            return list;
        }
    }
}
