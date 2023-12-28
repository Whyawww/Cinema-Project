using Cinema.Model.Entity;
using Cinema.Model.Repository;
using Ecommerce.Model.Context;

namespace Cinema.Controller
{
    public class TransactionController
    {
        private TransactionRepository _repo;
        public string Create(int id_mv, int id_kursi, int id_jadwal, int id_studio)
        {
            // membuat objek collection
            string result = string.Empty;
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repo = new TransactionRepository(context);
                // panggil method GetAll yang ada di dalam class repository
                result = _repo.Create(id_mv, id_kursi, id_jadwal, id_studio);
            }
            return result;
        }

        public Transaction Read(string kode)
        {
            // membuat objek collection
            Transaction result = new Transaction();
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repo = new TransactionRepository(context);
                // panggil method GetAll yang ada di dalam class repository
                result = _repo.Read(kode);
            }
            return result;
        }
    }
}
