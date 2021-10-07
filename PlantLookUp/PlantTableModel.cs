using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantLookUp
{
    class PlantTableModel
    {
        [Key]
        public int RecordID { get; set; }
        public string Adrress { get; set; }
        public int PlantID { get; set; }
        public bool PlantKind { get; set; }
        public string PlantRace { get; set; }
        public int PlantRarity { get; set; }
        public int PlantCycle { get; set; }
        public int PlantBaseLE { get; set; }
        //public int TokenID { get; set; }
        public DateTime MintTime { get; set; }
        public double BlockNumber { get; set; }

    }
}
