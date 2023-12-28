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
    public class JadwalController
    {
        private JadwalRepository _repo;
        public List<Jadwal> ReadAll(int id_movie)
        {
            // membuat objek collection
            List<Jadwal> list = new List<Jadwal>();
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repo = new JadwalRepository(context);
                // panggil method GetAll yang ada di dalam class repository
                list = _repo.ReadAll(id_movie);
            }
            return list;
        }
    }
}
