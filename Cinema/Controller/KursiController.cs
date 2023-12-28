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
    public class KursiController
    {
        private KursiRepository _repo;

        public List<Kursi> ReadAll(int mv_id, int jadwal, int studio)
        {
            // membuat objek collection
            List<Kursi> list = new List<Kursi>();
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repo = new KursiRepository(context);
                // panggil method GetAll yang ada di dalam class repository
                list = _repo.ReadAll(mv_id, jadwal, studio);
            }
            return list;
        }
    }
}
