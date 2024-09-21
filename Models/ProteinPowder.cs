using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace MAUILearning.Model
{


    public class ProteinPowder
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double ProteinPerServing { get; set; }
        public string Flavor { get; set; }
    }

}
