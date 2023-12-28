using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model.Entity
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Kode { get; set; } 
        public string Judul { get; set; }
        public int Kursi { get; set; }
        public int Harga { get; set; }
        public DateTime Jadwal { get; set; }
        public int Studio { get; set; }
        public string Username { get; set; }
    }
}
