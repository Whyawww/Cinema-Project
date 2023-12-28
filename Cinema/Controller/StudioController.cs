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
    public class StudioController
    {
        private StudioRepository _repo;
        public List<Studio> ReadAll(int id_jadwal)
        {
            // membuat objek collection
            List<Studio> list = new List<Studio>();
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repo = new StudioRepository(context);
                // panggil method GetAll yang ada di dalam class repository
                list = _repo.ReadAll(id_jadwal);
            }
            return list;
        }
    }
}
