using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATABAZEK
{

    public class Objednavka
    {
        public int Id { get; set; }
        public DateTime DatumObjednani { get; set; }
        public ICollection<PolozkaObjednavky> PolozkyObjednavky { get; set; }
    }
}


