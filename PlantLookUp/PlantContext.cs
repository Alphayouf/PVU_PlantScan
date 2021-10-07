using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PlantLookUp
{
    class PlantContext : System.Data.Entity.DbContext
    {
        public DbSet<PlantTableModel> Plants { get; set; }
    }
}
