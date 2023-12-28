using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model.Entity
{
    public class Jadwal
    {
        public int Id { get; set; }
        public MySqlDateTime JadwalTayang { get; set; }
    }
}
