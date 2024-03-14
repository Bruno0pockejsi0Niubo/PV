using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATABAZEK
{
    public class PolozkaObjednavky
    {
        public int ObjednavkaId { get; set; }
        public Objednavka Objednavka { get; set; }
        public int ProduktId { get; set; }
        public Produkt Produkt { get; set; }
        public int Mnozstvi { get; set; }
    }
}
